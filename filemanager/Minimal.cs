using System;
using System.Diagnostics;
using System.IO;
using System.Text;
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
            fileManager = mainWindow.fileManager;

            InitializeComponent();
        }

        private void processesFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            saveProcessesButton.Enabled = processesFileNameTextBox.Text.Length != 0;
        }

        private void saveProcessesButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            saveProcessesButton.Enabled = false;

            // Сохранение списка процессов, запущенных после основного процесса, в файл
            try
            {
                StringBuilder buffer = new StringBuilder();
                foreach (Process process in Process.GetProcesses())
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

        private void Minimal_Shown(object sender, EventArgs e)
        {
            usbScanTimer.Start();
        }

        private void Minimal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            usbScanTimer.Stop();
        }

        private void usbScanTimer_Tick(object sender, EventArgs e)
        {
            // Обновление списка подключенных съёмных устройств
            externalStorageListView.Items.Clear();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                if (driveInfo.IsReady && driveInfo.DriveType == DriveType.Removable)
                {
                    externalStorageListView.Items.Add(string.Format("{0} ({1})",
                    (string.IsNullOrEmpty(driveInfo.VolumeLabel) ? "Съёмный диск" : driveInfo.VolumeLabel),
                    driveInfo.Name));
                }
            }
        }
    }
}
