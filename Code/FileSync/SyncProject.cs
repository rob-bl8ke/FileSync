using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FileSync
{
    public class SyncProject
    {
        public enum MissingFileCheckEnum
        {
            All,
            CheckedOnly,
            SelectedOnly,
            CheckedAndSelectedOnly
        }

        public event EventHandler ItemsLoaded;
        public event EventHandler<FileCopiedEventArgs> FileCopied;

        private ProjectFile projectFile = new ProjectFile();

        //private List<SyncItem> syncItems = new List<SyncItem>();
        // http://stackoverflow.com/questions/8490533/notify-observablecollection-when-item-changes
        // Source Idea: http://stackoverflow.com/questions/1427471/observablecollection-not-noticing-when-item-in-it-changes-even-with-inotifyprop
        private TrulyObservableCollection<SyncItem> syncItems = new TrulyObservableCollection<SyncItem>();

        private List<SyncItem> selectedSyncItems = new List<SyncItem>();

        public List<SyncItem> SyncItems
        {
            get { return this.syncItems.ToList(); }
        }

        public bool HasChanges { get; private set; }

        public string FilePath 
        {
            get { return this.projectFile.FilePath; }
        }

        public string FileDirectory
        {
            get { return Path.GetDirectoryName(this.projectFile.FilePath); }
        }

        public bool ProjectLoaded
        {
            get { return this.FilePath != string.Empty && File.Exists(this.FilePath); }
        }

        public bool ItemsChecked { get { return this.CheckedItems.Length > 0; } }

        public SyncItem[] CheckedItems
        {
            get { return syncItems.Where(r => r.Checked).ToArray(); }

        }

        public bool ItemsSelected { get { return this.SelectedItems.Length > 0; } }

        public SyncItem[] SelectedItems
        {
            get { return syncItems.Where(r => r.Selected).ToArray(); }
        }


        public SyncItem SelectedItem 
        {
            get
            {
                if (this.SingleSelection)
                    return syncItems.ToList().Find(r => r.Selected);
                else
                    return null;
            }
        }

        public bool SingleSelection { get { return syncItems.Count > 0 && syncItems.Where(r => r.Selected).Count() == 1; } }

        public void Load(string filePath)
        {
            List<SyncItem> items;

            projectFile.FilePath = filePath;
            projectFile.Load(out items);

            ResetSyncItems(items);

            if (ItemsLoaded != null)
                ItemsLoaded(this, new EventArgs());
        }

        public void Create(string filePath)
        {
            List<SyncItem> items;

            projectFile.FilePath = filePath;
            projectFile.Create();
            projectFile.Load(out items);

            ResetSyncItems(items);

            if (ItemsLoaded != null)
                ItemsLoaded(this, new EventArgs());
        }

        public void SelectItems(string[] ids)
        {
            foreach (SyncItem item in syncItems)
            {
                item.Selected = ids.Any(a => a == item.Id);
            }
        }

        public void ChangeCheckedStatus(string id, bool isChecked)
        {
            if (syncItems.Any(s => s.Id == id))
            {
                SyncItem item = syncItems.Where(s => s.Id == id).Single();
                item.Checked = isChecked;
            }
        }

        public SyncItem AddSyncItem(string targetFile, string workingFile)
        {
            SyncItem item = new SyncItem();
            item.TargetFile = targetFile;
            item.WorkingFile = workingFile;
            this.syncItems.Add(item);

            return item;
        }

        public void RemoveSyncItem(SyncItem item)
        {
            syncItems.Remove(item);
        }

        public void Save(bool ignoreBackup = false)
        {
            if (ConfigSettings.BackupBeforeProjectEdit && !ignoreBackup)
            {
                ProjectBackup projBackup = new ProjectBackup();
                projBackup.DeleteOldBackups(this.FileDirectory);
                projBackup.Backup(this.FilePath, this.syncItems.ToList(), Constants.SyncOperation.ProjectEdit);
            }
            projectFile.Save(syncItems.ToList());
            this.HasChanges = false;
        }

        public bool WorkingFileExists(string filePath)
        {
            return syncItems.Any(r => r.WorkingFile == filePath);
        }

        public bool TargetFileExists(string filePath)
        {
            return syncItems.Any(r => r.TargetFile == filePath);
        }

        public bool PathIsDirectory(string path)
        {
            bool isDir = false;
            try
            {
                isDir = (File.GetAttributes(path) & FileAttributes.Directory)
                 == FileAttributes.Directory;
            }
            catch (Exception) { isDir = false; }
            return isDir;
        }

        public bool TargetFilesMissing(MissingFileCheckEnum missingCheckType)
        {
            if (missingCheckType == MissingFileCheckEnum.CheckedAndSelectedOnly)
                return syncItems.Any(s => s.Checked && s.Selected && s.TargetFileMissing);
            else if (missingCheckType == MissingFileCheckEnum.CheckedOnly)
                return syncItems.Any(s => s.Checked && s.TargetFileMissing);
            else if (missingCheckType == MissingFileCheckEnum.SelectedOnly)
                return syncItems.Any(s => s.Selected && s.TargetFileMissing);
            else
                return syncItems.Any(s => s.TargetFileMissing);

        }

        public bool WorkingFilesMissing(MissingFileCheckEnum missingCheckType)
        {
            if (missingCheckType == MissingFileCheckEnum.CheckedAndSelectedOnly)
                return syncItems.Any(s => s.Checked && s.Selected && s.WorkingFileMissing);
            else if (missingCheckType == MissingFileCheckEnum.CheckedOnly)
                return syncItems.Any(s => s.Checked && s.WorkingFileMissing);
            else if (missingCheckType == MissingFileCheckEnum.SelectedOnly)
                return syncItems.Any(s => s.Selected && s.WorkingFileMissing);
            else
                return syncItems.Any(s => s.WorkingFileMissing);
        }

        public bool MissingWorkingFileData()
        {
            foreach (SyncItem item in this.SyncItems)
            {
                if (!item.HasWorkingFile)
                    return true;
            }
            return false;
        }

        public SyncItem[] GetMissingTargetFileItems()
        {
            return syncItems.Where(s => s.TargetFileMissing).ToArray();
        }

        public SyncItem[] GetMissingWorkingFileItems()
        {
            return syncItems.Where(s => s.WorkingFileMissing).ToArray();
        }

        public void CopyCheckedWorkingFilesToTargets()
        {
            if (ConfigSettings.BackupBeforeLeft)
            {
                ProjectBackup projBackup = new ProjectBackup();
                projBackup.DeleteOldBackups(this.FileDirectory);
                projBackup.Backup(this.FilePath, this.syncItems.ToList(), Constants.SyncOperation.SyncLeftToRight);
            }

            foreach (SyncItem item in this.CheckedItems)
            {
                this.CopyWorkingToTarget(item);
                if (FileCopied != null)
                    FileCopied(this, new FileCopiedEventArgs(item, FileCopiedEventArgs.FileCopyDirection.WorkingToTarget));
            }
        }

        public void CopyCheckedTargetFilesToWorkings()
        {
            if (ConfigSettings.BackupBeforeRight)
            {
                ProjectBackup projBackup = new ProjectBackup();
                projBackup.DeleteOldBackups(this.FileDirectory);
                projBackup.Backup(this.FilePath, this.syncItems.ToList(), Constants.SyncOperation.SyncRightToLeft);
            }

            foreach (SyncItem item in this.CheckedItems)
            {
                this.CopyTargetToWorking(item);
                if (FileCopied != null)
                    FileCopied(this, new FileCopiedEventArgs(item, FileCopiedEventArgs.FileCopyDirection.TargetToWorking));
            }
        }


        private void CopyWorkingToTarget(SyncItem item)
        {
            // copy file
            File.Copy(item.WorkingFile, item.TargetFile, true);
        }

        private void CopyTargetToWorking(SyncItem item)
        {
            // copy file
            File.Copy(item.TargetFile, item.WorkingFile, true);
        }

        public void CreateWorkingPaths(List<SyncItem> selectedItems, string selectedFolder)
        {
            foreach (SyncItem item in selectedItems)
            {
                if (!string.IsNullOrWhiteSpace(item.TargetFile))
                {
                    item.WorkingFile = Path.Combine(selectedFolder, item.TargetTitle);
                }
            }
        }

        public string GetTargetFolderPathsText()
        {
            List<string> targetFolders = new List<string>();

            foreach (SyncItem item in this.SelectedItems)
            {
                targetFolders.Add(item.TargetFolder);
            }

            targetFolders.Sort();
            var distinctFolders = targetFolders.Distinct();
            StringBuilder builder = new StringBuilder();

            foreach (string folder in distinctFolders)
            {
                builder.AppendLine(folder);
            }

            return builder.ToString();
        }

        public string GetWorkingFolderPathsText()
        {
            List<string> workingFolders = new List<string>();

            foreach (SyncItem item in this.SelectedItems)
            {
                workingFolders.Add(item.WorkingFolder);
            }

            workingFolders.Sort();
            var distinctFolders = workingFolders.Distinct();
            StringBuilder builder = new StringBuilder();

            foreach (string folder in distinctFolders)
            {
                builder.AppendLine(folder);
            }

            return builder.ToString();
        }

        public string[] GetWorkingFolderPaths()
        {
            List<string> workingFolders = new List<string>();

            foreach (SyncItem item in this.syncItems)
            {
                workingFolders.Add(item.WorkingFolder);
            }

            workingFolders.Sort();
            var distinctFolders = workingFolders.Distinct();
            return distinctFolders.ToArray();
        }

        public void InitiateDiffTool(SyncItem item)
        {
            Process.Start(ConfigSettings.WinMergePath, 
                string.Format("/u {0} {1}", 
                ToQuotes(item.TargetFile), ToQuotes(item.WorkingFile)));
        }

        private string ToQuotes(string text)
        {
            return "\"" + text + "\"";
        }

        private void ResetSyncItems(List<SyncItem> items)
        {
            this.syncItems.CollectionChanged -= syncItems_CollectionChanged;
            //this.syncItems.ItemPropertyChanged -= syncItems_ItemPropertyChanged;

            this.syncItems.Clear();
            foreach (SyncItem item in items)
                this.syncItems.Add(item);

            this.syncItems.CollectionChanged += syncItems_CollectionChanged;
            //this.syncItems.ItemPropertyChanged += syncItems_ItemPropertyChanged;
        }

        private void syncItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.HasChanges = true;
        }
    }
}
