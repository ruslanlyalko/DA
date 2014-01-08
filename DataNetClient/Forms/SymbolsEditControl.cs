using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using DataNetClient.Core;
using DataNetClient.Core.DbConnector;
using DevComponents.DotNetBar;

namespace DataNetClient.Forms
{
    public partial class SymbolsEditControl : UserControl
    {
        public delegate void UpdateSymbolsEventHandler();
        public event UpdateSymbolsEventHandler UpdateSymbolsEvent;

        public delegate void UpdateGroupsEventHandler();
        public event UpdateGroupsEventHandler UpdateGroupsEvent;

        private void OnUpdateSymbolsEvent()
        {
            UpdateSymbolsEventHandler handler = UpdateSymbolsEvent;
            if (handler != null) handler();
        }

        private void OnUpdateGroupsEvent()
        {
            UpdateGroupsEventHandler handler = UpdateGroupsEvent;
            if (handler != null) handler();
        }

        public SymbolsEditControl(int userID)
        {
            _userID = userID;
            InitializeComponent();
        }

        private readonly int _userID ;
        private List<SymbolModel> _symbols;
        private List<SymbolModel> _allSymbols; 
        private List<GroupModel> _groups;
        private List<GroupModel> _allGroups;

        private MetroBillCommands _commands;        

