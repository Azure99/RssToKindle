using System;
using System.Collections.Generic;
using System.Text;
using RssToKindle.Model;
using RssToKindle.Utils;

namespace RssToKindle.Parser
{
    static class HeaderParser
    {
        public static NewsBody Parse(NewsHeader header)
        {
            string page = Client.GET(header.Url);

            string content = ArticleParser.Parse(page, header.Url);

            NewsBody body = new NewsBody(header.Title, header.Description, content);

            return body;
        }
    }
}
