using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using RssToKindle.Model;
using RssToKindle.Utils;

namespace RssToKindle.Controller
{
    static class ParseRulesManager
    {
        private static ArticleParseRule[] _rules;
        static ParseRulesManager()
        {
            ReadRules();
        }

        /// <summary>
        /// 读取规则
        /// </summary>
        public static void ReadRules()
        {
            try
            {
                string json = File.ReadAllText("ParseRules.json");
                _rules = JsonSerialization.DeSerialize<ArticleParseRule[]>(json);
            }
            catch (Exception ex)
            {
                LogManager.ShowException(ex, "Read parse rules file fail!");
                LogManager.WriteLine("Creating parse rules file...");
                _rules = GetDefaultRules();
                SaveRules();
            }
        }

        /// <summary>
        /// 保存规则
        /// </summary>
        public static void SaveRules()
        {
            try
            {
                string json = JsonSerialization.Serialize(_rules);
                File.WriteAllText("ParseRules.json", json);
            }
            catch (Exception ex)
            {
                LogManager.ShowException(ex, "Cannot write ParseRules.json!");
            }
        }

        /// <summary>
        /// 获取适合Url的规则
        /// </summary>
        /// <param name="url"></param>
        /// <returns>xPath规则</returns>
        public static string GetRule(string url)
        {
            foreach(ArticleParseRule rule in _rules)
            {
                if (url.ToLower().IndexOf(rule.Domain.ToLower()) != -1)
                {
                    return rule.XPath;
                }
            }
            return "";
        }

        /// <summary>
        /// 获取默认新闻页面解析规则
        /// </summary>
        /// <returns></returns>
        private static ArticleParseRule[] GetDefaultRules()
        {
            return new ArticleParseRule[] {
                new ArticleParseRule("daily.zhihu.com", "//div[@class='content']"),//知乎日报
                new ArticleParseRule("news.sina.com.cn", "//div[@class='article']"),//新浪新闻
                new ArticleParseRule("column.chinadaily.com.cn", "//div[@class='article']"),//中国日报专栏
                new ArticleParseRule("sspai.com", "//div[@ref='content']"),//少数派
                new ArticleParseRule("cnbeta.com", "//div[@class='article-summary']|//div[@class='article-content']"),//CnBeta
                new ArticleParseRule("www.infzm.com", "//section[@id='articleContent']"),//南方周末
                new ArticleParseRule("www.jianshu.com", "//div[@class='show-content-free']"),//简书
                new ArticleParseRule("www.thepaper.cn", "//div[@class='news_txt']")//澎湃新闻
            };
        }
    }
}
