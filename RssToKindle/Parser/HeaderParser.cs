using System;
using System.Collections.Generic;
using System.Text;
using RssToKindle.Model;
using RssToKindle.Parser.PageParser;
using RssToKindle.Utils;

namespace RssToKindle.Parser
{
    static class HeaderParser
    {
        public static NewsBody Parse(NewsHeader header)
        {
            string page = Client.GET(header.Url);

            BaseParser parser = ParserFactory.CreateParser(header.Url);
            string content = parser.Parse(page);

            NewsBody body = new NewsBody(header.Title, header.Description, content);

            return body;
        }
    }
}
