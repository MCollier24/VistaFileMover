namespace Vista_File_Mover
{
    partial class FileMoverForm
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
            this.applicationMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbFileTransfers = new System.Windows.Forms.GroupBox();
            this.dgvFileTransfers = new System.Windows.Forms.DataGridView();
            this.transferContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.panelProgressBar = new System.Windows.Forms.Panel();
            this.pbFileTransfer = new System.Windows.Forms.ProgressBar();
            this.btnStartTransfer = new System.Windows.Forms.Button();
            this.tlpSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbTransferSettings = new System.Windows.Forms.GroupBox();
            this.tlpTransferSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbTransferSource = new System.Windows.Forms.GroupBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.tbTransferSource = new System.Windows.Forms.TextBox();
            this.gbTransferDestination = new System.Windows.Forms.GroupBox();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.tbTransferDestination = new System.Windows.Forms.TextBox();
            this.gbNameFilters = new System.Windows.Forms.GroupBox();
            this.dgvCopyFilters = new System.Windows.Forms.DataGridView();
            this.gbItemFilters = new System.Windows.Forms.GroupBox();
            this.dgvGroupFilters = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbEndDate = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.gbStartDate = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbTransferLog = new System.Windows.Forms.TextBox();
            this.tlpMainWindow = new System.Windows.Forms.TableLayoutPanel();
            this.folderBrowserDialog = new System.Windows.Forms.OpenFileDialog();
            this.openTransferFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveTransferFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fileTransferWorker = new System.ComponentModel.BackgroundWorker();
            this.applicationMenuStrip.SuspendLayout();
            this.gbFileTransfers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransfers)).BeginInit();
            this.transferContextMenuStrip.SuspendLayout();
            this.panelProgressBar.SuspendLayout();
            this.tlpSettings.SuspendLayout();
            this.gbTransferSettings.SuspendLayout();
            this.tlpTransferSettings.SuspendLayout();
            this.gbTransferSource.SuspendLayout();
            this.gbTransferDestination.SuspendLayout();
            this.gbNameFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopyFilters)).BeginInit();
            this.gbItemFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupFilters)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbEndDate.SuspendLayout();
            this.gbStartDate.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tlpMainWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // applicationMenuStrip
            // 
            this.applicationMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.applicationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.applicationMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.applicationMenuStrip.Name = "applicationMenuStrip";
            this.applicationMenuStrip.Size = new System.Drawing.Size(800, 28);
            this.applicationMenuStrip.TabIndex = 1;
            this.applicationMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // gbFileTransfers
            // 
            this.gbFileTransfers.Controls.Add(this.dgvFileTransfers);
            this.gbFileTransfers.Controls.Add(this.btnAddSource);
            this.gbFileTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFileTransfers.Location = new System.Drawing.Point(3, 3);
            this.gbFileTransfers.Name = "gbFileTransfers";
            this.gbFileTransfers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbFileTransfers.Size = new System.Drawing.Size(194, 373);
            this.gbFileTransfers.TabIndex = 1;
            this.gbFileTransfers.TabStop = false;
            this.gbFileTransfers.Text = "Transfer Sources";
            // 
            // dgvFileTransfers
            // 
            this.dgvFileTransfers.AllowUserToAddRows = false;
            this.dgvFileTransfers.AllowUserToResizeColumns = false;
            this.dgvFileTransfers.AllowUserToResizeRows = false;
            this.dgvFileTransfers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvFileTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileTransfers.ContextMenuStrip = this.transferContextMenuStrip;
            this.dgvFileTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFileTransfers.Location = new System.Drawing.Point(3, 18);
            this.dgvFileTransfers.MultiSelect = false;
            this.dgvFileTransfers.Name = "dgvFileTransfers";
            this.dgvFileTransfers.RowHeadersVisible = false;
            this.dgvFileTransfers.RowHeadersWidth = 51;
            this.dgvFileTransfers.RowTemplate.Height = 24;
            this.dgvFileTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileTransfers.Size = new System.Drawing.Size(188, 322);
            this.dgvFileTransfers.TabIndex = 2;
            this.dgvFileTransfers.SelectionChanged += new System.EventHandler(this.dgvFileTransfers_SelectionChanged);
            this.dgvFileTransfers.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvFileTransfers_UserDeletedRow);
            // 
            // transferContextMenuStrip
            // 
            this.transferContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.transferContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.transferContextMenuStrip.Name = "contextMenuStrip1";
            this.transferContextMenuStrip.Size = new System.Drawing.Size(113, 52);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // btnAddSource
            // 
            this.btnAddSource.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddSource.Location = new System.Drawing.Point(3, 340);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(188, 30);
            this.btnAddSource.TabIndex = 1;
            this.btnAddSource.Text = "Add Source";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // panelProgressBar
            // 
            this.tlpMainWindow.SetColumnSpan(this.panelProgressBar, 2);
            this.panelProgressBar.Controls.Add(this.pbFileTransfer);
            this.panelProgressBar.Controls.Add(this.btnStartTransfer);
            this.panelProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgressBar.Location = new System.Drawing.Point(3, 382);
            this.panelProgressBar.Name = "panelProgressBar";
            this.panelProgressBar.Size = new System.Drawing.Size(794, 37);
            this.panelProgressBar.TabIndex = 0;
            // 
            // pbFileTransfer
            // 
            this.pbFileTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFileTransfer.Location = new System.Drawing.Point(0, 0);
            this.pbFileTransfer.Name = "pbFileTransfer";
            this.pbFileTransfer.Size = new System.Drawing.Size(697, 37);
            this.pbFileTransfer.TabIndex = 1;
            // 
            // btnStartTransfer
            // 
            this.btnStartTransfer.AutoSize = true;
            this.btnStartTransfer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStartTransfer.Location = new System.Drawing.Point(697, 0);
            this.btnStartTransfer.Name = "btnStartTransfer";
            this.btnStartTransfer.Size = new System.Drawing.Size(97, 37);
            this.btnStartTransfer.TabIndex = 0;
            this.btnStartTransfer.Text = "Start Transfer";
            this.btnStartTransfer.UseVisualStyleBackColor = true;
            this.btnStartTransfer.Click += new System.EventHandler(this.btnStartTransfer_Click);
            // 
            // tlpSettings
            // 
            this.tlpSettings.ColumnCount = 2;
            this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings.Controls.Add(this.gbTransferSettings, 0, 0);
            this.tlpSettings.Controls.Add(this.groupBox2, 1, 0);
            this.tlpSettings.Controls.Add(this.groupBox3, 1, 1);
            this.tlpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSettings.Location = new System.Drawing.Point(203, 3);
            this.tlpSettings.Name = "tlpSettings";
            this.tlpSettings.RowCount = 2;
            this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings.Size = new System.Drawing.Size(594, 373);
            this.tlpSettings.TabIndex = 2;
            // 
            // gbTransferSettings
            // 
            this.gbTransferSettings.Controls.Add(this.tlpTransferSettings);
            this.gbTransferSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTransferSettings.Location = new System.Drawing.Point(3, 3);
            this.gbTransferSettings.Name = "gbTransferSettings";
            this.tlpSettings.SetRowSpan(this.gbTransferSettings, 2);
            this.gbTransferSettings.Size = new System.Drawing.Size(291, 367);
            this.gbTransferSettings.TabIndex = 0;
            this.gbTransferSettings.TabStop = false;
            this.gbTransferSettings.Text = "Transfer Settings";
            // 
            // tlpTransferSettings
            // 
            this.tlpTransferSettings.ColumnCount = 1;
            this.tlpTransferSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTransferSettings.Controls.Add(this.gbTransferSource, 0, 0);
            this.tlpTransferSettings.Controls.Add(this.gbTransferDestination, 0, 1);
            this.tlpTransferSettings.Controls.Add(this.gbNameFilters, 0, 2);
            this.tlpTransferSettings.Controls.Add(this.gbItemFilters, 0, 3);
            this.tlpTransferSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTransferSettings.Enabled = false;
            this.tlpTransferSettings.Location = new System.Drawing.Point(3, 18);
            this.tlpTransferSettings.Name = "tlpTransferSettings";
            this.tlpTransferSettings.RowCount = 4;
            this.tlpTransferSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTransferSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTransferSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTransferSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTransferSettings.Size = new System.Drawing.Size(285, 346);
            this.tlpTransferSettings.TabIndex = 0;
            // 
            // gbTransferSource
            // 
            this.gbTransferSource.AutoSize = true;
            this.gbTransferSource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbTransferSource.Controls.Add(this.btnBrowseSource);
            this.gbTransferSource.Controls.Add(this.tbTransferSource);
            this.gbTransferSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTransferSource.Location = new System.Drawing.Point(3, 3);
            this.gbTransferSource.Name = "gbTransferSource";
            this.gbTransferSource.Size = new System.Drawing.Size(279, 66);
            this.gbTransferSource.TabIndex = 0;
            this.gbTransferSource.TabStop = false;
            this.gbTransferSource.Text = "Source Directory";
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSource.AutoSize = true;
            this.btnBrowseSource.Location = new System.Drawing.Point(198, 19);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 26);
            this.btnBrowseSource.TabIndex = 1;
            this.btnBrowseSource.Text = "Browse";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // tbTransferSource
            // 
            this.tbTransferSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTransferSource.Location = new System.Drawing.Point(6, 21);
            this.tbTransferSource.Name = "tbTransferSource";
            this.tbTransferSource.Size = new System.Drawing.Size(186, 22);
            this.tbTransferSource.TabIndex = 0;
            // 
            // gbTransferDestination
            // 
            this.gbTransferDestination.AutoSize = true;
            this.gbTransferDestination.Controls.Add(this.btnBrowseDestination);
            this.gbTransferDestination.Controls.Add(this.tbTransferDestination);
            this.gbTransferDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTransferDestination.Location = new System.Drawing.Point(3, 75);
            this.gbTransferDestination.Name = "gbTransferDestination";
            this.gbTransferDestination.Size = new System.Drawing.Size(279, 65);
            this.gbTransferDestination.TabIndex = 1;
            this.gbTransferDestination.TabStop = false;
            this.gbTransferDestination.Text = "Destination Directory";
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDestination.AutoSize = true;
            this.btnBrowseDestination.Location = new System.Drawing.Point(198, 18);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(75, 26);
            this.btnBrowseDestination.TabIndex = 3;
            this.btnBrowseDestination.Text = "Browse";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // tbTransferDestination
            // 
            this.tbTransferDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTransferDestination.Location = new System.Drawing.Point(6, 20);
            this.tbTransferDestination.Name = "tbTransferDestination";
            this.tbTransferDestination.Size = new System.Drawing.Size(186, 22);
            this.tbTransferDestination.TabIndex = 2;
            // 
            // gbNameFilters
            // 
            this.gbNameFilters.Controls.Add(this.dgvCopyFilters);
            this.gbNameFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbNameFilters.Location = new System.Drawing.Point(3, 146);
            this.gbNameFilters.Name = "gbNameFilters";
            this.gbNameFilters.Size = new System.Drawing.Size(279, 95);
            this.gbNameFilters.TabIndex = 2;
            this.gbNameFilters.TabStop = false;
            this.gbNameFilters.Text = "Copy Filters";
            // 
            // dgvCopyFilters
            // 
            this.dgvCopyFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCopyFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCopyFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCopyFilters.Location = new System.Drawing.Point(3, 18);
            this.dgvCopyFilters.MultiSelect = false;
            this.dgvCopyFilters.Name = "dgvCopyFilters";
            this.dgvCopyFilters.RowHeadersVisible = false;
            this.dgvCopyFilters.RowHeadersWidth = 51;
            this.dgvCopyFilters.RowTemplate.Height = 24;
            this.dgvCopyFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCopyFilters.Size = new System.Drawing.Size(273, 74);
            this.dgvCopyFilters.TabIndex = 0;
            // 
            // gbItemFilters
            // 
            this.gbItemFilters.Controls.Add(this.dgvGroupFilters);
            this.gbItemFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbItemFilters.Location = new System.Drawing.Point(3, 247);
            this.gbItemFilters.Name = "gbItemFilters";
            this.gbItemFilters.Size = new System.Drawing.Size(279, 96);
            this.gbItemFilters.TabIndex = 3;
            this.gbItemFilters.TabStop = false;
            this.gbItemFilters.Text = "Grouping Filters";
            // 
            // dgvGroupFilters
            // 
            this.dgvGroupFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroupFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupFilters.Location = new System.Drawing.Point(3, 18);
            this.dgvGroupFilters.MultiSelect = false;
            this.dgvGroupFilters.Name = "dgvGroupFilters";
            this.dgvGroupFilters.RowHeadersVisible = false;
            this.dgvGroupFilters.RowHeadersWidth = 51;
            this.dgvGroupFilters.RowTemplate.Height = 24;
            this.dgvGroupFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupFilters.Size = new System.Drawing.Size(273, 75);
            this.dgvGroupFilters.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbEndDate);
            this.groupBox2.Controls.Add(this.gbStartDate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(300, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 180);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Global Settings";
            // 
            // gbEndDate
            // 
            this.gbEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEndDate.AutoSize = true;
            this.gbEndDate.Controls.Add(this.dtpEndDate);
            this.gbEndDate.Location = new System.Drawing.Point(3, 82);
            this.gbEndDate.Name = "gbEndDate";
            this.gbEndDate.Size = new System.Drawing.Size(289, 54);
            this.gbEndDate.TabIndex = 1;
            this.gbEndDate.TabStop = false;
            this.gbEndDate.Text = "End Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy/MM/dd hh\':\'mm tt";
            this.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEndDate.Location = new System.Drawing.Point(3, 18);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(283, 22);
            this.dtpEndDate.TabIndex = 0;
            // 
            // gbStartDate
            // 
            this.gbStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStartDate.AutoSize = true;
            this.gbStartDate.Controls.Add(this.dtpStartDate);
            this.gbStartDate.Location = new System.Drawing.Point(3, 18);
            this.gbStartDate.Name = "gbStartDate";
            this.gbStartDate.Size = new System.Drawing.Size(285, 64);
            this.gbStartDate.TabIndex = 0;
            this.gbStartDate.TabStop = false;
            this.gbStartDate.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy/MM/dd hh\':\'mm tt";
            this.dtpStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStartDate.Location = new System.Drawing.Point(3, 18);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(279, 22);
            this.dtpStartDate.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbTransferLog);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(300, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 181);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // tbTransferLog
            // 
            this.tbTransferLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTransferLog.Location = new System.Drawing.Point(3, 18);
            this.tbTransferLog.Multiline = true;
            this.tbTransferLog.Name = "tbTransferLog";
            this.tbTransferLog.ReadOnly = true;
            this.tbTransferLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTransferLog.Size = new System.Drawing.Size(285, 160);
            this.tbTransferLog.TabIndex = 0;
            // 
            // tlpMainWindow
            // 
            this.tlpMainWindow.ColumnCount = 2;
            this.tlpMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpMainWindow.Controls.Add(this.tlpSettings, 1, 0);
            this.tlpMainWindow.Controls.Add(this.panelProgressBar, 0, 1);
            this.tlpMainWindow.Controls.Add(this.gbFileTransfers, 0, 0);
            this.tlpMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainWindow.Location = new System.Drawing.Point(0, 28);
            this.tlpMainWindow.Name = "tlpMainWindow";
            this.tlpMainWindow.RowCount = 2;
            this.tlpMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMainWindow.Size = new System.Drawing.Size(800, 422);
            this.tlpMainWindow.TabIndex = 2;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.FileName = "openFileDialog1";
            // 
            // openTransferFileDialog
            // 
            this.openTransferFileDialog.DefaultExt = "json";
            this.openTransferFileDialog.FileName = "openFileDialog2";
            this.openTransferFileDialog.Filter = "JSON Files|*.json";
            this.openTransferFileDialog.Title = "Select Transfer JSON File";
            // 
            // saveTransferFileDialog
            // 
            this.saveTransferFileDialog.DefaultExt = "json";
            this.saveTransferFileDialog.Filter = "JSON Files|*.json";
            this.saveTransferFileDialog.Title = "Save Current Transfer";
            // 
            // fileTransferWorker
            // 
            this.fileTransferWorker.WorkerReportsProgress = true;
            this.fileTransferWorker.WorkerSupportsCancellation = true;
            this.fileTransferWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fileTransferWorker_DoWork);
            this.fileTransferWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fileTransferWorker_ProgressChanged);
            this.fileTransferWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileTransferWorker_RunWorkerCompleted);
            // 
            // FileMoverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMainWindow);
            this.Controls.Add(this.applicationMenuStrip);
            this.MainMenuStrip = this.applicationMenuStrip;
            this.Name = "FileMoverForm";
            this.Text = "Vista File Mover";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.applicationMenuStrip.ResumeLayout(false);
            this.applicationMenuStrip.PerformLayout();
            this.gbFileTransfers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransfers)).EndInit();
            this.transferContextMenuStrip.ResumeLayout(false);
            this.panelProgressBar.ResumeLayout(false);
            this.panelProgressBar.PerformLayout();
            this.tlpSettings.ResumeLayout(false);
            this.gbTransferSettings.ResumeLayout(false);
            this.tlpTransferSettings.ResumeLayout(false);
            this.tlpTransferSettings.PerformLayout();
            this.gbTransferSource.ResumeLayout(false);
            this.gbTransferSource.PerformLayout();
            this.gbTransferDestination.ResumeLayout(false);
            this.gbTransferDestination.PerformLayout();
            this.gbNameFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopyFilters)).EndInit();
            this.gbItemFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupFilters)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbEndDate.ResumeLayout(false);
            this.gbStartDate.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tlpMainWindow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip applicationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbFileTransfers;
        private System.Windows.Forms.DataGridView dgvFileTransfers;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Panel panelProgressBar;
        private System.Windows.Forms.TableLayoutPanel tlpMainWindow;
        private System.Windows.Forms.TableLayoutPanel tlpSettings;
        private System.Windows.Forms.GroupBox gbTransferSettings;
        private System.Windows.Forms.TableLayoutPanel tlpTransferSettings;
        private System.Windows.Forms.GroupBox gbTransferSource;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox tbTransferSource;
        private System.Windows.Forms.GroupBox gbTransferDestination;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.TextBox tbTransferDestination;
        private System.Windows.Forms.GroupBox gbNameFilters;
        private System.Windows.Forms.GroupBox gbItemFilters;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbTransferLog;
        private System.Windows.Forms.ProgressBar pbFileTransfer;
        private System.Windows.Forms.Button btnStartTransfer;
        private System.Windows.Forms.OpenFileDialog folderBrowserDialog;
        private System.Windows.Forms.DataGridView dgvCopyFilters;
        private System.Windows.Forms.DataGridView dgvGroupFilters;
        private System.Windows.Forms.GroupBox gbEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.GroupBox gbStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.OpenFileDialog openTransferFileDialog;
        private System.Windows.Forms.SaveFileDialog saveTransferFileDialog;
        private System.Windows.Forms.ContextMenuStrip transferContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker fileTransferWorker;
    }
}

