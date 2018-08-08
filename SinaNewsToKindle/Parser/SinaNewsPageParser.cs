namespace SinaNewsToKindle
{
    static class SinaNewsPageParser
    {
        private const string ArticleStart = "<div class=\"article\" id=\"article\">";
        private const string ArticleEnd = "<p class=\"show_author\">";
        public static SinaNewsBody Parse(SinaNewsHeader header)
        {
            string page = Client.GET(header.Url);
            int startP = page.IndexOf(ArticleStart) + ArticleStart.Length;
            int endP = page.IndexOf(ArticleEnd, startP);
            string article = page.Substring(startP, endP - startP);

            return new SinaNewsBody(header.Tittle, header.Description, article);
        }
    }
}
