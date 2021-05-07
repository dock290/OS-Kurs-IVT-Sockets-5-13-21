namespace filemanager
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonBack = new System.Windows.Forms.Button();
            this.directoryContentListView = new System.Windows.Forms.ListView();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.mainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceWatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recycleContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recycleRestoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recycleDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContextMenu.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.itemContextMenu.SuspendLayout();
            this.recycleContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(11, 26);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(45, 20);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "«";
            this.buttonBack.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // directoryContentListView
            // 
            this.directoryContentListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryContentListView.BackColor = System.Drawing.SystemColors.Window;
            this.directoryContentListView.HideSelection = false;
            this.directoryContentListView.LabelEdit = true;
            this.directoryContentListView.LargeImageList = this.iconList;
            this.directoryContentListView.Location = new System.Drawing.Point(11, 49);
            this.directoryContentListView.Margin = new System.Windows.Forms.Padding(2);
            this.directoryContentListView.Name = "directoryContentListView";
            this.directoryContentListView.Size = new System.Drawing.Size(578, 306);
            this.directoryContentListView.SmallImageList = this.iconList;
            this.directoryContentListView.TabIndex = 3;
            this.directoryContentListView.UseCompatibleStateImageBehavior = false;
            this.directoryContentListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.directoryContentListView_AfterLabelEdit);
            this.directoryContentListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.directoryContentListView_MouseDoubleClick);
            this.directoryContentListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.directoryContentListView_MouseDown);
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "macos_big_sur_folder_icon_186046.ico");
            this.iconList.Images.SetKeyName(1, "txt.png");
            this.iconList.Images.SetKeyName(2, "exe.png");
            this.iconList.Images.SetKeyName(3, "doc.png");
            this.iconList.Images.SetKeyName(4, "mp3.png");
            // 
            // mainContextMenu
            // 
            this.mainContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.mainContextMenu.Name = "contextMenuStrip2";
            this.mainContextMenu.ShowImageMargin = false;
            this.mainContextMenu.Size = new System.Drawing.Size(104, 70);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirectoryToolStripMenuItem,
            this.createFileToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.createToolStripMenuItem.Text = "Создать";
            // 
            // createDirectoryToolStripMenuItem
            // 
            this.createDirectoryToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.createDirectoryToolStripMenuItem.Name = "createDirectoryToolStripMenuItem";
            this.createDirectoryToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createDirectoryToolStripMenuItem.Text = "Папку";
            this.createDirectoryToolStripMenuItem.Click += new System.EventHandler(this.createDirectoryToolStripMenuItem_Click);
            // 
            // createFileToolStripMenuItem
            // 
            this.createFileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.createFileToolStripMenuItem.Name = "createFileToolStripMenuItem";
            this.createFileToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createFileToolStripMenuItem.Text = "Файл";
            this.createFileToolStripMenuItem.Click += new System.EventHandler(this.createFileToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pasteToolStripMenuItem.Text = "Вставить";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.updateToolStripMenuItem.Text = "Обновить";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Location = new System.Drawing.Point(60, 26);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(529, 20);
            this.pathTextBox.TabIndex = 5;
            this.pathTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pathTextBox_KeyPress);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem,
            this.utilsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(600, 24);
            this.mainMenuStrip.TabIndex = 7;
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutProgramToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aboutProgramToolStripMenuItem.Text = "О программе";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // utilsToolStripMenuItem
            // 
            this.utilsToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.utilsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.utilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskManagerToolStripMenuItem,
            this.cmdToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.controlConsoleToolStripMenuItem,
            this.resourceWatcherToolStripMenuItem});
            this.utilsToolStripMenuItem.Name = "utilsToolStripMenuItem";
            this.utilsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.utilsToolStripMenuItem.Text = "Инструменты";
            // 
            // taskManagerToolStripMenuItem
            // 
            this.taskManagerToolStripMenuItem.Name = "taskManagerToolStripMenuItem";
            this.taskManagerToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.taskManagerToolStripMenuItem.Text = "Диспетчер задач";
            this.taskManagerToolStripMenuItem.Click += new System.EventHandler(this.taskManagerToolStripMenuItem_Click);
            // 
            // cmdToolStripMenuItem
            // 
            this.cmdToolStripMenuItem.Name = "cmdToolStripMenuItem";
            this.cmdToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.cmdToolStripMenuItem.Text = "Командная строка";
            this.cmdToolStripMenuItem.Click += new System.EventHandler(this.cmdToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.controlToolStripMenuItem.Text = "Панель управления";
            this.controlToolStripMenuItem.Click += new System.EventHandler(this.controlToolStripMenuItem_Click);
            // 
            // controlConsoleToolStripMenuItem
            // 
            this.controlConsoleToolStripMenuItem.Name = "controlConsoleToolStripMenuItem";
            this.controlConsoleToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.controlConsoleToolStripMenuItem.Text = "Управление компьютером";
            this.controlConsoleToolStripMenuItem.Click += new System.EventHandler(this.controlConsoleToolStripMenuItem_Click);
            // 
            // resourceWatcherToolStripMenuItem
            // 
            this.resourceWatcherToolStripMenuItem.Name = "resourceWatcherToolStripMenuItem";
            this.resourceWatcherToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.resourceWatcherToolStripMenuItem.Text = "Монитор ресурсов";
            this.resourceWatcherToolStripMenuItem.Click += new System.EventHandler(this.resourceWatcherToolStripMenuItem_Click);
            // 
            // itemContextMenu
            // 
            this.itemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.cutMenuItem,
            this.copyMenuItem,
            this.deleteMenuItem,
            this.renameMenuItem});
            this.itemContextMenu.Name = "itemContextMenu";
            this.itemContextMenu.ShowImageMargin = false;
            this.itemContextMenu.Size = new System.Drawing.Size(137, 114);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openMenuItem.Text = "Открыть";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.Size = new System.Drawing.Size(136, 22);
            this.cutMenuItem.Text = "Вырезать";
            this.cutMenuItem.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.Size = new System.Drawing.Size(136, 22);
            this.copyMenuItem.Text = "Копировать";
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deleteMenuItem.Text = "Удалить";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // renameMenuItem
            // 
            this.renameMenuItem.Name = "renameMenuItem";
            this.renameMenuItem.Size = new System.Drawing.Size(136, 22);
            this.renameMenuItem.Text = "Переименовать";
            this.renameMenuItem.Click += new System.EventHandler(this.renameMenuItem_Click);
            // 
            // recycleContextMenu
            // 
            this.recycleContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recycleRestoreMenuItem,
            this.recycleDeleteMenuItem});
            this.recycleContextMenu.Name = "itemContextMenu";
            this.recycleContextMenu.ShowImageMargin = false;
            this.recycleContextMenu.Size = new System.Drawing.Size(171, 48);
            // 
            // recycleRestoreMenuItem
            // 
            this.recycleRestoreMenuItem.Name = "recycleRestoreMenuItem";
            this.recycleRestoreMenuItem.Size = new System.Drawing.Size(170, 22);
            this.recycleRestoreMenuItem.Text = "Восстановить";
            this.recycleRestoreMenuItem.Click += new System.EventHandler(this.recycleRestoreMenuItem_Click);
            // 
            // recycleDeleteMenuItem
            // 
            this.recycleDeleteMenuItem.Name = "recycleDeleteMenuItem";
            this.recycleDeleteMenuItem.Size = new System.Drawing.Size(170, 22);
            this.recycleDeleteMenuItem.Text = "Удалить безвозвратно";
            this.recycleDeleteMenuItem.Click += new System.EventHandler(this.recycleDeleteMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.directoryContentListView);
            this.Controls.Add(this.buttonBack);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(616, 405);
            this.Name = "Main";
            this.Text = "Файловый менеджер";
            this.Load += new System.EventHandler(this.Main_Load);
            this.mainContextMenu.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.itemContextMenu.ResumeLayout(false);
            this.recycleContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ListView directoryContentListView;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.ContextMenuStrip mainContextMenu;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip itemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourceWatcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlConsoleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip recycleContextMenu;
        private System.Windows.Forms.ToolStripMenuItem recycleRestoreMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recycleDeleteMenuItem;
    }
}

