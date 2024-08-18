using BangumiAnimeScraper;
using HtmlAgilityPack;
using static System.Net.WebRequestMethods;

public interface IHtmlParser
{
    AnimeInfo ParseAnimeInfo(string htmlContent);
}

public class HtmlParser : IHtmlParser
{
    public AnimeInfo ParseAnimeInfo(string htmlContent)
    {
        var animeInfo = new AnimeInfo();
        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
        htmlDoc.LoadHtml(htmlContent);
        var ratingNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='number']");
        if (ratingNode != null)
        {
            // 如果节点存在，获取其InnerText并去除空白字符
            animeInfo.Rating = ratingNode.InnerText.Trim();
        }
        else
        {
            // 如果节点不存在，记录错误或设置默认值
            Console.WriteLine("未找到评分节点。");
            animeInfo.Rating = "未知"; // 或其他默认值
        }



        animeInfo.Title = htmlDoc.DocumentNode.SelectSingleNode("//title").InnerText.Trim();
        
     
        animeInfo.Episodes = htmlDoc.DocumentNode.SelectSingleNode("//li/span[@class='tip'][1]").InnerText.Trim();
        animeInfo.CoverImageUrl = htmlDoc.DocumentNode.SelectSingleNode("//a[@class='thickbox cover']/@href").InnerText.Trim();
        // 其他字段解析同理...
        //我问了ai大人才知道的。。。。。。
        //同理个毛啊，我不懂html。。。。。

        return animeInfo;
    }
}
