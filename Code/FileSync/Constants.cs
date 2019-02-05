using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSync
{
    public class Constants
    {
        public enum SyncOperation
        {
            SyncLeftToRight,
            SyncRightToLeft,
            ProjectEdit,
        }

        public enum FileCategory
        {
            ProjectFile,
            TargetFile,
            WorkingFile
        }

        public class ImageKeys
        {
            public const string CheckItems = "Check";
            public const string UncheckItems = "Uncheck";
            public const string Save = "Save";
            public const string AddItem = "Add";
            public const string DeleteItem = "Delete";
            public const string Open = "Open";
            public const string Create = "Create";
            public const string GetDifferences = "Diff";
            public const string CopyLeft = "CopyLeft";
            public const string CopyRight = "CopyRight";
        }

    }
}
