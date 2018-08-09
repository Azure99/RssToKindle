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
    }
}
