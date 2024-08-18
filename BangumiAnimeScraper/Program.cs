using BangumiAnimeScraper;
using System.Security.Policy;

class Program
{
    static async Task Main(string[] args)
    {
        Form1 form= new Form1();
        
        Application.Run(form);
        //��ȡ�û���������Ϣ
        string animeName = form.GetUserInput();


        BangumiSearch GetId=new BangumiSearch();
        //�ڴ˶�����subjectId�����������汻����
        string subjectId;
        //�õ�id��������await�첽����
        subjectId = await GetId.GetAnimeIdByNameAsync(animeName);

        IHtmlParser htmlParser = new HtmlParser();

        var scraperService = new ScraperService(htmlParser);

       // string subjectId = "464376";  ʾ�� ID������ʵ�������ȡ
        

        var animeInfo = await scraperService.ScrapeAnimeInfoAsync(subjectId);
        string FirstUrl = "https:";
        string URL;
        URL = FirstUrl + animeInfo.CoverImageUrl;
       
        string test = "https://lain.bgm.tv/pic/cover/l/e4/dc/464376_NsZRw.jpg";
        Uri TEST = new Uri(URL);
        string imageUrlString = TEST.ToString();


        if (animeInfo != null)
        {
            Console.WriteLine($"Title: {animeInfo.Title}");
            // ������Ϣ���...

            // ���ط���ͼƬ
            string imagePath = "C:\\Users\\�л��ö�\\Documents\\anime_cover1.jpg";
            await ImageDownloader.DownloadImageAsync(imageUrlString, imagePath);
        }
    }
}