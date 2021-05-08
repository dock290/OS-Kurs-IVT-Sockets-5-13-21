
namespace MainFunctional
{
    partial class mainFunctionalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cpuUsageLabel = new System.Windows.Forms.Label();
            this.cpuUsageTextBox = new System.Windows.Forms.TextBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.coreColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.usageColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // cpuUsageLabel
            // 
            this.cpuUsageLabel.AutoSize = true;
            this.cpuUsageLabel.Location = new System.Drawing.Point(13, 13);
            this.cpuUsageLabel.Name = "cpuUsageLabel";
            this.cpuUsageLabel.Size = new System.Drawing.Size(161, 15);
            this.cpuUsageLabel.TabIndex = 0;
            this.cpuUsageLabel.Text = "Использованное время ЦП:";
            // 
            // cpuUsageTextBox
            // 
            this.cpuUsageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cpuUsageTextBox.Location = new System.Drawing.Point(180, 10);
            this.cpuUsageTextBox.Name = "cpuUsageTextBox";
            this.cpuUsageTextBox.ReadOnly = true;
            this.cpuUsageTextBox.Size = new System.Drawing.Size(112, 23);
            this.cpuUsageTextBox.TabIndex = 1;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.coreColumnHeader,
            this.usageColumnHeader});
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(13, 121);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(279, 88);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // coreColumnHeader
            // 
            this.coreColumnHeader.Text = "Ядро";
            // 
            // usageColumnHeader
            // 
            this.usageColumnHeader.Text = "Загрузка";
            // 
            // mainFunctionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 221);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.cpuUsageTextBox);
            this.Controls.Add(this.cpuUsageLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 260);
            this.Name = "mainFunctionalForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Основной функционал";
            this.Load += new System.EventHandler(this.mainFunctionalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cpuUsageLabel;
        private System.Windows.Forms.TextBox cpuUsageTextBox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader coreColumnHeader;
        private System.Windows.Forms.ColumnHeader usageColumnHeader;
    }
}

