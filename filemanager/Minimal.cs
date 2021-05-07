using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filemanager
{
    public partial class Minimal : Form
    {
        private readonly Process currentProcess = Process.GetCurrentProcess();

        private readonly Main mainWindow;
        private readonly FileManager fileManager;

        public Minimal(Main mainWindow)
        {
            this.mainWindow = mainWindow;
            this.fileManager = mainWindow.fileManager;

            InitializeComponent();
        }

        public void updateExternalStorageList()
        {
            externalStorageListView.Items.Clear();

            ListViewItem item = new ListViewItem("Файловый менеджер");
            externalStorageListView.Items.Add(item);


        }

        private void Minimal_Load(object sender, EventArgs e)
        {
            updateExternalStorageList();
        }

        private void processesFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            saveProcessesButton.Enabled = processesFileNameTextBox.Text.Length != 0;
        }

        private void saveProcessesButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            saveProcessesButton.Enabled = false;

            try
            {
                StringBuilder buffer = new StringBuilder();
                foreach (var process in Process.GetProcesses())
                {
                    try
                    {
                        if (process.StartTime > currentProcess.StartTime)
                        {
                            buffer.AppendFormat($"{process.StartTime} {process.ProcessName}\n");
                        }
                    }
                    catch (Exception) { }
                }

                string directoryPath = Path.Combine(fileManager.ROOT_PATH, "Логи");
                if (!Directory.Exists(directoryPath))
                {
                    if (File.Exists(directoryPath))
                    {
                        File.Delete(directoryPath);
                    }

                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, processesFileNameTextBox.Text);
                if (Directory.Exists(filePath))
                {
                    Directory.Delete(filePath);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (StreamWriter streamWriter = File.CreateText(filePath))
                {
                    streamWriter.Write(buffer);
                }

                mainWindow.updateUI();
                MessageBox.Show(this, "Процессы успешно сохранены", "Внимание", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                saveProcessesButton.Enabled = true;
                Cursor = Cursors.Arrow;
            }
        }

        private void externalStorageListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void updateExternalStorageButton_Click(object sender, EventArgs e)
        {
            updateExternalStorageList();
        }

        private void Minimal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
