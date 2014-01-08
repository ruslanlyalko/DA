using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataNetClient.Core.CQGDataCollector;

namespace DataNetClient.Controls
{
    public partial class StyledListControl : UserControl
    {
        private int _selectedItem;
        private bool _stateChangingEnabled;

        public StyledListControl()
        {
            InitializeComponent();
            SelectedItem = -1;
        }

        
        public int SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value < panelEx_container.Controls.Count)
                _selectedItem = value;
                
            }
        }
 

        public delegate void ItemStateChangedHandler(int index, GroupState state);

        public event ItemStateChangedHandler ItemStateChanged;

        protected virtual void OnItemStateChanged(int index, GroupState state)
        {
            ItemStateChangedHandler handler = ItemStateChanged;
            if (handler != null) handler(index, state);
        }


        void cntrl_ItemSelectedChanged( int itemIndex, GroupState state)
        {                        
            OnItemStateChanged(itemIndex, state);
        }

        public void AddItem(string text,GroupState state, DateTime datetime, string count, List<string> symbols)
        {
            var ind = panelEx_container.Controls.Count;
            var cntrl = new StyledListItemControl(text, ind, state, datetime, count);
            cntrl.ItemSelectedChanged += cntrl_ItemSelectedChanged;
            panelEx_container.Controls.Add(cntrl);
            //if(SelectedItem==-1) SelectFirstItem();
            cntrl.Symbols = symbols;
        }

        public void RemoveItem(int index)
        {
            SelectedItem = -1;
            bool removed=false;
            for (int i = 0; i < panelEx_container.Controls.Count; i++)
            {
                var item = panelEx_container.Controls[i];
                var styledListItemControl = item as StyledListItemControl;
                if (styledListItemControl != null)
                {
                    if (removed)
                    {
                        styledListItemControl.ItemIndex--;
                    }
                    else if (styledListItemControl.ItemIndex == index)
                    {
                        panelEx_container.Controls.Remove(styledListItemControl);
                        removed = true;
                        i--;
                    }
                }
            }            
        }

        public void RenameSelectedItem(string p)
        {
            var styledListItemControl = panelEx_container.Controls[SelectedItem] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemText = p;
        }

        internal void ClearItems()
        {
            panelEx_container.Controls.Clear();
        }

        internal void ChangeState(int index, GroupState state)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemState = state;
        }

        public void ChangeCollectedCount(int index, int count, int totalCount)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemCount = "["+count+"/"+totalCount+"]";
        }

        public void ChangeDateTime(int index, DateTime end)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemDateTime = end;
        }
        public void SetSymbols(int index, List<string> list)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.Symbols = list;
        }


        public bool StateChangingEnabled
        {
            get { return _stateChangingEnabled; }
            set
            {
                _stateChangingEnabled = value;
                for (int i = 0; i < panelEx_container.Controls.Count; i++)
                {
                    var item = panelEx_container.Controls[i];
                    var styledListItemControl = item as StyledListItemControl;
                    if (styledListItemControl != null)
                    {
                        styledListItemControl.ItemStateChangingEnabled = value;
                    }
                }     
            }
        }

        public void ChangeStartDateTime(int index, DateTime dateTime)
        {
            var styledListItemControl = panelEx_container.Controls[index] as StyledListItemControl;
            if (styledListItemControl != null)
                styledListItemControl.ItemStartDateTime = dateTime;
        }
    }
}
