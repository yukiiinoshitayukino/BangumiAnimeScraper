using System;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

public class BangumiSearch
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<string> GetAnimeIdByNameAsync(string animeName)
    {
        string searchUrl = $"https://bangumi.tv/subject_search/{animeName}";

        try
        {
            // 发送GET请求到Bangumi搜索接口
            var response = await _httpClient.GetAsync(searchUrl);
            if (response.IsSuccessStatusCode)
            {
                string htmlContent = await response.Content.ReadAsStringAsync();

                // 解析HTML以提取动漫ID
                string animeId = ExtractAnimeIdFromHtml(htmlContent);
                return animeId;
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve content. Status Code: {response.StatusCode}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return null;
        }
    }

    private string ExtractAnimeIdFromHtml(string htmlContent)
    {
        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
        htmlDoc.LoadHtml(htmlContent);
        string Animeid= htmlDoc.DocumentNode.SelectSingleNode("//a[@class=['1']/@href").InnerText.Trim();



        //    // 使用XPath选择器定位包含动漫ID的元素
        //    // 注意：以下XPath仅为示例，需要根据实际页面结构进行调整
        //    var animeIdNode = htmlDoc.DocumentNode.SelectSingleNode("//a[@class=['1']/@href");
        //    if (animeIdNode != null)
        //    {



        //        //string animeId = animeIdNode.GetAttributeValue("href", string.Empty); // 第二个参数是默认值，如果属性不存在
        //        //                                                                      // 解析 animeId 字符串以获取实际的ID
        //        //                                                                      // Bangumi 的 URL 结构通常是 https://bgm.tv/subject/ID
        //        //int id = int.Parse(animeId.Split('/')[2]); // 根据URL结构调整索引
        //        //string ID = $"{id}";
        //        //return ID ;
        //    }

        //    return null;
        //}
    }

