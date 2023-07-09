using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloaderBeatmapPack
{
    public partial class Form1 : Form
    {
        private readonly FileDownloader fileDownloader;
        private CancellationTokenSource cancellationTokenSource;

        private Boolean isLimit = true;
        private Boolean isExtract = false;
        private Boolean isDelete = false;
        public Form1()
        {
            InitializeComponent();
            getVersion();
            fileDownloader = new FileDownloader();
            cancellationTokenSource = new CancellationTokenSource();
            labelPath.Text = Properties.Settings.Default.pathToSave;
            stopButton.Enabled = false;
            this.Text = "Osu Beatmap Downloader";
            writeNewLine("Set the path to save the files first! Settings > Save Path");
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            List<string> links = GenerateDownloadLinks();

            if (links.Count == 0)
            {
                writeErrorLine("No download links");
                labelStatus.Text = "Status: Error";
                return;
            }
            downloadButton.Enabled = false;
            stopButton.Enabled = true;

            try
            {
                progressBarAll.Minimum = 0;
                progressBarAll.Maximum = links.Count;
                progressBarAll.Value = 0;


                writeNewLine("Download started");
                for (int i = 0; i < links.Count; i++)
                {
                    string link = links[i];
                    string fileName = GetFileNameFromUrl(link);
                    string destinationPath = GetDestinationPath(fileName);
                    labelStatus.Text = "Status: Downloading : " + i + "/" + links.Count;
                    labelProgressAll.Text = i + "/" + links.Count;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = 100;
                    progressBar.Value = 0;

                    await fileDownloader.DownloadFileAsync(link, destinationPath, cancellationTokenSource.Token, progress =>
                    {
                        progressBar.Invoke((MethodInvoker)(() =>
                        {
                            int progressPercentage = (int)(progress * 100);
                            progressBar.Value = progressPercentage;
                            labelProgress.Invoke((MethodInvoker)(() =>
                            {
                                labelProgress.Text = progressPercentage + "%";
                            }));
                        }));
                    });
                    progressBarAll.Value = i + 1;
                    if (isExtract)
                    {
                        if (Path.GetExtension(destinationPath).Equals(".zip", StringComparison.OrdinalIgnoreCase))
                        {
                            string extractPath = GetExtractPath(destinationPath);
                            await Task.Run(() =>
                            {
                                ZipFile.ExtractToDirectory(destinationPath, extractPath);
                            });
                        }
                        if (isExtract && Path.GetExtension(destinationPath).Equals(".7z", StringComparison.OrdinalIgnoreCase))
                        {
                            string extractPath = GetExtractPath(destinationPath);
                            if (!Directory.Exists(extractPath))
                            {
                                Directory.CreateDirectory(extractPath);
                            }
                            await Task.Run(() =>
                            {
                                using (var archive = ArchiveFactory.Open(destinationPath))
                                {
                                    foreach (var entry in archive.Entries)
                                    {
                                        if (!entry.IsDirectory)
                                        {
                                            entry.WriteToDirectory(extractPath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                                        }
                                    }
                                }
                            });
                        }
                    }
                    if (isExtract && isDelete)
                    {
                        try
                        {

                            if (File.Exists(destinationPath))
                            {
                                File.Delete(destinationPath);
                                writeNewLine("Plik został usunięty.");
                            }
                            else
                            {
                                writeNewLine("Plik nie istnieje.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Wystąpił błąd podczas usuwania pliku: {ex.Message}");
                        }
                    }


                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        break;
                    }
                }
                labelStatus.Text = "Status: Download complete";
                writeNewLine("The download is complete");
            }
            catch (Exception ex)
            {
                labelStatus.Text = "Status: Error";
                writeErrorLine($"An error occurred while downloading the file: {ex.Message}");
            }

            downloadButton.Enabled = true;
            stopButton.Enabled = false;
            progressBarAll.Value = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            writeErrorLine("Download canceled");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownFrom.Value > numericUpDownTo.Value)
            {
                numericUpDownTo.Value = numericUpDownFrom.Value;
            }
            if (isLimit)
            {
                if ((numericUpDownTo.Value - numericUpDownFrom.Value) > 200)
                {
                    numericUpDownTo.Value = numericUpDownFrom.Value + 200;
                    writeErrorLine("Max limit links is 200! Click checkbox limit to: disabled for disable limits");
                }
            }

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownFrom.Value > numericUpDownTo.Value)
            {
                numericUpDownFrom.Value = numericUpDownTo.Value;
            }
            if (isLimit)
            {
                if ((numericUpDownTo.Value - numericUpDownFrom.Value) > 200)
                {
                    numericUpDownFrom.Value = numericUpDownTo.Value - 200;
                    writeErrorLine("Max limit links is 200! Click checkbox limit to: disabled for disable limits");
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private List<string> GenerateDownloadLinks()
        {
            labelStatus.Text = "Status: Generate request";
            writeNewLine("Link generation");
            List<string> links = new List<string>();
            int from = (int)numericUpDownFrom.Value;
            int to = (int)numericUpDownTo.Value;
            string formatFile = (from > 1299) ? ".zip" : ".7z";

            for (int i = from; i <= to; i++)
            {
                string tempPath = $"https://packs.ppy.sh/S{i}%20-%20Beatmap%20Pack%20%23{i}{formatFile}";
                writeNewLine("Links generated: " + tempPath);
                links.Add(tempPath);
            }

            return links;
        }

        private string GetFileNameFromUrl(string url)
        {
            Uri uri = new Uri(url);
            return uri.Segments[uri.Segments.Length - 1];
        }
        private string GetDestinationPath(string fileName)
        {
            writeNewLine("Save Path: " + Properties.Settings.Default.pathToSave + "\\" + fileName);
            string destinationDirectory = Properties.Settings.Default.pathToSave;
            return Path.Combine(destinationDirectory, fileName);
        }
        public void writeErrorLine(string textError)
        {
            DateTime currentTime = DateTime.Now;
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;
            textBox.SelectionColor = Color.Red;
            textBox.AppendText("[" + currentTime + "] " + textError + Environment.NewLine);
            textBox.SelectionColor = textBox.ForeColor;
        }
        public void writeNewLine(string textLine)
        {
            DateTime currentTime = DateTime.Now;
            textBox.AppendText("[" + currentTime + "] " + textLine + Environment.NewLine);
        }
        private void savePathToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public static string ShowFolderDialog()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    return folderDialog.SelectedPath;
                }
            }

            return null;
        }

        public void getVersion()
        {
            toolStripMenuItemVersion.Text = "0.0.1.0";
        }
        private string GetExtractPath(string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string directory = Path.GetDirectoryName(filePath);
            string extractPath = Path.Combine(directory, "extracted_songs");
            return extractPath;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string link = "http://mateuszokruch.pl";
            Process.Start(link);
        }
        private void limitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (limitToolStripMenuItem.Checked == true)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to do this? This is highly not recommended!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    limitToolStripMenuItem.Checked = false;
                    isLimit = false;

                    numericUpDownFrom.Value = 1;
                    numericUpDownTo.Value = 1;

                    statusLimitLabel.Text = "Limit is disabled!";
                    statusLimitLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                limitToolStripMenuItem.Checked = true;
                isLimit = true;
                numericUpDownFrom.Value = 1;
                numericUpDownTo.Value = 1;

                statusLimitLabel.Text = "Limit is enabled!";
                statusLimitLabel.ForeColor = Color.Black;
            }
        }

        private void changePathButton_Click(object sender, EventArgs e)
        {
            string folderPath = ShowFolderDialog();
            if (!string.IsNullOrEmpty(folderPath))
            {
                Properties.Settings.Default.pathToSave = folderPath;
                Properties.Settings.Default.Save();
                string getPath = Properties.Settings.Default.pathToSave;
                labelPath.Text = "Path Save: " + getPath;
                Console.WriteLine("Selected location to save the file: " + getPath);
            }
            else
            {
                Console.WriteLine("No path");
            }
        }

        private void extractFile_CheckedChanged(object sender, EventArgs e)
        {
            extractFileAndDeleteCheckbox.Checked = false;
            isExtract = true;
            isDelete = false;
        }
        private void extractFileAndDelete_CheckedChanged(object sender, EventArgs e)
        {
            extractFileCheckbox.Checked = false;
            isExtract = true;
            isDelete = true;
        }
    }
}
