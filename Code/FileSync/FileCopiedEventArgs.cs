using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSync
{
    public class FileCopiedEventArgs : EventArgs
    {
        public enum FileCopyDirection
        {
            WorkingToTarget,
            TargetToWorking
        }

        public SyncItem Item { get; private set; }
        public FileCopyDirection Direction { get; private set; }

        public FileCopiedEventArgs(SyncItem item, FileCopyDirection direction)
        {
            this.Item = item;
            this.Direction = direction;
        }
    }
}
