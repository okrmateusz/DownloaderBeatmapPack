using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace DownloaderBeatmapPack
{
    public partial class Form1 : Form
    {
        private readonly FileDownloader fileDownloader;
        private CancellationTokenSource cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
            fileDownloader = new FileDownloader();
            cancellationTokenSource = new CancellationTokenSource();
            labelPath.Text = Properties.Settings.Default.pathToSave;
            this.Text = "Osu Beatmap Downloader";
            newLine("Set the path to save the files first! Settings > Save Path");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async void downloadButton_Click(object sender, EventArgs e)
        {
            List<string> links = GenerateDownloadLinks();

            if (links.Count == 0)
            {
                errorLine("No download links");
                labelStatus.Text = "Status: Error";
                return;
            }
            // Wyłączamy przycisk, aby uniknąć wielokrotnego klikania
            downloadButton.Enabled = false;
            cancelButton.Enabled = true;

            try
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = links.Count;
                progressBar1.Value = 0;

                labelStatus.Text = "Status: Downloading...";
                newLine("Download started");
                for (int i = 0; i < links.Count; i++)
                {
                    string link = links[i];
                    string fileName = GetFileNameFromUrl(link);
                    string destinationPath = GetDestinationPath(fileName);

                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = 100;
                    progressBar2.Value = 0;

                    await fileDownloader.DownloadFileAsync(link, destinationPath, cancellationTokenSource.Token, progress =>
                    {
                        // Aktualizuj progressBar2 na podstawie postępu pobierania
                        progressBar2.Invoke((MethodInvoker)(() =>
                        {
                            progressBar2.Value = (int)(progress * 100);
                        }));
                    });

                    progressBar1.Value = i + 1;


                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        break;
                    }
                }
                labelStatus.Text = "Status: Download complete";
                newLine("The download is complete");
            }
            catch (Exception ex)
            {
                labelStatus.Text = "Status: Error";
                errorLine($"An error occurred while downloading the file: {ex.Message}");
            }

            // Włączamy ponownie przycisk
            downloadButton.Enabled = true;
            cancelButton.Enabled = false;
            progressBar1.Value = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            errorLine("Download canceled");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownFrom.Value > numericUpDownTo.Value)
            {
                errorLine("Wrong value");
                numericUpDownFrom.Value = numericUpDownTo.Value;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownFrom.Value > numericUpDownTo.Value)
            {
                errorLine("Wrong value");
                numericUpDownFrom.Value = numericUpDownTo.Value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private List<string> GenerateDownloadLinks()
        {
            labelStatus.Text = "Status: Generate request";
            newLine("Link generation");
            List<string> links = new List<string>();
            int from = (int) numericUpDownFrom.Value;
            int to = (int) numericUpDownTo.Value;
            string formatFile = (from > 1299) ? ".zip" : ".7z";

            for (int i = from; i <= to; i++)
            {
                string tempPath = $"https://packs.ppy.sh/S{i}%20-%20Beatmap%20Pack%20%23{i}{formatFile}";
                newLine("Links generated: " + tempPath);
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
            newLine("Save Path: "+ Properties.Settings.Default.pathToSave);
            string destinationDirectory = Properties.Settings.Default.pathToSave;
            return Path.Combine(destinationDirectory, fileName);
        }
        public void errorLine(string textError)
        {
            DateTime currentTime = DateTime.Now;
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;
            textBox.SelectionColor = Color.Red;
            textBox.AppendText("[" + currentTime + "] " + textError + Environment.NewLine);
            textBox.SelectionColor = textBox.ForeColor; // Przywróć domyślny kolor tekstu
        }
        public void newLine(string textLine)
        {
            DateTime currentTime = DateTime.Now;
            textBox.AppendText("[" + currentTime + "] " + textLine + Environment.NewLine);
        }

        private void savePathToolStripMenuItem_Click(object sender, EventArgs e)
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


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
