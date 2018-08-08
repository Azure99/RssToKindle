using System.Collections.Generic;

namespace SinaNewsToKindle
{
    static class SinaNewsRssParser
    {
        private const string ItemStart = "<item>";
        private const string ItemEnd = "</item>";
        private const string TittleStart = "<title>";
        private const string TittleEnd = "</title>";
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

                string tittle = TagParser.GetTag(pureItem, TittleStart, TittleEnd);
                string link = TagParser.GetTag(pureItem, LinkStart, LinkEnd);
                string description = TagParser.GetTag(pureItem, DesStart, DesEnd);
                if (description.Length > ConfigManager.Config.MaxDescriptionLength)
                {
                    description = description.Substring(0, ConfigManager.Config.MaxDescriptionLength);
                }
                description += "...";

                if (tittle != "" && link != "" && description != "")
                {
                    headers.Add(new SinaNewsHeader(tittle, description, link));
                }
                /*
                Console.WriteLine(tittle);
                Console.WriteLine(link);
                Console.WriteLine(description);
                */
            }

            return headers.ToArray();
        }
    }
}