        /// <summary>
        /// Gets or sets the commands associated with the control.
        /// </summary>
        public MetroBillCommands Commands
        {
            get { return _commands; }
            set
            {
                if (value != _commands)
                {
                    MetroBillCommands oldValue = _commands;
                    _commands = value;
                    OnCommandsChanged(oldValue, value);
                }
            }
        }
        /// <summary>
        /// Called when Commands property has changed.
        /// </summary>
        /// <param name="oldValue">Old property value</param>
        /// <param name="newValue">New property value</param>
        protected virtual void OnCommandsChanged(MetroBillCommands oldValue, MetroBillCommands newValue)
        {
            if (newValue != null)
            {
                //saveButton.Command = newValue.NewSymbolCommands.Add;
                ui_buttonX_newGroup.Command = newValue.NewSymbolCommands.NewGroup;
                ui_buttonX_editGroup.Command = newValue.NewSymbolCommands.EditGroup;
                ui_ButtonX_cancel.Command = newValue.NewSymbolCommands.Cancel;                
            }
            else
            {
                ui_ButtonX_add.Command = null;
                ui_ButtonX_cancel.Command = null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ui_ButtonX_cancel.Command.Execute();
        }

        private void SymbolsEditControl_Load(object sender, EventArgs e)
        {
            new Thread((ThreadStart) (()=>
                                          {
                                              Thread.Sleep(200);
                                              RefreshSymbols();
                                              RefreshGroups();
                                          })).Start();
            
        }

        private void RefreshSymbols()
        {
            ui_listBox_symbols.Invoke((Action)(() => ui_listBox_symbols.Items.Clear()));

            _symbols = DataNetClientDataManager.GetSymbols(_userID);
            if (DataNetClientDataManager.CurrentDbIsShared) _allSymbols = DataNetClientDataManager.GetAllSymbols();
            foreach (var item in _symbols)
            {
                SymbolModel item1 = item;
                ui_listBox_symbols.Invoke((Action)(() =>ui_listBox_symbols.Items.Add(item1.SymbolName)));
            }
        }
        
        private void RefreshGroups()
        {
            _groups = DataNetClientDataManager.GetGroups(_userID);
            ui_listBox_groups.Invoke((Action)(() => ui_listBox_groups.Items.Clear()));
            if (DataNetClientDataManager.CurrentDbIsShared) _allGroups = DataNetClientDataManager.GetAllGroups();
            foreach (var item in _groups)
            {
                var item1 = item;
                ui_listBox_groups.Invoke((Action)(() => ui_listBox_groups.Items.Add(item1.GroupName)));
            }            
        }

        private void ui_ButtonX_add_Click(object sender, EventArgs e)
        {
            if (ui_textBoxXSymbolName.Text == "")
            {
                ToastNotification.Show(this, "Please, enter new symbol name");
                return;
            }
            if(_symbols.Exists(a=>a.SymbolName==ui_textBoxXSymbolName.Text))
            {
                ToastNotification.Show(this, "The name of symbol already exists");
                return;
            }
            var newSymbol = ui_textBoxXSymbolName.Text;
            if (!DataNetClientDataManager.CurrentDbIsShared) DataNetClientDataManager.AddNewSymbol(newSymbol);
            if (DataNetClientDataManager.CurrentDbIsShared)
            {
                if (!_allSymbols.Exists(a => a.SymbolName == newSymbol)) DataNetClientDataManager.AddNewSymbol(newSymbol);
                DataNetClientDataManager.Commit();
                var symbolId = DataNetClientDataManager.GetAllSymbols().Find(a => a.SymbolName == newSymbol).SymbolId;
                DataNetClientDataManager.AddSymbolForUser(_userID, symbolId);
            }
            RefreshSymbols();
            ToastNotification.Show(this, "Symbol '" + newSymbol + "' added");
            OnUpdateSymbolsEvent();
        }

        private void ui_buttonX_del_Click(object sender, EventArgs e)
        {
            if (ui_listBox_symbols.SelectedItem == null)
            {
                ToastNotification.Show(this, "Please, select symbol");
                return;
            }

            if (MessageBox.Show("Do you wish to delete this symbol?", "", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                if (!DataNetClientDataManager.CurrentDbIsShared)
                    DataNetClientDataManager.DeleteSymbol(
                    _symbols.Find(a => a.SymbolName == ui_listBox_symbols.SelectedItem.ToString()).SymbolId);
                if (DataNetClientDataManager.CurrentDbIsShared)
                {
                    var symbolId = _allSymbols.Find(a => a.SymbolName == ui_listBox_symbols.SelectedItem.ToString()).SymbolId;
                    if (DataNetClientDataManager.IsSymbolOnlyForThisUser(symbolId))
                    {
                        DataNetClientDataManager.DeleteSymbol(symbolId);
                    }
                    DataNetClientDataManager.DeleteSymbolForUser(_userID, symbolId);
                }
                RefreshSymbols();
                ToastNotification.Show(this, "Symbol deleted");
                OnUpdateSymbolsEvent();
            }
        }

        private void ui_buttonX_replace_Click(object sender, EventArgs e)
        {
            if(ui_listBox_symbols.SelectedItem == null)
            {
                ToastNotification.Show(this, "Please, select symbol");
                return;
            }
            if (ui_textBoxXSymbolName.Text == "")
            {
                ToastNotification.Show(this, "Please, enter new symbol name");
                return;
            }
            if (_symbols.Exists(symbol => symbol.SymbolName == ui_textBoxXSymbolName.Text) || (!DataNetClientDataManager.CurrentDbIsShared && _allSymbols.Exists(a => a.SymbolName == ui_textBoxXSymbolName.Text)))
            {
                ToastNotification.Show(this, "Symbol with this name already exists");
                return;
            }

            if (MessageBox.Show("Do you wish to replace this symbol?", "", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                var ind = ui_listBox_symbols.SelectedIndex;
                var oldName = ui_listBox_symbols.SelectedItem.ToString();
                var newName = ui_textBoxXSymbolName.Text;

                DataNetClientDataManager.EditSymbol(oldName, newName,_userID);
                RefreshSymbols();
                if (ui_listBox_symbols.Items.Count > 0)
                    ui_listBox_symbols.SelectedIndex = ind;
                ToastNotification.Show(this, "The symbol '" + oldName + "' replaaced by '"+newName+"'");
                OnUpdateSymbolsEvent();
            }

        }

        private void ui_buttonX_join_Click(object sender, EventArgs e)
        {
            var symbCount = ui_listBox_symbols.SelectedItems.Count;
            var groupCount = ui_listBox_groups.SelectedItems.Count;

            if (symbCount==0)
            {
                ToastNotification.Show(this, "Please, select symbols");
                return;
            }
            if(groupCount==0)
            {
                ToastNotification.Show(this, "Please, select groups");
                return;
            }

            for (int i = 0; i < symbCount; i++)
            {
                var currSmb = ui_listBox_symbols.SelectedItems[i].ToString();
                var currSmbId = _symbols.Find(a => a.SymbolName == currSmb).SymbolId;

                for (int j = 0; j < groupCount; j++)
                {                    
                    var currGroup = ui_listBox_groups.SelectedItems[j].ToString();
                    var currGroupId = _groups.Find(a => a.GroupName == currGroup).GroupId;
                    var currGroupSymbols = DataNetClientDataManager.GetSymbolsInGroup(currGroupId);
                    if (!currGroupSymbols.Exists(a => a.SymbolName == currSmb))
                    {
                        var sModel = new SymbolModel { SymbolId = currSmbId, SymbolName = currSmb };
                        DataNetClientDataManager.AddSymbolIntoGroup(currGroupId, sModel);
                    }
                }

                ui_listBox_symbolsInGroup.Items.Clear();
                var currentGroup = _groups.Find(a => a.GroupName == ui_listBox_groups.SelectedItems[0].ToString());
                if (ui_listBox_groups.SelectedItems.Count == 1 && currentGroup.Privilege != GroupPrivilege.UseGroup)
                {
                    var symbolsForCurrGroup = DataNetClientDataManager.GetSymbolsInGroup(currentGroup.GroupId);

                    foreach (var symbolModel in symbolsForCurrGroup)
                    {
                        ui_listBox_symbolsInGroup.Items.Add(symbolModel.SymbolName);
                    }
                }
            }
            ToastNotification.Show(this, "Joined");
            OnUpdateGroupsEvent();
        }


        private void ui_buttonX_delGroup_Click(object sender, EventArgs e)
        {
            if (ui_listBox_groups.SelectedItem == null)
            {
                ToastNotification.Show(this, "Please, select group");
                return;
            }

            if (
                MessageBox.Show("Do you wish to delete this group?", "", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                if (!DataNetClientDataManager.CurrentDbIsShared)
                    DataNetClientDataManager.DeleteGroupForUser(_userID,
                    _groups.Find(a => a.GroupName == ui_listBox_groups.SelectedItem.ToString()).GroupId, ApplicationType.DataNet.ToString());

                if (DataNetClientDataManager.CurrentDbIsShared)
                {
                    var groupId = _allGroups.Find(a => a.GroupName == ui_listBox_groups.SelectedItem.ToString()).GroupId;
                    if (DataNetClientDataManager.IsGroupOnlyForThisUser(groupId))
                    {
                        DataNetClientDataManager.DeleteGroupOfSymbols(groupId);
                    }
                    DataNetClientDataManager.DeleteGroupForUser(_userID, groupId, ApplicationType.DataNet.ToString());
                  
                }
                RefreshGroups();
                ToastNotification.Show(this, "Group deleted"); 
                OnUpdateGroupsEvent();
            }
        }

        private void ui_listBox_groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_listBox_symbolsInGroup.Items.Clear();
            ui_buttonX_delGroup.Enabled = true;
            ui_buttonX_editGroup.Enabled = true;
            ui_buttonX_join.Enabled = true;
            if (ui_listBox_groups.SelectedItems.Count <= 0) return;

            var privilege = new GroupPrivilege();
            int groupId = 0;

            for (int i = 0; i < ui_listBox_groups.SelectedItems.Count; i++)
            {
                var groupName = ui_listBox_groups.SelectedItems[i].ToString();

                groupId = _groups.Find(a => a.GroupName == groupName).GroupId;
                privilege = DataNetClientDataManager.GetUserPrivilegeForGroup(groupId, _userID, ApplicationType.DataNet.ToString());

                if (privilege != GroupPrivilege.Creator)
                {
                    ui_buttonX_delGroup.Enabled = false;
                    ui_buttonX_editGroup.Enabled = false;
                    ui_buttonX_join.Enabled = false;
                }
            }

            if (ui_listBox_groups.SelectedItems.Count == 1 && privilege != GroupPrivilege.UseGroup)
            {
                var symbolsForCurrGroup = DataNetClientDataManager.GetSymbolsInGroup(groupId);

                foreach (var symbolModel in symbolsForCurrGroup)
                {
                    ui_listBox_symbolsInGroup.Items.Add(symbolModel.SymbolName);
                }
            }
        }


    }
}
