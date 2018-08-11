using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace RssToKindle.Utils
{
    static class HtmlHelper
    {
        /// <summary>
        /// 获取html页面纯文本
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string GetPureText(string html)
        {
            HtmlDocument hDoc = new HtmlDocument();
            hDoc.LoadHtml(html);

            return hDoc.DocumentNode.InnerText;
        }

        /// <summary>
        /// 移除两行以上的换行符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveMultiplyNewLine(string str)
        {
            return str.Replace("\r\n\r\n", "").Replace("\r\r", "").Replace("\n\n", "");
        }

        /// <summary>
        /// 移除无文本的节点
        /// </summary>
        /// <param name="node"></param>
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
                }
                FindAllNoTextNode(child, noTextNodes);
            }
        }
        /// <summary>
        /// 移除所有特定标签
        /// </summary>
        /// <param name="tagName">标签名</param>
        public static void RemoveTags(HtmlNode node, string tagName)
        {
            List<HtmlNode> nodes = new List<HtmlNode>();
            FindTags(node, tagName, nodes);
            foreach (HtmlNode child in nodes)
            {
                try
                {
                    child.Remove();
                }
                catch { }
            }
        }

        private static void FindTags(HtmlNode node, string tagName, List<HtmlNode> nodes)
        {
            foreach (HtmlNode child in node.ChildNodes)
            {
                if(child.Name.ToLower() == tagName.ToLower())
                {
                    nodes.Add(child);
                }
                FindTags(child, tagName, nodes);
            }
        }
    }
}
