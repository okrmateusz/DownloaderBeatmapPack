using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class FileDownloader
{
    private readonly HttpClient httpClient;

    public FileDownloader()
    {
        httpClient = new HttpClient();
    }

    public async Task DownloadFileAsync(string url, string destinationPath, CancellationToken cancellationToken, Action<double> progressCallback)
    {
        using (HttpResponseMessage response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
        {
            response.EnsureSuccessStatusCode();

            using (Stream contentStream = await response.Content.ReadAsStreamAsync())
            {
                long totalBytes = response.Content.Headers.ContentLength ?? -1;
                long downloadedBytes = 0;
                byte[] buffer = new byte[8192];
                int bytesRead;

                using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                        downloadedBytes += bytesRead;

                        if (totalBytes > 0 && progressCallback != null)
                        {
                            double progress = (double)downloadedBytes / totalBytes;
                            progressCallback.Invoke(progress);
                        }

                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }
            }
        }
    }
}