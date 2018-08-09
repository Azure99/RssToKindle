using System;
using System.Collections.Generic;
using System.Text;

namespace RssToKindle.Parser.PageParser
{
    static class ParserFactory
    {
        public static BaseParser CreateParser(string url)
        {
            url = url.ToLower();
            if(url.IndexOf("daily.zhihu.com") != -1)
            {
                return new ZhiHuDailyParser();
            }
            else if(url.IndexOf("news.sina.com.cn") != -1)
            {
                return new SinaNewsParser();
            }

            return new BaseParser();
        }
    }
}
