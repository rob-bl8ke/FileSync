using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSync
{
    public partial class FolderBrowseBox : UserControl
    {
        public event EventHandler FolderChanged;

        public FolderBrowseBox()
        {
            InitializeComponent();
        }

        public string Directory
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();

            if (System.IO.Directory.Exists(textBox1.Text))
            {
                browserDialog.SelectedPath = textBox1.Text;
                browserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            }

            DialogResult result = browserDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                textBox1.Text = browserDialog.SelectedPath;
                if (FolderChanged != null)
                    FolderChanged(this, new EventArgs());
            }
        }
    }
}
