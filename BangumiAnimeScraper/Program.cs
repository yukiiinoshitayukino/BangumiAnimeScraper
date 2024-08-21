using BangumiAnimeScraper;
using System.Security.Policy;

class Program
{
    static async Task Main(string[] args)
    {
        Form1 form= new Form1();
        
         Application.Run(form);
        //获取用户的输入信息
        //string animeName = form.GetUserInput();
        string animeName = "虫师 动画";




        BangumiSearch GetId=new BangumiSearch();
        //在此定义了subjectId，并且在下面被引用
        string subjectId;
        //得到id，调用了await异步方法
        subjectId = await GetId.GetAnimeIdByNameAsync(animeName);

        IHtmlParser htmlParser = new HtmlParser();

        var scraperService = new ScraperService(htmlParser);

       

        var animeInfo = await scraperService.ScrapeAnimeInfoAsync(subjectId);
        string FirstUrl = "https:";
        string URL;
        URL = FirstUrl + animeInfo.CoverImageUrl;
       
        string test = "https://lain.bgm.tv/pic/cover/l/e4/dc/464376_NsZRw.jpg";
        Uri TEST = new Uri(URL);
        string imageUrlString = TEST.ToString();


            Console.WriteLine($"Title: {animeInfo.Title}");
            // 其他信息输出...

            // 下载封面图片
            string imagePath = $"C:\\Users\\夹击妹抖\\Documents\\{animeName}.jpg";
            await ImageDownloader.DownloadImageAsync(imageUrlString, imagePath);
        
    }
}