namespace DataNetClient.Forms
{
    partial class SymbolsEditControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ui_ButtonX_add = new DevComponents.DotNetBar.ButtonX();
            this.ui_ButtonX_cancel = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ui_buttonX_del = new DevComponents.DotNetBar.ButtonX();
            this.ui_buttonX_replace = new DevComponents.DotNetBar.ButtonX();
            this.ui_buttonX_join = new DevComponents.DotNetBar.ButtonX();
            this.ui_buttonX_editGroup = new DevComponents.DotNetBar.ButtonX();
            this.ui_buttonX_delGroup = new DevComponents.DotNetBar.ButtonX();
            this.ui_buttonX_newGroup = new DevComponents.DotNetBar.ButtonX();
            this.labelXTitle = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ui_textBoxXSymbolName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ui_listBox_symbols = new System.Windows.Forms.ListBox();
            this.ui_listBox_groups = new System.Windows.Forms.ListBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.ui_listBox_symbolsInGroup = new System.Windows.Forms.ListBox();
            this.ui_labelX_symbolsInGroup = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_ButtonX_add
            // 
            this.ui_ButtonX_add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_ButtonX_add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_ButtonX_add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_ButtonX_add.Location = new System.Drawing.Point(249, 145);
            this.ui_ButtonX_add.Name = "ui_ButtonX_add";
            this.ui_ButtonX_add.Size = new System.Drawing.Size(92, 29);
            this.ui_ButtonX_add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_ButtonX_add.TabIndex = 74;
            this.ui_ButtonX_add.Text = "Add";
            this.toolTip1.SetToolTip(this.ui_ButtonX_add, "Add symbol to list");
            this.ui_ButtonX_add.Click += new System.EventHandler(this.ui_ButtonX_add_Click);
            // 
            // ui_ButtonX_cancel
            // 
            this.ui_ButtonX_cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_ButtonX_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_ButtonX_cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_ButtonX_cancel.Location = new System.Drawing.Point(657, 3);
            this.ui_ButtonX_cancel.Name = "ui_ButtonX_cancel";
            this.ui_ButtonX_cancel.Size = new System.Drawing.Size(92, 29);
            this.ui_ButtonX_cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_ButtonX_cancel.TabIndex = 75;
            this.ui_ButtonX_cancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.ui_ButtonX_cancel, "Add symbol to list");
            this.ui_ButtonX_cancel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::DataNetClient.Properties.Resources.backbutton1;
            this.pictureBox1.Location = new System.Drawing.Point(48, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 44);
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Back");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ui_buttonX_del
            // 
            this.ui_buttonX_del.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_buttonX_del.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_buttonX_del.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_buttonX_del.Location = new System.Drawing.Point(347, 145);
            this.ui_buttonX_del.Name = "ui_buttonX_del";
            this.ui_buttonX_del.Size = new System.Drawing.Size(92, 29);
            this.ui_buttonX_del.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_buttonX_del.TabIndex = 77;
            this.ui_buttonX_del.Text = "Delete";
            this.toolTip1.SetToolTip(this.ui_buttonX_del, "Delete selected symbol");
            this.ui_buttonX_del.Click += new System.EventHandler(this.ui_buttonX_del_Click);
            // 
            // ui_buttonX_replace
            // 
            this.ui_buttonX_replace.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_buttonX_replace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_buttonX_replace.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_buttonX_replace.Location = new System.Drawing.Point(445, 145);
            this.ui_buttonX_replace.Name = "ui_buttonX_replace";
            this.ui_buttonX_replace.Size = new System.Drawing.Size(92, 29);
            this.ui_buttonX_replace.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_buttonX_replace.TabIndex = 78;
            this.ui_buttonX_replace.Text = "Replace";
            this.toolTip1.SetToolTip(this.ui_buttonX_replace, "Replace selected symbol");
            this.ui_buttonX_replace.Click += new System.EventHandler(this.ui_buttonX_replace_Click);
            // 
            // ui_buttonX_join
            // 
            this.ui_buttonX_join.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_buttonX_join.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_buttonX_join.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_buttonX_join.Location = new System.Drawing.Point(445, 188);
            this.ui_buttonX_join.Name = "ui_buttonX_join";
            this.ui_buttonX_join.Size = new System.Drawing.Size(92, 29);
            this.ui_buttonX_join.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_buttonX_join.TabIndex = 83;
            this.ui_buttonX_join.Text = "Join";
            this.toolTip1.SetToolTip(this.ui_buttonX_join, "Join");
            this.ui_buttonX_join.Click += new System.EventHandler(this.ui_buttonX_join_Click);
            // 
            // ui_buttonX_editGroup
            // 
            this.ui_buttonX_editGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_buttonX_editGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_buttonX_editGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_buttonX_editGroup.Location = new System.Drawing.Point(445, 227);
            this.ui_buttonX_editGroup.Name = "ui_buttonX_editGroup";
            this.ui_buttonX_editGroup.Size = new System.Drawing.Size(92, 29);
            this.ui_buttonX_editGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_buttonX_editGroup.TabIndex = 86;
            this.ui_buttonX_editGroup.Text = "Edit";
            this.toolTip1.SetToolTip(this.ui_buttonX_editGroup, "Replace selected symbol");
            // 
            // ui_buttonX_delGroup
            // 
            this.ui_buttonX_delGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_buttonX_delGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_buttonX_delGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_buttonX_delGroup.Location = new System.Drawing.Point(347, 227);
            this.ui_buttonX_delGroup.Name = "ui_buttonX_delGroup";
            this.ui_buttonX_delGroup.Size = new System.Drawing.Size(92, 29);
            this.ui_buttonX_delGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_buttonX_delGroup.TabIndex = 85;
            this.ui_buttonX_delGroup.Text = "Delete";
            this.toolTip1.SetToolTip(this.ui_buttonX_delGroup, "Delete selected symbol");
            this.ui_buttonX_delGroup.Click += new System.EventHandler(this.ui_buttonX_delGroup_Click);
            // 
            // ui_buttonX_newGroup
            // 
            this.ui_buttonX_newGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ui_buttonX_newGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_buttonX_newGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ui_buttonX_newGroup.Location = new System.Drawing.Point(249, 227);
            this.ui_buttonX_newGroup.Name = "ui_buttonX_newGroup";
            this.ui_buttonX_newGroup.Size = new System.Drawing.Size(92, 29);
            this.ui_buttonX_newGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ui_buttonX_newGroup.TabIndex = 84;
            this.ui_buttonX_newGroup.Text = "New";
            this.toolTip1.SetToolTip(this.ui_buttonX_newGroup, "Add symbol to list");
            // 
            // labelXTitle
            // 
            this.labelXTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.labelXTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXTitle.Location = new System.Drawing.Point(117, 21);
            this.labelXTitle.Name = "labelXTitle";
            this.labelXTitle.Size = new System.Drawing.Size(257, 32);
            this.labelXTitle.TabIndex = 73;
            this.labelXTitle.Text = "SYMBOLS EDIT";
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(249, 80);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(190, 20);
            this.labelX1.TabIndex = 72;
            this.labelX1.Text = "New symbol name";
            // 
            // ui_textBoxXSymbolName
            // 
            this.ui_textBoxXSymbolName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ui_textBoxXSymbolName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ui_textBoxXSymbolName.Border.Class = "TextBoxBorder";
            this.ui_textBoxXSymbolName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_textBoxXSymbolName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ui_textBoxXSymbolName.ForeColor = System.Drawing.Color.Black;
            this.ui_textBoxXSymbolName.Location = new System.Drawing.Point(249, 106);
            this.ui_textBoxXSymbolName.Name = "ui_textBoxXSymbolName";
            this.ui_textBoxXSymbolName.Size = new System.Drawing.Size(288, 26);
            this.ui_textBoxXSymbolName.TabIndex = 71;
            // 
            // ui_listBox_symbols
            // 
            this.ui_listBox_symbols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ui_listBox_symbols.BackColor = System.Drawing.Color.White;
            this.ui_listBox_symbols.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_listBox_symbols.ForeColor = System.Drawing.Color.Black;
            this.ui_listBox_symbols.FormattingEnabled = true;
            this.ui_listBox_symbols.ItemHeight = 19;
            this.ui_listBox_symbols.Location = new System.Drawing.Point(48, 106);
            this.ui_listBox_symbols.Name = "ui_listBox_symbols";
            this.ui_listBox_symbols.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ui_listBox_symbols.Size = new System.Drawing.Size(195, 268);
            this.ui_listBox_symbols.TabIndex = 79;
            // 
            // ui_listBox_groups
            // 
            this.ui_listBox_groups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ui_listBox_groups.BackColor = System.Drawing.Color.White;
            this.ui_listBox_groups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_listBox_groups.ForeColor = System.Drawing.Color.Black;
            this.ui_listBox_groups.ItemHeight = 19;
            this.ui_listBox_groups.Location = new System.Drawing.Point(249, 262);
            this.ui_listBox_groups.Name = "ui_listBox_groups";
            this.ui_listBox_groups.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ui_listBox_groups.Size = new System.Drawing.Size(288, 116);
            this.ui_listBox_groups.TabIndex = 80;
            this.ui_listBox_groups.SelectedIndexChanged += new System.EventHandler(this.ui_listBox_groups_SelectedIndexChanged);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(48, 80);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(106, 20);
            this.labelX2.TabIndex = 81;
            this.labelX2.Text = "SYMBOLS";
            // 
            // labelX3
            // 
            this.labelX3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(249, 201);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(92, 20);
            this.labelX3.TabIndex = 82;
            this.labelX3.Text = "LISTS";
            // 
            // ui_listBox_symbolsInGroup
            // 
            this.ui_listBox_symbolsInGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ui_listBox_symbolsInGroup.BackColor = System.Drawing.Color.White;
            this.ui_listBox_symbolsInGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_listBox_symbolsInGroup.ForeColor = System.Drawing.Color.Black;
            this.ui_listBox_symbolsInGroup.FormattingEnabled = true;
            this.ui_listBox_symbolsInGroup.ItemHeight = 19;
            this.ui_listBox_symbolsInGroup.Location = new System.Drawing.Point(543, 106);
            this.ui_listBox_symbolsInGroup.Name = "ui_listBox_symbolsInGroup";
            this.ui_listBox_symbolsInGroup.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ui_listBox_symbolsInGroup.Size = new System.Drawing.Size(195, 268);
            this.ui_listBox_symbolsInGroup.TabIndex = 87;
            // 
            // ui_labelX_symbolsInGroup
            // 
            this.ui_labelX_symbolsInGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.ui_labelX_symbolsInGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ui_labelX_symbolsInGroup.Location = new System.Drawing.Point(543, 80);
            this.ui_labelX_symbolsInGroup.Name = "ui_labelX_symbolsInGroup";
            this.ui_labelX_symbolsInGroup.Size = new System.Drawing.Size(195, 20);
            this.ui_labelX_symbolsInGroup.TabIndex = 88;
            this.ui_labelX_symbolsInGroup.Text = "SYMBOLS IN GROUP";
            // 
            // SymbolsEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ui_labelX_symbolsInGroup);
            this.Controls.Add(this.ui_listBox_symbolsInGroup);
            this.Controls.Add(this.ui_buttonX_editGroup);
            this.Controls.Add(this.ui_buttonX_delGroup);
            this.Controls.Add(this.ui_buttonX_newGroup);
            this.Controls.Add(this.ui_buttonX_join);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.ui_listBox_groups);
            this.Controls.Add(this.ui_listBox_symbols);
            this.Controls.Add(this.ui_buttonX_replace);
            this.Controls.Add(this.ui_buttonX_del);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ui_ButtonX_cancel);
            this.Controls.Add(this.ui_ButtonX_add);
            this.Controls.Add(this.labelXTitle);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.ui_textBoxXSymbolName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SymbolsEditControl";
            this.Size = new System.Drawing.Size(752, 416);
            this.Load += new System.EventHandler(this.SymbolsEditControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        internal DevComponents.DotNetBar.ButtonX ui_ButtonX_add;
        internal DevComponents.DotNetBar.LabelX labelXTitle;
        internal DevComponents.DotNetBar.LabelX labelX1;
        internal DevComponents.DotNetBar.Controls.TextBoxX ui_textBoxXSymbolName;
        internal DevComponents.DotNetBar.ButtonX ui_ButtonX_cancel;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal DevComponents.DotNetBar.ButtonX ui_buttonX_del;
        internal DevComponents.DotNetBar.ButtonX ui_buttonX_replace;
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal DevComponents.DotNetBar.LabelX labelX3;
        internal DevComponents.DotNetBar.ButtonX ui_buttonX_join;
        internal DevComponents.DotNetBar.ButtonX ui_buttonX_editGroup;
        internal DevComponents.DotNetBar.ButtonX ui_buttonX_delGroup;
        internal DevComponents.DotNetBar.ButtonX ui_buttonX_newGroup;
        public System.Windows.Forms.ListBox ui_listBox_symbols;
        public System.Windows.Forms.ListBox ui_listBox_groups;
        public System.Windows.Forms.ListBox ui_listBox_symbolsInGroup;
        internal DevComponents.DotNetBar.LabelX ui_labelX_symbolsInGroup;

    }
}
