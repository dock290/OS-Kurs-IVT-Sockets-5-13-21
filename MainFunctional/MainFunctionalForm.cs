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
        private readonly List<PerformanceCounter> performanceCounterList = new List<PerformanceCounter>();

        public mainFunctionalForm()
        {
            InitializeComponent();
        }

        private void mainFunctionalForm_Load(object sender, EventArgs e)
        {
            int i = 1;
            PerformanceCounterCategory pfc = new PerformanceCounterCategory("Processor");
            foreach (string instanceName in pfc.GetInstanceNames())
            {
                if (!instanceName.Equals("_Total"))
                {
                    PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time");
                    cpuUsage.InstanceName = instanceName;
                    performanceCounterList.Add(cpuUsage);
                    cpuUsage.NextValue();
                    ListViewItem item = new ListViewItem(new string[] { $"{i++}", $"{0}%" });
                    listView.Items.Add(item);
                }
            }
            performanceCounterList.Sort((pc1, pc2) => pc1.InstanceName.CompareTo(pc2.InstanceName));

            updateTimer.Start();

            Focus();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            cpuUsageValueLabel.Text = $"{currentProcess.TotalProcessorTime.TotalMilliseconds} мс";
            workingSetValueLabel.Text = $"{currentProcess.WorkingSet64} байт";

            int i = 0;
            foreach (PerformanceCounter pc in performanceCounterList)
            {
                float value = pc.NextValue();
                listView.Items[i++].SubItems[1].Text = $"{value}%";
            }
        }
    }
}
