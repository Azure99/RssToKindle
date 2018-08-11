using HtmlAgilityPack;
using RssToKindle.Utils;

namespace RssToKindle.Parser
{
    static class ArticleParser
    {
        public static string Parse(string html, string url = "")
        {
            url = url.ToLower();

            if (url.IndexOf("daily.zhihu.com") != -1)//知乎日报
            {
                return GeneralParse(html, "//div[@class='content']");
            }
            else if (url.IndexOf("news.sina.com.cn") != -1)//新浪新闻
            {
                return GeneralParse(html, "//div[@class='article']");
            }
            else if (url.IndexOf("column.chinadaily.com.cn") != -1)//中国日报:专栏
            {
                return GeneralParse(html, "//div[@class='article']");
            }
            else if (url.IndexOf("sspai.com") != -1)//少数派
            {
                return GeneralParse(html, "//div[@ref='content']");
            }
            else if (url.IndexOf("www.cnbeta.com") != -1)//CnBeta
            {
                return "<div>" +
                    GeneralParse(html, "//div[@class='article-summary']") +
                    "</div><div>" + 
                    GeneralParse(html, "//div[@class='article-content']") +
                    "</div>";
            }
            else if (url.IndexOf("www.infzm.com") != -1)//南方周末
            {
                return GeneralParse(html, "//section[@id='articleContent']");
            }
            else if (url.IndexOf("www.jianshu.com") != -1)//简书
            {
                return GeneralParse(html, "//div[@class='show-content-free']");
            }

            return GeneralParse(html);
        }

        private static string GeneralParse(string html, string xpath)
        {
            HtmlDocument hDoc = new HtmlDocument();
            hDoc.LoadHtml(html);

            HtmlNode node = hDoc.DocumentNode.SelectSingleNode(xpath);

            HtmlHelper.RemoveNoTextNode(node);
            HtmlHelper.RemoveTags(node, "img");
            HtmlHelper.RemoveTags(node, "script");
            HtmlHelper.RemoveTags(node, "button");

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
