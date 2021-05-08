using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFunctional
{
    public partial class mainFunctionalForm : Form
    {
        private readonly Process currentProcess = Process.GetCurrentProcess();

        public mainFunctionalForm()
        {
            InitializeComponent();
        }

        private void mainFunctionalForm_Load(object sender, EventArgs e)
        {
            updateTimer.Start();
            Focus();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            cpuUsageTextBox.Text = $"{currentProcess.TotalProcessorTime.TotalMilliseconds} мс";
        }
    }
}
