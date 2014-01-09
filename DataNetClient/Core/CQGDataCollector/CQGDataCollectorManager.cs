using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using CQG;
using DataNetClient.Core.DbConnector;
using DataNetClient.Properties;
using Timer = System.Windows.Forms.Timer;

namespace DataNetClient.Core.CQGDataCollector
{
    static class CQGDataCollectorManager
    {
        #region VARS

        private static readonly CQGCEL Cel;
        private static List<GroupItem> _groups;
        private static bool _modeIsAuto;
        private static int _groupCurrent;
        private static bool _startedManualCollecting;
        private static eHistoricalPeriod _aHistoricalPeriod;

        private static string _userName;       


        private static int _rangeStart;
        private static int _rangeEnd=-3000;

        private static DateTime _rangeDateStart;
        private static DateTime _rangeDateEnd;

        private static int _sessionFilter;
        private static string _historicalPeriod;
        private static string _continuationType;
        private static bool _isStoped;
        private static bool _isFromList;

        private static List<string> _symbols = new List<string>();
        private static List<string> _symbolsCollected = new List<string>();

        private static Timer _timerScheduler = new Timer{Interval = 3000};
        private static bool _isStarted;
        
        #endregion

        #region EVENTS

        public delegate void ItemStateChangedHandler(int index, GroupState state);

        public static event ItemStateChangedHandler ItemStateChanged;

        private static void OnItemStateChanged(int index, GroupState state)
        {
            ItemStateChangedHandler handler = ItemStateChanged;
            if (handler != null) handler(index, state);
        }

        public delegate void RunnedStateChangedHandler(bool state);

        public static event RunnedStateChangedHandler RunnedStateChanged;

        private static void OnRunnedStateChanged(bool state)
        {
            RunnedStateChangedHandler handler = RunnedStateChanged;
            if (handler != null) handler(state);
        }


        public delegate void CollectedSymbolCountChangedHandler(int index, string symbol, int count, int totalCount);

        public static event CollectedSymbolCountChangedHandler CollectedSymbolCountChanged;

        private static void OnCollectedSymbolCountChanged(int index, string symbol, int count, int totalCount)
        {
            CollectedSymbolCountChangedHandler handler = CollectedSymbolCountChanged;
            if (handler != null) handler(index, symbol, count, totalCount);
        }

        public delegate void StartTimeChangedHandler(int index, DateTime dateTime);

        public static event StartTimeChangedHandler StartTimeChanged;

        private static void OnStartTimeChanged(int index, DateTime dateTime)
        {
            StartTimeChangedHandler handler = StartTimeChanged;
            if (handler != null) handler(index, dateTime);
        }


        public delegate void CQGStatusChangedHandler(bool isConnected);

        public static event CQGStatusChangedHandler CQGStatusChanged;

        private static void OnCQGStatusChanged(bool isConnected)
        {
            CQGStatusChangedHandler handler = CQGStatusChanged;
            if (handler != null) handler(isConnected);
        }
        #endregion
        
        #region INIT

        static CQGDataCollectorManager()
        {
            try
            {

                Cel = new CQGCEL();
                Cel.APIConfiguration.TimeZoneCode = eTimeZone.tzGMT;
                Cel.APIConfiguration.ReadyStatusCheck = eReadyStatusCheck.rscOff;
                Cel.APIConfiguration.CollectionsThrowException = false;
                Cel.APIConfiguration.LogSeverity = eLogSeverity.lsDebug;
                Cel.APIConfiguration.MessageProcessingTimeout = 30000;

                Cel.DataConnectionStatusChanged += _cel_DataConnectionStatusChanged;
                _cel_DataConnectionStatusChanged(eConnectionStatus.csConnectionDown);

                Cel.InstrumentSubscribed += _cel_InstrumentSubscribed;

                Cel.DataError += _cel_DataError;
                Cel.IncorrectSymbol += _cel_IncorrectSymbol;

                Cel.TimedBarsResolved += _cel_TimedBarsResolved;
                Cel.TicksResolved += _cel_TicksResolved;

                Cel.HistoricalSessionsResolved += _cel_HistoricalSessionsResolved;

                Cel.Startup();


                _timerScheduler.Tick += _timerScheduler_Tick;
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex);
            }
        }

