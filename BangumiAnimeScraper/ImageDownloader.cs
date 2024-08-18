using BangumiAnimeScraper;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using static IHtmlParser;
using static System.Net.WebRequestMethods;


public class ImageDownloader
{
    
    public static async Task DownloadImageAsync(string imageUrl, string savePath)
    {
        
        

        using (var client = new WebClient())
        {
           

            await client.DownloadFileTaskAsync(new Uri(imageUrl), savePath);
        }
    }
}
