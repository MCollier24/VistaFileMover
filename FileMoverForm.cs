﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista_File_Mover
{
    public partial class FileMoverForm : Form
    {
        //FileTransfer list and selected FileTransfer object
        BindingList<FileTransfer> fileTransfers = new BindingList<FileTransfer>();
        FileTransfer selectedTransfer, copiedTransfer;

        //Filter and grouping data grid columns
        DataGridViewTextBoxColumn copyFilterSource = new DataGridViewTextBoxColumn();
        DataGridViewComboBoxColumn copyFilterType = new DataGridViewComboBoxColumn();
        DataGridViewTextBoxColumn copyFilterKey = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn groupFilterSource = new DataGridViewTextBoxColumn();
        DataGridViewComboBoxColumn groupFilterType = new DataGridViewComboBoxColumn();
        DataGridViewTextBoxColumn groupFilterKey = new DataGridViewTextBoxColumn();

        public FileMoverForm()
        {
            InitializeComponent();
        }

        #region Form Opening/Closing
        private void FileMoverForm_Load(object sender, EventArgs e)
        {
            //Load the cached JSON file
            loadTransfer(Directory.GetCurrentDirectory() + "\\previous.json");

            //Intialize file transfer datagrid
            dgvFileTransfers.DataSource = fileTransfers;
            foreach (DataGridViewColumn column in dgvFileTransfers.Columns)
            {
                column.Visible = false;
            }
            dgvFileTransfers.Columns["transferEnabled"].Visible = true;
            dgvFileTransfers.Columns["transferEnabled"].DisplayIndex = 0;
            dgvFileTransfers.Columns["transferEnabled"].HeaderText = "Enabled";
            dgvFileTransfers.Columns["transferEnabled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvFileTransfers.Columns["transferName"].Visible = true;
            dgvFileTransfers.Columns["transferName"].DisplayIndex = 1;
            dgvFileTransfers.Columns["transferName"].HeaderText = "Name";
            dgvFileTransfers.Columns["transferName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Setup folder selector
            folderBrowserDialog.ValidateNames = false;
            folderBrowserDialog.CheckFileExists = false;
            folderBrowserDialog.CheckPathExists = true;
            folderBrowserDialog.Multiselect = false;
            folderBrowserDialog.FileName = "Select Folder";
            folderBrowserDialog.Filter = "Folders|n";
        }

        private void FileMoverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save the current transfer to a JSON file
            saveTransfer(Directory.GetCurrentDirectory() + "\\previous.json");
        }
        #endregion

        #region Transfer Menu Manipulation
        private void btnAddSource_Click(object sender, EventArgs e)
        {
            //Add a new file transfer
            newFileTransfer();
        }

        private void newFileTransfer()
        {
            //Add a new FileTransfer object to the list, set selected row to the new row
            fileTransfers.Add(new FileTransfer("Transfer" + fileTransfers.Count.ToString()));

            dgvFileTransfers.ClearSelection();
            dgvFileTransfers.Rows[dgvFileTransfers.Rows.Count - 1].Selected = true;

            log("File Transfer Added");
        }

        private void dgvFileTransfers_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //Feedback that transfer was deleted
            log("File Transfer Removed");
        }

        private void dgvFileTransfers_SelectionChanged(object sender, EventArgs e)
        {
            // If selection is valid update selected transfer and display new settings
            if (dgvFileTransfers.SelectedRows.Count == 1)
            {
                //Show current transfer settings and enable controls
                selectedTransfer = (FileTransfer)(dgvFileTransfers.SelectedRows[0].DataBoundItem);
                tlpTransferSettings.Enabled = true;
                updateTransferSettings();
            }
            else
            {
                //Clear selected transfer and disable controls
                selectedTransfer = null;
                tlpTransferSettings.Enabled = false;
                clearTransferSettings();
            }
        }

        private void dgvFileTransfers_MouseClick(object sender, MouseEventArgs e)
        {
            //Select row by right-click
            if (e.Button != MouseButtons.Right)
                return;

            DataGridView dgv = (DataGridView)sender;

            dgv.ClearSelection();

            int rowIndex = dgv.HitTest(e.X, e.Y).RowIndex;

            if (rowIndex != -1)
            {
                dgv.Rows[rowIndex].Selected = true;
            }

            transferContextMenuStrip.Show(Cursor.Position);
        }
        #endregion

        #region StartTransfer Button
        private void btnStartTransfer_Click(object sender, EventArgs e)
        {
            //If worker isn't running then start worker, otherwise stop worker
            if (!fileTransferWorker.IsBusy)
            {
                IEnumerable<FileTransfer> enabledTransfers =
                        from transfer in fileTransfers
                        where transfer.transferEnabled
                        select transfer;

                //Check that the transfers are not empty
                if (enabledTransfers.Count() == 0)
                {
                    log("No Transfers Enabled: Please add/enable some transfers!");
                }
                else
                {
                    FileTransferArgs transferArgs = new FileTransferArgs(enabledTransfers, dtpStartDate.Value, dtpEndDate.Value);

                    fileTransferWorker.RunWorkerAsync(transferArgs);
                    btnStartTransfer.Text = "Cancel";

                    //Disable controls while copying files
                    gbFileTransfers.Enabled = false;
                    gbTransferSettings.Enabled = false;
                    gbStartDate.Enabled = false;
                    gbEndDate.Enabled = false;
                    newToolStripMenuItem.Enabled = false;
                    openToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                fileTransferWorker.CancelAsync();
            }
        }
        #endregion

        #region Source/Destination Browsers
        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Title = "Select Source Folder";

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbTransferSource.Text = folderBrowserDialog.FileName.Substring(0, folderBrowserDialog.FileName.Length - "\\SelectFolder".Length);
                foreach (Binding dataBind in tbTransferSource.DataBindings)
                {
                    dataBind.BindingManagerBase.EndCurrentEdit();
                }
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Title = "Select Destination Folder";

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbTransferDestination.Text = folderBrowserDialog.FileName.Substring(0, folderBrowserDialog.FileName.Length - "\\SelectFolder".Length);
                foreach (Binding dataBind in tbTransferDestination.DataBindings)
                {
                    dataBind.BindingManagerBase.EndCurrentEdit();
                }
            }
        }
        #endregion

        #region Transfer Settings Menus
        private void updateTransferSettings()
        {
            //Clear current transfer settings
            clearTransferSettings();

            //Bind transfer source/destination elements
            tbTransferSource.DataBindings.Add("Text", selectedTransfer, "source");
            tbTransferDestination.DataBindings.Add("Text", selectedTransfer, "destination");

            //Display filter settings
            dgvCopyFilters.AutoGenerateColumns = false;
            dgvCopyFilters.DataSource = selectedTransfer.copyFilters;

            copyFilterSource.DataPropertyName = "filterSource";
            copyFilterSource.Name = "Source";
            copyFilterSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            copyFilterSource.ReadOnly = true;
            dgvCopyFilters.Columns.Add(copyFilterSource);

            copyFilterType.DataSource = Filter.filterStyles;
            copyFilterType.DataPropertyName = "filterStyle";
            copyFilterType.Name = "Type";
            copyFilterType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCopyFilters.Columns.Add(copyFilterType);

            copyFilterKey.DataPropertyName = "filterKey";
            copyFilterKey.Name = "Key";
            copyFilterKey.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCopyFilters.Columns.Add(copyFilterKey);

            //Display grouping settings
            dgvGroupFilters.AutoGenerateColumns = false;
            dgvGroupFilters.DataSource = selectedTransfer.groupFilters;

            groupFilterSource.DataPropertyName = "filterSource";
            groupFilterSource.Name = "Source";
            groupFilterSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            groupFilterSource.ReadOnly = true;
            dgvGroupFilters.Columns.Add(groupFilterSource);

            groupFilterType.DataSource = Filter.filterStyles;
            groupFilterType.DataPropertyName = "filterStyle";
            groupFilterType.Name = "Type";
            groupFilterType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGroupFilters.Columns.Add(groupFilterType);

            groupFilterKey.DataPropertyName = "filterKey";
            groupFilterKey.Name = "Key";
            groupFilterKey.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGroupFilters.Columns.Add(groupFilterKey);
        }

        private void clearTransferSettings()
        {
            //Clear all transfer specific elements
            tbTransferSource.DataBindings.Clear();
            tbTransferSource.Clear();

            tbTransferDestination.DataBindings.Clear();
            tbTransferDestination.Clear();

            dgvCopyFilters.DataBindings.Clear();
            dgvCopyFilters.Columns.Clear();

            dgvGroupFilters.DataBindings.Clear();
            dgvGroupFilters.Columns.Clear();
        }
        #endregion

        #region Logging
        public void log(string text)
        {
            tbTransferLog.AppendText($"{DateTime.Now.ToLongTimeString()}: {text}{Environment.NewLine}");
        }
        #endregion

        #region Transfer JSON File Save/Load
        private void saveTransfer(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileTransfersJSON = JsonSerializer.Serialize<BindingList<FileTransfer>>(fileTransfers, options);
            File.WriteAllText(filePath, fileTransfersJSON);
        }

        private void loadTransfer(string filePath)
        {
            // If the specified file exists then deserialize into fileTransfers
            if (File.Exists(filePath))
            {
                tbTransferLog.Clear();
                string jsonString = File.ReadAllText(filePath);
                fileTransfers = JsonSerializer.Deserialize<BindingList<FileTransfer>>(jsonString);
                log("Succesfully loaded transfer file: " + filePath);
                dgvFileTransfers.DataSource = fileTransfers;
            }
        }
        #endregion

        #region CopyFiles Method
        private void copyFiles(IEnumerable<FileTransfer> transfers, DateTime startDate, DateTime endDate, bool groupByDate, BackgroundWorker worker, DoWorkEventArgs e)
        {
            //Generate a range of DateTime dates between startDate and endDate
            IEnumerable<DateTime> dateRange = getDateRange(startDate, endDate);

            //Loop through file transfers
            foreach (FileTransfer transfer in transfers)
            {
                //Check for cancellation
                if (checkCancellation(worker, e))
                    return;

                worker.ReportProgress(0, $"{transfer.transferName} - Transfer Started");

                DirectoryInfo sourceDirectory = new DirectoryInfo(transfer.source);
                DirectoryInfo destinationDirectory = new DirectoryInfo(transfer.destination);

                //Check that source and destination exist
                if (!sourceDirectory.Exists)
                {
                    worker.ReportProgress(0, $"{transfer.transferName} - Unable to access source directory!");
                    continue;
                }
                if (!destinationDirectory.Exists)
                {
                    worker.ReportProgress(0, $"{transfer.transferName} - Unable to access destination directory!");
                    continue;
                }

                //File counting
                int filesChecked = 0;
                int fileCount = int.MaxValue;

                worker.ReportProgress(0, $"CountReset");

#if DEBUG
                DateTime startTime = System.DateTime.Now;
#endif

                Task<int> fileCountTask = Task.Run(() => {
                    int count = 0;

                    foreach (DirectoryInfo dir in sourceDirectory.EnumerateDirectories("*", SearchOption.AllDirectories).Where(x => x.LastWriteTime.Date >= startDate.Date && x.LastWriteTime.Date <= endDate.Date).AsParallel())
                    {
                        count += dir.EnumerateFiles().Where(f => f.LastWriteTime.Date >= startDate.Date && f.LastWriteTime.Date <= endDate.Date).AsParallel().Count();
                    }

                    return count;
                });

                foreach (DirectoryInfo d in sourceDirectory.EnumerateDirectories("*", SearchOption.AllDirectories).Where(x => x.LastWriteTime.Date >= startDate.Date && x.LastWriteTime.Date <= endDate.Date))
                {
                    if (checkCancellation(worker, e))
                        return;

#if DEBUG
                    //Debug.WriteLine($"Checking Folder - {d.Name}", "COPY");
#endif
                    
                    //Loop through files in the source directory of the current transfer
                    foreach (FileInfo f in d.EnumerateFiles())
                    {
                        //Check for cancellation
                        if (checkCancellation(worker, e))
                            return;

                        if (f.LastWriteTime.Date < startDate.Date || f.LastWriteTime.Date > endDate.Date)
                        {
                            continue;
                        }

                        string fullFilename = f.FullName;
                        string shortFilename = f.Name;

#if DEBUG
                        //Debug.WriteLine($"Copying - {shortFilename}", "COPY");
#endif

                        //Get date of current file  
                        DateTime currentDate = File.GetLastWriteTime(fullFilename).Date;

                        //Apply all copy filters
                        Boolean passFilter = true;
                        foreach (Filter filter in transfer.copyFilters)
                        {
                            if (!filter.apply(shortFilename))
                                passFilter = false;
                        }

                        //If copy filters passed then copy into grouped destination folder
                        if (passFilter)
                        {
                            string currentDatePath;
                            if (groupByDate)
                            {
                                string currentDateString = currentDate.ToString("yyyy-MM-dd");
                                currentDatePath = transfer.destination + "\\" + currentDateString;
                            }
                            else
                            {
                                currentDatePath = transfer.destination;
                            }
                            Boolean copied = false;
                            //Apply group filters, copy into group folder if passed group filter
                            foreach (Filter filter in transfer.groupFilters)
                            {
                                if (filter.apply(shortFilename))
                                {
                                    string filterPath = currentDatePath + "\\" + filter.filterKey;
                                    Directory.CreateDirectory(filterPath);
                                    if (!File.Exists(filterPath + "\\" + shortFilename))
                                    {
                                        //Task.Run(() => File.Copy(fullFilename, filterPath + "\\" + shortFilename));
                                        File.Copy(fullFilename, filterPath + "\\" + shortFilename);
                                    }
                                    copied = true;
                                }
                            }

                            //If file not copied to a group folder copy to the general date folder
                            if (!copied)
                            {
                                Directory.CreateDirectory(currentDatePath);
                                if (!File.Exists(currentDatePath + "\\" + shortFilename))
                                {
                                    //Task.Run(() => File.Copy(fullFilename, currentDatePath + "\\" + shortFilename));
                                    File.Copy(fullFilename, currentDatePath + "\\" + shortFilename);
                                }
                            }
                        }

                        if (fileCountTask.IsCompleted && fileCount == int.MaxValue)
                        {
                            fileCount = fileCountTask.Result;
                            worker.ReportProgress(filesChecked * 100 / fileCount, "CountCompleted");
                            fileCountTask.Dispose();
#if DEBUG
                            Debug.WriteLine($"Time to count files: {DateTime.Now - startTime}", "TIMER");
#endif
                        }

                        worker.ReportProgress(++filesChecked * 100 / fileCount);
                    }
                }

                worker.ReportProgress(100,  $"{transfer.transferName} - Transfer Complete.");
            }
        }
        #endregion

        #region getDateRange Method
        public IEnumerable<DateTime> getDateRange(DateTime start, DateTime end)
        {
            for (DateTime day = start.Date; day.Date <= end.Date; day = day.AddDays(1))
                yield return day;
        }
        #endregion

        #region ToolStrip Menu Items (File->Open/Save/Load)
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear file transfers and clear file log
            fileTransfers.Clear();
            tbTransferLog.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get user to select a transfer .json file and load the file
            DialogResult result = openTransferFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadTransfer(openTransferFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get user to select a location for the .json file and save
            DialogResult result = saveTransferFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Write current transfer to JSON file
                saveTransfer(saveTransferFileDialog.FileName);
            }
        }
        #endregion

        #region FileTransferWorker
        private void fileTransferWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            FileTransferArgs transferArgs = e.Argument as FileTransferArgs;

            IEnumerable<FileTransfer> asyncTransfers = transferArgs.transfers;
            DateTime startDate = transferArgs.startDate;
            DateTime endDate = transferArgs.endDate;


            worker.ReportProgress(0, "Starting File Transfers...");

            //Start file transfer
            copyFiles(asyncTransfers, startDate, endDate, cbGroupByDate.Checked, worker, e);
        }

        private void fileTransferWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Reset button state
            btnStartTransfer.Text = "Start Transfer";

            //Re-enable controls after copying files
            gbFileTransfers.Enabled = true;
            gbTransferSettings.Enabled = true;
            gbStartDate.Enabled = true;
            gbEndDate.Enabled = true;
            newToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = true;

            pbFileTransfer.Value = 100;
            pbFileTransfer.Style = ProgressBarStyle.Continuous;

            //Check results
            if (e.Cancelled)
            {
                log("File Transfer Cancelled!");
            }
            else if (e.Error != null)
            {
                log("ERROR: " + e.Error.Message);
            }
            else
            {
                log("File Transfers Completed!");
            }
        }

        private void fileTransferWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Update progress bar
            if (pbFileTransfer.Style == ProgressBarStyle.Continuous)
            {
                if (e.ProgressPercentage >= 100)
                {
                    pbFileTransfer.Value = 100;
                }
                else if (e.ProgressPercentage <= 0)
                {
                    pbFileTransfer.Value = 0;
                }
                else
                {
                    pbFileTransfer.Value = e.ProgressPercentage;
                }
            }

            //Log message
            if (e.UserState != null)
            {
                string message = (string)e.UserState;

                if (message == "CountCompleted")
                {
                    pbFileTransfer.Style = ProgressBarStyle.Continuous;
                }
                else if (message == "CountReset")
                {
                    pbFileTransfer.Style = ProgressBarStyle.Marquee;
                }
                else
                {
                    log(message);
                }
            }

        }

        private class FileTransferArgs
        {
            public IEnumerable<FileTransfer> transfers { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }

            public FileTransferArgs(IEnumerable<FileTransfer> transfers, DateTime startDate, DateTime endDate)
            {
                this.transfers = transfers;
                this.startDate = startDate;
                this.endDate = endDate;
            }
        }

        private bool checkCancellation(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Copy/Paste Transfers

        private void copySelectedTransfer()
        {
            copiedTransfer = selectedTransfer;
        }

        private void pasteTransfer()
        {
            if (copiedTransfer != null)
            {
                fileTransfers.Add(copiedTransfer.Clone());
                log("File Transfer Pasted!");
            }
        }
        #endregion

        #region FileTransfer Context Menu

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copySelectedTransfer();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteTransfer();
        }

        private void transferContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //Disable copy/paste unless items are selected/copied
            transferContextMenuStrip.Items[0].Enabled = false;
            transferContextMenuStrip.Items[1].Enabled = false;

            if (selectedTransfer != null)
                transferContextMenuStrip.Items[0].Enabled = true;

            if (copiedTransfer != null)
                transferContextMenuStrip.Items[1].Enabled = true;
        }
        #endregion

        #region Form Key Events
        private void FileMoverForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Check for Ctrl+C
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (selectedTransfer != null && ActiveControl == dgvFileTransfers)
                    copySelectedTransfer();
            }

            //Check for Ctrl+V
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (ActiveControl == dgvFileTransfers)
                    pasteTransfer();
            }
        }
        #endregion
    }
}