        public static void Init(string userName)
        {
            _userName = userName;
        }
        #endregion

        #region CEL Events Handlers

        static void _cel_InstrumentSubscribed(string symbol, CQGInstrument cqgInstrument)
        {
            
        }

        static void _cel_HistoricalSessionsResolved(CQGSessionsCollection cqgHistoricalSessions, CQGHistoricalSessionsRequest cqgHistoricalSessionsRequest, CQGError cqgError)
        {            
        }

        static void _cel_IncorrectSymbol(string symbol)
        {
            FinishCollectingSymbol(symbol);
        }

        static void _cel_TicksResolved(CQGTicks cqgTicks, CQGError cqgError)
        {
            if (_isStoped) return;
            var symbol = cqgTicks.Request.Symbol;

            TicksAdd(cqgTicks, cqgError, _userName);
            FinishCollectingSymbol(symbol);
                
        }

        static void _cel_TimedBarsResolved(CQGTimedBars cqgTimedBars, CQGError cqgError)
        {
            if (_isStoped) return;
            var symbol = cqgTimedBars.Request.Symbol;

            BarsAdd(cqgTimedBars, cqgError, _userName);
            FinishCollectingSymbol(symbol);            
        }

        static void _cel_DataError(object cqgError, string errorDescription)
        {
            Console.WriteLine(errorDescription);
        }

        static void _cel_DataConnectionStatusChanged(eConnectionStatus newStatus)
        {
            OnCQGStatusChanged(newStatus == eConnectionStatus.csConnectionUp);
        }
        
        #endregion

        #region Collecting Requests
        public static void TimeBarRequest(string symbolName)
        {
            try
            {
                if (!Cel.IsStarted)
                {
                    FinishCollectingSymbol(symbolName);
                    return;
                }

                _aHistoricalPeriod = eHistoricalPeriod.hpUndefined;
                DataNetClientDataManager.CreateBarsTable(symbolName, GetTableType(_historicalPeriod));

                CQGTimedBarsRequest request = Cel.CreateTimedBarsRequest();

                request.RangeStart = _rangeStart;
                request.RangeEnd = _rangeEnd;
                request.SessionsFilter = _sessionFilter;
                request.Symbol = symbolName;
                request.Continuation = ConvertToTsts(_continuationType);

                request.IntradayPeriod = GetIntradayPeriod(_historicalPeriod);

                if (_aHistoricalPeriod != eHistoricalPeriod.hpUndefined)
                    request.HistoricalPeriod = _aHistoricalPeriod;

                var bars = Cel.RequestTimedBars(request);
                var curTimedBars = Cel.AllTimedBars.ItemById[bars.Id];

                if (curTimedBars.Status == eRequestStatus.rsInProgress)
                {
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex);
            }

        }

