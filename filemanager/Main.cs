using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace filemanager
{
    public partial class Main : Form
    {
        private static readonly int DIRECTORY_IMAGE = 0;
        private static readonly int TEXT_IMAGE = 1;
        private static readonly int EXECUTABLE_IMAGE = 2;
        private static readonly int DOCUMENT_IMAGE = 3;
        private static readonly int MUSIC_IMAGE = 4;

        /// <summary>
        /// Отношение расширения файла к номеру изображения в формате ключ-значение
        /// </summary>
        private readonly Dictionary<string, int> extenstionImageIndexMap = new Dictionary<string, int>();

        private readonly MainFunctionalInteraction mainFunctional;

        private readonly Minimal minimalForm;

        public readonly FileManager fileManager;

        /// <summary>
        /// Список путей к элементам, которые сохранены для последующего копирования
        /// </summary>
        private readonly List<string> bufferedPaths = new List<string>();

        /// <summary>
        /// Если true - элементы вырезаны, иначе - скопированы
        /// </summary>
        private bool isCut = false;

        /// <summary>
        /// Если true - взаимодействие происходит с папкой, иначе - с файлом
        /// </summary>
        private bool isDirectoryInteracted = false;

        public Main()
        {
            Process[] processes = Process.GetProcessesByName("MainFunctional");
            foreach (Process process in processes)
            {
                process.Kill();
            }


            // Заполнение отношения расширения файла к номеру изображения
            extenstionImageIndexMap.Add(".TXT", TEXT_IMAGE);
            extenstionImageIndexMap.Add(".EXE", EXECUTABLE_IMAGE);
            extenstionImageIndexMap.Add(".DOC", DOCUMENT_IMAGE);
            extenstionImageIndexMap.Add(".DOCX", DOCUMENT_IMAGE);
            extenstionImageIndexMap.Add(".MP3", MUSIC_IMAGE);
            fileManager = new FileManager();

            InitializeComponent();

            minimalForm = new Minimal(this);

            mainFunctional = new MainFunctionalInteraction();
            try
            {
                string mainFunctionalProcessPath = Path.Combine(fileManager.SYSTEM_PATH, "MainFunctional.exe");
                mainFunctional.startMainFunctionalProcess(mainFunctionalProcessPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage("Не удалось запустить процесс основного функционала");
            }
        }

        /// <summary>
        /// Обновляет интерфейс
        /// </summary>
        public void updateUI()
        {
            pathTextBox.Text = fileManager.getCurrentDirectory();
            updateDirectoryItemList();

            buttonBack.Enabled = fileManager.getCurrentDirectory().Length != 0;
            pasteToolStripMenuItem.Enabled = bufferedPaths.Count != 0;
        }

        /// <summary>
        /// Обновляет отображаемое в интерфейсе содержимое текущей директории
        /// </summary>
        public void updateDirectoryItemList()
        {
            directoryContentListView.Items.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(fileManager.getFullCurrentDirectory());

            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                directoryContentListView.Items.Add(dir.Name, DIRECTORY_IMAGE);
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                string fileExtension = file.Extension.ToUpper();
                int imageIndex = extenstionImageIndexMap.ContainsKey(fileExtension) ? extenstionImageIndexMap[fileExtension] : TEXT_IMAGE;
                directoryContentListView.Items.Add(file.Name, imageIndex);
            }
        }

        /// <summary>
        /// Запускает ресурс процесса, блокируя интерфейс на время запуска
        /// </summary>
        /// <param name="fileName">Имя файла для запуска</param>
        /// <param name="button">Пункт меню, который будет заблокирован</param>
        private void startProcess(string fileName, ToolStripMenuItem menuItem)
        {
            menuItem.Enabled = false;
            startProcess(fileName);
            menuItem.Enabled = true;
        }

        /// <summary>
        /// Запускает ресурс процесса, блокируя интерфейс на время запуска
        /// </summary>
        /// <param name="fileName">Имя файла для запуска</param>
        private void startProcess(string fileName)
        {
            try
            {
                Cursor = directoryContentListView.Cursor = Cursors.WaitCursor;

                Process.Start(fileName);

                Cursor = directoryContentListView.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
            }
        }

        private void openSelectedItem()
        {
            try
            {
                if (directoryContentListView.SelectedItems.Count > 0)
                {
                    string itemPath = Path.Combine(fileManager.getFullCurrentDirectory(), directoryContentListView.SelectedItems[0].Text);
                    if (File.Exists(itemPath))
                    {
                        startProcess(itemPath);
                    }
                    else if (Directory.Exists(itemPath))
                    {
                        fileManager.setCurrentDirectory(itemPath);
                        updateUI();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
                updateUI();
            }
        }

        /// <summary>
        /// Показывает сообщение с ошибкой
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        private void showErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Показывает сообщение с предупреждением
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        private void showWarningMessage(string message)
        {
            MessageBox.Show(this, message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                mainFunctional.connectToMainFunctionalProcess();
                mainFunctional.sendMessage("Show=false\n");
                mainFunctional.sendMessage($"Cores={Environment.ProcessorCount}\n");
                updateTimer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage("Не удалось подключиться к процессу основного функционала");
                Application.Exit();
            }

            updateUI();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Операционная система: Windows\nЯзык программирования: C#\n\nТолеген Дина Галымжанкызы\nГруппа: ИВТ-92",
                "О программе", MessageBoxButtons.OK);
        }

        private void directoryContentListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string currentPath = fileManager.getFullCurrentDirectory();
                if (FileManager.Utils.IsPathInRoot(fileManager.RECYCLE_PATH, currentPath))
                {
                    string itemPath = Path.Combine(fileManager.getFullCurrentDirectory(), directoryContentListView.SelectedItems[0].Text);
                    if (Directory.Exists(itemPath))
                    {
                        fileManager.setCurrentDirectory(itemPath);
                        updateUI();
                    }
                }
                else
                {
                    openSelectedItem();
                }
            }
        }

        private void directoryContentListView_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTestInfo = directoryContentListView.HitTest(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                switch (hitTestInfo.Location)
                {
                    case ListViewHitTestLocations.Label:
                    case ListViewHitTestLocations.Image:
                        {
                            string currentPath = fileManager.getFullCurrentDirectory();
                            if (FileManager.Utils.IsPathInRoot(fileManager.RECYCLE_PATH, currentPath))
                            {
                                recycleContextMenu.Show(MousePosition);
                            }
                            else
                            {
                                itemContextMenu.Show(MousePosition);
                            }
                        }
                        break;

                    case ListViewHitTestLocations.None:
                        mainContextMenu.Show(MousePosition);
                        break;
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            try
            {
                fileManager.setCurrentDirectory(FileManager.Utils.GetParentDirectory(fileManager.getFullCurrentDirectory()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
            }
            finally
            {
                updateUI();
            }
        }

        private void pathTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если в поле пути был нажат Enter, то выполнить переход по данному пути
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    string newPath = Path.Combine(fileManager.ROOT_PATH, pathTextBox.Text);
                    fileManager.setCurrentDirectory(newPath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    showErrorMessage(ex.Message);
                }
                finally
                {
                    updateUI();
                }
            }
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
            => startProcess("taskmgr", taskManagerToolStripMenuItem);

        private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
            => startProcess("control", cmdToolStripMenuItem);

        private void controlToolStripMenuItem_Click(object sender, EventArgs e)
            => startProcess("control", controlToolStripMenuItem);

        private void controlConsoleToolStripMenuItem_Click(object sender, EventArgs e)
            => startProcess("compmgmt.msc", controlConsoleToolStripMenuItem);

        private void resourceWatcherToolStripMenuItem_Click(object sender, EventArgs e)
            => startProcess("resmon", resourceWatcherToolStripMenuItem);

        private void createDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string newDirectoryName = fileManager.createNameWithNumber("Новая папка");
                ListViewItem newListViewItem = new ListViewItem(newDirectoryName, DIRECTORY_IMAGE);
                directoryContentListView.Items.Add(newListViewItem);
                isDirectoryInteracted = true;
                newListViewItem.BeginEdit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
            }
        }

        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string newFileName = fileManager.createNameWithNumber("Новый файл");
                ListViewItem newListViewItem = new ListViewItem(newFileName, TEXT_IMAGE);
                directoryContentListView.Items.Add(newListViewItem);
                isDirectoryInteracted = false;
                newListViewItem.BeginEdit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
            }
        }

        private void directoryContentListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string path = fileManager.getFullCurrentDirectory();
                if (e.Label == null)
                {
                    string newPath = Path.Combine(path, directoryContentListView.Items[e.Item].Text);

                    if (isDirectoryInteracted)
                    {
                        fileManager.createDirectory(newPath);
                    }
                    else
                    {
                        fileManager.createFile(newPath);
                    }
                }
                else
                {
                    string newPath = Path.Combine(path, e.Label);
                    string oldPath = Path.Combine(path, directoryContentListView.Items[e.Item].Text);

                    if (Directory.Exists(oldPath))
                    {
                        fileManager.renameDirectory(oldPath, newPath);
                    }
                    else if (isDirectoryInteracted)
                    {
                        fileManager.createDirectory(newPath);
                    }
                    else if (File.Exists(oldPath))
                    {
                        fileManager.renameFile(oldPath, newPath);
                    }
                    else
                    {
                        fileManager.createFile(newPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
            }
            finally
            {
                e.CancelEdit = true;
                updateUI();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
            => updateUI();

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            openSelectedItem();
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            bufferedPaths.Clear();
            foreach (ListViewItem item in directoryContentListView.SelectedItems)
            {
                bufferedPaths.Add(Path.Combine(fileManager.getFullCurrentDirectory(), item.Text));
            }

            isCut = true;
            pasteToolStripMenuItem.Enabled = bufferedPaths.Count != 0;
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            bufferedPaths.Clear();
            foreach (ListViewItem item in directoryContentListView.SelectedItems)
            {
                bufferedPaths.Add(Path.Combine(fileManager.getFullCurrentDirectory(), item.Text));
            }

            pasteToolStripMenuItem.Enabled = bufferedPaths.Count != 0;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = directoryContentListView.Cursor = Cursors.WaitCursor;

            List<KeyValuePair<string, string>> oldPathNewPathPairList = new List<KeyValuePair<string, string>>();
            string basePath = fileManager.getFullCurrentDirectory();

            foreach (string oldPath in bufferedPaths)
            {
                string newPath = Path.Combine(basePath, oldPath.Remove(0, oldPath.LastIndexOf('\\') + 1));
                oldPathNewPathPairList.Add(new KeyValuePair<string, string>(oldPath, newPath));
            }

            try
            {
                if (isCut)
                {
                    if (!fileManager.cutPaste(oldPathNewPathPairList))
                    {
                        showWarningMessage("Не все файлы были перемещены");
                    }
                    bufferedPaths.Clear();
                }
                else
                {
                    if (!fileManager.copyPaste(oldPathNewPathPairList))
                    {
                        showWarningMessage("Не все файлы были перемещены");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
            }
            finally
            {
                updateUI();
            }

            Cursor = directoryContentListView.Cursor = Cursors.Arrow;
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = directoryContentListView.Cursor = Cursors.WaitCursor;

            try
            {
                List<string> itemPaths = new List<string>();
                foreach (ListViewItem item in directoryContentListView.SelectedItems)
                {
                    string itemPath = Path.Combine(fileManager.getFullCurrentDirectory(), item.Text);
                    itemPaths.Add(itemPath);
                }

                if (itemPaths.Count > 0)
                {
                    fileManager.addItemsToRecycleBin(itemPaths);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
            }
            finally
            {
                Cursor = directoryContentListView.Cursor = Cursors.Arrow;
                updateUI();
            }
        }

        private void renameMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = directoryContentListView.Cursor = Cursors.WaitCursor;

            try
            {
                if (directoryContentListView.SelectedItems.Count > 0)
                {
                    directoryContentListView.SelectedItems[0].BeginEdit();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
            }
            finally
            {
                Cursor = directoryContentListView.Cursor = Cursors.Arrow;
            }
        }

        private void recycleRestoreMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = directoryContentListView.Cursor = Cursors.WaitCursor;

            try
            {
                if (directoryContentListView.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in directoryContentListView.SelectedItems)
                    {
                        string itemPath = Path.Combine(fileManager.getFullCurrentDirectory(), item.Text);
                        if (FileManager.Utils.IsItemExists(itemPath))
                        {
                            fileManager.restoreItemFromRecycleBin(itemPath);
                        }
                    }
                    updateUI();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
                updateUI();
            }
            finally
            {
                Cursor = directoryContentListView.Cursor = Cursors.Arrow;
            }
        }

        private void recycleDeleteMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = directoryContentListView.Cursor = Cursors.WaitCursor;

            try
            {
                if (directoryContentListView.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in directoryContentListView.SelectedItems)
                    {
                        string itemPath = Path.Combine(fileManager.getFullCurrentDirectory(), item.Text);
                        if (Directory.Exists(itemPath))
                        {
                            fileManager.deleteDirectory(itemPath);
                        }
                        else if (File.Exists(itemPath))
                        {
                            fileManager.deleteFile(itemPath);
                        }
                    }
                    updateUI();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showErrorMessage(ex.Message);
                updateUI();
            }
            finally
            {
                Cursor = directoryContentListView.Cursor = Cursors.Arrow;
            }
        }

        private void minimalFunctionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimalForm.Show();
            minimalForm.Focus();
        }

        private void mainFunctionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFunctional.sendMessage("Show=true\n");
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("ProcessorTime");
                sb.Append("=");
                sb.Append(mainFunctional.currentProcess.TotalProcessorTime.TotalMilliseconds);
                sb.Append("\n");

                sb.Append("WorkingSet");
                sb.Append("=");
                sb.Append(mainFunctional.currentProcess.WorkingSet64);
                sb.Append("\n");

                foreach (PerformanceCounter pc in mainFunctional.performanceCounterList)
                {
                    float value = pc.NextValue();
                    sb.Append(pc.InstanceName);
                    sb.Append("=");
                    sb.Append(value);
                    sb.Append("\n");
                }

                mainFunctional.sendMessage(sb.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateTimer.Stop();

            if (!mainFunctional.mainFunctionalProcess.HasExited)
            {
                mainFunctional.mainFunctionalProcess.Kill();
            }
        }
    }

    public class FileManager
    {
        /// <summary>
        /// Путь к системной папке
        /// </summary>
        public readonly string SYSTEM_PATH;

        /// <summary>
        /// Путь к корневой папке
        /// </summary>
        public readonly string ROOT_PATH;

        public readonly string RECYCLE_PATH;

        public readonly List<string> fullProtectedPaths = new List<string>();
        public readonly List<string> protectedPaths = new List<string>();

        public readonly RecycleBin recycleBin;

        public FileManager()
        {
            SYSTEM_PATH = GetApplicationDirectory();
            ROOT_PATH = Utils.GetParentDirectory(SYSTEM_PATH);
            RECYCLE_PATH = Path.Combine(ROOT_PATH, "Корзина");
            if (!Directory.Exists(RECYCLE_PATH))
            {
                Directory.CreateDirectory(RECYCLE_PATH);
            }

            List<string> deletedItems = new List<string>();

            DirectoryInfo recycleBinInfo = new DirectoryInfo(RECYCLE_PATH);
            foreach (DirectoryInfo dirInfo in recycleBinInfo.GetDirectories())
            {
                deletedItems.Add(dirInfo.Name);
            }

            foreach (FileInfo fileInfo in recycleBinInfo.GetFiles())
            {
                deletedItems.Add(fileInfo.Name);
            }

            recycleBin = new RecycleBin(deletedItems);

            fullProtectedPaths.Add(SYSTEM_PATH);
            protectedPaths.Add(RECYCLE_PATH);

            Directory.SetCurrentDirectory(ROOT_PATH);
        }

        public void addItemsToRecycleBin(List<string> itemPaths)
        {
            foreach (string itemPath in itemPaths)
            {
                addItemToRecycleBin(itemPath);
            }
        }

        public void addItemToRecycleBin(string itemPath)
        {
            throwIfProtected(itemPath);

            string relativePath = Utils.GetRelativePath(ROOT_PATH, itemPath);
            string newPath = Path.Combine(RECYCLE_PATH, relativePath);

            // Если по пути не хватает папок, то создать их
            string directoryPath = RECYCLE_PATH;
            foreach (string dir in relativePath.Split('\\'))
            {
                directoryPath = Path.Combine(directoryPath, dir);
                if (!Directory.Exists(directoryPath))
                {
                    if (File.Exists(directoryPath))
                    {
                        File.Delete(directoryPath);
                    }

                    Directory.CreateDirectory(directoryPath);
                }
            }

            List<KeyValuePair<string, string>> oldPathNewPaths = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(itemPath, newPath)
            };
            cutPaste(oldPathNewPaths);
        }

        public void restoreItemFromRecycleBin(string itemPath)
        {
            string relativePath = Utils.GetRelativePath(RECYCLE_PATH, itemPath);
            string newPath = Path.Combine(ROOT_PATH, relativePath);

            List<KeyValuePair<string, string>> oldPathNewPaths = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(itemPath, newPath)
            };
            cutPaste(oldPathNewPaths);
        }

        /// <summary>
        /// Устанавливает рабочую директорию относительно корня
        /// </summary>
        /// <param name="path">Путь к новой рабочей директории относительно корня</param>
        /// <returns>Строка, содержащая путь к текущей директории относительно корня</returns>
        public string setCurrentDirectory(string path)
        {
            string newPath = Utils.FormatPath(path);

            if (!newPath.Contains(ROOT_PATH))
            {
                throw new ArgumentException($"Путь \"{Utils.GetRelativePath(ROOT_PATH, path)}\" не разрешён");
            }

            if (!Directory.Exists(newPath))
            {
                throw new ArgumentException($"Папка по пути \"{Utils.GetRelativePath(ROOT_PATH, path)}\" не найдена");
            }

            Directory.SetCurrentDirectory(newPath);

            return getCurrentDirectory();
        }

        /// <summary>
        /// Получает рабочую директорию относительно корня
        /// </summary>
        /// <returns>Строка, содержащая путь к текущей директории относительно корня</returns>
        public string getCurrentDirectory()
            => Utils.GetRelativePath(ROOT_PATH, Directory.GetCurrentDirectory());

        /// <summary>
        /// Получает рабочую директорию
        /// </summary>
        /// <returns>Строка, содержащая путь к текущей директории</returns>
        public string getFullCurrentDirectory()
            => Directory.GetCurrentDirectory();

        /// <summary>
        /// Получает путь к системной папке
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationDirectory()
            => Application.StartupPath;

        public void createDirectory(string path)
        {
            string directoryPath = Utils.FormatPath(path);

            throwIfProtected(directoryPath);

            if (Utils.IsItemExists(directoryPath))
            {
                throw new ArgumentException($"По пути \"{Utils.GetRelativePath(ROOT_PATH, directoryPath)}\" уже существует папка или файл");
            }

            Directory.CreateDirectory(directoryPath);
        }

        public void createFile(string path)
        {
            string filePath = Utils.FormatPath(path);

            throwIfProtected(filePath);

            if (Utils.IsItemExists(filePath))
            {
                throw new ArgumentException($"По пути \"{Utils.GetRelativePath(ROOT_PATH, filePath)}\" уже существует папка или файл");
            }

            File.Create(filePath).Close();
        }

        public void renameDirectory(string oldPath, string newPath)
        {
            string oldDirectoryPath = Utils.FormatPath(oldPath);
            string newDirectoryPath = Utils.FormatPath(newPath);

            throwIfProtected(oldDirectoryPath);
            throwIfProtected(newDirectoryPath);

            moveDirectory(oldDirectoryPath, newDirectoryPath);
        }

        public void renameFile(string oldPath, string newPath)
        {
            string oldFilePath = Utils.FormatPath(oldPath);
            string newFilePath = Utils.FormatPath(newPath);

            throwIfProtected(oldFilePath);
            throwIfProtected(newFilePath);

            moveFile(oldFilePath, newFilePath);
        }

        public void moveDirectory(string oldPath, string newPath)
        {
            string oldDirectoryPath = Utils.FormatPath(oldPath);
            string newDirectoryPath = Utils.FormatPath(newPath);

            throwIfProtected(oldDirectoryPath);
            throwIfProtected(newDirectoryPath);

            if (!Directory.Exists(oldDirectoryPath))
            {
                throw new ArgumentException($"Папка по пути \"{Utils.GetRelativePath(ROOT_PATH, oldDirectoryPath)}\" не найдена");
            }

            if (Utils.IsItemExists(newDirectoryPath))
            {
                throw new ArgumentException($"По пути \"{Utils.GetRelativePath(ROOT_PATH, newDirectoryPath)}\" уже существует папка или файл");
            }

            Directory.Move(oldDirectoryPath, newDirectoryPath);
        }

        public void moveFile(string oldPath, string newPath)
        {
            string oldFilePath = Utils.FormatPath(oldPath);
            string newFilePath = Utils.FormatPath(newPath);

            throwIfProtected(oldFilePath);
            throwIfProtected(newFilePath);

            if (!File.Exists(oldFilePath))
            {
                throw new ArgumentException($"Файл по пути \"{Utils.GetRelativePath(ROOT_PATH, oldFilePath)}\" не найден");
            }

            if (Utils.IsItemExists(newFilePath))
            {
                throw new ArgumentException($"По пути \"{Utils.GetRelativePath(ROOT_PATH, newFilePath)}\" уже существует папка или файл");
            }

            File.Move(oldFilePath, newFilePath);
        }

        public bool copyPaste(List<KeyValuePair<string, string>> oldPathNewPathPairList)
        {
            bool isOk = true;

            foreach (KeyValuePair<string, string> oldPathNewPathPair in oldPathNewPathPairList)
            {
                throwIfProtected(oldPathNewPathPair.Key);
                throwIfProtected(oldPathNewPathPair.Value);

                try
                {
                    if (Directory.Exists(oldPathNewPathPair.Key))
                    {
                        if (File.Exists(oldPathNewPathPair.Value))
                        {
                            throw new ArgumentException($"По пути \"{Utils.GetRelativePath(ROOT_PATH, oldPathNewPathPair.Value)}\" уже существует файл");
                        }

                        if (!copyPasteDirectory(oldPathNewPathPair.Key, oldPathNewPathPair.Value))
                        {
                            isOk = false;
                        }
                    }
                    else if (File.Exists(oldPathNewPathPair.Key))
                    {
                        if (Directory.Exists(oldPathNewPathPair.Value))
                        {
                            throw new ArgumentException($"По пути \"{Utils.GetRelativePath(ROOT_PATH, oldPathNewPathPair.Value)}\" уже существует папка");
                        }

                        copyPasteFile(oldPathNewPathPair.Key, oldPathNewPathPair.Value);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    isOk = false;
                }
            }

            return isOk;
        }

        private bool copyPasteDirectory(string oldPath, string newPath)
        {
            Directory.CreateDirectory(newPath);

            List<KeyValuePair<string, string>> oldPathNewPathPairList = new List<KeyValuePair<string, string>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(oldPath);
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                string fileOldPath = Path.Combine(oldPath, fileInfo.Name);
                string fileNewPath = Path.Combine(newPath, fileInfo.Name);

                oldPathNewPathPairList.Add(new KeyValuePair<string, string>(fileOldPath, fileNewPath));
            }

            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
            {
                string dirOldPath = Path.Combine(oldPath, dirInfo.Name);
                string dirNewPath = Path.Combine(newPath, dirInfo.Name);

                oldPathNewPathPairList.Add(new KeyValuePair<string, string>(dirOldPath, dirNewPath));
            }

            return copyPaste(oldPathNewPathPairList);
        }

        private void copyPasteFile(string oldPath, string newPath)
        {
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            File.Copy(oldPath, newPath);
        }

        public bool cutPaste(List<KeyValuePair<string, string>> oldPathNewPathPairList)
        {
            bool isOk = true;

            foreach (KeyValuePair<string, string> oldPathNewPathPair in oldPathNewPathPairList)
            {
                if (oldPathNewPathPair.Key.Equals(oldPathNewPathPair.Value))
                {
                    continue;
                }

                if (Utils.IsPathInRoot(oldPathNewPathPair.Key, oldPathNewPathPair.Value))
                {
                    throw new ArgumentException(string.Format(
                        "Конечная папка \"{1}\", куда следует поместить файлы, " +
                        "является дочерней для папки \"{0}\", в которой они находятся.",
                        Utils.GetRelativePath(ROOT_PATH, oldPathNewPathPair.Key), Utils.GetRelativePath(ROOT_PATH, oldPathNewPathPair.Value))
                    );
                }

                throwIfProtected(oldPathNewPathPair.Key);
                throwIfProtected(oldPathNewPathPair.Value);

                try
                {
                    if (Directory.Exists(oldPathNewPathPair.Key))
                    {
                        if (File.Exists(oldPathNewPathPair.Value))
                        {
                            throw new ArgumentException($"По пути \"{Utils.GetRelativePath(ROOT_PATH, oldPathNewPathPair.Value)}\" уже существует файл");
                        }

                        cutPasteDirectory(oldPathNewPathPair.Key, oldPathNewPathPair.Value);
                    }
                    else if (File.Exists(oldPathNewPathPair.Key))
                    {
                        if (Directory.Exists(oldPathNewPathPair.Value))
                        {
                            throw new ArgumentException($"По пути \"{Utils.GetRelativePath(ROOT_PATH, oldPathNewPathPair.Value)}\" уже существует папка");
                        }

                        cutPasteFile(oldPathNewPathPair.Key, oldPathNewPathPair.Value);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    isOk = false;
                }
            }

            return isOk;
        }

        private void cutPasteDirectory(string oldPath, string newPath)
        {
            if (Directory.Exists(newPath))
            {
                Directory.Delete(newPath, true);
            }

            Directory.Move(oldPath, newPath);
        }

        private void cutPasteFile(string oldPath, string newPath)
        {
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            File.Move(oldPath, newPath);
        }

        public void deleteDirectory(string path)
        {
            string directoryPath = Utils.FormatPath(path);

            throwIfProtected(directoryPath);

            Directory.Delete(directoryPath, true);
        }

        public void deleteFile(string path)
        {
            string filePath = Utils.FormatPath(path);

            throwIfProtected(filePath);

            File.Delete(filePath);
        }

        public string createNameWithNumber(string fullPath)
        {
            string result;

            result = fullPath;
            if (!Utils.IsItemExists(result))
            {
                return fullPath;
            }

            int i = 1;
            do
            {
                result = $"{fullPath} ({i})";

                if (!Utils.IsItemExists(result))
                {
                    return result;
                }
            } while (i++ < int.MaxValue);

            throw new Exception("Невозможно получить свободное название");
        }

        public void throwIfProtected(string path)
        {
            foreach (string protectedPath in fullProtectedPaths)
            {
                if (Utils.IsPathInRoot(protectedPath, path))
                {
                    throw new ArgumentException($"Папка \"{protectedPath}\" и её содержимое защищены от изменений");
                }
            }

            foreach (string protectedPath in protectedPaths)
            {
                if (path.Equals(protectedPath))
                {
                    throw new ArgumentException($"Папка \"{protectedPath}\" защищена от изменений");
                }
            }
        }

        public static class Utils
        {
            /// <summary>
            /// Регулярное выражение для удаления дублирующих символов
            /// </summary>
            private static readonly Regex regex = new Regex("[ ]{2,}", RegexOptions.None);

            /// <summary>
            /// Проверяет существование файла или папки по переданному пути
            /// </summary>
            /// <param name="path">Строка, содержащая путь</param>
            /// <returns>true, если fullPath ссылается на существующий элемент</returns>
            public static bool IsItemExists(string path)
                => Directory.Exists(path) || File.Exists(path);

            /// <summary>
            /// Проверяет путь на отношение к корневому пути
            /// </summary>
            /// <param name="root">Строка, содержащая корневой путь</param>
            /// <param name="path">Строка, содержащая путь по отношению к заданному корневому пути</param>
            /// <returns></returns>
            public static bool IsPathInRoot(string root, string path)
                => path.Contains(root);

            /// <summary>
            /// Преобразует строку в относительный путь
            /// </summary>
            /// <param name="root">Строка, содержащая корневой путь</param>
            /// <param name="path">Строка, содержащая путь по отношению к заданному корневому пути</param>
            /// <returns>Строка, содержащая относительный путь</returns>
            public static string GetRelativePath(string root, string path)
            {
                string result;
                if (IsPathInRoot(root, path))
                {
                    result = path.Substring(root.Length);
                }
                else
                {
                    result = path;
                }

                return FormatPath(result);
            }

            /// <summary>
            /// Получает путь к родительской папке
            /// </summary>
            /// <param name="path"></param>
            /// <returns>Строка, содержащая путь к родительской папке</returns>
            public static string GetParentDirectory(string path)
            {
                string result = FormatPath(path);

                if (result.Contains("\\"))
                {

                    int index = result.LastIndexOf('\\');
                    if (index == result.Length)
                    {
                        result = result.Remove(index);
                        index = result.LastIndexOf('\\');
                    }

                    if (index != -1)
                    {
                        result = result.Remove(index);
                    }
                }
                else
                {
                    result = string.Empty;
                }

                result = Utils.FormatPath(result);

                return result;
            }

            /// <summary>
            /// Форматирует путь
            /// </summary>
            /// <param name="path">Строка, содержащая путь</param>
            /// <returns>Строка, содержащая отформатированный путь</returns>
            public static string FormatPath(string path)
            {
                string result = path;

                // Удаление начальных и конечных пробелов
                result = result.Trim(' ');

                // Удаление начальных и конечных разделителей пути
                result = result.Replace('/', '\\');
                result = result.Trim('\\');

                // Удаление дублирующих пробелов
                result = regex.Replace(result, " ");

                // Выполнение переходов к родительской папке
                if (result.Length != 0)
                {
                    List<string> tokens = new List<string>(result.Split('\\'));

                    if (tokens[0].Contains(":"))
                    {
                        if (tokens.Count > 1)
                        {
                            tokens[0] = string.Format("{0}\\{1}", tokens[0], tokens[1]);

                            tokens.RemoveAt(1);
                        }
                    }

                    for (int i = 0; i < tokens.Count; i++)
                    {
                        if (tokens[i].Equals(".."))
                        {
                            tokens.RemoveAt(i);
                            if (i != 0)
                            {
                                tokens.RemoveAt(i - 1);
                            }
                            i--;
                        }
                    }

                    result = Path.Combine(tokens.ToArray());
                }

                // Удаление лишней точки в конце пути
                if (result.Length != 0)
                {
                    if (result[result.Length - 1] == '.')
                    {
                        result.Remove(result.Length - 1);
                    }
                }

                return result;
            }
        }
    }

    public class RecycleBin
    {
        private readonly List<string> deletedItems;

        public RecycleBin() : this(new List<string>())
        {

        }

        public RecycleBin(List<string> deletedItems)
        {
            this.deletedItems = deletedItems;
        }

        public void add(string itemPath)
        {
            deletedItems.Add(itemPath);
        }

        public string get(string itemPath)
        {
            foreach (string item in deletedItems)
            {
                if (item.Equals(itemPath))
                {
                    string result = item;

                    deletedItems.Remove(item);

                    return result;
                }
            }

            throw new ArgumentException($"Недопустимое значение {itemPath}");
        }
    }

    public class MainFunctionalInteraction
    {
        public readonly Process currentProcess = Process.GetCurrentProcess();
        public readonly List<PerformanceCounter> performanceCounterList = new List<PerformanceCounter>();

        public readonly Process mainFunctionalProcess = new Process();

        private readonly IPEndPoint ipPoint;
        private readonly Socket socket;

        public MainFunctionalInteraction()
        {
            ipPoint = new IPEndPoint(Dns.GetHostAddresses("localhost")[0], 8000);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            PerformanceCounterCategory pfc = new PerformanceCounterCategory("Processor");
            foreach (string instanceName in pfc.GetInstanceNames())
            {
                if (!instanceName.Equals("_Total"))
                {
                    PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time")
                    {
                        InstanceName = instanceName
                    };
                    performanceCounterList.Add(cpuUsage);
                    cpuUsage.NextValue();
                }
            }
            performanceCounterList.Sort((pc1, pc2) => pc1.InstanceName.CompareTo(pc2.InstanceName));
        }

        public void startMainFunctionalProcess(string processPath)
        {
            mainFunctionalProcess.StartInfo.FileName = processPath;
            mainFunctionalProcess.Start();
        }

        public void connectToMainFunctionalProcess()
        {
            socket.Connect(ipPoint);
        }

        public void sendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
