using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MainFunctional
{
    public partial class mainFunctionalForm : Form
    {
        private readonly IPEndPoint ipPoint;
        private readonly Socket listenSocket;

        private readonly Thread socketListenThread;
        private bool isWorking = true;

        public mainFunctionalForm()
        {
            Process[] processes = Process.GetProcessesByName("MainFunctional");
            foreach (Process process in processes)
            {
                if (processes.Length > 1)
                {
                    process.Kill();
                }
            }

            ipPoint = new IPEndPoint(Dns.GetHostAddresses("localhost")[0], 8000);
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socketListenThread = new Thread(receiveMessage);
            socketListenThread.Start();

            InitializeComponent();
        }

        private void mainFunctionalForm_Load(object sender, EventArgs e)
        {
            Focus();
        }

        private void receiveMessage()
        {
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);
                Socket handler = listenSocket.Accept();

                do
                {
                    StringBuilder sb = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];

                    do
                    {
                        bytes = handler.Receive(data);
                        sb.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (handler.Available > 0);

                    string[] tokens = sb.ToString().Split('\n');
                    foreach (string token in tokens)
                    {
                        if (token.Length > 0)
                        {
                            string[] keyValue = token.Split('=');

                            if (keyValue[0].Equals("Show"))
                            {
                                if (keyValue[1].Equals("true"))
                                {
                                    Show();
                                    Focus();
                                }
                                else
                                {
                                    Hide();
                                }
                            }
                            else if (keyValue[0].Equals("ProcessorTime"))
                            {
                                string processorTime = keyValue[1];
                                cpuTimeValueLabel.Text = $"{processorTime} мс";
                            }
                            else if (keyValue[0].Equals("WorkingSet"))
                            {
                                string workingSet = keyValue[1];
                                workingSetValueLabel.Text = $"{workingSet} байт";
                            }
                            else if (keyValue[0].Equals("Cores"))
                            {
                                int cores = int.Parse(keyValue[1]);
                                for (int i = 0; i < cores; i++)
                                {
                                    ListViewItem item = new ListViewItem(new string[] { $"{i + 1}", "0" });
                                    listView.Items.Add(item);
                                }
                            }
                            else if (int.TryParse(keyValue[0], out int core))
                            {
                                listView.Items[core].SubItems[1].Text = keyValue[1];
                            }
                        }
                    }
                } while (isWorking);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isWorking = false;
                Application.Exit();
            }
        }

        private void mainFunctionalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isWorking = false;
        }

        private void mainFunctionalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
