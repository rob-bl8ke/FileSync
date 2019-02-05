using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSync
{
    public partial class ItemSyncBox : UserControl
    {
        public event EventHandler TargetFileChanged;
        public event EventHandler WorkingFileChanged;
        public event EventHandler<BeforeFileSelectedEventArgs> BeforeTargetFileChanged;
        public event EventHandler<BeforeFileSelectedEventArgs> BeforeWorkingFileChanged;


        public ItemSyncBox()
        {
            InitializeComponent();
            this.browseWorkingFile.FileChanged += new EventHandler(browseWorkingFile_FileChanged);
            this.browseTargetFile.FileChanged += new EventHandler(browseTargetFile_FileChanged);

            this.browseTargetFile.BeforeFileSelected += new EventHandler<BeforeFileSelectedEventArgs>(browseTargetFile_BeforeFileSelected);
            this.browseWorkingFile.BeforeFileSelected += new EventHandler<BeforeFileSelectedEventArgs>(browseWorkingFile_BeforeFileSelected);
        }

        private void browseWorkingFile_BeforeFileSelected(object sender, BeforeFileSelectedEventArgs e)
        {
            if (BeforeWorkingFileChanged != null)
            {
                BeforeWorkingFileChanged(this, e); // new BeforeFileSelectedEventArgs(cancelFileSelection, e.ExpectedFilePath));
            }
        }

        private void browseTargetFile_BeforeFileSelected(object sender, BeforeFileSelectedEventArgs e)
        {
            if (BeforeTargetFileChanged != null)
            {
                BeforeTargetFileChanged(this, e); // new BeforeFileSelectedEventArgs(cancelFileSelection, e.ExpectedFilePath));
            }
        }

        private void browseTargetFile_FileChanged(object sender, EventArgs e)
        {
            this.syncItem.TargetFile = browseTargetFile.File;
            if (TargetFileChanged != null)
                TargetFileChanged(this, new EventArgs());
        }

        private void browseWorkingFile_FileChanged(object sender, EventArgs e)
        {
            this.syncItem.WorkingFile = browseWorkingFile.File;
            if (WorkingFileChanged != null)
                WorkingFileChanged(this, new EventArgs());
        }

        private SyncItem syncItem;
        public SyncItem CurrentSyncItem
        {
            get { return this.syncItem; }
            set
            {
                this.syncItem = value;
                if (syncItem == null)
                {
                    this.browseTargetFile.File = string.Empty;
                    this.browseWorkingFile.File = string.Empty;
                }
                else
                {
                    this.browseTargetFile.File = syncItem.TargetFile;
                    this.browseWorkingFile.File = syncItem.WorkingFile;
                }
            }
        }
    }
}
