using System.Text;
using HtmlAgilityPack;
using RssToKindle.Controller;
using RssToKindle.Utils;

namespace RssToKindle.Parser
{
    static class ArticleParser
    {
        public static string Parse(string html, string url = "")
        {
            string xPath = ParseRulesManager.GetRule(url);

            if (!string.IsNullOrEmpty(xPath)) //判断是否匹配到规则
            {
                return GeneralParse(html, xPath);
            }

            return GeneralParse(html);
        }

        private static string GeneralParse(string html, string xpath)
        {
            HtmlDocument hDoc = new HtmlDocument();
            hDoc.LoadHtml(html);

            StringBuilder sb = new StringBuilder();

            HtmlNodeCollection nodes = hDoc.DocumentNode.SelectNodes(xpath);
            foreach(HtmlNode node in nodes)
            {
                HtmlHelper.RemoveNoTextNode(node);
                HtmlHelper.RemoveTags(node, "img");
                HtmlHelper.RemoveTags(node, "script");
                HtmlHelper.RemoveTags(node, "button");

                sb.AppendLine("<div>" + node.InnerHtml + "</div>");
            }

            return sb.ToString();
        }

        private static string GeneralParse(string html)
        {
            return HtmlHelper.RemoveMultiplyNewLine(
                HtmlHelper.GetPureText(html));
        }
    }
}
