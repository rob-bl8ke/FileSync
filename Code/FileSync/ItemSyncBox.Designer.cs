namespace FileSync
{
    partial class ItemSyncBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browseWorkingFile = new FileSync.FileBrowseBox();
            this.browseTargetFile = new FileSync.FileBrowseBox();
            this.SuspendLayout();
            // 
            // browseWorkingFile
            // 
            this.browseWorkingFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browseWorkingFile.File = "";
            this.browseWorkingFile.Location = new System.Drawing.Point(3, 35);
            this.browseWorkingFile.Name = "browseWorkingFile";
            this.browseWorkingFile.Size = new System.Drawing.Size(745, 26);
            this.browseWorkingFile.TabIndex = 1;
            // 
            // browseTargetFile
            // 
            this.browseTargetFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browseTargetFile.File = "";
            this.browseTargetFile.Location = new System.Drawing.Point(3, 3);
            this.browseTargetFile.Name = "browseTargetFile";
            this.browseTargetFile.Size = new System.Drawing.Size(745, 26);
            this.browseTargetFile.TabIndex = 0;
            // 
            // ItemSyncBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browseWorkingFile);
            this.Controls.Add(this.browseTargetFile);
            this.Name = "ItemSyncBox";
            this.Size = new System.Drawing.Size(751, 64);
            this.ResumeLayout(false);

        }

        #endregion

        private FileBrowseBox browseTargetFile;
        private FileBrowseBox browseWorkingFile;
    }
}
