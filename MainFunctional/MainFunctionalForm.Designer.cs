﻿
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
            // mainFunctionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 221);
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
    }
}

