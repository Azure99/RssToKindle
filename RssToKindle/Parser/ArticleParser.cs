using HtmlAgilityPack;
using RssToKindle.Utils;

namespace RssToKindle.Parser
{
    static class ArticleParser
    {
        public static string Parse(string html, string url = "")
        {
            url = url.ToLower();

            if (url.IndexOf("daily.zhihu.com") != -1)
            {
                return GeneralParse(html, "//div[@class='content']");
            }
            else if (url.IndexOf("news.sina.com.cn") != -1)
            {
                return GeneralParse(html, "//div[@class='article']");
            }
            else if (url.IndexOf("column.chinadaily.com.cn") != -1)
            {
                return GeneralParse(html, "//div[@class='article']");
            }
            else if (url.IndexOf("sspai.com") != -1)
            {
                return GeneralParse(html, "//div[@ref='content']");
            }
            else if (url.IndexOf("www.cnbeta.com") != -1)
            {
                return GeneralParse(html, "//div[@class='cnbeta-article-body']");
            }

            return GeneralParse(html);
        }

        private static string GeneralParse(string html, string xpath)
        {
            HtmlDocument hDoc = new HtmlDocument();
            hDoc.LoadHtml(html);

            HtmlNode node = hDoc.DocumentNode.SelectSingleNode(xpath);

            string content = node.InnerHtml;

            return content;
        }

        private static string GeneralParse(string html)
        {
            return HtmlHelper.RemoveMultiplyNewLine(
                HtmlHelper.GetPureText(html));
        }
    }
}
