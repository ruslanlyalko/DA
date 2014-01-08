namespace DataNetClient.Controls
{
    partial class StyledListItemControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelEx_back = new DevComponents.DotNetBar.PanelEx();
            this.labelX_startTime = new DevComponents.DotNetBar.LabelX();
            this.labelX_title = new DevComponents.DotNetBar.LabelX();
            this.labelX_count = new DevComponents.DotNetBar.LabelX();
            this.labelX_datetime = new DevComponents.DotNetBar.LabelX();
            this.panelEx_left = new DevComponents.DotNetBar.PanelEx();
            this.labelX_state = new DevComponents.DotNetBar.LabelX();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.symbolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx_back.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx_back
            // 
            this.panelEx_back.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_back.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_back.ContextMenuStrip = this.contextMenuStrip1;
            this.panelEx_back.Controls.Add(this.labelX_startTime);
            this.panelEx_back.Controls.Add(this.labelX_title);
            this.panelEx_back.Controls.Add(this.labelX_count);
            this.panelEx_back.Controls.Add(this.labelX_datetime);
            this.panelEx_back.Controls.Add(this.panelEx_left);
            this.panelEx_back.Controls.Add(this.labelX_state);
            this.panelEx_back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_back.Location = new System.Drawing.Point(0, 0);
            this.panelEx_back.Name = "panelEx_back";
            this.panelEx_back.Size = new System.Drawing.Size(309, 41);
            this.panelEx_back.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_back.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx_back.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_back.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_back.Style.GradientAngle = 90;
            this.panelEx_back.TabIndex = 1;
            this.panelEx_back.Click += new System.EventHandler(this.panelEx_back_Click);
            this.panelEx_back.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.panelEx_back.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // labelX_startTime
            // 
            this.labelX_startTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_startTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_startTime.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_startTime.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_startTime.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_startTime.Location = new System.Drawing.Point(196, 3);
            this.labelX_startTime.Name = "labelX_startTime";
            this.labelX_startTime.Size = new System.Drawing.Size(110, 17);
            this.labelX_startTime.TabIndex = 9;
            this.labelX_startTime.Text = "12:00";
            this.labelX_startTime.TextAlignment = System.Drawing.StringAlignment.Center;
            this.toolTip1.SetToolTip(this.labelX_startTime, "Scheduled date/time");
            // 
            // labelX_title
            // 
            this.labelX_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_title.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_title.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX_title.Location = new System.Drawing.Point(7, 3);
            this.labelX_title.Name = "labelX_title";
            this.labelX_title.Size = new System.Drawing.Size(183, 20);
            this.labelX_title.TabIndex = 4;
            this.labelX_title.Text = "КСМ - 1";
            this.labelX_title.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelX_title.Click += new System.EventHandler(this.panelEx_back_Click);
            this.labelX_title.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // labelX_count
            // 
            // 
            // 
            // 
            this.labelX_count.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_count.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_count.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelX_count.ForeColor = System.Drawing.Color.Black;
            this.labelX_count.Location = new System.Drawing.Point(70, 21);
            this.labelX_count.Name = "labelX_count";
            this.labelX_count.PaddingRight = 5;
            this.labelX_count.Size = new System.Drawing.Size(48, 17);
            this.labelX_count.SymbolColor = System.Drawing.Color.Black;
            this.labelX_count.SymbolSize = 15F;
            this.labelX_count.TabIndex = 3;
            this.labelX_count.Text = "[15]";
            this.labelX_count.TextAlignment = System.Drawing.StringAlignment.Far;
            this.toolTip1.SetToolTip(this.labelX_count, "Total symbol count");
            this.labelX_count.Click += new System.EventHandler(this.panelEx_back_Click);
            this.labelX_count.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_count.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // labelX_datetime
            // 
            this.labelX_datetime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_datetime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_datetime.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_datetime.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_datetime.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_datetime.Location = new System.Drawing.Point(196, 21);
            this.labelX_datetime.Name = "labelX_datetime";
            this.labelX_datetime.Size = new System.Drawing.Size(110, 17);
            this.labelX_datetime.TabIndex = 8;
            this.labelX_datetime.Text = "12:00";
            this.labelX_datetime.TextAlignment = System.Drawing.StringAlignment.Center;
            this.toolTip1.SetToolTip(this.labelX_datetime, "Date/time of last collection");
            this.labelX_datetime.Click += new System.EventHandler(this.panelEx_back_Click);
            this.labelX_datetime.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_datetime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // panelEx_left
            // 
            this.panelEx_left.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_left.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx_left.Location = new System.Drawing.Point(0, 0);
            this.panelEx_left.MaximumSize = new System.Drawing.Size(3, 0);
            this.panelEx_left.Name = "panelEx_left";
            this.panelEx_left.Size = new System.Drawing.Size(3, 41);
            this.panelEx_left.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_left.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_left.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_left.Style.GradientAngle = 90;
            this.panelEx_left.TabIndex = 6;
            // 
            // labelX_state
            // 
            // 
            // 
            // 
            this.labelX_state.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_state.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.labelX_state.ContextMenuStrip = this.contextMenuStrip1;
            this.labelX_state.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelX_state.Location = new System.Drawing.Point(7, 22);
            this.labelX_state.Name = "labelX_state";
            this.labelX_state.Size = new System.Drawing.Size(69, 16);
            this.labelX_state.TabIndex = 7;
            this.labelX_state.Text = "In progress";
            this.toolTip1.SetToolTip(this.labelX_state, "State");
            this.labelX_state.Click += new System.EventHandler(this.panelEx_back_Click);
            this.labelX_state.MouseLeave += new System.EventHandler(this.panelEx_back_MouseLeave);
            this.labelX_state.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEx_back_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.symbolsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 26);
            // 
            // symbolsToolStripMenuItem
            // 
            this.symbolsToolStripMenuItem.Name = "symbolsToolStripMenuItem";
            this.symbolsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.symbolsToolStripMenuItem.Text = "Symbols";
            // 
            // StyledListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelEx_back);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "StyledListItemControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Size = new System.Drawing.Size(309, 43);
            this.panelEx_back.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_back;
        private DevComponents.DotNetBar.LabelX labelX_count;
        private DevComponents.DotNetBar.LabelX labelX_title;
        private DevComponents.DotNetBar.PanelEx panelEx_left;
        private DevComponents.DotNetBar.LabelX labelX_datetime;
        private DevComponents.DotNetBar.LabelX labelX_state;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.LabelX labelX_startTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem symbolsToolStripMenuItem;
    }
}
