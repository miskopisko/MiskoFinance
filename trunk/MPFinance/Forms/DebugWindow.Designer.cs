namespace MPFinance.Forms
{
    partial class DebugWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWindow));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.messageTimingGridView = new MPFinance.Forms.Controls.MessageTimingGridView();
            this.messageNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMessageTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSqlTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sqlTimingGridView = new MPFinance.Forms.Controls.SqlTimingGridView();
            this.messageTimingGridViewqqqq = new MPFinance.Forms.Controls.MessageTimingGridView();
            this.messageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMessageTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSqlTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageTimingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlTimingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTimingGridViewqqqq)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.MessageText);
            this.splitContainer3.Size = new System.Drawing.Size(1043, 321);
            this.splitContainer3.SplitterDistance = 587;
            this.splitContainer3.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.messageTimingGridView);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.sqlTimingGridView);
            this.splitContainer4.Size = new System.Drawing.Size(587, 321);
            this.splitContainer4.SplitterDistance = 165;
            this.splitContainer4.TabIndex = 0;
            // 
            // MessageText
            // 
            this.MessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageText.Location = new System.Drawing.Point(0, 0);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MessageText.Size = new System.Drawing.Size(452, 321);
            this.MessageText.TabIndex = 1;
            this.MessageText.WordWrap = false;
            // 
            // messageTimingGridView
            // 
            this.messageTimingGridView.AllowUserToAddRows = false;
            this.messageTimingGridView.AllowUserToDeleteRows = false;
            this.messageTimingGridView.AllowUserToResizeColumns = false;
            this.messageTimingGridView.AllowUserToResizeRows = false;
            this.messageTimingGridView.AutoGenerateColumns = false;
            this.messageTimingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.messageTimingGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messageNameDataGridViewTextBoxColumn1,
            this.startTimeDataGridViewTextBoxColumn1,
            this.endTimeDataGridViewTextBoxColumn1,
            this.totalMessageTimeDataGridViewTextBoxColumn1,
            this.totalSqlTimeDataGridViewTextBoxColumn1});
            this.messageTimingGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTimingGridView.Location = new System.Drawing.Point(0, 0);
            this.messageTimingGridView.MultiSelect = false;
            this.messageTimingGridView.Name = "messageTimingGridView";
            this.messageTimingGridView.ReadOnly = true;
            this.messageTimingGridView.RowHeadersVisible = false;
            this.messageTimingGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTimingGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.messageTimingGridView.Size = new System.Drawing.Size(587, 165);
            this.messageTimingGridView.TabIndex = 1;
            // 
            // messageNameDataGridViewTextBoxColumn1
            // 
            this.messageNameDataGridViewTextBoxColumn1.DataPropertyName = "MessageName";
            this.messageNameDataGridViewTextBoxColumn1.HeaderText = "MessageName";
            this.messageNameDataGridViewTextBoxColumn1.Name = "messageNameDataGridViewTextBoxColumn1";
            this.messageNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // startTimeDataGridViewTextBoxColumn1
            // 
            this.startTimeDataGridViewTextBoxColumn1.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn1.HeaderText = "StartTime";
            this.startTimeDataGridViewTextBoxColumn1.Name = "startTimeDataGridViewTextBoxColumn1";
            this.startTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn1
            // 
            this.endTimeDataGridViewTextBoxColumn1.DataPropertyName = "EndTime";
            this.endTimeDataGridViewTextBoxColumn1.HeaderText = "EndTime";
            this.endTimeDataGridViewTextBoxColumn1.Name = "endTimeDataGridViewTextBoxColumn1";
            this.endTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalMessageTimeDataGridViewTextBoxColumn1
            // 
            this.totalMessageTimeDataGridViewTextBoxColumn1.DataPropertyName = "TotalMessageTime";
            this.totalMessageTimeDataGridViewTextBoxColumn1.HeaderText = "TotalMessageTime";
            this.totalMessageTimeDataGridViewTextBoxColumn1.Name = "totalMessageTimeDataGridViewTextBoxColumn1";
            this.totalMessageTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalSqlTimeDataGridViewTextBoxColumn1
            // 
            this.totalSqlTimeDataGridViewTextBoxColumn1.DataPropertyName = "TotalSqlTime";
            this.totalSqlTimeDataGridViewTextBoxColumn1.HeaderText = "TotalSqlTime";
            this.totalSqlTimeDataGridViewTextBoxColumn1.Name = "totalSqlTimeDataGridViewTextBoxColumn1";
            this.totalSqlTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // sqlTimingGridView
            // 
            this.sqlTimingGridView.AllowUserToAddRows = false;
            this.sqlTimingGridView.AllowUserToDeleteRows = false;
            this.sqlTimingGridView.AllowUserToResizeColumns = false;
            this.sqlTimingGridView.AllowUserToResizeRows = false;
            this.sqlTimingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sqlTimingGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlTimingGridView.Location = new System.Drawing.Point(0, 0);
            this.sqlTimingGridView.Name = "sqlTimingGridView";
            this.sqlTimingGridView.ReadOnly = true;
            this.sqlTimingGridView.RowHeadersVisible = false;
            this.sqlTimingGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sqlTimingGridView.Size = new System.Drawing.Size(587, 152);
            this.sqlTimingGridView.TabIndex = 0;
            // 
            // messageTimingGridViewqqqq
            // 
            this.messageTimingGridViewqqqq.AllowUserToAddRows = false;
            this.messageTimingGridViewqqqq.AllowUserToDeleteRows = false;
            this.messageTimingGridViewqqqq.AllowUserToResizeColumns = false;
            this.messageTimingGridViewqqqq.AllowUserToResizeRows = false;
            this.messageTimingGridViewqqqq.AutoGenerateColumns = false;
            this.messageTimingGridViewqqqq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.messageTimingGridViewqqqq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messageNameDataGridViewTextBoxColumn,
            this.startTimeDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn,
            this.totalMessageTimeDataGridViewTextBoxColumn,
            this.totalSqlTimeDataGridViewTextBoxColumn});
            this.messageTimingGridViewqqqq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTimingGridViewqqqq.Location = new System.Drawing.Point(0, 0);
            this.messageTimingGridViewqqqq.MultiSelect = false;
            this.messageTimingGridViewqqqq.Name = "messageTimingGridViewqqqq";
            this.messageTimingGridViewqqqq.ReadOnly = true;
            this.messageTimingGridViewqqqq.RowHeadersVisible = false;
            this.messageTimingGridViewqqqq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTimingGridViewqqqq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.messageTimingGridViewqqqq.Size = new System.Drawing.Size(539, 185);
            this.messageTimingGridViewqqqq.TabIndex = 0;
            // 
            // messageNameDataGridViewTextBoxColumn
            // 
            this.messageNameDataGridViewTextBoxColumn.DataPropertyName = "MessageName";
            this.messageNameDataGridViewTextBoxColumn.HeaderText = "MessageName";
            this.messageNameDataGridViewTextBoxColumn.Name = "messageNameDataGridViewTextBoxColumn";
            this.messageNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.HeaderText = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalMessageTimeDataGridViewTextBoxColumn
            // 
            this.totalMessageTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalMessageTime";
            this.totalMessageTimeDataGridViewTextBoxColumn.HeaderText = "TotalMessageTime";
            this.totalMessageTimeDataGridViewTextBoxColumn.Name = "totalMessageTimeDataGridViewTextBoxColumn";
            this.totalMessageTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalSqlTimeDataGridViewTextBoxColumn
            // 
            this.totalSqlTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalSqlTime";
            this.totalSqlTimeDataGridViewTextBoxColumn.HeaderText = "TotalSqlTime";
            this.totalSqlTimeDataGridViewTextBoxColumn.Name = "totalSqlTimeDataGridViewTextBoxColumn";
            this.totalSqlTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 321);
            this.Controls.Add(this.splitContainer3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(10, 10);
            this.MaximizeBox = false;
            this.Name = "DebugWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Debug Window";
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.messageTimingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlTimingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTimingGridViewqqqq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MessageTimingGridView messageTimingGridViewqqqq;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMessageTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSqlTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Controls.MessageTimingGridView messageTimingGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMessageTimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSqlTimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox MessageText;
        private Controls.SqlTimingGridView sqlTimingGridView;
    }
}