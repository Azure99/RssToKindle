using System.Collections.Generic;

namespace SinaNewsToKindle
{
    static class SinaNewsRssParser
    {
        private const string ItemStart = "<item>";
        private const string ItemEnd = "</item>";
        private const string TitleStart = "<title>";
        private const string TitleEnd = "</title>";
        private const string DesStart = "<description>";
        private const string DesEnd = "</description>";
        private const string LinkStart = "<link>";
        private const string LinkEnd = "</link>";
        public static SinaNewsHeader[] Parse(string xml)
        {
            List<SinaNewsHeader> headers = new List<SinaNewsHeader>();

            string[] items = TagParser.GetTags(xml, ItemStart, ItemEnd);
            foreach (string item in items)
            {
                string pureItem = item.
                    Replace("<![CDATA[", "").
                    Replace("]]>", "").
                    Replace("原标题：", "").
                    Replace("\t", "").
                    Replace("　", "");

                string title = TagParser.GetTag(pureItem, TitleStart, TitleEnd);
                string link = TagParser.GetTag(pureItem, LinkStart, LinkEnd);
                string description = TagParser.GetTag(pureItem, DesStart, DesEnd);
                if (description.Length > ConfigManager.Config.MaxDescriptionLength)
                {
                    description = description.Substring(0, ConfigManager.Config.MaxDescriptionLength);
                }
                description += "...";

                if (title != "" && link != "" && description != "")
                {
                    headers.Add(new SinaNewsHeader(title, description, link));
                }
            }

            return headers.ToArray();
        }
    }
}
