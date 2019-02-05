using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSync
{
    public class BeforeFileSelectedEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
        public string CurrentFilePath { get; private set; }
        public string ExpectedFilePath { get; private set; }

        public BeforeFileSelectedEventArgs(string currentFilePath, string expectedFilePath)
        {
            this.Cancel = false;
            this.CurrentFilePath = currentFilePath;
            this.ExpectedFilePath = expectedFilePath;
        }
    }
}
