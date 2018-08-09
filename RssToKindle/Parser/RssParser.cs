using System.Collections.Generic;
using System.Xml;
using RssToKindle.Controller;
using RssToKindle.Model;
using RssToKindle.Utils;

namespace RssToKindle.Parser
{
    static class RssParser
    {
        public static NewsHeader[] Parse(string xml, string rssClass)
        {
            xml = xml.Replace("content:encoded", "description");
            

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);

            List<XmlNode> items = new List<XmlNode>();
            FindAllNodes(xDoc, "item", items);

            List<NewsHeader> headers = new List<NewsHeader>();
            foreach(XmlNode item in items)
            {
                try
                {
                    string description = item.SelectSingleNode("description").InnerText;
                    description = PreDescription(description);

                    NewsHeader header = new NewsHeader(
                        item.SelectSingleNode("title").InnerText,
                        description,
                        item.SelectSingleNode("link").InnerText,
                        rssClass
                        );
                    headers.Add(header);

                }
                catch { }

            }

            return headers.ToArray();
        }

        private static void FindAllNodes(XmlNode father, string nodeName, List<XmlNode> nodes)
        {
            foreach(XmlNode item in father)
            {
                if(item.Name.ToLower() == nodeName.ToLower())
                {
                    nodes.Add(item);
                }
                else
                {
                    FindAllNodes(item, nodeName, nodes);
                }
            }
        }

        private static string PreDescription(string description)
        {
            description = HtmlHelper.GetPureText(description);//获取纯文本
            description = HtmlHelper.RemoveMultiplyNewLine(description);

            description = description.Trim();

            try//去除原标题
            {
                int titleP = description.IndexOf("原标题");
                if (titleP != -1)
                {
                    int spaceP = description.IndexOf("　", titleP);
                    if (spaceP != -1)
                    {
                        description = description.Substring(spaceP, description.Length - spaceP).Trim();
                    }
                }
            }
            catch { }

            if (description.Length > ConfigManager.Config.MaxDescriptionLength)//最大描述长度限制
            {
                description = description.Substring(0, ConfigManager.Config.MaxDescriptionLength);
            }

            return description;
        }
    }
}
