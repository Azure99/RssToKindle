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
            else if(url.IndexOf("column.chinadaily.com.cn") != -1)
            {
                return new ChinaDailyColumnParser();
            }
            else if(url.IndexOf("sspai.com") != -1)
            {
                return new SspaiParser();
            }

            return new BaseParser();
        }
    }
}
