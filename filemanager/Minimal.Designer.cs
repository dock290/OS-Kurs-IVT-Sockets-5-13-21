
namespace filemanager
{
    partial class Minimal
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
            this.externalStorageGroupBox = new System.Windows.Forms.GroupBox();
            this.externalStorageListView = new System.Windows.Forms.ListView();
            this.processesGroupBox = new System.Windows.Forms.GroupBox();
            this.saveProcessesButton = new System.Windows.Forms.Button();
            this.processesFileNameTextBox = new System.Windows.Forms.TextBox();
            this.updateExternalStorageButton = new System.Windows.Forms.Button();
            this.externalStorageGroupBox.SuspendLayout();
            this.processesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // externalStorageGroupBox
            // 
            this.externalStorageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.externalStorageGroupBox.Controls.Add(this.updateExternalStorageButton);
            this.externalStorageGroupBox.Controls.Add(this.externalStorageListView);
            this.externalStorageGroupBox.Location = new System.Drawing.Point(13, 69);
            this.externalStorageGroupBox.Name = "externalStorageGroupBox";
            this.externalStorageGroupBox.Size = new System.Drawing.Size(279, 140);
            this.externalStorageGroupBox.TabIndex = 0;
            this.externalStorageGroupBox.TabStop = false;
            this.externalStorageGroupBox.Text = "Съёмные носители";
            // 
            // externalStorageListView
            // 
            this.externalStorageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.externalStorageListView.HideSelection = false;
            this.externalStorageListView.Location = new System.Drawing.Point(7, 20);
            this.externalStorageListView.Name = "externalStorageListView";
            this.externalStorageListView.Size = new System.Drawing.Size(235, 114);
            this.externalStorageListView.TabIndex = 0;
            this.externalStorageListView.UseCompatibleStateImageBehavior = false;
            this.externalStorageListView.View = System.Windows.Forms.View.List;
            this.externalStorageListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.externalStorageListView_MouseDoubleClick);
            // 
            // processesGroupBox
            // 
            this.processesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processesGroupBox.Controls.Add(this.saveProcessesButton);
            this.processesGroupBox.Controls.Add(this.processesFileNameTextBox);
            this.processesGroupBox.Location = new System.Drawing.Point(13, 13);
            this.processesGroupBox.Name = "processesGroupBox";
            this.processesGroupBox.Size = new System.Drawing.Size(279, 50);
            this.processesGroupBox.TabIndex = 1;
            this.processesGroupBox.TabStop = false;
            this.processesGroupBox.Text = "Протокол запущенных процессов";
            // 
            // saveProcessesButton
            // 
            this.saveProcessesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.saveProcessesButton.Location = new System.Drawing.Point(198, 24);
            this.saveProcessesButton.Name = "saveProcessesButton";
            this.saveProcessesButton.Size = new System.Drawing.Size(75, 20);
            this.saveProcessesButton.TabIndex = 1;
            this.saveProcessesButton.Text = "Сохранить";
            this.saveProcessesButton.UseVisualStyleBackColor = true;
            this.saveProcessesButton.Click += new System.EventHandler(this.saveProcessesButton_Click);
            // 
            // processesFileNameTextBox
            // 
            this.processesFileNameTextBox.Location = new System.Drawing.Point(7, 24);
            this.processesFileNameTextBox.Name = "processesFileNameTextBox";
            this.processesFileNameTextBox.Size = new System.Drawing.Size(185, 20);
            this.processesFileNameTextBox.TabIndex = 0;
            this.processesFileNameTextBox.Text = "processes.txt";
            this.processesFileNameTextBox.TextChanged += new System.EventHandler(this.processesFileNameTextBox_TextChanged);
            // 
            // updateExternalStorageButton
            // 
            this.updateExternalStorageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateExternalStorageButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.updateExternalStorageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateExternalStorageButton.Location = new System.Drawing.Point(248, 20);
            this.updateExternalStorageButton.Name = "updateExternalStorageButton";
            this.updateExternalStorageButton.Size = new System.Drawing.Size(25, 25);
            this.updateExternalStorageButton.TabIndex = 1;
            this.updateExternalStorageButton.Text = "⭮";
            this.updateExternalStorageButton.UseVisualStyleBackColor = true;
            this.updateExternalStorageButton.Click += new System.EventHandler(this.updateExternalStorageButton_Click);
            // 
            // Minimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 221);
            this.Controls.Add(this.processesGroupBox);
            this.Controls.Add(this.externalStorageGroupBox);
            this.MinimumSize = new System.Drawing.Size(320, 260);
            this.Name = "Minimal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Монитор процессов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Minimal_FormClosing);
            this.Load += new System.EventHandler(this.Minimal_Load);
            this.externalStorageGroupBox.ResumeLayout(false);
            this.processesGroupBox.ResumeLayout(false);
            this.processesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox externalStorageGroupBox;
        private System.Windows.Forms.GroupBox processesGroupBox;
        private System.Windows.Forms.Button saveProcessesButton;
        private System.Windows.Forms.TextBox processesFileNameTextBox;
        private System.Windows.Forms.ListView externalStorageListView;
        private System.Windows.Forms.Button updateExternalStorageButton;
    }
}