﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CQG;
using DevComponents.DotNetBar;
using TickNetClient.Core.DbConnector;

namespace TickNetClient.Core
{
    #region Structures

    public struct SymbolData
    {
        public string SymbolName;
        public ICQGInstrument Instrument;
        public bool IsNewTrade;
        public bool FirstTride;
        public double PrevTradePrice;
        public double PrevTradeVol;
        public DateTime PrevTradeTime;

        public bool TsIsNewTrade;
        public bool TsFirstTride;
        public double TsPrevTradePrice;
        public double TsPrevTradeVol;
        public DateTime TsPrevTradeTime;

        private readonly String _tableName;
        public bool IsCanceled;
        public uint GroupId;
        public uint TsGroupId;
        public int Depth;
        public Control MsgObject;

        public SymbolData(String tableName)
        {
            Instrument = null;
            _tableName = tableName;
            SymbolName = String.Empty;
            FirstTride = true;
            IsNewTrade = true;
            PrevTradePrice = 0;
            PrevTradeVol = 0;
            PrevTradeTime = new DateTime();

            TsFirstTride = true;
            TsIsNewTrade = true;
            TsPrevTradePrice = 0;
            TsPrevTradeVol = 0;
            TsPrevTradeTime = new DateTime();

            IsCanceled = false;
            GroupId = 0;
            TsGroupId = 0;
            Depth = 1;
            MsgObject = null;
        }

        public String TableName
        {
            get { return _tableName; }
        }
    }

    public struct SymbolMessage
    {
        public String SymbolName;
        public Control MsgObject;
    }

    public struct TickData
    {
        private readonly String _tableName;
        public bool IsCanceled;
        public string SymbolName;
        public bool IsNewTrade;
        public DateTime Timestamp;

        public double BidPrice;
        public int BidVolume;

        public double AskPrice;
        public int AskVolume;

        public double TradePrice;
        public int TradeVolume;

        public int TickCount;
        public uint GroupID;

        public string TickType;

        public String TableName
        {
            get { return _tableName; }
        }
        public TickData(String tableName, string symbolName)
        {
            _tableName = tableName;
            IsCanceled = false;
            SymbolName = symbolName;
            IsNewTrade = false;
            Timestamp = new DateTime();
            BidPrice = AskPrice = TradePrice = 0;
            AskVolume = BidVolume = TradeVolume = 0;
            TickCount = 0;
            GroupID = 0;
            TickType = String.Empty;
        }
    }

    #endregion

    class SymbolDataWriter
    {

        #region VARS

        public delegate void RaiseSymbolSubscribed(List<string> symbol, int depth);
        public event RaiseSymbolSubscribed SymbolSubscribed;

        private readonly Dictionary<String, SymbolData> _symbolsTable;
        private CQGCEL _cel;
        private readonly Dictionary<String, Control> _addSybolsList;
        private readonly Dictionary<String, TickData> _tickTable;
        private readonly string _userName;
        private volatile Dictionary<string, DateTime> _allowedSymbols = new Dictionary<string, DateTime>();
        private readonly List<string> _symbolsInProgress = new List<string>();
        public bool IsMi;
        public int Depth;
        private static object _waitingLocker = new object();
        private List<string> _subscribedSymbols = new List<string>();
        #endregion

        #region HANDLES

        public SymbolDataWriter(CQGConnector connector, string userName)
        {
            _allowedSymbols.Clear();
            _userName = userName;
            Depth = 1;
            if (connector == null)
            {
                throw new Exception("Not initialized CQG connector attached.");
            }
            _symbolsTable = new Dictionary<string, SymbolData>();
            _tickTable = new Dictionary<string, TickData>();
            _cel = connector.ICEL;

            connector.addIncorrectSymbolListener(CEL_IncorrectSymbol);
            connector.addInstrumentSubscribedListener(CEL_InstrumentSubscribed);
            connector.addInstrumentChanged(CQG_InstrumentChanged);
            connector.addInstrumentDOMChangedListene(CEL_InstrumentDOMChanged);
            connector.addStartedListener(CEL_CELStarted);

            _addSybolsList = new Dictionary<string, Control>();
        }
        #endregion


