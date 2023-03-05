using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Vista_File_Mover
{
    public partial class FileMoverForm : Form
    {
        //FileTransfer list and selected FileTransfer object
        BindingList<FileTransfer> fileTransfers = new BindingList<FileTransfer>();
        FileTransfer selectedTransfer;

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
        private void Form1_Load(object sender, EventArgs e)
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
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
#endregion

        #region StartTransfer Button
        private void btnStartTransfer_Click(object sender, EventArgs e)
        {
            //If worker isn't running then start worker, otherwise stop worker
            if (!fileTransferWorker.IsBusy)
            {
                fileTransferWorker.RunWorkerAsync(fileTransfers);
                btnStartTransfer.Text = "Cancel";

                //Disable controls while copying files
                gbFileTransfers.Enabled = false;
                gbTransferSettings.Enabled = false;
                gbStartDate.Enabled = false;
                gbEndDate.Enabled = false;
                newToolStripMenuItem.Enabled = false;
                openToolStripMenuItem.Enabled = false;
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
            tbTransferLog.AppendText(text + Environment.NewLine);
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
        private void copyFiles(BindingList<FileTransfer> transfers, BackgroundWorker worker, DoWorkEventArgs e)
        {
            //Check that the transfers are not empty
            if (transfers.Count == 0)
            {
                throw new ArgumentException("You must add transfers to be completed!");
            }

            int counter = 0;

            //Loop through all transfers
            foreach (FileTransfer transfer in transfers)
            {
                if (transfer.transferEnabled)
                {
                    worker.ReportProgress((int)((float)(counter / transfers.Count()) * 100), transfer.transferName + ": Transfer Starting.");

                    //Check that source and destination directories are valid
                    if (!Directory.Exists(transfer.source))
                    {
                        worker.ReportProgress((int)((float)(counter / transfers.Count()) * 100), transfer.transferName + ": Unable to access source directory!");
                    }

                    if (!Directory.Exists(transfer.destination))
                    {
                        worker.ReportProgress((int)((float)(counter / transfers.Count()) * 100), transfer.transferName + ": Unable to access destination directory!");
                    }

                    //Instantiate glob matcher
                    Matcher matcher = new Matcher();

                    //If no copy filters then incude everything otherwise set filters as needed
                    if (transfer.copyFilters.Count == 0)
                    {
                        matcher.AddInclude("**/*.*");
                    }
                    else
                    {
                        foreach (Filter copyFilter in transfer.copyFilters)
                        {
                            if (copyFilter.filterSource.Equals("Filename"))
                            {
                                if (copyFilter.filterStyle.Equals("Contains"))
                                {
                                    matcher.AddInclude("**/**" + copyFilter.filterKey + "*");
                                }
                                else if (copyFilter.filterStyle.Equals("Not Contains"))
                                {
                                    matcher.AddExclude("**/**" + copyFilter.filterKey + "*");
                                }
                                else if (copyFilter.filterStyle == "Extension")
                                {
                                    matcher.AddInclude("**/**" + copyFilter.filterKey);
                                }
                            }
                        }
                    }

                    //Get files using glob
                    IEnumerable<String> fileList = matcher.GetResultsInFullPath(transfer.source);

                    //Loop through date range
                    foreach (DateTime date in getDateRange(dtpStartDate.Value, dtpEndDate.Value))
                    {
                        //Create a folder in the destination for current date
                        DirectoryInfo currDirectory = Directory.CreateDirectory(transfer.destination + '/' + date.ToString("yyyy-MM-dd"));

                        //If we have no groupFilters then copy all files with the current date
                        if (transfer.groupFilters.Count == 0)
                        {
                            foreach (String file in fileList)
                            {
                                if (File.GetLastWriteTime(file).Date == date.Date && !File.Exists(currDirectory.FullName + "\\" + Path.GetFileName(file)))
                                {
                                    File.Copy(file, currDirectory.FullName + "\\" + Path.GetFileName(file));
                                }
                            }
                        }
                        else
                        {
                            foreach (Filter filter in transfer.groupFilters)
                            {
                                //Create a directory for the group
                                currDirectory = Directory.CreateDirectory(transfer.destination + '/' + date.ToString("yyyy-MM-dd") + '/' + filter.filterKey);

                                foreach (String file in fileList)
                                {
                                    //Check if the files fit the filter and copy if they do
                                    if (filter.filterStyle.Equals("Contains") && file.Contains(filter.filterKey))
                                    {
                                        if (File.GetLastWriteTime(file).Date == date.Date && !File.Exists(currDirectory.FullName + "\\" + Path.GetFileName(file)))
                                        {
                                            File.Copy(file, currDirectory.FullName + "\\" + Path.GetFileName(file));
                                        }
                                    }
                                    else if (filter.filterStyle.Equals("Not Contains") && !file.Contains(filter.filterKey))
                                    {
                                        if (File.GetLastWriteTime(file).Date == date.Date && !File.Exists(currDirectory.FullName + "\\" + Path.GetFileName(file)))
                                        {
                                            File.Copy(file, currDirectory.FullName + "\\" + Path.GetFileName(file));
                                        }
                                    }
                                    else if (filter.filterStyle == "Extension" && file.EndsWith(filter.filterKey))
                                    {
                                        if (File.GetLastWriteTime(file).Date == date.Date && !File.Exists(currDirectory.FullName + "\\" + Path.GetFileName(file)))
                                        {
                                            File.Copy(file, currDirectory.FullName + "\\" + Path.GetFileName(file));
                                        }
                                    }
                                }

                            }
                        }
                    }
                    counter++;
                    worker.ReportProgress((int)((float)(counter / transfers.Count()) * 100), transfer.transferName + ": Transfer Complete.");
                }
                else
                {
                    counter++;
                    worker.ReportProgress((int)((float)(counter / transfers.Count()) * 100), transfer.transferName + ": Transfer Disabled.");
                }
            }
            return;
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
            BindingList<FileTransfer> asyncTransfers = e.Argument as BindingList<FileTransfer>;
            BackgroundWorker worker = sender as BackgroundWorker;

            worker.ReportProgress(0, "Starting File Transfers...");

            //Start file transfer
            copyFiles(asyncTransfers, worker, e);

            worker.ReportProgress(100, "File Transfers Complete!");
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
        }

        private void fileTransferWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Update progress bar
            pbFileTransfer.Value = e.ProgressPercentage;

            //Log message
            log((string)e.UserState);
        }
        #endregion
    }
}
