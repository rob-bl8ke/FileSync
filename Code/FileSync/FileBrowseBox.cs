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
    public partial class FileBrowseBox : UserControl
    {
        public event EventHandler<BeforeFileSelectedEventArgs> BeforeFileSelected;
        public FileBrowseBox()
        {
            InitializeComponent();
        }

        public event EventHandler FileChanged;

        public string File
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); // ApplicationDialogs.OpenScriptDialog("");
            dialog.CheckFileExists = false;
            DialogResult result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                if (BeforeFileSelected != null)
                {
                    BeforeFileSelectedEventArgs eventArgs = new BeforeFileSelectedEventArgs(textBox1.Text, dialog.FileName);
                    BeforeFileSelected(this, eventArgs);
                    if (eventArgs.Cancel)
                        return;
                }

                textBox1.Text = dialog.FileName;
                if (FileChanged != null)
                    FileChanged(this, new EventArgs());
            }
        }
    }
}
