using System;
using System.Collections.Generic;
using System.Text;

namespace RssToKindle.Model
{
    class ArticleParseRule
    {
        public string Domain { get; }
        public string XPath { get; set; }
        public ArticleParseRule(string domain, string xPath)
        {
            Domain = domain;
            XPath = xPath;
        }
    }
}
