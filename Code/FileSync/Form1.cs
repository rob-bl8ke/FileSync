using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using CygX1.UI.WinForms.RecentFileMenu;

namespace FileSync
{
    public partial class Form1 : Form
    {
        private RecentProjectMenu recentProjectMenu;
        private RegistrySettings registrySettings;
        private SyncProject syncProject = new SyncProject();

        public Form1()
        {
            InitializeComponent();
            this.listView1.DragDrop += listView1_DragDrop;
            this.listView1.DragEnter += listView1_DragEnter;
            this.itemSyncBox1.TargetFileChanged += new EventHandler(itemSyncBox1_TargetFileChanged);
            this.itemSyncBox1.WorkingFileChanged += new EventHandler(itemSyncBox1_WorkingFileChanged);
            this.itemSyncBox1.BeforeTargetFileChanged += new EventHandler<BeforeFileSelectedEventArgs>(itemSyncBox1_BeforeTargetFileChanged);
            this.itemSyncBox1.BeforeWorkingFileChanged += new EventHandler<BeforeFileSelectedEventArgs>(itemSyncBox1_BeforeWorkingFileChanged);
            this.syncProject.FileCopied += syncProject_FileCopied;
            this.Text = WindowCaption();
            InitializeIconImages();
            this.registrySettings = new RegistrySettings(ConfigSettings.RegistryPath);
            InitializeRecentProjectMenu();
            if (!LoadLastProject())
            {
                this.Text = WindowCaption();
                EnableControls();
            }

            EnableControls();

            bool backupRight = ConfigSettings.BackupBeforeRight;
            bool backupLeft = ConfigSettings.BackupBeforeLeft;
        }

