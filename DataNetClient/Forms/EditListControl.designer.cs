namespace DataNetClient.Forms
{
    partial class EditListControl
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
            this.labelXTitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cancelButton = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_add_date = new DevComponents.DotNetBar.ButtonX();
            this.listViewEx_dates = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeInput_date = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.buttonX_add = new DevComponents.DotNetBar.ButtonX();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.checkedListBox_rd = new System.Windows.Forms.CheckedListBox();
            this.checkBoxX_parttime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.listViewEx_times = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX_repeat_dialy = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cmbContinuationType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbHistoricalPeriod = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem_tick = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.comboItem14 = new DevComponents.Editors.ComboItem();
            this.comboItem15 = new DevComponents.Editors.ComboItem();
            this.textBoxXListName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnRemov = new DevComponents.DotNetBar.ButtonX();
            this.saveButton = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.lbSelList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelXTitle
            // 
            // 
            // 
            // 
            this.labelXTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelXTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXTitle.Location = new System.Drawing.Point(101, 4);
            this.labelXTitle.Name = "labelXTitle";
            this.labelXTitle.Size = new System.Drawing.Size(239, 34);
            this.labelXTitle.TabIndex = 19;
            this.labelXTitle.Text = "EDIT SYMBOLS LIST";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DataNetClient.Properties.Resources.backbutton1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 44);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Cancel");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelButton.Location = new System.Drawing.Point(666, 403);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 31);
            this.cancelButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelButton.TabIndex = 91;
            this.cancelButton.Text = "Cancel";
            this.toolTip1.SetToolTip(this.cancelButton, "Return without saving");
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.buttonX_add_date);
            this.panelEx1.Controls.Add(this.listViewEx_dates);
            this.panelEx1.Controls.Add(this.dateTimeInput_date);
            this.panelEx1.Controls.Add(this.buttonX_add);
            this.panelEx1.Controls.Add(this.dateTimeInput2);
            this.panelEx1.Controls.Add(this.dateTimeInput1);
            this.panelEx1.Controls.Add(this.checkedListBox_rd);
            this.panelEx1.Controls.Add(this.checkBoxX_parttime);
            this.panelEx1.Controls.Add(this.listViewEx_times);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.checkBoxX_repeat_dialy);
            this.panelEx1.Location = new System.Drawing.Point(24, 172);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(512, 218);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 102;
            // 
            // buttonX_add_date
            // 
            this.buttonX_add_date.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_add_date.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_add_date.Location = new System.Drawing.Point(448, 28);
            this.buttonX_add_date.Name = "buttonX_add_date";
            this.buttonX_add_date.Size = new System.Drawing.Size(49, 23);
            this.buttonX_add_date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_add_date.TabIndex = 103;
            this.buttonX_add_date.Text = "Add";
            this.buttonX_add_date.Click += new System.EventHandler(this.buttonX_add_date_Click);
            // 
            // listViewEx_dates
            // 
            this.listViewEx_dates.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx_dates.Border.Class = "ListViewBorder";
            this.listViewEx_dates.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx_dates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewEx_dates.ContextMenuStrip = this.contextMenuStrip2;
            this.listViewEx_dates.ForeColor = System.Drawing.Color.Black;
            this.listViewEx_dates.Location = new System.Drawing.Point(354, 57);
            this.listViewEx_dates.Name = "listViewEx_dates";
            this.listViewEx_dates.Size = new System.Drawing.Size(143, 149);
            this.listViewEx_dates.TabIndex = 102;
            this.listViewEx_dates.UseCompatibleStateImageBehavior = false;
            this.listViewEx_dates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 120;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(108, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "Delete";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // dateTimeInput_date
            // 
            // 
            // 
            // 
            this.dateTimeInput_date.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput_date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_date.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput_date.ButtonDropDown.Visible = true;
            this.dateTimeInput_date.IsPopupCalendarOpen = false;
            this.dateTimeInput_date.Location = new System.Drawing.Point(354, 28);
            // 
            // 
            // 
            this.dateTimeInput_date.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput_date.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_date.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput_date.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput_date.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput_date.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_date.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput_date.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput_date.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput_date.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput_date.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_date.MonthCalendar.DisplayMonth = new System.DateTime(2013, 12, 1, 0, 0, 0, 0);
            this.dateTimeInput_date.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateTimeInput_date.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput_date.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput_date.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput_date.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_date.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput_date.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_date.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput_date.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput_date.Name = "dateTimeInput_date";
            this.dateTimeInput_date.Size = new System.Drawing.Size(88, 23);
            this.dateTimeInput_date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput_date.TabIndex = 101;
            this.dateTimeInput_date.Value = new System.DateTime(2013, 12, 17, 0, 0, 0, 0);
            // 
            // buttonX_add
            // 
            this.buttonX_add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_add.Enabled = false;
            this.buttonX_add.Location = new System.Drawing.Point(155, 57);
            this.buttonX_add.Name = "buttonX_add";
            this.buttonX_add.Size = new System.Drawing.Size(49, 23);
            this.buttonX_add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_add.TabIndex = 100;
            this.buttonX_add.Text = "Add";
            this.buttonX_add.Click += new System.EventHandler(this.buttonX_add_Click);
            // 
            // dateTimeInput2
            // 
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.Enabled = false;
            this.dateTimeInput2.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(79, 58);
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2013, 12, 1, 0, 0, 0, 0);
            this.dateTimeInput2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateTimeInput2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput2.MonthCalendar.Visible = false;
            this.dateTimeInput2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput2.Name = "dateTimeInput2";
            this.dateTimeInput2.Size = new System.Drawing.Size(64, 23);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 99;
            this.dateTimeInput2.Value = new System.DateTime(2013, 12, 17, 0, 0, 0, 0);
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.Enabled = false;
            this.dateTimeInput1.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(12, 58);
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2013, 12, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateTimeInput1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.MonthCalendar.Visible = false;
            this.dateTimeInput1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(64, 23);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 98;
            this.dateTimeInput1.Value = new System.DateTime(2013, 12, 17, 0, 0, 0, 0);
            // 
            // checkedListBox_rd
            // 
            this.checkedListBox_rd.Enabled = false;
            this.checkedListBox_rd.FormattingEnabled = true;
            this.checkedListBox_rd.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.checkedListBox_rd.Location = new System.Drawing.Point(212, 57);
            this.checkedListBox_rd.Name = "checkedListBox_rd";
            this.checkedListBox_rd.Size = new System.Drawing.Size(136, 148);
            this.checkedListBox_rd.TabIndex = 96;
            // 
            // checkBoxX_parttime
            // 
            // 
            // 
            // 
            this.checkBoxX_parttime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_parttime.Location = new System.Drawing.Point(12, 28);
            this.checkBoxX_parttime.Name = "checkBoxX_parttime";
            this.checkBoxX_parttime.Size = new System.Drawing.Size(192, 23);
            this.checkBoxX_parttime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_parttime.TabIndex = 95;
            this.checkBoxX_parttime.Text = "Is particular?";
            this.checkBoxX_parttime.CheckedChanged += new System.EventHandler(this.checkBoxX_parttime_CheckedChanged);
            // 
            // listViewEx_times
            // 
            this.listViewEx_times.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx_times.Border.Class = "ListViewBorder";
            this.listViewEx_times.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx_times.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.listViewEx_times.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewEx_times.Enabled = false;
            this.listViewEx_times.ForeColor = System.Drawing.Color.Black;
            this.listViewEx_times.Location = new System.Drawing.Point(12, 87);
            this.listViewEx_times.Name = "listViewEx_times";
            this.listViewEx_times.Size = new System.Drawing.Size(192, 116);
            this.listViewEx_times.TabIndex = 94;
            this.listViewEx_times.UseCompatibleStateImageBehavior = false;
            this.listViewEx_times.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time Start";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Time End";
            this.columnHeader3.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.labelX4.Location = new System.Drawing.Point(3, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.PaddingLeft = 10;
            this.labelX4.Size = new System.Drawing.Size(110, 23);
            this.labelX4.TabIndex = 90;
            this.labelX4.Text = "Schedule";
            // 
            // checkBoxX_repeat_dialy
            // 
            // 
            // 
            // 
            this.checkBoxX_repeat_dialy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_repeat_dialy.Location = new System.Drawing.Point(212, 28);
            this.checkBoxX_repeat_dialy.Name = "checkBoxX_repeat_dialy";
            this.checkBoxX_repeat_dialy.Size = new System.Drawing.Size(136, 23);
            this.checkBoxX_repeat_dialy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_repeat_dialy.TabIndex = 89;
            this.checkBoxX_repeat_dialy.Text = "Days required";
            this.checkBoxX_repeat_dialy.CheckedChanged += new System.EventHandler(this.checkBoxX_repeat_dialy_CheckedChanged);
            // 
            // cmbContinuationType
            // 
            this.cmbContinuationType.DisplayMember = "Text";
            this.cmbContinuationType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbContinuationType.FormattingEnabled = true;
            this.cmbContinuationType.ItemHeight = 17;
            this.cmbContinuationType.Location = new System.Drawing.Point(185, 129);
            this.cmbContinuationType.Name = "cmbContinuationType";
            this.cmbContinuationType.Size = new System.Drawing.Size(351, 23);
            this.cmbContinuationType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbContinuationType.TabIndex = 101;
            // 
            // cmbHistoricalPeriod
            // 
            this.cmbHistoricalPeriod.DisplayMember = "Text";
            this.cmbHistoricalPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHistoricalPeriod.FormattingEnabled = true;
            this.cmbHistoricalPeriod.ItemHeight = 17;
            this.cmbHistoricalPeriod.Items.AddRange(new object[] {
            this.comboItem_tick,
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8,
            this.comboItem9,
            this.comboItem10,
            this.comboItem11,
            this.comboItem12,
            this.comboItem13,
            this.comboItem14,
            this.comboItem15});
            this.cmbHistoricalPeriod.Location = new System.Drawing.Point(185, 100);
            this.cmbHistoricalPeriod.Name = "cmbHistoricalPeriod";
            this.cmbHistoricalPeriod.Size = new System.Drawing.Size(351, 23);
            this.cmbHistoricalPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbHistoricalPeriod.TabIndex = 100;
            // 
            // comboItem_tick
            // 
            this.comboItem_tick.Text = "tick";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "1 minute";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2 minutes";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "3 minutes";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "5 minutes";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "10 minutes";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "15 minutes";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "30 minutes";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "60 minutes";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "240 minutes";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "Daily";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "Weekly";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "Monthly";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "Quarterly";
            // 
            // comboItem14
            // 
            this.comboItem14.Text = "Semiannual";
            // 
            // comboItem15
            // 
            this.comboItem15.Text = "Yearly";
            // 
            // textBoxXListName
            // 
            this.textBoxXListName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxXListName.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBoxXListName.Border.BorderLeftColor = System.Drawing.Color.Green;
            this.textBoxXListName.Border.BorderLeftWidth = 3;
            this.textBoxXListName.Border.Class = "TextBoxBorder";
            this.textBoxXListName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXListName.ForeColor = System.Drawing.Color.Black;
            this.textBoxXListName.Location = new System.Drawing.Point(185, 71);
            this.textBoxXListName.Name = "textBoxXListName";
            this.textBoxXListName.Size = new System.Drawing.Size(351, 23);
            this.textBoxXListName.TabIndex = 96;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX1.Location = new System.Drawing.Point(104, 71);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 21);
            this.labelX1.TabIndex = 97;
            this.labelX1.Text = "List Name:";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX2.Location = new System.Drawing.Point(104, 100);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 21);
            this.labelX2.TabIndex = 98;
            this.labelX2.Text = "Timeframe:";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX3.Location = new System.Drawing.Point(45, 127);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(134, 21);
            this.labelX3.TabIndex = 99;
            this.labelX3.Text = "Continuation Types:";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnRemov
            // 
            this.btnRemov.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemov.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRemov.Location = new System.Drawing.Point(696, 45);
            this.btnRemov.Name = "btnRemov";
            this.btnRemov.Size = new System.Drawing.Size(75, 24);
            this.btnRemov.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRemov.TabIndex = 95;
            this.btnRemov.Text = "<";
            this.btnRemov.Click += new System.EventHandler(this.btnRemov_Click);
            // 
            // saveButton
            // 
            this.saveButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.saveButton.Location = new System.Drawing.Point(542, 403);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 31);
            this.saveButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.saveButton.TabIndex = 94;
            this.saveButton.Text = "Save";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX5.Location = new System.Drawing.Point(546, 48);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(131, 21);
            this.labelX5.TabIndex = 93;
            this.labelX5.Text = "Selected symbols:";
            // 
            // lbSelList
            // 
            this.lbSelList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSelList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSelList.FormattingEnabled = true;
            this.lbSelList.ItemHeight = 15;
            this.lbSelList.Location = new System.Drawing.Point(542, 71);
            this.lbSelList.Name = "lbSelList";
            this.lbSelList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSelList.Size = new System.Drawing.Size(229, 319);
            this.lbSelList.TabIndex = 92;
            // 
            // EditListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.cmbContinuationType);
            this.Controls.Add(this.cmbHistoricalPeriod);
            this.Controls.Add(this.textBoxXListName);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.btnRemov);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.lbSelList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelXTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "EditListControl";
            this.Size = new System.Drawing.Size(800, 482);
            this.Load += new System.EventHandler(this.EditListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevComponents.DotNetBar.LabelX labelXTitle;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonX_add_date;
        internal DevComponents.DotNetBar.Controls.ListViewEx listViewEx_dates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput_date;
        private DevComponents.DotNetBar.ButtonX buttonX_add;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        internal System.Windows.Forms.CheckedListBox checkedListBox_rd;
        internal DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_parttime;
        internal DevComponents.DotNetBar.Controls.ListViewEx listViewEx_times;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevComponents.DotNetBar.LabelX labelX4;
        internal DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_repeat_dialy;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cmbContinuationType;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx cmbHistoricalPeriod;
        private DevComponents.Editors.ComboItem comboItem_tick;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.Editors.ComboItem comboItem14;
        private DevComponents.Editors.ComboItem comboItem15;
        internal DevComponents.DotNetBar.Controls.TextBoxX textBoxXListName;
        internal DevComponents.DotNetBar.LabelX labelX1;
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnRemov;
        internal DevComponents.DotNetBar.ButtonX cancelButton;
        internal DevComponents.DotNetBar.ButtonX saveButton;
        internal DevComponents.DotNetBar.LabelX labelX5;
        internal System.Windows.Forms.ListBox lbSelList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

    }
}
