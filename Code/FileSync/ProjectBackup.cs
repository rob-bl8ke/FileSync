using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    public class ProjectBackup
    {
        private class NewToOldDirectoryComparer : IComparer<DirectoryInfo>
        {
            public int Compare(DirectoryInfo x, DirectoryInfo y)
            {
                if (x.CreationTime < y.CreationTime)
                    return 1;
                if (x.CreationTime > y.CreationTime)
                    return -1;
                return 0;
            }
        }

        public void DeleteOldBackups(string projectDirectory)
        {
            string backupFolder = ConfigSettings.ProjectBackupFolder;
            List<DirectoryInfo> directoryInfoList = new List<DirectoryInfo>();

            string folderPath = Path.Combine(projectDirectory, backupFolder);

            if (Directory.Exists(folderPath))
            {
                int startIndex = ConfigSettings.BackupFolderLimit - 1;
                string[] directories = Directory.EnumerateDirectories(folderPath).ToArray();

                if (directories.Length >= startIndex)
                {
                    foreach (string directory in directories)
                        directoryInfoList.Add(new DirectoryInfo(directory));

                    directoryInfoList.Sort(new NewToOldDirectoryComparer());

                    for (int x = startIndex; x < directoryInfoList.Count; x++)
                    {
                        Directory.Delete(directoryInfoList[x].FullName, true);
                    }
                }
            }
        }

        public void Backup(string projectFile, List<SyncItem> syncItems, Constants.SyncOperation syncOperation)
        {
            DateTime timeStamp = DateTime.Now;
            string projectDirectory = Path.GetDirectoryName(projectFile);
            string backupSubFolder = ConfigSettings.ProjectBackupFolder;
            string targetDirectory = GenerateDirectoryPath(timeStamp, projectDirectory, backupSubFolder, syncOperation, Constants.FileCategory.TargetFile);
            string workingDirectory = GenerateDirectoryPath(timeStamp, projectDirectory, backupSubFolder, syncOperation, Constants.FileCategory.WorkingFile);

            foreach (SyncItem item in syncItems)
            {
                if (File.Exists(item.TargetFile))
                {
                    if (!Directory.Exists(targetDirectory))
                        Directory.CreateDirectory(targetDirectory);

                    File.Copy(item.TargetFile, Path.Combine(targetDirectory, item.TargetTitle));
                }
                if (File.Exists(item.WorkingFile))
                {
                    if (!Directory.Exists(workingDirectory))
                        Directory.CreateDirectory(workingDirectory);
                    File.Copy(item.WorkingFile, Path.Combine(workingDirectory, item.WorkingTitle));
                }
            }

            if (syncOperation == Constants.SyncOperation.ProjectEdit)
                File.Copy(projectFile, Path.Combine(GenerateDirectoryPath(timeStamp, projectDirectory, backupSubFolder, syncOperation, Constants.FileCategory.ProjectFile), Path.GetFileName(projectFile)));
        }

        private string GenerateDirectoryPath(DateTime timeStamp, string projectDirectory, string backupSubFolder, Constants.SyncOperation syncOperation, Constants.FileCategory fileSource)
        {
            
            string directory = string.Empty;

            if (syncOperation == Constants.SyncOperation.SyncLeftToRight)
            {
                if (fileSource == Constants.FileCategory.TargetFile)
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_LtoR", "Target");
                else if (fileSource == Constants.FileCategory.WorkingFile)
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_LtoR", "Working");
                else
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_LtoR");
            }
            else if (syncOperation == Constants.SyncOperation.SyncRightToLeft)
            {
                if (fileSource == Constants.FileCategory.TargetFile)
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_RtoL", "Target");
                else if (fileSource == Constants.FileCategory.WorkingFile)
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_RtoL", "Working");
                else
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_RtoL");
            }
            else if (syncOperation == Constants.SyncOperation.ProjectEdit)
            {
                if (fileSource == Constants.FileCategory.TargetFile)
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_edit", "Target");
                else if (fileSource == Constants.FileCategory.WorkingFile)
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_edit", "Working");
                else
                    directory = Path.Combine(projectDirectory, backupSubFolder, TodayPart(timeStamp) + "__" + TimePart(timeStamp) + "_edit");
            }
            return directory;
        }

        private string TodayPart(DateTime theDate)
        {
            return Path.Combine(theDate.Year + "-" + EnsureTwoCharacters(theDate.Month) + "-" + EnsureTwoCharacters(theDate.Day));
        }

        private string TimePart(DateTime theDate)
        {
            string directory =
                EnsureTwoCharacters(theDate.Hour) + "-" +
                EnsureTwoCharacters(theDate.Minute) + "-" +
                EnsureTwoCharacters(theDate.Second) + "-" +
                theDate.Millisecond.ToString();

            return directory;
        }

        private string EnsureTwoCharacters(int dayOrMonth)
        {
            if (dayOrMonth < 10)
                return "0" + dayOrMonth.ToString();
            else
                return dayOrMonth.ToString();
        }
    }
}
