using BangumiAnimeScraper;
using HtmlAgilityPack;


public class ScraperService
{
    private readonly IHtmlParser _htmlParser;

    public ScraperService(IHtmlParser htmlParser)
    {
        _htmlParser = htmlParser;
    }

    public async Task<AnimeInfo> ScrapeAnimeInfoAsync(string subjectId)
    {
        string url = $"https://bangumi.tv/subject/{subjectId}";
        string htmlContent = await FetchPageContentAsync(url);
        return _htmlParser.ParseAnimeInfo(htmlContent);
    }

    private async Task<string> FetchPageContentAsync(string url)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve content. Status Code: {response.StatusCode}");
            }
        }
    }
}