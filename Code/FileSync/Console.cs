using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSync
{
    public class Console
    {
        public static void CopyWorkingFile(RichTextBox richTextBox1, SyncItem item)
        {
            richTextBox1.AppendText(string.Format("copying {0} to {1}", item.WorkingFile, item.TargetFile));
            richTextBox1.AppendText(Environment.NewLine);
        }

        public static void CopyTargetFile(RichTextBox richTextBox1, SyncItem item)
        {
            richTextBox1.AppendText(string.Format("copying {0} to {1}", item.TargetFile, item.WorkingFile));
            richTextBox1.AppendText(Environment.NewLine);
        }

        public static void StartWriteMissingFiles(RichTextBox richTextBox1)
        {
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(string.Format("List of Missing Target Files - Date: {0} {1}", DateTime.Now.ToLongDateString(),
                DateTime.Now.ToLongTimeString()));
            richTextBox1.AppendText(Environment.NewLine);
        }

        public static void WriteMissingFile(RichTextBox richTextBox1, SyncItem item)
        {
            richTextBox1.AppendText(string.Format("Missing: {0} - {1}", item.TargetTitle, item.TargetFile));
            richTextBox1.AppendText(Environment.NewLine);
        }

        public static void StartCopyingWorkingFiles(RichTextBox richTextBox1)
        {
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(string.Format("Copying from Working to Target - Date: {0} {1}", DateTime.Now.ToLongDateString(),
                DateTime.Now.ToLongTimeString()));
            richTextBox1.AppendText(Environment.NewLine);
        }

        public static void StartCopyingTargetFiles(RichTextBox richTextBox1)
        {
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(string.Format("Copying from Target to Working - Date: {0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString()));
            richTextBox1.AppendText(Environment.NewLine);
        }

        public static void EndWrite(RichTextBox richTextBox1)
        {
            richTextBox1.AppendText("Done.");
            richTextBox1.AppendText(Environment.NewLine);
        }

        public static void EndCopying(RichTextBox richTextBox1)
        {
            richTextBox1.AppendText("Done.");
            richTextBox1.AppendText(Environment.NewLine);
        }

        public static void CopyErrorOccurred(RichTextBox richTextBox1)
        {
            richTextBox1.AppendText("Error: A file copy error occurred. Process has terminated.");
            richTextBox1.AppendText(Environment.NewLine);
        }
    }
}