        private bool LoadLastProject()
        {
            try
            {
                string lastProject = ConfigSettings.LastProject;
                if (!string.IsNullOrEmpty(lastProject))
                {
                    syncProject.Load(lastProject);
                    ListviewHelper.ReloadListview(listView1, imageList, syncProject.SyncItems);
                    recentProjectMenu.Notify(lastProject);
                    recentProjectMenu.CurrentlyOpenedFile = lastProject;
                    this.Text = WindowCaption();
                    EnableControls();
                    return true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void InitializeRecentProjectMenu()
        {
            RecentFiles recentFiles = new RecentFiles();
            recentFiles.MaxNoOfFiles = 15;
            recentFiles.RegistryPath = ConfigSettings.RegistryPath;
            recentFiles.RegistrySubFolder = RegistrySettings.RecentFilesFolder;
            recentFiles.MaxDisplayNameLength = 80;

            recentProjectMenu = new RecentProjectMenu(mnuOpenRecent, recentFiles);
            recentProjectMenu.RecentProjectOpened += recentProjectMenu_RecentProjectOpened;
        }

        private void recentProjectMenu_RecentProjectOpened(object sender, RecentProjectEventArgs e)
        {
            if (File.Exists(e.RecentFile.FullPath))
            {
                syncProject.Load(e.RecentFile.FullPath);
                ListviewHelper.ReloadListview(listView1, imageList, syncProject.SyncItems);
                recentProjectMenu.Notify(e.RecentFile.FullPath);
                recentProjectMenu.CurrentlyOpenedFile = e.RecentFile.FullPath;
                ConfigSettings.LastProject = e.RecentFile.FullPath;
                this.Text = WindowCaption();
                EnableControls();
            }
            else
            {

                DialogResult result = Dialogs.MissingRecentFileError(this);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    recentProjectMenu.Remove(e.RecentFile.FullPath);
                }
            }
        }

        private void InitializeIconImages()
        {
            Resources.Namespace = "FileSync.UiResource";
            Resources.ExecutingAssembly = Assembly.GetExecutingAssembly();

            btnOpen.Image = Resources.GetImage(Constants.ImageKeys.Open);
            btnCreate.Image = Resources.GetImage(Constants.ImageKeys.Create);
            btnCheck.Image = Resources.GetImage(Constants.ImageKeys.CheckItems);
            btnUncheck.Image = Resources.GetImage(Constants.ImageKeys.UncheckItems);
            btnSave.Image = Resources.GetImage(Constants.ImageKeys.Save);
            mnuCheck.Image = Resources.GetImage(Constants.ImageKeys.CheckItems);
            mnuUncheck.Image = Resources.GetImage(Constants.ImageKeys.UncheckItems);
            mnuContextCheck.Image = Resources.GetImage(Constants.ImageKeys.CheckItems);
            mnuContextUncheck.Image = Resources.GetImage(Constants.ImageKeys.UncheckItems);
            mnuSave.Image = Resources.GetImage(Constants.ImageKeys.Save);
            mnuAddItem.Image = Resources.GetImage(Constants.ImageKeys.AddItem);
            mnuCreate.Image = Resources.GetImage(Constants.ImageKeys.Create);
            mnuOpen.Image = Resources.GetImage(Constants.ImageKeys.Open);
            mnuDeleteItem.Image = Resources.GetImage(Constants.ImageKeys.DeleteItem);
            mnuContextDelete.Image = Resources.GetImage(Constants.ImageKeys.DeleteItem);
            mnuGetDifferences.Image = Resources.GetImage(Constants.ImageKeys.GetDifferences);
            mnuContextGetDifferences.Image = Resources.GetImage(Constants.ImageKeys.GetDifferences);
            
            btnCopyLeft.Image = Resources.GetImage(Constants.ImageKeys.CopyLeft);
            btnCopyRight.Image = Resources.GetImage(Constants.ImageKeys.CopyRight);

            mnuCopyLeft.Image = Resources.GetImage(Constants.ImageKeys.CopyLeft);
            mnuCopyRight.Image = Resources.GetImage(Constants.ImageKeys.CopyRight);
        }


        private void DeleteItem()
        {
            if (syncProject.SingleSelection)
            {
                DialogResult result = Dialogs.DeleteSyncItemPrompt(this);
                if (result == System.Windows.Forms.DialogResult.No)
                    return;

                itemSyncBox1.CurrentSyncItem = null;
                syncProject.RemoveSyncItem((listView1.SelectedItems[0].Tag as SyncItem));

                listView1.SelectedItems[0].Remove();

            }
            EnableControls();
        }

        private void CopyRight()
        {
            DialogResult repoResult = Dialogs.UpdateRepositoryPrompt(this);
            if (repoResult == System.Windows.Forms.DialogResult.No)
                return;

            if (syncProject.TargetFilesMissing(SyncProject.MissingFileCheckEnum.CheckedOnly))
            {
                string targetFileTitle = syncProject.GetMissingTargetFileItems()[0].TargetTitle;
                Dialogs.NoExistingTargetFilePrompt(this, targetFileTitle);
                return;
            }

            if (syncProject.MissingWorkingFileData())
            {
                Dialogs.MissingWorkingFilePathsPrompt(this);
                return;
            }

            DialogResult result = Dialogs.BeforeCopyTargetFilesPrompt(this);
            if (result == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                Console.StartCopyingTargetFiles(richTextBox1);
                syncProject.CopyCheckedTargetFilesToWorkings();
                Console.EndCopying(richTextBox1);
            }
            catch (Exception ex)
            {
                Dialogs.FileCopyError(this);
                Console.CopyErrorOccurred(richTextBox1);
            }

        }

        private void AddItem()
        {
            listView1.SelectedItems.Clear();

            SyncItem newItem = syncProject.AddSyncItem(string.Empty, string.Empty);
            ListviewHelper.CreateListviewItem(listView1, imageList, newItem, true);
            this.itemSyncBox1.CurrentSyncItem = newItem;
            EnableControls();
        }

        private void CopyLeft()
        {
            if (syncProject.WorkingFilesMissing(SyncProject.MissingFileCheckEnum.CheckedOnly))
            {
                Dialogs.NoExistingWorkingFilePrompt(this);
                return;
            }

            if (syncProject.TargetFilesMissing(SyncProject.MissingFileCheckEnum.CheckedOnly))
            {
                string targetFileTitle = syncProject.GetMissingTargetFileItems()[0].TargetTitle;
                Dialogs.NoExistingTargetFilePrompt(this, targetFileTitle);
                return;
            }

            DialogResult result = Dialogs.BeforeCopyWorkingFilesPrompt(this);
            if (result == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                Console.StartCopyingWorkingFiles(richTextBox1);
                syncProject.CopyCheckedWorkingFilesToTargets();
                Console.EndCopying(richTextBox1);
            }
            catch (Exception ex)
            {
                Dialogs.FileCopyError(this);
                Console.CopyErrorOccurred(richTextBox1);
            }
        }

        private void EnableControls()
        {
            this.listView1.AllowDrop = syncProject.ProjectLoaded;

            bool projectLoaded = syncProject.ProjectLoaded;
            bool singleSelection = syncProject.SingleSelection;
            bool itemsLoaded = listView1.Items.Count > 0;
            bool itemsChecked = syncProject.ItemsChecked;
            bool itemsSelected = syncProject.ItemsSelected;

            btnCopyRight.Enabled = itemsLoaded && itemsChecked;
            btnCopyLeft.Enabled = itemsLoaded && itemsChecked;
            mnuCopyRight.Enabled = itemsLoaded && itemsChecked;
            mnuCopyLeft.Enabled = itemsLoaded && itemsChecked;

            itemSyncBox1.Enabled = syncProject.SingleSelection;

            btnSave.Enabled = projectLoaded;
            mnuSave.Enabled = projectLoaded;
            mnuAddItem.Enabled = projectLoaded;
            mnuDeleteItem.Enabled = projectLoaded && singleSelection;
            mnuGetDifferences.Enabled = projectLoaded && singleSelection;
            mnuOpenTargetFolder.Enabled = projectLoaded && singleSelection;
            mnuCopyTargetFilePath.Enabled = projectLoaded && singleSelection;
            mnuOpenWorkingFolder.Enabled = projectLoaded && singleSelection;
            mnuCopyWorkingFilePath.Enabled = projectLoaded && singleSelection;

            mnuCheck.Enabled = projectLoaded && itemsSelected;
            mnuUncheck.Enabled = projectLoaded && itemsSelected;
            btnCheck.Enabled = projectLoaded && itemsSelected;
            btnUncheck.Enabled = projectLoaded && itemsSelected;

            mnuCreateWorkingPaths.Enabled = projectLoaded && itemsSelected;
            mnuCopyTargetFolders.Enabled = projectLoaded && itemsSelected;
            mnuCopyWorkingFolders.Enabled = projectLoaded && itemsSelected;
            mnuMissingTargetsCheck.Enabled = projectLoaded;

            mnuContextCheck.Enabled = projectLoaded && itemsSelected;
            mnuContextUncheck.Enabled = projectLoaded && itemsSelected;

            mnuContextGetDifferences.Enabled = projectLoaded && singleSelection;
            mnuContextDelete.Enabled = projectLoaded && singleSelection;
            mnuContextCopyTargetFilePath.Enabled = projectLoaded && singleSelection;
            mnuContextCopyWorkingFilePath.Enabled = projectLoaded && singleSelection;
            mnuContextOpenTargetFolder.Enabled = projectLoaded && singleSelection;
            mnuContextOpenWorkingFolder.Enabled = projectLoaded && singleSelection;
        }

        private void CopyTargetDirectories()
        {
            string folderText = syncProject.GetTargetFolderPathsText();
            Clipboard.Clear();
            Clipboard.SetText(folderText.ToString());

            Dialogs.DistinctTargetFoldersToClipboard(this);
        }

        private void CopyWorkingDirectories()
        {
            string folderText = syncProject.GetWorkingFolderPathsText();
            Clipboard.Clear();
            Clipboard.SetText(folderText.ToString());

            Dialogs.DistinctWorkingFoldersToClipboard(this);
        }

        private void CreateWorkingPaths()
        {
            /*
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DialogResult pathResult = Dialogs.ChangeWorkingFilePathsPrompt(this);
                if (pathResult == System.Windows.Forms.DialogResult.Yes)
                {
                    List<SyncItem> syncItems = ListviewHelper.GetListviewSyncItems(listView1);
                    syncProject.CreateWorkingPaths(syncItems, folderDialog.SelectedPath);
                    ListviewHelper.UpdateListviewItems(listView1);
                }
            }
             * */

            WorkingPaths workingPaths = new WorkingPaths();
            workingPaths.SetInitialDirectory(Environment.CurrentDirectory);
            workingPaths.SetExistingFolders(syncProject.GetWorkingFolderPaths());
            DialogResult result = workingPaths.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                List<SyncItem> syncItems = ListviewHelper.GetListviewSyncItems(listView1);
                syncProject.CreateWorkingPaths(syncItems, workingPaths.FolderPath);
                ListviewHelper.UpdateListviewItems(listView1);
            }
        }

        private string WindowCaption()
        {
            if (string.IsNullOrEmpty(syncProject.FilePath))
                return ConfigSettings.ApplicationTitle;
            else
                return ConfigSettings.ApplicationTitle + " - [" + syncProject.FilePath + "]";
        }

        private void GetDifferences()
        {
            try
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    syncProject.InitiateDiffTool(listView1.SelectedItems[0].Tag as SyncItem);
                }
            }
            catch (Exception ex)
            {
                Dialogs.DiffMergeToolError(this);
            }
        }

