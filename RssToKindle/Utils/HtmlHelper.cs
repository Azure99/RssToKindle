using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace RssToKindle.Utils
{
    static class HtmlHelper
    {
        public static string GetPureText(string html)
        {
            HtmlDocument hDoc = new HtmlDocument();
            hDoc.LoadHtml(html);

            return hDoc.DocumentNode.InnerText;
        }

        public static string RemoveMultiplyNewLine(string str)
        {
            return str.Replace("\r\n\r\n", "").Replace("\r\r", "").Replace("\n\n", "");
        }

        public static void RemoveNoTextNode(HtmlNode node)
        {
            List<HtmlNode> noTextNodes = new List<HtmlNode>();
            FindAllNoTextNode(node, noTextNodes);

            foreach(HtmlNode child in noTextNodes)
            {
                try
                {
                    child.Remove();
                }
                catch { }
            }
        }

        private static void FindAllNoTextNode(HtmlNode node, List<HtmlNode> noTextNodes)
        {
            foreach(HtmlNode child in node.ChildNodes)
            {
                if (string.IsNullOrEmpty(child.InnerText))
                {
                    noTextNodes.Add(child);
                    return;
                }
                FindAllNoTextNode(child, noTextNodes);
            }
        }
    }
}