        private static eTimeSeriesContinuationType ConvertToTsts(string continuationType)
        {
            switch (continuationType)
            {
                case "tsctStandard":
                    return eTimeSeriesContinuationType.tsctStandard;

                default: return eTimeSeriesContinuationType.tsctNoContinuation;
            }
        }

        
        private static void TicksRequest(string symbolName)
        {
            try
            {
                if (!Cel.IsStarted)
                {
                    FinishCollectingSymbol(symbolName);
                    return;
                }
                if (_rangeDateStart < DateTime.Now.AddDays(-Settings.Default.MaxTickDays))
                    _rangeDateStart = DateTime.Now.AddDays(-Settings.Default.MaxTickDays);


                _historicalPeriod = "tick";

                var tickRequest = Cel.CreateTicksRequest();
                //LineTime = CEL.Environment.LineTime;
                tickRequest.RangeStart = _rangeDateStart;
                tickRequest.RangeEnd = _rangeDateEnd;
                tickRequest.Type = eTicksRequestType.trtSinceTimeNotify;
                tickRequest.Symbol = symbolName;

                CQGTicks ticks = Cel.RequestTicks(tickRequest);

                if (ticks.Status == eRequestStatus.rsInProgress)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion

        #region SAVING COLLECTED DATA
        public static  void BarsAdd(CQGTimedBars mCurTimedBars, CQGError cqgError, string userName)
        {            
            try
            {
              
                if (cqgError != null && cqgError.Code != 0)
                {
                    
                }
                else
                {
                    if (mCurTimedBars.Status == eRequestStatus.rsSuccess)
                    {
                        DateTime runDateTime = DateTime.Now;
                        if (mCurTimedBars.Count != 0)
                        {
                            for (int i = mCurTimedBars.Count - 1; i >= 0; i--)
                            {                                
                                AddBar(mCurTimedBars[i], mCurTimedBars.Request.Symbol, runDateTime, GetTableType(_historicalPeriod), userName);
                            }
                        }
                        DataNetClientDataManager.CommitQueueBar();
                    }                    
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);            
            }
        }

        private static void AddBar(CQGTimedBar timedBar, string symbol, DateTime runDateTime, string tType, string userName)
        {            
            try
            {
                var str5 = symbol.Trim();
                var str = str5.Split('.');
                str5 = str[str.Length - 1];

                if (GetValueAsString(timedBar.Open) == "N/A")
                {
                }
                else
                {
                    GetValueAsString(timedBar.Open);
                }
                GetValueAsString(timedBar.Timestamp);
                var str3 = "'" + symbol + "'," +
                           GetValueAsString(Math.Max(timedBar.Open, 0)) + "," +
                           GetValueAsString(Math.Max(timedBar.High, 0)) + "," +
                           GetValueAsString(Math.Max(timedBar.Low, 0)) + "," +
                           GetValueAsString(Math.Max(timedBar.Close, 0)) + "," +

                           GetValueAsString(Math.Max(timedBar.TickVolume, 0)) + "," +
                           GetValueAsString(Math.Max(timedBar.ActualVolume, 0)) + "," +
                           GetValueAsString(Math.Max(timedBar.AskVolume, 0)) + "," +
                           GetValueAsString(Math.Max(timedBar.BidVolume, 0)) + "," +
                           GetValueAsString(Math.Max(timedBar.OpenInterest, 0)) + "," +

                           GetValueAsString(timedBar.Timestamp) + "," +
                           GetValueAsString(runDateTime) + ",'" +
                           _continuationType + "','" +
                           userName + "'";

                var sql = "INSERT IGNORE INTO B_" + str5 + "_" + tType + " (Symbol, OpenValue, HighValue, LowValue, CloseValue," +
                    " TickVol, ActualVol, AskVol, BidVol, OpenInterest," +
                             "BarTime, SystemTime, ContinuationType, UserName) VALUES (" + str3 + ");";

                DataNetClientDataManager.AddToQueue(sql, 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
        }

        private static string GetValueAsString(object val)
        {
            try
            {
                if ((val is Double) || (val is float))
                {
                    var v = (Double)val;
                    if (v == 0.0)
                        return "0.0";
                    return v.ToString("G", CultureInfo.InvariantCulture);
                }
                if (val is int)
                {
                    return Convert.ToString(val);
                }
                if (val is DateTime)
                    return "'" + Convert.ToDateTime(val).ToString("yyyy/MM/dd HH:mm:ss") + "'";
                return "NULL";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
                return "0";
            }
        }

        public static void TicksAdd(CQGTicks cqgTicks, CQGError cqgError, string userName)
        {
            
            try
            {
                
                if (cqgError != null && cqgError.Code != 0)
                {
                    
                }
                else
                {
                    DataNetClientDataManager.CreateTickTable(cqgTicks.Request.Symbol);


                    DateTime runDateTime = DateTime.Now;
                    int groupId = 0;

                    if (cqgTicks.Count != 0)
                    {
                        DataNetClientDataManager.DeleteTicks(cqgTicks.Request.Symbol, cqgTicks[0].Timestamp, cqgTicks[cqgTicks.Count - 1].Timestamp);
                        for (int i = cqgTicks.Count - 1; i >= 0; i--)
                        {                            
                            AddTick(cqgTicks[i], cqgTicks.Request.Symbol, runDateTime, ++groupId, userName);
                        }

                    }
                    DataNetClientDataManager.CommitQueueTick();

                }
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
        }

        private static void AddTick(CQGTick tick, string symbol, DateTime runDateTime, int groupId, string userName)
        {
            try
            {

                var str = symbol.Trim().Split('.');
                var query = "INSERT IGNORE INTO T_" + str[str.Length - 1];
                query += "(Symbol, Price, Volume, TickTime, SystemTime, ContinuationType, PriceType, GroupId, UserName) VALUES";
                query += "('";
                query += symbol + "',";
                query += GetValueAsString(tick.Price) + ",";
                query += GetValueAsString(tick.Volume) + ",";
                query += GetValueAsString(tick.Timestamp) + ",";
                query += GetValueAsString(runDateTime) + ",";
                query += "'" + _continuationType + "',";
                query += "'" + tick.PriceType.ToString() + "',";
                query += GetValueAsString(groupId) + ",";
                query += "'" + userName + "');";

                DataNetClientDataManager.AddToQueue(query, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
        }



        #endregion

        #region GROUP LIST public
        public static void LoadGroups(List<GroupItem> groups)
        {
            _groups = groups.ToList();
            foreach (var groupItem in _groups)
            {
                groupItem.CollectedSymbols.Clear();                
            }
            
            RecalcStartTime();
        }



        public static bool Start()
        //    DateTime rangeDateStart, DateTime rangeDateEnd, int sessionFilter,  int rangeStart, int rangeEnd, 
        {
            if (IsStarted) return false;
            _isFromList = false;
            IsStarted = true;

            //_rangeStart = rangeStart;
            //_rangeEnd = rangeEnd;
            //_sessionFilter = sessionFilter;
            //_rangeDateStart = rangeDateStart;
            //_rangeDateEnd = rangeDateEnd;



            foreach (var groupItem in _groups)
            {
                groupItem.CollectedSymbols.Clear();
            }            
            new Thread(() =>
            {
                _isStoped = false;
                StartFirst();    
            }).Start();
            return true;

        }
        public static bool StartFromList(List<string> symbols, DateTime rangeDateStart, DateTime rangeDateEnd, int sessionFilter, string historicalPeriod, string continuationType, int rangeStart, int rangeEnd, string userName)
        {
            if (IsStarted) return false;

            IsStarted = true;
            _userName = userName;
            _rangeStart = rangeStart;
            _rangeEnd = rangeEnd;
            _sessionFilter = sessionFilter;
            _historicalPeriod = historicalPeriod;
            _continuationType = continuationType;

            _rangeDateStart = rangeDateStart;
            _rangeDateEnd = rangeDateEnd;


            new Thread(() =>
            {
                _isStoped = false;
                _isFromList = true;
                _symbols = symbols;
                _symbolsCollected.Clear();

                foreach (var symbol in _symbols)
                {

                    if (_historicalPeriod == "tick")
                        TicksRequest(symbol);
                    else
                        TimeBarRequest(symbol);

                }

            }).Start();
            return true;

        }
        public static void Stop()
        {
            if (!IsStarted) return;

            IsStarted = false;
            _isStoped = true;
            if (_isFromList)
            {
                _symbols.Clear();
                _symbolsCollected.Clear();
            }

            else
                FinishCollectingGroup(_groupCurrent);
        }

        public static void ChangeState(int index, GroupState groupState)
        {
            _groups[index].GroupState = groupState;
        }

        #endregion

        #region GROUP LIST private
        private static bool ThereAreHaveInProgress()
        {
            int a = 5;

            for (int i = 0; i < 10; i++)
            {
                a++;

            }
            a++;

            return _groups.Any(groupItem => groupItem.GroupState == GroupState.InProgress)||_symbols.Count!=_symbolsCollected.Count;
        }

        private static void StartFirst()
        {

            // searching first InQueue
            for (int index =  _groups.Count-1; index>=0; index--)
            {
                var groupItem = _groups[index];
                if (groupItem.GroupState == GroupState.InQueue)
                {
                    

                    _historicalPeriod = groupItem.GroupModel.TimeFrame;
                    _continuationType = groupItem.GroupModel.CntType;

                    

                    _groupCurrent = index;
                                       
                    StartCollectingGroup(index);
                    return;
                }
            }
            IsStarted = false;
            //            
        }

        private static void StartCollectingGroup(int index)
        {

            var group = _groups[index];
            
            StartProgress(index);
            OnCollectedSymbolCountChanged(_groupCurrent,"", 0, _groups[index].AllSymbols.Count);

            foreach (var symbol in group.AllSymbols)
            {
                if(group.GroupModel.TimeFrame == "tick")
                    TicksRequest(symbol);
                else
                    TimeBarRequest(symbol);
                
            }
            if(group.AllSymbols.Count == 0)
                FinishCollectingGroup(index);
        }

        private static void FinishCollectingGroup(int index)
        {
            FinishProgress(index);
            if (!_isStoped)
            {
                if (_modeIsAuto)
                {
                    RecalcStartTimeForGroup(index);
                }
                StartFirst();
            }
        }
        
        private static void StartProgress(int index)
        {
            _groups[index].GroupState = GroupState.InProgress;
            OnItemStateChanged(index,  GroupState.InProgress);
        }

        private static void FinishCollectingSymbol(string symbol)
        {
            if (_isFromList)
            {
                _symbolsCollected.Add(symbol);

                var totalCount = _symbols.Count;
                var cCount = _symbolsCollected.Count;

                OnCollectedSymbolCountChanged(-1,symbol,  cCount, totalCount);

                if (_symbols.Count == _symbolsCollected.Count)
                {
                    FinishCollectingAllSymbols();
                }
                return;
            }

            _groups[_groupCurrent].CollectedSymbols.Add(symbol);

            var tCount = _groups[_groupCurrent].AllSymbols.Count;
            var count =  _groups[_groupCurrent].CollectedSymbols.Count;

            OnCollectedSymbolCountChanged(_groupCurrent,symbol, count,tCount);
            
            if (count == tCount)
            {
                FinishCollectingGroup(_groupCurrent);
            }


        }

        private static void FinishCollectingAllSymbols()
        {
            IsStarted = false;
        }

        private static void FinishProgress(int index)
        {
            if (index >= _groups.Count) return;

            _groups[index].GroupState = GroupState.Finished;
            OnItemStateChanged(index, GroupState.Finished);
        }

        
        

        #endregion

        private static string GetTableType(string historicalPeriod)
        {
            switch (historicalPeriod)
            {
                case "1 minute":                    
                    return "1M";                    
                case "2 minutes":
                    return "2M";                    
                case "3 minutes":
                    return "3M";                    
                case "5 minutes":
                    return"5M";                    
                case "10 minutes":
                    return "10M";                    
                case "15 minutes":
                    return "15M";
                case "30 minutes":
                    return "30M";
                case "60 minutes":
                    return "60M";
                case "240 minutes":
                    return "240M";
                    
                case "Daily":
                    _aHistoricalPeriod = eHistoricalPeriod.hpDaily;
                    return "D";

                case "Weekly":
                    _aHistoricalPeriod = eHistoricalPeriod.hpWeekly;
                    return "W";

                case "Monthly":
                    _aHistoricalPeriod = eHistoricalPeriod.hpMonthly;
                    return "M";

                case "Quarterly":
                    _aHistoricalPeriod = eHistoricalPeriod.hpQuarterly;
                    return "Q";

                case "Yearly":
                    _aHistoricalPeriod = eHistoricalPeriod.hpYearly;
                    return "Y";

                case "Semiannual":
                    _aHistoricalPeriod = eHistoricalPeriod.hpSemiannual;
                    return "S";
                                   
            }
            return "1M";
        }

        private static int GetIntradayPeriod(string historicalPeriod)
        {
            switch (historicalPeriod)
            {
                case "1 minute":
                    return 1;
                case "2 minutes":
                    return 2;
                case "3 minutes":
                    return 3;
                case "5 minutes":
                    return 5;
                case "10 minutes":
                    return 10;
                case "15 minutes":
                    return 15;
                case "30 minutes":
                    return 30;
                case "60 minutes":
                    return 60;
                case "240 minutes":
                    return 240;


            }
            return 1 ;
        }

        #region Scheuler

        public static void ChangeMode(bool isAuto)
        {
            if (isAuto)
            {
                if (_modeIsAuto == false)
                {
                    _modeIsAuto = true;
                    Stop();

                    MakeAllGroupsNotInQue();

                    RecalcStartTime();


                    _timerScheduler.Enabled = true;

                }
            }
            else
            {
                if (_modeIsAuto)
                {
                    _modeIsAuto = false;
                    MakeAllGroupsNotInQue();

                    _timerScheduler.Enabled = false;
                    Stop();
                }                
            }
        }

        private static void MakeAllGroupsNotInQue()
        {
            for (int index = 0; index < _groups.Count; index++)
            {
                var item = _groups[index];
                item.GroupState = GroupState.NotInQueue;

                OnItemStateChanged(index, GroupState.NotInQueue);
            }
        }

        private static DateTime GetScheduledDate(GroupModel groupModel, bool needSecond = false)
        {
            var now = needSecond ? DateTime.Now.AddDays(1) : DateTime.Now;
            var schDateTime = DateTime.Today;

            if (groupModel.IsDaily)
            {
                schDateTime = GetMinDateFromToday(groupModel.WeekDays, needSecond);
            }
            else
            {
                DateTime minDt = DateTime.Today;
                var dates = groupModel.MonthDays.Split(',');
                foreach (string date in dates)
                {
                    if (date != "")
                    {
                        var dt = Convert.ToDateTime(date);

                        if (dt > now && minDt > dt)
                        {
                            minDt = dt;
                        }
                    }
                }
                if (minDt != now.Date)
                {
//found
                    schDateTime = minDt.Date;
                }

            }
            return schDateTime;
        }

        private static DateTime GetScheduledTime(GroupItem groupItem, DateTime schDateTime)
        {
            if (groupItem.GroupModel.IsPart)
            {
                var times = groupItem.GroupModel.TimePeriods.Split(',');
                var minTime = DateTime.Today.AddDays(1).AddMinutes(-1);
                for (int i = 0; i < times.Length; i++)
                {
                    string time = times[i];
                    if (time != "")
                    {
                        var ss = time.Split('-');
                        if (ss.Count() > 1)
                        {
                            if (i == 0)
                            {
                                var timeE = Convert.ToDateTime(ss[0]);
                                if (schDateTime.Date != DateTime.Today)
                                {
                                    minTime = timeE;
                                }
                                else if (timeE.TimeOfDay > DateTime.Now.TimeOfDay)
                                {
                                    minTime = timeE;
                                }
                            }
                            else
                            {
                                var timeE = Convert.ToDateTime(ss[0]);
                                if (schDateTime.Date != DateTime.Today)
                                {
                                    if (minTime.TimeOfDay > timeE.TimeOfDay)
                                    {
                                        minTime = timeE;
                                    }
                                }
                                else if (timeE.TimeOfDay > DateTime.Now.TimeOfDay && minTime.TimeOfDay > timeE.TimeOfDay)
                                {
                                    minTime = timeE;
                                }
                            }

                        }
                    }
                }
                return schDateTime.Date.AddMinutes(minTime.TimeOfDay.TotalMinutes);
            }
            return schDateTime;
        }

        private static void GetNextTwoDays(GroupModel groupModel, out DateTime firstDt, out DateTime secondDt)
        {

            firstDt = DateTime.Today;
            secondDt = DateTime.Today.AddDays(1);

            if (groupModel.IsDaily)
            {
                firstDt = GetMinDateFromToday(groupModel.WeekDays, false);
                secondDt = GetMinDateFromToday(groupModel.WeekDays, true);
                
            }
            else
            {
                DateTime minDt = DateTime.Today;
                DateTime minDtSecond = DateTime.Today.AddDays(1);
                var dates = groupModel.MonthDays.Split(',');
                foreach (string date in dates)
                {
                    if (date != "")
                    {
                        var dt = Convert.ToDateTime(date);

                        if (dt > DateTime.Today && minDt > dt)
                        {
                            minDt = dt;
                        }
                        if (dt > DateTime.Today.AddDays(1) && minDtSecond > dt)
                        {
                            minDtSecond = dt;
                        }
                    }
                }

                if (minDt.Date != DateTime.Today)
                {                
                    firstDt = minDt.Date;
                    secondDt = minDtSecond.Date;
                }

            }
            
        }

        private static DateTime GetMaxTodayTime(GroupModel groupModel)
        {
            var res = DateTime.Today;

            if (groupModel.IsPart)
            {
                var times = groupModel.TimePeriods.Split(',');
                
                for (int i = 0; i < times.Length; i++)
                {
                    string time = times[i];
                    if (time != "")
                    {
                        var ss = time.Split('-');
                        if (ss.Count() > 1)
                        {
                            var timeE = Convert.ToDateTime(ss[0]);

                            
                            if (res.TimeOfDay < timeE.TimeOfDay)
                            {
                                res = timeE;
                            }                                                    
                        }
                    }
                }                
            }
            return res;
        }

        private static DateTime GetScheduledDateTime(GroupModel groupModel)
        {
            DateTime firstDt, secondDt, schDateTime = new DateTime();

            GetNextTwoDays(groupModel, out firstDt, out secondDt);
            var maxTime = GetMaxTodayTime(groupModel);
            if (firstDt.Date != DateTime.Today)
            {
                var tm = GetMinTime(groupModel);

                schDateTime = firstDt.Date.AddMinutes(tm.TimeOfDay.TotalMinutes);
            }
            else if (maxTime.TimeOfDay > DateTime.Now.TimeOfDay && firstDt.Date == DateTime.Today)
            {
                
                var tm = GetFirstTimeFromNow(groupModel);

                schDateTime = firstDt.Date.AddMinutes(tm.TimeOfDay.TotalMinutes);

            }
            else 
            {
                var tm = GetMinTime(groupModel);

                schDateTime = secondDt.Date.AddMinutes(tm.TimeOfDay.TotalMinutes);
            }
            /*
            
            var test = GetScheduledTime(groupItem, schDateTime);

            {
                if (test.TimeOfDay > DateTime.Now.TimeOfDay)
                {
                    schDateTime = schDateTime.AddMinutes(test.TimeOfDay.TotalMinutes);
                }
                else
                {
                    var sch = GetScheduledDate(groupItem.GroupModel, true);
                    schDateTime = GetScheduledTime(groupItem, sch);
                }
            }
            */
            return schDateTime;
        }

        private static DateTime GetMinTime(GroupModel groupModel)
        {
            var res = DateTime.Today.AddDays(1).AddMinutes(-1);

            if (groupModel.IsPart)
            {
                var times = groupModel.TimePeriods.Split(',');

                for (int i = 0; i < times.Length; i++)
                {
                    string time = times[i];
                    if (time != "")
                    {
                        var ss = time.Split('-');
                        if (ss.Count() > 1)
                        {
                            var timeE = Convert.ToDateTime(ss[0]);


                            if (res.TimeOfDay > timeE.TimeOfDay)
                            {
                                res = timeE;
                            }
                        }
                    }
                }
            }
            return res;
        }

        private static DateTime GetFirstTimeFromNow(GroupModel groupModel)
        {
            var res = DateTime.Today.AddDays(1).AddMinutes(-1);

            if (groupModel.IsPart)
            {
                var times = groupModel.TimePeriods.Split(',');

                for (int i = 0; i < times.Length; i++)
                {
                    string time = times[i];
                    if (time != "")
                    {
                        var ss = time.Split('-');
                        if (ss.Count() > 1)
                        {
                            var timeE = Convert.ToDateTime(ss[0]);


                            if (timeE.TimeOfDay> DateTime.Now.TimeOfDay && res.TimeOfDay > timeE.TimeOfDay)
                            {
                                res = timeE;
                            }
                        }
                    }
                }
            }
            return res;
        }

        public static void RecalcStartTime()
        {
            for (int index = 0; index < _groups.Count; index++)
            {
                RecalcStartTimeForGroup(index);
            }
        }

        public static void RecalcStartTimeForGroup(int index)
        {
            var groupItem = _groups[index];
            var schDateTime = GetScheduledDateTime(groupItem.GroupModel);

            groupItem.GroupModel.Start = schDateTime;

            DataNetClientDataManager.SetGroupStartDatetime(groupItem.GroupModel.GroupId, groupItem.GroupModel.Start);
            OnStartTimeChanged(index, schDateTime);
        }
        private static DateTime GetMinDateFromToday(string weekDays, bool needSecond)
        {
            if (weekDays.Length < 3) return needSecond ? DateTime.Today.AddDays(1): DateTime.Today;

            var dt = DateTime.Today;
            if (needSecond) dt = DateTime.Today.AddDays(1);

            while (!weekDays.Contains(dt.DayOfWeek.ToString()))
            {
                dt = dt.AddDays(1);
            }

            return dt;
        }

        private static void TickScheduler()
        {
            
            var now = DateTime.Now;

            for (int index = 0; index < _groups.Count; index++)
            {
                var groupItem = _groups[index];

                var res= Math.Abs((groupItem.GroupModel.Start - now).TotalMinutes);
                if (res < 1 && (now - groupItem.GroupModel.End).TotalMinutes > 1)
                {                    

                        _groups[index].GroupState = GroupState.InQueue;
                    //todo 
                    
                }
            }
            Start();
        }

        static void _timerScheduler_Tick(object sender, EventArgs e)
        {
            TickScheduler();
        }

        private static bool IsTodayWeNeedToCollect(bool isDaily, DateTime now, string weekDays,
             string monthDays)
        {
            return isDaily ?
                weekDays.Contains(now.DayOfWeek.ToString()) :
                monthDays.Length < 3 || monthDays.Contains(now.ToShortDateString());
        }

        private static bool IsNowWeNeedToCollect(bool isPart, DateTime now, string timePeriods)
        {
            if (!isPart) return true;

            var list = timePeriods.Split(',');
            foreach (var s in list)
            {
                var seTime = s.Split('-');
                if (!string.IsNullOrEmpty(seTime[0]))
                {
                    var sTime = DateTime.Today.Date.Add(Convert.ToDateTime(seTime[0]).TimeOfDay);
                    var eTime = DateTime.Today.Date.Add(Convert.ToDateTime(seTime[1]).TimeOfDay);

                    if (now > sTime && now < eTime) return true;

                }
            }
            return false;
        }


        #endregion

        public static bool IsStarted
        {
            get { return _isStarted; }
            private set
            {
                _isStarted = value;
                OnRunnedStateChanged(value);
            }
        }

#region MyRegion
		

        #region dfsgdfhbzdmn  fdhgfdbfv cvb

        #endregion
 
	#endregion    
    
    
    }
}
