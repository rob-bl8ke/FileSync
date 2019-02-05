namespace FileSync
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.colTargetTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWorking = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.btnCheck = new System.Windows.Forms.ToolStripButton();
            this.btnUncheck = new System.Windows.Forms.ToolStripButton();
            this.btnCopyRight = new System.Windows.Forms.Button();
            this.btnCopyLeft = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGetDifferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenTargetFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenWorkingFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopyTargetFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyWorkingFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUncheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCreateWorkingPaths = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyTargetFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyWorkingFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopyRight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMissingTargetsCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextUncheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContextGetDifferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContextOpenTargetFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextOpenWorkingFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContextCopyTargetFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextCopyWorkingFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMergeProjectFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.itemSyncBox1 = new FileSync.ItemSyncBox();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTargetTitle,
            this.colTarget,
            this.colWorking});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 52);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(890, 340);
            this.listView1.SmallImageList = this.imageList;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // colTargetTitle
            // 
            this.colTargetTitle.Text = "Title";
            this.colTargetTitle.Width = 217;
            // 
            // colTarget
            // 
            this.colTarget.Text = "Target";
            this.colTarget.Width = 543;
            // 
            // colWorking
            // 
            this.colWorking.Text = "Working";
            this.colWorking.Width = 480;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.btnCreate,
            this.btnCheck,
            this.btnUncheck});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(914, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(96, 22);
            this.btnOpen.Text = "Open Project";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 22);
            this.btnSave.Text = "Save Project";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(101, 22);
            this.btnCreate.Text = "Create Project";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck.Image")));
            this.btnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(60, 22);
            this.btnCheck.Text = "Check";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnUncheck
            // 
            this.btnUncheck.Image = ((System.Drawing.Image)(resources.GetObject("btnUncheck.Image")));
            this.btnUncheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(73, 22);
            this.btnUncheck.Text = "Uncheck";
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // btnCopyRight
            // 
            this.btnCopyRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyRight.Location = new System.Drawing.Point(12, 398);
            this.btnCopyRight.Name = "btnCopyRight";
            this.btnCopyRight.Size = new System.Drawing.Size(87, 153);
            this.btnCopyRight.TabIndex = 3;
            this.btnCopyRight.UseVisualStyleBackColor = true;
            this.btnCopyRight.Click += new System.EventHandler(this.btnCopyRight_Click);
            // 
            // btnCopyLeft
            // 
            this.btnCopyLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyLeft.Location = new System.Drawing.Point(815, 398);
            this.btnCopyLeft.Name = "btnCopyLeft";
            this.btnCopyLeft.Size = new System.Drawing.Size(87, 153);
            this.btnCopyLeft.TabIndex = 4;
            this.btnCopyLeft.UseVisualStyleBackColor = true;
            this.btnCopyLeft.Click += new System.EventHandler(this.btnCopyLeft_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(105, 398);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(704, 155);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuOpenRecent,
            this.mnuCreate,
            this.toolStripMenuItem1,
            this.mnuSave,
            this.toolStripMenuItem4,
            this.mnuMergeProjectFiles,
            this.toolStripMenuItem9,
            this.mnuQuit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(183, 22);
            this.mnuOpen.Text = "Open...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuOpenRecent
            // 
            this.mnuOpenRecent.Name = "mnuOpenRecent";
            this.mnuOpenRecent.Size = new System.Drawing.Size(183, 22);
            this.mnuOpenRecent.Text = "Open Recent";
            // 
            // mnuCreate
            // 
            this.mnuCreate.Name = "mnuCreate";
            this.mnuCreate.Size = new System.Drawing.Size(183, 22);
            this.mnuCreate.Text = "Create...";
            this.mnuCreate.Click += new System.EventHandler(this.mnuCreate_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(183, 22);
            this.mnuSave.Text = "Save...";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuQuit
            // 
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuQuit.Size = new System.Drawing.Size(183, 22);
            this.mnuQuit.Text = "Quit";
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddItem,
            this.mnuDeleteItem,
            this.toolStripMenuItem5,
            this.mnuGetDifferences,
            this.toolStripMenuItem7,
            this.mnuOpenTargetFolder,
            this.mnuOpenWorkingFolder,
            this.toolStripMenuItem8,
            this.mnuCopyTargetFilePath,
            this.mnuCopyWorkingFilePath});
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // mnuAddItem
            // 
            this.mnuAddItem.Name = "mnuAddItem";
            this.mnuAddItem.Size = new System.Drawing.Size(198, 22);
            this.mnuAddItem.Text = "Add";
            this.mnuAddItem.Click += new System.EventHandler(this.mnuAddItem_Click);
            // 
            // mnuDeleteItem
            // 
            this.mnuDeleteItem.Name = "mnuDeleteItem";
            this.mnuDeleteItem.Size = new System.Drawing.Size(198, 22);
            this.mnuDeleteItem.Text = "Delete";
            this.mnuDeleteItem.Click += new System.EventHandler(this.mnuDeleteItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuGetDifferences
            // 
            this.mnuGetDifferences.Name = "mnuGetDifferences";
            this.mnuGetDifferences.Size = new System.Drawing.Size(198, 22);
            this.mnuGetDifferences.Text = "Get Differences...";
            this.mnuGetDifferences.Click += new System.EventHandler(this.mnuGetDifferences_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuOpenTargetFolder
            // 
            this.mnuOpenTargetFolder.Name = "mnuOpenTargetFolder";
            this.mnuOpenTargetFolder.Size = new System.Drawing.Size(198, 22);
            this.mnuOpenTargetFolder.Text = "Open Target Folder";
            this.mnuOpenTargetFolder.Click += new System.EventHandler(this.mnuOpenTargetFolder_Click);
            // 
            // mnuOpenWorkingFolder
            // 
            this.mnuOpenWorkingFolder.Name = "mnuOpenWorkingFolder";
            this.mnuOpenWorkingFolder.Size = new System.Drawing.Size(198, 22);
            this.mnuOpenWorkingFolder.Text = "Open Working Folder";
            this.mnuOpenWorkingFolder.Click += new System.EventHandler(this.mnuOpenWorkingFolder_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuCopyTargetFilePath
            // 
            this.mnuCopyTargetFilePath.Name = "mnuCopyTargetFilePath";
            this.mnuCopyTargetFilePath.Size = new System.Drawing.Size(198, 22);
            this.mnuCopyTargetFilePath.Text = "Copy Target File Path";
            this.mnuCopyTargetFilePath.Click += new System.EventHandler(this.mnuCopyTargetFilePath_Click);
            // 
            // mnuCopyWorkingFilePath
            // 
            this.mnuCopyWorkingFilePath.Name = "mnuCopyWorkingFilePath";
            this.mnuCopyWorkingFilePath.Size = new System.Drawing.Size(198, 22);
            this.mnuCopyWorkingFilePath.Text = "Copy Working File Path";
            this.mnuCopyWorkingFilePath.Click += new System.EventHandler(this.mnuCopyWorkingFilePath_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheck,
            this.mnuUncheck,
            this.toolStripMenuItem2,
            this.mnuCreateWorkingPaths,
            this.mnuCopyTargetFolders,
            this.mnuCopyWorkingFolders,
            this.toolStripMenuItem3,
            this.mnuCopyRight,
            this.mnuCopyLeft,
            this.toolStripMenuItem6,
            this.mnuMissingTargetsCheck});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // mnuCheck
            // 
            this.mnuCheck.Name = "mnuCheck";
            this.mnuCheck.Size = new System.Drawing.Size(240, 22);
            this.mnuCheck.Text = "Check";
            this.mnuCheck.Click += new System.EventHandler(this.mnuCheck_Click);
            // 
            // mnuUncheck
            // 
            this.mnuUncheck.Name = "mnuUncheck";
            this.mnuUncheck.Size = new System.Drawing.Size(240, 22);
            this.mnuUncheck.Text = "Uncheck";
            this.mnuUncheck.Click += new System.EventHandler(this.mnuUncheck_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(237, 6);
            // 
            // mnuCreateWorkingPaths
            // 
            this.mnuCreateWorkingPaths.Name = "mnuCreateWorkingPaths";
            this.mnuCreateWorkingPaths.Size = new System.Drawing.Size(240, 22);
            this.mnuCreateWorkingPaths.Text = "Create\\Modify Working Paths...";
            this.mnuCreateWorkingPaths.Click += new System.EventHandler(this.mnuCreateWorkingPaths_Click);
            // 
            // mnuCopyTargetFolders
            // 
            this.mnuCopyTargetFolders.Name = "mnuCopyTargetFolders";
            this.mnuCopyTargetFolders.Size = new System.Drawing.Size(240, 22);
            this.mnuCopyTargetFolders.Text = "Copy Target Folders";
            this.mnuCopyTargetFolders.Click += new System.EventHandler(this.mnuCopyTargetFolders_Click);
            // 
            // mnuCopyWorkingFolders
            // 
            this.mnuCopyWorkingFolders.Name = "mnuCopyWorkingFolders";
            this.mnuCopyWorkingFolders.Size = new System.Drawing.Size(240, 22);
            this.mnuCopyWorkingFolders.Text = "Copy Working Folders";
            this.mnuCopyWorkingFolders.Click += new System.EventHandler(this.mnuCopyWorkingFolders_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(237, 6);
            // 
            // mnuCopyRight
            // 
            this.mnuCopyRight.Name = "mnuCopyRight";
            this.mnuCopyRight.Size = new System.Drawing.Size(240, 22);
            this.mnuCopyRight.Text = "Copy Right";
            this.mnuCopyRight.Click += new System.EventHandler(this.mnuCopyRight_Click);
            // 
            // mnuCopyLeft
            // 
            this.mnuCopyLeft.Name = "mnuCopyLeft";
            this.mnuCopyLeft.Size = new System.Drawing.Size(240, 22);
            this.mnuCopyLeft.Text = "Copy Left";
            this.mnuCopyLeft.Click += new System.EventHandler(this.mnuCopyLeft_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(237, 6);
            // 
            // mnuMissingTargetsCheck
            // 
            this.mnuMissingTargetsCheck.Name = "mnuMissingTargetsCheck";
            this.mnuMissingTargetsCheck.Size = new System.Drawing.Size(240, 22);
            this.mnuMissingTargetsCheck.Text = "Check for Missing Target Files";
            this.mnuMissingTargetsCheck.Click += new System.EventHandler(this.mnuMissingTargetsCheck_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(116, 22);
            this.mnuHelp.Text = "About...";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextCheck,
            this.mnuContextUncheck,
            this.toolStripMenuItem13,
            this.mnuContextGetDifferences,
            this.toolStripMenuItem12,
            this.mnuContextOpenTargetFolder,
            this.mnuContextOpenWorkingFolder,
            this.toolStripMenuItem11,
            this.mnuContextCopyTargetFilePath,
            this.mnuContextCopyWorkingFilePath,
            this.toolStripMenuItem10,
            this.mnuContextDelete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(199, 204);
            // 
            // mnuContextCheck
            // 
            this.mnuContextCheck.Name = "mnuContextCheck";
            this.mnuContextCheck.Size = new System.Drawing.Size(198, 22);
            this.mnuContextCheck.Text = "Check";
            this.mnuContextCheck.Click += new System.EventHandler(this.mnuContextCheck_Click);
            // 
            // mnuContextUncheck
            // 
            this.mnuContextUncheck.Name = "mnuContextUncheck";
            this.mnuContextUncheck.Size = new System.Drawing.Size(198, 22);
            this.mnuContextUncheck.Text = "Uncheck";
            this.mnuContextUncheck.Click += new System.EventHandler(this.mnuContextUncheck_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuContextGetDifferences
            // 
            this.mnuContextGetDifferences.Name = "mnuContextGetDifferences";
            this.mnuContextGetDifferences.Size = new System.Drawing.Size(198, 22);
            this.mnuContextGetDifferences.Text = "Get Differences...";
            this.mnuContextGetDifferences.Click += new System.EventHandler(this.mnuContextGetDifferences_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuContextOpenTargetFolder
            // 
            this.mnuContextOpenTargetFolder.Name = "mnuContextOpenTargetFolder";
            this.mnuContextOpenTargetFolder.Size = new System.Drawing.Size(198, 22);
            this.mnuContextOpenTargetFolder.Text = "Open Target Folder";
            this.mnuContextOpenTargetFolder.Click += new System.EventHandler(this.mnuContextOpenTargetFolder_Click);
            // 
            // mnuContextOpenWorkingFolder
            // 
            this.mnuContextOpenWorkingFolder.Name = "mnuContextOpenWorkingFolder";
            this.mnuContextOpenWorkingFolder.Size = new System.Drawing.Size(198, 22);
            this.mnuContextOpenWorkingFolder.Text = "Open Working Folder";
            this.mnuContextOpenWorkingFolder.Click += new System.EventHandler(this.mnuContextOpenWorkingFolder_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuContextCopyTargetFilePath
            // 
            this.mnuContextCopyTargetFilePath.Name = "mnuContextCopyTargetFilePath";
            this.mnuContextCopyTargetFilePath.Size = new System.Drawing.Size(198, 22);
            this.mnuContextCopyTargetFilePath.Text = "Copy Target File Path";
            this.mnuContextCopyTargetFilePath.Click += new System.EventHandler(this.mnuContextCopyTargetFilePath_Click);
            // 
            // mnuContextCopyWorkingFilePath
            // 
            this.mnuContextCopyWorkingFilePath.Name = "mnuContextCopyWorkingFilePath";
            this.mnuContextCopyWorkingFilePath.Size = new System.Drawing.Size(198, 22);
            this.mnuContextCopyWorkingFilePath.Text = "Copy Working File Path";
            this.mnuContextCopyWorkingFilePath.Click += new System.EventHandler(this.mnuContextCopyWorkingFilePath_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuContextDelete
            // 
            this.mnuContextDelete.Name = "mnuContextDelete";
            this.mnuContextDelete.Size = new System.Drawing.Size(198, 22);
            this.mnuContextDelete.Text = "Delete";
            this.mnuContextDelete.Click += new System.EventHandler(this.mnuContextDelete_Click);
            // 
            // mnuMergeProjectFiles
            // 
            this.mnuMergeProjectFiles.Enabled = false;
            this.mnuMergeProjectFiles.Name = "mnuMergeProjectFiles";
            this.mnuMergeProjectFiles.Size = new System.Drawing.Size(183, 22);
            this.mnuMergeProjectFiles.Text = "Merge Project Files...";
            this.mnuMergeProjectFiles.Click += new System.EventHandler(this.mnuMergeProjectFiles_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(180, 6);
            // 
            // itemSyncBox1
            // 
            this.itemSyncBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemSyncBox1.CurrentSyncItem = null;
            this.itemSyncBox1.Location = new System.Drawing.Point(0, 550);
            this.itemSyncBox1.Name = "itemSyncBox1";
            this.itemSyncBox1.Size = new System.Drawing.Size(914, 63);
            this.itemSyncBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 612);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnCopyLeft);
            this.Controls.Add(this.btnCopyRight);
            this.Controls.Add(this.itemSyncBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colTarget;
        private System.Windows.Forms.ColumnHeader colWorking;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ItemSyncBox itemSyncBox1;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.Button btnCopyRight;
        private System.Windows.Forms.Button btnCopyLeft;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ColumnHeader colTargetTitle;
        private System.Windows.Forms.ToolStripButton btnCheck;
        private System.Windows.Forms.ToolStripButton btnUncheck;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuCreate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCheck;
        private System.Windows.Forms.ToolStripMenuItem mnuUncheck;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateWorkingPaths;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuGetDifferences;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyTargetFolders;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyRight;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyLeft;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyWorkingFolders;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenTargetFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenWorkingFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyTargetFilePath;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyWorkingFilePath;
        private System.Windows.Forms.ToolStripMenuItem mnuMissingTargetsCheck;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenRecent;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuContextGetDifferences;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem mnuContextOpenTargetFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuContextOpenWorkingFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem mnuContextCopyTargetFilePath;
        private System.Windows.Forms.ToolStripMenuItem mnuContextCopyWorkingFilePath;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem mnuContextDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuContextCheck;
        private System.Windows.Forms.ToolStripMenuItem mnuContextUncheck;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem mnuMergeProjectFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
    }
}

