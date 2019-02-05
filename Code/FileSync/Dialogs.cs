using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSync
{
    public class Dialogs
    {
        public static DialogResult ChangeWorkingPathPrompt(IWin32Window owner, string filePath)
        {
            return MessageBox.Show(owner, string.Format("Sure you'd like to change the current WORKING file path?\n{0}", filePath),
                "Current File Path.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult ChangeTargetPathPrompt(IWin32Window owner, string filePath)
        {
            return MessageBox.Show(owner, string.Format("Sure you'd like to change the current TARGET file path?\n{0}", filePath),
                "Current File Path.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult DuplicateWorkingPathPrompt(IWin32Window owner, string filePath)
        {
            return MessageBox.Show(owner, string.Format("This  WORKING file path already exists as part of the set.\n{0}\nStill want to add it?", filePath),
                "File Path exists.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult DuplicateTargetPathPrompt(IWin32Window owner, string filePath)
        {
            return MessageBox.Show(owner, string.Format("This  TARGET file path already exists as part of the set.\n{0}\nStill want to add it?", filePath),
                "File Path exists.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static void DuplicateTargetDroppedPathPrompt(IWin32Window owner, string filePath)
        {
            MessageBox.Show(owner, string.Format("This  TARGET file path already exists as part of the set.\n{0}\nThis file will not be added.", filePath), 
                ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void DirectoryTargetDroppedPathPrompt(IWin32Window owner, string filePath)
        {
            MessageBox.Show(owner, string.Format("The TARGET path provided is a directory:\n{0}\nThis path will not be added.", filePath),
                ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult UpdateRepositoryPrompt(IWin32Window owner)
        {
            return MessageBox.Show(owner, "Have you UPDATED THE REPO before copying ???", "Update Repo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult PromptSaveBeforeContinuing(IWin32Window owner)
        {
            return MessageBox.Show(owner, "Would you like to save your project?", "Save",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult DeleteSyncItemPrompt(IWin32Window owner)
        {
            return MessageBox.Show(owner, "Sure you want to delete this item?", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult BeforeCopyTargetFilesPrompt(IWin32Window owner)
        {
            return MessageBox.Show(owner, "You're about to copy selected TARGET files to their WORKING files, would you like to continue?", "Copy", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult BeforeCopyWorkingFilesPrompt(IWin32Window owner)
        {
            return MessageBox.Show(owner, "You're about to copy selected WORKING files to their TARGET files, would you like to continue?", "Copy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        public static void NoExistingTargetFilePrompt(IWin32Window owner, string targetFileTitle)
        {
            MessageBox.Show(owner, string.Format("One of your TARGET files:{1}{0}{1}does not point to an existing file.",
                    targetFileTitle, Environment.NewLine), ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void MissingWorkingFilePathsPrompt(IWin32Window owner)
        {
            MessageBox.Show(owner, "You have not provided the system with some of your working file paths.", ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void NoExistingWorkingFilePrompt(IWin32Window owner)
        {
            MessageBox.Show(owner, "One of your WORKING files does not point to an existing file.", ConfigSettings.ApplicationTitle, 
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void MissingTargetFilesFound(IWin32Window owner)
        {
            MessageBox.Show(owner, "Missing target files were found. Details have been written to the console.", ConfigSettings.ApplicationTitle, 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void NoMissingTargetFilesFound(IWin32Window owner)
        {
            MessageBox.Show(owner, "No missing target files were found.", ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ChangeWorkingFilePathsPrompt(IWin32Window owner)
        {
            return MessageBox.Show(owner, "You're about to change all the paths of your working files. Sure about this?",
                "Working Paths", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void DistinctTargetFoldersToClipboard(IWin32Window owner)
        {
            MessageBox.Show(owner, "Distinct target folders copied to clipboard.", ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void OperationRequiresSingleSelection(IWin32Window owner)
        {
            MessageBox.Show(owner, "This operation requires that only a single item is selected.", ConfigSettings.ApplicationTitle, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void DistinctWorkingFoldersToClipboard(IWin32Window owner)
        {
            MessageBox.Show(owner, "Distinct working folders copied to clipboard.", ConfigSettings.ApplicationTitle, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void DiffMergeToolError(IWin32Window owner)
        {
            MessageBox.Show(owner, "Could not start the external diff/merge tool. Please check your path.", ConfigSettings.ApplicationTitle, 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void FileCopyError(IWin32Window owner)
        {
            MessageBox.Show(owner, "Could not copy files. Check that all your paths are correctly entered.", 
                ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void FileDropError(IWin32Window owner, Exception exception)
        {
            MessageBox.Show(owner, string.Format("Could not drop file(s). An error occurred while attempting to drop the file(s).\n{0}", exception.Message),
                ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult MissingRecentFileError(IWin32Window owner)
        {
            return MessageBox.Show(owner, "Project file does not exist, would you like to remove this from the recent menu?",
                ConfigSettings.ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult OpenProjectDialog(IWin32Window owner, out string filePath)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filter = ConfigSettings.ProjectFileDialogFilterPattern;
            openDialog.DefaultExt = ConfigSettings.ProjectFileDialogDefaultExtension;
            openDialog.Title = "Open Project";
            openDialog.AddExtension = true;
            openDialog.FilterIndex = 0;

            DialogResult result = openDialog.ShowDialog(owner);
            filePath = openDialog.FileName;

            return result;
        }

        public static DialogResult CreateProjectDialog(IWin32Window owner, out string filePath)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter =  ConfigSettings.ProjectFileDialogFilterPattern;
            saveDialog.DefaultExt = ConfigSettings.ProjectFileDialogDefaultExtension;
            saveDialog.Title = "Create New Project";
            saveDialog.AddExtension = true;
            saveDialog.FilterIndex = 0;

            DialogResult result = saveDialog.ShowDialog(owner);
            filePath = saveDialog.FileName;

            return result;
        }
    }
}