        #region CEL Start, Subsribe

        private void CEL_CELStarted()
        {
            Control ctrl = null;
            IEnumerator<String> enumList = _addSybolsList.Keys.GetEnumerator();
            while (enumList.MoveNext())
            {
                try
                {
                    ctrl = _addSybolsList[enumList.Current];
                    _cel.NewInstrument(enumList.Current);

                    CQGTicksRequest req = _cel.CreateTicksRequest();
                    req.Type = eTicksRequestType.trtCurrentNotify;
                    req.SessionsFilter = 0;
                    req.TickFilter = eTickFilter.tfAll;
                    req.Symbol = enumList.Current;

                    _cel.RequestTicks(req);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ctrl != null)
                    {
                        ctrl.ForeColor = Color.OrangeRed;
                        ctrl.Text = ex.Message;
                    }
                }
            }

        }

        public void CEL_InstrumentSubscribed(string symbol1, ICQGInstrument instrument)
        {
            var sdata = new SymbolData();
            try
            {
                var symbol = symbol1;
                var symbolLen = symbol.Length;
                sdata = new SymbolData("DM_" + symbol.Substring(5, symbolLen - 5).ToUpper()) { Instrument = instrument, Depth = Depth };
                sdata.SymbolName = symbol;

                if (_addSybolsList.Count == 0) return;
                sdata.MsgObject = _addSybolsList[symbol];
                var tdata = new TickData("TS_" + symbol.Substring(5, symbol.Length - 5).ToUpper(), symbol);

                TickNetClientDataManager.DoSqlLive(QueryBuilder.createTable_tick(tdata.TableName));
                TickNetClientDataManager.DoSqlLive(QueryBuilder.createTable_dom(sdata.TableName));

                if (IsMi)
                {
                    sdata.MsgObject.Text = @"Subscribed. Waiting for data...";
                    sdata.MsgObject.ForeColor = Color.Green;
                }
                else
                {
                    sdata.MsgObject.Text = @"Subscribed";
                    sdata.MsgObject.ForeColor = Color.Green;
                }
                instrument.DataSubscriptionLevel = eDataSubscriptionLevel.dsQuotesAndDOM;
                sdata.GroupId = 0;

                Console.WriteLine(@"dom:" + sdata.GroupId);
                _symbolsTable.Add(instrument.FullName, sdata);

                tdata.GroupID = 0;
                _tickTable.Add(instrument.FullName, tdata);

                if (!_subscribedSymbols.Exists(oo => oo == symbol1))
                    _subscribedSymbols.Add(symbol1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (sdata.MsgObject != null)
                {
                    sdata.MsgObject.ForeColor = Color.OrangeRed;
                    sdata.MsgObject.Text = ex.Message;
                }
            }
        }

        #endregion


        #region Inserting

        private void CQG_InstrumentChanged(CQGInstrument instrument, CQGQuotes quotes,
                                           CQGInstrumentProperties instrumentProperties)
        {
            if (!_tickTable.ContainsKey(instrument.FullName)) return;

            lock (_waitingLocker)
            {

                if (_subscribedSymbols.Exists(oo => oo == instrument.FullName))
                {
                    _subscribedSymbols.Remove(instrument.FullName);
                    if (SymbolSubscribed != null)
                        SymbolSubscribed(new List<string> { instrument.FullName }, Depth);
                }

                var tickData = _tickTable[instrument.FullName];

                if (!tickData.IsCanceled)
                {
                    tickData.TickCount = 0;
                    foreach (CQGQuote item in quotes)
                    {
                        CQGQuote tick = item;

                        tickData.IsNewTrade = tick.Name == "Trade";
                        switch (tick.Name)
                        {
                            case "Ask":
                                {
                                    tickData.AskPrice = tick.Price;
                                    tickData.AskVolume = tick.Volume;
                                    tickData.TradePrice = 0;
                                    tickData.TradeVolume = 0;
                                    break;
                                }
                            case "Bid":
                                {
                                    tickData.BidPrice = tick.Price;
                                    tickData.BidVolume = tick.Volume;
                                    tickData.TradePrice = 0;
                                    tickData.TradeVolume = 0;
                                    break;
                                }
                            case "Trade":
                                {
                                    tickData.TradePrice = tick.Price;
                                    tickData.TradeVolume = tick.Volume;
                                    break;
                                }

                        }
                        tickData.TickCount++;
                    }

                    if (tickData.TickCount > 0)
                    {
                        var quoteList = (from CQGQuote item in quotes
                                         where item.Name == "Ask" ||
                                               item.Name == "Bid" ||
                                               item.Name == "Trade"
                                         select item).ToList();
                        quoteList.OrderBy(quote => quote.ServerTimestamp);
                        if (quoteList.Any())
                        {
                            tickData.Timestamp = quoteList.Last().ServerTimestamp;
                            tickData.TickType = quoteList.Last().Name;
                        }
                        else
                            tickData.Timestamp = instrument.ServerTimestamp;
                        var query = QueryBuilder.InsertData(tickData.TableName, tickData.SymbolName,
                                                            tickData.BidPrice,
                                                            tickData.BidVolume,
                                                            tickData.AskPrice, tickData.AskVolume,
                                                            tickData.TradePrice,
                                                            tickData.TradeVolume,
                                                            tickData.IsNewTrade, tickData.Timestamp,
                                                            ++tickData.GroupID,
                                                            _userName, tickData.TickType);
                        if (tickData.Timestamp < DateTime.Now.AddDays(-1))
                            return;
                        if (_onSymbolsList.Contains(instrument.FullName))
                        {
                            TickNetClientDataManager.AddToBuffer(query, false, tickData);
                            if (_allowedSymbols.ContainsKey(tickData.SymbolName) ||
                                !TickNetClientDataManager.CurrentDbIsShared)
                            {
                                if (TickNetClientDataManager.CurrentDbIsShared && tickData.Timestamp < _allowedSymbols[tickData.SymbolName])
                                    return;
                                TickNetClientDataManager.RunSQL(query, "InsertData", instrument.FullName);
                            }
                        }

                       

                    }
                }
                else
                {
                    RemoveSymbol(instrument.FullName);
                    return;
                }
                _tickTable[instrument.FullName] = tickData;
            }

        }

        private void CEL_InstrumentDOMChanged(CQGInstrument instrument, CQGDOMQuotes prevAsks, CQGDOMQuotes prevBids)
        {

            if (!_symbolsTable.Keys.Contains(instrument.FullName)) return;

            lock (_waitingLocker)
            {
                SymbolData symbolData = _symbolsTable[instrument.FullName];
                if (symbolData.IsCanceled)
                {
                    RemoveSymbol(instrument.FullName);
                    return;
                }
                if (!(_cel.IsValid(instrument.DOMBids) && _cel.IsValid(instrument.DOMAsks))) return;
                if (!symbolData.FirstTride)
                {
                    const double epsilon = 0.0000001;
                    if ((Math.Abs(instrument.Trade.Price - symbolData.PrevTradePrice) > epsilon) ||
                        (Math.Abs(instrument.Trade.Volume - symbolData.PrevTradeVol) > epsilon))
                    {
                        symbolData.IsNewTrade = true;
                        if (IsMi)
                        {
                            if (symbolData.MsgObject.Parent.Parent != null)
                                symbolData.MsgObject.Parent.Parent.BeginInvoke(
                                    new Action(
                                        () =>
                                        symbolData.MsgObject.Text =
                                        @"DOMBids depth: " + instrument.DOMBids.Count + @" DOMAsks depth: " +
                                        instrument.DOMAsks.Count));
                        }
                    }
                    else
                    {
                        symbolData.IsNewTrade = false;
                    }
                    symbolData.PrevTradePrice = instrument.Trade.Price;
                    symbolData.PrevTradeVol = instrument.Trade.Volume;
                    symbolData.PrevTradeTime = instrument.Timestamp;
                }
                else
                {
                    symbolData.PrevTradePrice = instrument.Trade.Price;
                    symbolData.PrevTradeVol = instrument.Trade.Volume;
                    symbolData.PrevTradeTime = instrument.Timestamp;
                }
                symbolData.FirstTride = false;

                double askPrice;
                double bidPrice;
                int askVol;
                int bidVol;
                var serverTimestamp = new DateTime(instrument.ServerTimestamp.Year,
                    instrument.ServerTimestamp.Month,
                    instrument.ServerTimestamp.Day,
                    instrument.ServerTimestamp.Hour,
                    instrument.ServerTimestamp.Minute,
                    instrument.ServerTimestamp.Second,
                    instrument.ServerTimestamp.Millisecond);

                var query = QueryBuilder.InsertData_dom(symbolData.TableName, instrument,
                                                        Convert.ToInt32(symbolData.Depth), ++symbolData.GroupId,
                                                        symbolData.IsNewTrade, _userName, out askPrice, out askVol, out bidPrice, out bidVol, serverTimestamp);
                if (instrument.ServerTimestamp < DateTime.Now.AddDays(-1))
                    return;

                var tickDomData = new TickData
                                      {
                                          AskPrice = askPrice,
                                          AskVolume = askVol,
                                          BidPrice = bidPrice,
                                          BidVolume = bidVol,
                                          SymbolName = symbolData.SymbolName,
                                          Timestamp = serverTimestamp,
                                          GroupID =  symbolData.GroupId
                                      };

                if (_onSymbolsList.Contains(instrument.FullName))
                {
                    TickNetClientDataManager.AddToBuffer(query, true, tickDomData);

                    if (_allowedSymbols.ContainsKey(_symbolsTable[instrument.FullName].SymbolName) ||
                    !TickNetClientDataManager.CurrentDbIsShared)
                    {
                        if (TickNetClientDataManager.CurrentDbIsShared && serverTimestamp < _allowedSymbols[instrument.FullName])
                            return;
                        TickNetClientDataManager.RunSQL(query, "InsertData", instrument.FullName);
                    }
                }
                
                
                _symbolsTable[instrument.FullName] = symbolData;
            }
        }

        #endregion


        #region Other

        public void CEL_IncorrectSymbol(string symbol)
        {
            _tickTable.Remove(symbol);
            _symbolsTable.Remove(symbol);
            Control ctrl = _addSybolsList[symbol];
            ctrl.Text = @"Invalid symbol";
            ctrl.ForeColor = Color.OrangeRed;
            ctrl.Parent.Controls[1].Text = @"remove";
            ctrl.Parent.Controls[2].Enabled = false;
        }


        public void AllowSymbol(string symbol)
        {
            lock (_waitingLocker)
            {
                TickNetClientDataManager.WriteFromBuffer(symbol, false);
                var date = TickNetClientDataManager.GetLastTickTime(symbol, false);
                _allowedSymbols.Add(symbol, date);
            }
        }

        public void DenySymbol(string symbol)
        {
            lock (_waitingLocker)
            {
                _allowedSymbols.Remove(symbol);
                TickNetClientDataManager.WriteFromBuffer(symbol, false);
                TickNetClientDataManager.RemoveSymbolFromBuffer(symbol);
                TickNetClientDataManager.ClearQueue(symbol);
            }
        }

        public List<string> GetSymbols()
        {
            return _symbolsInProgress.ToList();
        }

        public void attachCQG_Interface(CQGCEL cqgCell)
        {
            if (cqgCell == null)
            {
                throw new Exception("Not initialized CQG interface attached.");
            }
            _cel = cqgCell;
        }

        #endregion


        #region Add, Cancel Stop Remove

        public void AddSymbol(String symbol, Control ctrl)
        {
            _addSybolsList.Add(symbol, ctrl);
            _symbolsInProgress.Add(symbol);
        }


        public void RemoveSymbol(String symbol)
        {
            var I = (CQGInstrument)_symbolsTable[symbol].Instrument;
            _cel.RemoveInstrument(I);
            TickNetClientDataManager.RunSQL("DROP TABLE IF EXISTS " + _symbolsTable[symbol].TableName, "flush", "");
            _tickTable.Remove(symbol);
            _symbolsTable.Remove(symbol);
            _symbolsInProgress.Remove(symbol);
        }

        public void Cancel(String symbolName)
        {

            if (_allowedSymbols.ContainsKey(symbolName))
                _allowedSymbols.Remove(symbolName);
            if (_addSybolsList.ContainsKey(symbolName))
                _addSybolsList.Remove(symbolName);
            if (_symbolsInProgress.Contains(symbolName))
                _symbolsInProgress.Remove(symbolName);
            if (_subscribedSymbols.Exists(name => name == symbolName))
                _subscribedSymbols.Remove(symbolName);
            TickNetClientDataManager.CommitList();
            TickNetClientDataManager.RemoveSymbolFromBuffer(symbolName);

            if (_tickTable.ContainsKey(symbolName))
            {
                TickData td = _tickTable[symbolName];
                td.IsCanceled = true;
                _tickTable[symbolName] = td;
            }
            if (_symbolsTable.ContainsKey(symbolName))
            {
                SymbolData sd = _symbolsTable[symbolName];
                sd.IsCanceled = true;
                _symbolsTable[symbolName] = sd;
            }
        }
                             
        public void Stop(String symbolName)
        {

            if (_allowedSymbols.ContainsKey(symbolName))
                _allowedSymbols.Remove(symbolName);
            if (_addSybolsList.ContainsKey(symbolName))
                _addSybolsList.Remove(symbolName);
            if (_symbolsInProgress.Contains(symbolName))
                _symbolsInProgress.Remove(symbolName);
            if (_subscribedSymbols.Exists(name => name == symbolName))
                _subscribedSymbols.Remove(symbolName);
            TickNetClientDataManager.CommitList();

            TickNetClientDataManager.RemoveSymbolFromBuffer(symbolName);

            if (_tickTable.Any(a => a.Value.SymbolName == symbolName))
            {
                var tickKey = _tickTable.First(a => a.Value.SymbolName == symbolName).Key;
                _tickTable.Remove(tickKey);
            }
            if (_symbolsTable.Any(a => a.Value.SymbolName == symbolName))
            {
                var symbolKey = _symbolsTable.First(a => a.Value.SymbolName == symbolName).Key;
                Control ctrl = _symbolsTable[symbolKey].MsgObject;
                _cel.RemoveInstrument((CQGInstrument)_symbolsTable[symbolKey].Instrument);
                _symbolsTable.Remove(symbolKey);
                ctrl.Text = @"Stop";
            }
        }

        public bool Rm(String symbolName)
        {
            _addSybolsList.Remove(symbolName);
            _symbolsInProgress.Remove(symbolName);

            if (_tickTable.ContainsKey(symbolName))
                _tickTable.Remove(symbolName);
            if (_symbolsTable.ContainsKey(symbolName))
            {
                _symbolsTable.Remove(symbolName);
                TickNetClientDataManager.RunSQL("DROP TABLE IF EXISTS " + _symbolsTable[symbolName].TableName + ";COMMIT", "flush", "");
                return true;
            }
            return false;
        }

        #endregion

        private readonly List<string> _onSymbolsList= new List<string>();
        public void SchSymbolOn(string symbol)
        {
            if (!_addSybolsList.Keys.Contains(symbol)) return;
            try
            {

                var cntr = _addSybolsList[symbol];

                var labelX = cntr as LabelX;
                if (labelX != null)
                {
                    labelX.BackgroundStyle.BorderLeft = eStyleBorderType.Solid;
                    labelX.BackgroundStyle.BorderLeftColor = Color.MediumTurquoise;
                    labelX.BackgroundStyle.BorderLeftWidth = 3;

                    labelX.Refresh();
                }
                if (!_onSymbolsList.Contains(symbol))
                {
                    _onSymbolsList.Add(symbol);
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex);
            }
        }

        public void SchSymbolOff(string symbol)
        {
            if (!_addSybolsList.Keys.Contains(symbol)) return;

            try
            {                
                var cntr = _addSybolsList[symbol];

                var labelX = cntr as LabelX;
                if (labelX != null)
                {
                    labelX.BackgroundStyle.BorderLeft = eStyleBorderType.Solid;
                    labelX.BackgroundStyle.BorderLeftColor = Color.MediumVioletRed;
                    labelX.BackgroundStyle.BorderLeftWidth = 3;
                    labelX.Refresh();
                }
                if (_onSymbolsList.Contains(symbol))
                {
                    _onSymbolsList.Remove(symbol);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
