using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSync
{
    public partial class WorkingPaths : Form
    {
        public WorkingPaths()
        {
            InitializeComponent();
        }

        public string FolderPath
        {
            get { return folderBrowseBox.Directory; }
        }

        public void SetInitialDirectory(string initialDirectory)
        {
            folderBrowseBox.Directory = initialDirectory;
        }

        public void SetExistingFolders(string[] folderPaths)
        {
            cboExistingPaths.Items.Clear();
            foreach (string folderPath in folderPaths)
            {
                cboExistingPaths.Items.Add(folderPath);
            }
        }

        private void cboExistingPaths_SelectedValueChanged(object sender, EventArgs e)
        {
            folderBrowseBox.Directory = cboExistingPaths.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
