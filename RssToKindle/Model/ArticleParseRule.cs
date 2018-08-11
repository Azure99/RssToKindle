using System;
using System.Collections.Generic;
using System.Text;

namespace RssToKindle.Model
{
    /// <summary>
    /// 新闻页面爬取规则
    /// </summary>
    class ArticleParseRule
    {
        /// <summary>
        /// 新闻页面的域名(可以是Url的一部分)，用于匹配规则
        /// </summary>
        public string Domain { get; }
        /// <summary>
        /// XPath规则
        /// </summary>
        public string XPath { get; set; }
        public ArticleParseRule(string domain, string xPath)
        {
            Domain = domain;
            XPath = xPath;
        }
    }
}