        private void OpenTargetFolder()
        {
            if (syncProject.SingleSelection)
            {
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = syncProject.SelectedItem.TargetFolder;
                prc.Start();
            }
            else
            {
                Dialogs.OperationRequiresSingleSelection(this);
            }
        }

        private void OpenWorkingFolder()
        {
            if (syncProject.SingleSelection)
            {
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = syncProject.SelectedItem.WorkingFolder;
                prc.Start();
            }
            else
            {
                Dialogs.OperationRequiresSingleSelection(this);
            }
        }

        private void itemSyncBox1_BeforeWorkingFileChanged(object sender, BeforeFileSelectedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.CurrentFilePath))
            {
                DialogResult result = Dialogs.ChangeWorkingPathPrompt(this, e.CurrentFilePath);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (syncProject.WorkingFileExists(e.ExpectedFilePath))
            {
                DialogResult result = Dialogs.DuplicateWorkingPathPrompt(this, e.ExpectedFilePath);
                if (result == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void itemSyncBox1_BeforeTargetFileChanged(object sender, BeforeFileSelectedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.CurrentFilePath))
            {
                DialogResult result = Dialogs.ChangeTargetPathPrompt(this, e.ExpectedFilePath);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (syncProject.TargetFileExists(e.ExpectedFilePath))
            {
                DialogResult result = Dialogs.DuplicateTargetPathPrompt(this, e.ExpectedFilePath);
                if (result == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void itemSyncBox1_WorkingFileChanged(object sender, EventArgs e)
        {
            if (syncProject.SingleSelection)
            {
                ListviewHelper.UpdateSelectedListviewItem(listView1, imageList, this.itemSyncBox1.CurrentSyncItem);
                EnableControls();
            }
        }

        private void itemSyncBox1_TargetFileChanged(object sender, EventArgs e)
        {
            if (syncProject.SingleSelection)
            {
                ListviewHelper.UpdateSelectedListviewItem(listView1, imageList, this.itemSyncBox1.CurrentSyncItem);
                EnableControls();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void OpenProject()
        {
            string filePath;
            DialogResult result = Dialogs.OpenProjectDialog(this, out filePath);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                syncProject.Load(filePath);
                ListviewHelper.ReloadListview(listView1, imageList, syncProject.SyncItems);
                recentProjectMenu.Notify(filePath);
                recentProjectMenu.CurrentlyOpenedFile = filePath;
                ConfigSettings.LastProject = filePath;
                this.Text = WindowCaption();
                EnableControls();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateProject();
        }

        private void mnuCreate_Click(object sender, EventArgs e)
        {
            CreateProject();
        }

        private void CreateProject()
        {
            string filePath;
            DialogResult result = Dialogs.CreateProjectDialog(this, out filePath);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                syncProject.Create(filePath);
                ListviewHelper.ReloadListview(listView1, imageList, syncProject.SyncItems);
                recentProjectMenu.Notify(filePath);
                recentProjectMenu.CurrentlyOpenedFile = filePath;
                this.Text = WindowCaption();
                EnableControls();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void SaveProject()
        {
            syncProject.Save();
            EnableControls();
        }

        private void mnuAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void mnuDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void mnuContextDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void syncProject_FileCopied(object sender, FileCopiedEventArgs e)
        {
            if (e.Direction == FileCopiedEventArgs.FileCopyDirection.TargetToWorking)
                Console.CopyTargetFile(richTextBox1, e.Item);
            else
                Console.CopyWorkingFile(richTextBox1, e.Item);
        }

        private void btnCopyRight_Click(object sender, EventArgs e)
        {
            CopyRight();
            EnableControls();
        }

        private void btnCopyLeft_Click(object sender, EventArgs e)
        {
            CopyLeft();
            EnableControls();
        }


        private void mnuCopyRight_Click(object sender, EventArgs e)
        {
            CopyRight();
            EnableControls();
        }

        private void mnuCopyLeft_Click(object sender, EventArgs e)
        {
            CopyLeft();
            EnableControls();
        }




        private void btnCheck_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            Uncheck();
        }

        private void mnuCheck_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void mnuUncheck_Click(object sender, EventArgs e)
        {
            Uncheck();
        }

        private void mnuContextCheck_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void mnuContextUncheck_Click(object sender, EventArgs e)
        {
            Uncheck();
        }

        private void Check()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.Checked = true;
            }
            EnableControls();
        }

        private void Uncheck()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.Checked = false;
            }
            EnableControls();
        }

        private void CopyWorkingFilePath()
        {
            if (syncProject.SingleSelection)
            {
                string filePath = syncProject.SelectedItem.WorkingFile;
                Clipboard.Clear();
                Clipboard.SetText(filePath);
            }
            else
            {
                Dialogs.OperationRequiresSingleSelection(this);
            }
        }

        private void CopyTargetFilePath()
        {
            if (syncProject.SingleSelection)
            {
                string filePath = syncProject.SelectedItem.TargetFile;
                Clipboard.Clear();
                Clipboard.SetText(filePath);
            }
            else
            {
                Dialogs.OperationRequiresSingleSelection(this);
            }
        }

        private void mnuCreateWorkingPaths_Click(object sender, EventArgs e)
        {
            CreateWorkingPaths();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListviewHelper.SortColumn(listView1, e.Column);
        }

        private void mnuCopyTargetFolders_Click(object sender, EventArgs e)
        {
            CopyTargetDirectories();
        }

        private void mnuCopyWorkingFolders_Click(object sender, EventArgs e)
        {
            CopyWorkingDirectories();   
        }

        private void mnuContextGetDifferences_Click(object sender, EventArgs e)
        {
            GetDifferences();
        }

        private void mnuGetDifferences_Click(object sender, EventArgs e)
        {
            GetDifferences();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // here is where the syncItem list is synced.
            List<SyncItem> items = ListviewHelper.GetListviewSyncItems(listView1);
            syncProject.SelectItems(items.Select(r => r.Id).ToArray());
            this.itemSyncBox1.CurrentSyncItem = syncProject.SelectedItem; // e.Item.Tag as SyncItem;
            EnableControls();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // update the "checked" status of the selected syncItem on the syncProject.
            SyncItem syncItem = e.Item.Tag as SyncItem;
            if (syncItem != null)
                syncProject.ChangeCheckedStatus(syncItem.Id, e.Item.Checked);
            EnableControls();
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (syncProject.HasChanges)
            {
                DialogResult result = Dialogs.PromptSaveBeforeContinuing(this);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    SaveProject();
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void mnuContextOpenTargetFolder_Click(object sender, EventArgs e)
        {
            OpenTargetFolder();
        }

        private void mnuOpenTargetFolder_Click(object sender, EventArgs e)
        {
            OpenTargetFolder();
        }

        private void mnuContextOpenWorkingFolder_Click(object sender, EventArgs e)
        {
            OpenWorkingFolder();
        }

        private void mnuOpenWorkingFolder_Click(object sender, EventArgs e)
        {
            OpenWorkingFolder();
        }

        private void mnuCopyTargetFilePath_Click(object sender, EventArgs e)
        {
            CopyTargetFilePath();
        }

        private void mnuCopyWorkingFilePath_Click(object sender, EventArgs e)
        {
            CopyWorkingFilePath();
        }

        private void mnuContextCopyTargetFilePath_Click(object sender, EventArgs e)
        {
            CopyTargetFilePath();
        }

        private void mnuContextCopyWorkingFilePath_Click(object sender, EventArgs e)
        {
            CopyWorkingFilePath();
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    SyncItem newItem = null;
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string file in files)
                    {
                        if (syncProject.PathIsDirectory(file))
                        {
                            Dialogs.DirectoryTargetDroppedPathPrompt(this, file);
                        }
                        else if (syncProject.TargetFileExists(file))
                        {
                            Dialogs.DuplicateTargetDroppedPathPrompt(this, file);
                        }
                        else
                        {
                            newItem = syncProject.AddSyncItem(file, string.Empty);
                            ListviewHelper.CreateListviewItem(listView1, imageList, newItem, true);
                        }
                    }

                    this.itemSyncBox1.CurrentSyncItem = newItem;
                    EnableControls();
                }
                catch (Exception ex)
                {
                    Dialogs.FileDropError(this, ex);
                }
            }
        }

        private void mnuMissingTargetsCheck_Click(object sender, EventArgs e)
        {
            if (syncProject.TargetFilesMissing(SyncProject.MissingFileCheckEnum.All))
            {
                Console.StartWriteMissingFiles(richTextBox1);
                foreach (SyncItem syncItem in syncProject.GetMissingTargetFileItems())
                {
                    Console.WriteMissingFile(richTextBox1, syncItem);
                }
                Console.EndWrite(richTextBox1);
                Dialogs.MissingTargetFilesFound(this);
            }
            else
                Dialogs.NoMissingTargetFilesFound(this);
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            AboutBoxDialog dialog = new AboutBoxDialog();
            dialog.ShowDialog(this);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenu.Show(Cursor.Position);
                }
            } 
        }

        private void mnuMergeProjectFiles_Click(object sender, EventArgs e)
        {

        }
    }
}
