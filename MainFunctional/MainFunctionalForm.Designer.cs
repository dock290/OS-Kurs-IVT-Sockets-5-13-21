
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
            this.cpuUsageLabel = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.coreColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usageColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpuUsageValueLabel = new System.Windows.Forms.Label();
            this.workingSetLabel = new System.Windows.Forms.Label();
            this.workingSetValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cpuUsageLabel
            // 
            this.cpuUsageLabel.AutoSize = true;
            this.cpuUsageLabel.Location = new System.Drawing.Point(11, 11);
            this.cpuUsageLabel.Name = "cpuUsageLabel";
            this.cpuUsageLabel.Size = new System.Drawing.Size(150, 13);
            this.cpuUsageLabel.TabIndex = 0;
            this.cpuUsageLabel.Text = "Использованное время ЦП:";
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
            this.listView.Location = new System.Drawing.Point(11, 48);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(265, 91);
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
            this.usageColumnHeader.Width = 120;
            // 
            // cpuUsageValueLabel
            // 
            this.cpuUsageValueLabel.AutoSize = true;
            this.cpuUsageValueLabel.Location = new System.Drawing.Point(167, 11);
            this.cpuUsageValueLabel.Name = "cpuUsageValueLabel";
            this.cpuUsageValueLabel.Size = new System.Drawing.Size(30, 13);
            this.cpuUsageValueLabel.TabIndex = 3;
            this.cpuUsageValueLabel.Text = "0 мс";
            // 
            // workingSetLabel
            // 
            this.workingSetLabel.AutoSize = true;
            this.workingSetLabel.Location = new System.Drawing.Point(12, 32);
            this.workingSetLabel.Name = "workingSetLabel";
            this.workingSetLabel.Size = new System.Drawing.Size(202, 13);
            this.workingSetLabel.TabIndex = 4;
            this.workingSetLabel.Text = "Размер рабочего множества страниц:";
            // 
            // workingSetValueLabel
            // 
            this.workingSetValueLabel.AutoSize = true;
            this.workingSetValueLabel.Location = new System.Drawing.Point(220, 32);
            this.workingSetValueLabel.Name = "workingSetValueLabel";
            this.workingSetValueLabel.Size = new System.Drawing.Size(39, 13);
            this.workingSetValueLabel.TabIndex = 5;
            this.workingSetValueLabel.Text = "0 байт";
            // 
            // mainFunctionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 148);
            this.Controls.Add(this.workingSetValueLabel);
            this.Controls.Add(this.workingSetLabel);
            this.Controls.Add(this.cpuUsageValueLabel);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.cpuUsageLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(302, 187);
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
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader coreColumnHeader;
        private System.Windows.Forms.ColumnHeader usageColumnHeader;
        private System.Windows.Forms.Label cpuUsageValueLabel;
        private System.Windows.Forms.Label workingSetLabel;
        private System.Windows.Forms.Label workingSetValueLabel;
    }
}

