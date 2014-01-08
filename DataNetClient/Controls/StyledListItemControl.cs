using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataNetClient.Core.CQGDataCollector;

namespace DataNetClient.Controls
{
    public partial class StyledListItemControl : UserControl
    {
        private Color _mainColor = Color.Green;
        public StyledListItemControl()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            labelX_count.ForeColor = Color.Black;
            ItemState = GroupState.NotInQueue;
            ItemStateChangingEnabled = true;

        }

        public StyledListItemControl(string text, int index,GroupState state, DateTime datetime, string count)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            labelX_count.ForeColor = Color.Black;
            
            ItemText = text;
            ItemIndex = index;
            ItemState = state;
            ItemDateTime = datetime;
            ItemCount = count;
            ItemStateChangingEnabled = true;
        }

        public delegate void ItemSelectedChangedHandler(int itemIndex, GroupState state);

        public event ItemSelectedChangedHandler ItemSelectedChanged;

        protected virtual void OnItemSelectedChanged(int itemIndex, GroupState state)
        {
            if (state != GroupState.NotInQueue)
            {
                panelEx_left.BackColor =
                labelX_title.ForeColor = _mainColor;

                
            }
            else 
            {
                panelEx_left.BackColor = Color.White;
                labelX_title.ForeColor = Color.Black;                
            }

            ItemSelectedChangedHandler handler = ItemSelectedChanged;
            if (handler != null) handler( itemIndex, ItemState);
        }

        
        private void panelEx_back_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (ItemState != GroupState.NotInQueue)
            {
                panelEx_left.BackColor =
                labelX_title.ForeColor = _mainColor;                
                             
            }
            else
            {
                panelEx_left.BackColor = Color.LightGreen; 
                labelX_title.ForeColor = Color.Black;
            }
               

        }

        private void panelEx_back_MouseLeave(object sender, System.EventArgs e)
        {            
            labelX_count.ForeColor = Color.Black;
            panelEx_left.BackColor = ItemState!= GroupState.NotInQueue ? _mainColor :
            Color.White;
        }

        private void panelEx_back_Click(object sender, EventArgs e)
        {
            if (!ItemStateChangingEnabled) return;

            if (_state == GroupState.NotInQueue)
            {
                ItemState = GroupState.InQueue;
                OnItemSelectedChanged(ItemIndex, ItemState);

                return;
            }
            
            if (_state == GroupState.InQueue)
            {
                ItemState =GroupState.NotInQueue;
                OnItemSelectedChanged(ItemIndex, ItemState);

                return;
            }            
            if (_state == GroupState.Finished)
            {
                ItemState = GroupState.NotInQueue;
                OnItemSelectedChanged(ItemIndex, ItemState);

                return;
            }

            
        }

        public List<string> Symbols
        {
            get { return _symbols; }
            set
            {
                _symbols = value; 
                symbolsToolStripMenuItem.DropDownItems.Clear();
                foreach (string s in value)
                {
                    symbolsToolStripMenuItem.DropDownItems.Add(s);    
                }
                
            }
        }

        public int ItemIndex { get; set; }

        public string ItemText
        {
            get { return labelX_title.Text; }
            set { labelX_title.Text = value; }
        }

        public string ItemCount
        {
            get { return labelX_count.Text; }
            set { labelX_count.Text = value; }
        }

        private GroupState _state;
        public GroupState ItemState
        {
            get { return _state; }
            set
            {
                _state = value;
                labelX_state.Text = _state.ToString();
            }
        }

        private DateTime _itemDatetime;
        private List<string> _symbols;
        private DateTime _itemStartDateTime;

        public DateTime ItemDateTime
        {
            get { return _itemDatetime; }
            set
            {
                _itemDatetime = value;
                labelX_datetime.Text = value.ToShortDateString() + "  " + value.ToShortTimeString();
            }
        }


        public bool ItemStateChangingEnabled { get; set; }

        public DateTime ItemStartDateTime
        {
            get { return _itemStartDateTime; }
            set
            {
                _itemStartDateTime = value;

                labelX_startTime.Text = 
                    value.ToShortDateString() +"  "+ value.ToShortTimeString();
            }
        }
    }
}
