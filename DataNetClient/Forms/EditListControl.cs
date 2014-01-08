using System;
using System.Collections.Generic;
using System.Linq;
using CQG;
using DataNetClient.Core;
using DataNetClient.Core.DbConnector;

namespace DataNetClient.Forms
{
    public partial class EditListControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        public EditListControl(int groupId, GroupModel groupModel)
        {
            GroupId = groupId;
            AGroupModel = groupModel;
            InitializeComponent();

            cmbContinuationType.Items.Clear();
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctNoContinuation);
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctStandard);
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctStandardByMonth);
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctActive);
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctActiveByMonth);
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctAdjusted);
            cmbContinuationType.Items.Add(eTimeSeriesContinuationType.tsctAdjustedByMonth);
        }

        public bool OpenSymbolControl;
        private MetroBillCommands _commands;
        public int GroupId
        {
            get;
            set;
        }


        public string OldGroupName { get; private set; }
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
                saveButton.Command = newValue.EditListCommands.Save;
                cancelButton.Command = newValue.EditListCommands.Cancel;
            }
            else
            {
                saveButton.Command = null;
                cancelButton.Command = null;
            }
        }

        private void btnRemov_Click(object sender, EventArgs e)
        {
            var asd = lbSelList.SelectedItems;
            for (int index = 0; index < asd.Count; index++)
            {
                var item = asd[index];
                lbSelList.Items.Remove(item);
            }

            if (lbSelList.Items.Count > 0)
            {
                btnRemov.Enabled = true;
                lbSelList.SetSelected(0, true);
            }
            else
            {
                btnRemov.Enabled = false;

            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cancelButton.Command.Execute();
        }

        private void EditListControl_Load(object sender, EventArgs e)
        {
            OldGroupName = textBoxXListName.Text;

            var symbolsList = DataNetClientDataManager.GetSymbolsInGroup(GroupId);
            foreach (var symbol in symbolsList)
            {
                var exist = false;
                foreach (var item in lbSelList.Items)
                {
                    if (item.ToString() == symbol.SymbolName) exist = true;
                }
                if (!exist) lbSelList.Items.Add(symbol.SymbolName);
            }



            checkBoxX_repeat_dialy.Checked = AGroupModel.IsDaily;
            checkBoxX_parttime.Checked = AGroupModel.IsPart;

            if (AGroupModel.WeekDays == null) AGroupModel.WeekDays = "";
            if (AGroupModel.MonthDays == null) AGroupModel.MonthDays = "";
            if (AGroupModel.TimePeriods == null) AGroupModel.TimePeriods = "";

            checkedListBox_rd.SetItemChecked(0, (AGroupModel.WeekDays.Contains("Sunday")));
            checkedListBox_rd.SetItemChecked(1, (AGroupModel.WeekDays.Contains("Monday")));
            checkedListBox_rd.SetItemChecked(2, (AGroupModel.WeekDays.Contains("Tuesday")));
            checkedListBox_rd.SetItemChecked(3, (AGroupModel.WeekDays.Contains("Wednesday")));
            checkedListBox_rd.SetItemChecked(4, (AGroupModel.WeekDays.Contains("Thursday")));
            checkedListBox_rd.SetItemChecked(5, (AGroupModel.WeekDays.Contains("Friday")));
            checkedListBox_rd.SetItemChecked(6, (AGroupModel.WeekDays.Contains("Saturday")));


            // dates
            listViewEx_dates.Items.Clear();
            var splited = AGroupModel.MonthDays.Split(',');
            foreach (var s in splited)
            {
                if (!string.IsNullOrEmpty(s))
                    listViewEx_dates.Items.Add(s);
            }

            //var listH = (from s in splited where !string.IsNullOrEmpty(s) select Convert.ToInt32(s)).ToList();
            //foreach (var i in listH)
            //{
            //    checkedListBox_rm.SetItemChecked(i-1,true);
            //}

            //
            var timePeriods = AGroupModel.TimePeriods;
            StartTimes.Clear();
            EndTimes.Clear();

            var spl = timePeriods.Split(',');
            foreach (var s in spl)
            {
                var alt = s.Split('-');
                if (alt.Count() > 1)
                {
                    StartTimes.Add(alt[0]);
                    EndTimes.Add(alt[1]);

                    listViewEx_times.Items.Add(alt[0]).SubItems.Add(alt[1]);
                }


            }

        }



        private void checkBoxX_repeat_dialy_CheckedChanged(object sender, EventArgs e)
        {

            checkedListBox_rd.Enabled = checkBoxX_repeat_dialy.Checked;

            buttonX_add_date.Enabled =
                dateTimeInput_date.Enabled =
                    listViewEx_dates.Enabled = !checkBoxX_repeat_dialy.Checked;
        }

        private void checkBoxX_parttime_CheckedChanged(object sender, EventArgs e)
        {
            buttonX_add.Enabled =
                dateTimeInput1.Enabled =
                dateTimeInput2.Enabled =
            listViewEx_times.Enabled = checkBoxX_parttime.Checked;
        }

        private void buttonX_add_Click(object sender, EventArgs e)
        {
            listViewEx_times.Items.Add(dateTimeInput1.Value.ToShortTimeString()).SubItems.Add(dateTimeInput2.Value.ToShortTimeString());

            StartTimes.Add(dateTimeInput1.Value.ToShortTimeString());
            EndTimes.Add(dateTimeInput2.Value.ToShortTimeString());
        }


        public List<string> StartTimes = new List<string>();
        public List<string> EndTimes = new List<string>();
        public GroupModel AGroupModel { get; set; }

        internal string GetTimePeriods()
        {
            var res = "";
            for (int i = 0; i < StartTimes.Count; i++)
            {
                res += StartTimes[i] + "-" + EndTimes[i] + ",";
            }
            return res;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewEx_times.SelectedItems.Count <= 0) return;
            var index = listViewEx_times.SelectedIndices[0];
            listViewEx_times.Items.RemoveAt(index);

            StartTimes.RemoveAt(index);
            EndTimes.RemoveAt(index);
        }

        private void buttonX_add_date_Click(object sender, EventArgs e)
        {
            var res = dateTimeInput_date.Value.ToShortDateString();
            for (int i = 0; i < listViewEx_dates.Items.Count; i++)
            {
                var item = listViewEx_dates.Items[i];
                if (item.Text == res) return;
            }
            listViewEx_dates.Items.Add(res);


        }

        internal IList<string> GetDates()
        {
            var res = new List<string>();
            for (int index = 0; index < listViewEx_dates.Items.Count; index++)
            {
                var item = listViewEx_dates.Items[index].Text;
                res.Add(item);
            }

            return res;
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listViewEx_dates.SelectedItems.Count <= 0) return;
            var index = listViewEx_dates.SelectedIndices[0];
            listViewEx_dates.Items.RemoveAt(index);

        }
    }
}
