using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.ComponentModel;

namespace FileSync
{
    public class SyncItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SyncItem()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; private set; }

        public Icon GetAssociatedIcon()
        {


            if (!string.IsNullOrEmpty(this.TargetFile))
            {
                try
                {
                    Icon icon = Icon.ExtractAssociatedIcon(this.TargetFile);
                    if (icon == null)
                        icon = SystemIcons.WinLogo;
                    return icon;
                }
                catch (Exception) { return SystemIcons.WinLogo; }
            }
            return SystemIcons.WinLogo;
        }

        // keep in sync with UI control...
        public bool Checked { get; set; }
        public bool Selected { get; set; }

        private string workingFile;
        public string WorkingFile 
        {
            get { return this.workingFile; }
            set
            {
                this.workingFile = value;
                Notify("WorkingFile");
            }
        }

        private string targetFile;
        public string TargetFile 
        {
            get { return this.targetFile; }
            set
            {
                this.targetFile = value;
                Notify("TargetFile");
            }
        }

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public string WorkingTitle
        {
            get
            {
                if (this.WorkingFile == string.Empty)
                    return string.Empty;
                return Path.GetFileName(this.WorkingFile);
            }
        }

        public string TargetTitle
        {
            get
            {
                if (this.TargetFile == string.Empty)
                    return string.Empty;
                return Path.GetFileName(this.TargetFile);
            }
        }

        public string WorkingFolder
        {
            get
            {
                if (this.WorkingFile != string.Empty)
                    return Path.GetDirectoryName(this.WorkingFile);
                return string.Empty;
            }
        }

        public string TargetFolder
        {
            get
            {
                if (this.TargetFile != string.Empty)
                    return Path.GetDirectoryName(this.TargetFile);
                return string.Empty;
            }
        }

        public string BackupTargetFile
        {
            get { return CreateBackupFilePath(this.TargetFile); }
        }

        public string BackupWorkingFile
        {
            get { return CreateBackupFilePath(this.WorkingFile); }
        }

        public bool WorkingFileExists { get { return File.Exists(this.WorkingFile); } }
        public bool TargetFileExists { get { return File.Exists(this.TargetFile); } }

        public bool WorkingFileMissing { get { return !File.Exists(this.WorkingFile); } }
        public bool TargetFileMissing { get { return !File.Exists(this.TargetFile); } }

        public bool HasWorkingFile { get { return !string.IsNullOrWhiteSpace(this.WorkingFile); } }

        private string CreateBackupFilePath(string filePath)
        {
            try
            {
                string directory = Path.GetDirectoryName(filePath);
                string fileText = "BACKUP_" + Path.GetFileNameWithoutExtension(filePath);
                string extension = Path.GetExtension(filePath);

                string fileTitle = string.Format("{0}{1}", fileText, extension);
                string fullPath = Path.Combine(directory, fileTitle);

                return fullPath;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
