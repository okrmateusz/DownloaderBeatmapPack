using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace DownloaderBeatmapPack
{
    internal static class Program
    {

        public static string currentVersion = "0.0.1.0";
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string latestVersion = GetLatestVersion();
            Console.WriteLine(latestVersion);
            string latestVersiontest = "0.0.1.0";

            if (currentVersion != null && latestVersion != currentVersion)
            {
                DialogResult result = MessageBox.Show("Update is available! Do you want to download update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string link = "http://mateuszokruch.pl";
                        Process.Start(link);
                    }
                    catch (Exception ex)
                    {
                        // Obsługa błędu, jeśli nie uda się otworzyć strony
                        MessageBox.Show("Wystąpił błąd: " + ex.Message);
                    }
                }
                else
                {

                }
            }
            string GetLatestVersion()
            {
                // Wykonaj żądanie do serwera, aby pobrać najnowszą wersję aplikacji
                // Zwróć pobraną wersję lub null, jeśli wystąpił błąd

                try
                {
                    using (var client = new WebClient())
                    {
                        string version = client.DownloadString("http://mateuszokruch.pl/downloads/obpd/latest-version.txt");
                        return version.Trim();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while downloading information about the latest version of the application: " + ex.Message);
                    return null;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
