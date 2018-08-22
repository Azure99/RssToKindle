using System;
using System.Net;
using System.Text;

namespace RssToKindle.Utils
{
    static class Client
    {
        private static WebClient _wc;
        static Client()
        {
            _wc = new WebClient
            {
                Proxy = null,
                Encoding = Encoding.UTF8
            };
        }

        public static string GET(string url, int tryCount = 2) 
        {
            Exception lastEx = new ApplicationException("Cannot get " + url);
            while (tryCount-- > 0)
            {
                try
                {
                    _wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.79 Safari/537.36");
                    return _wc.DownloadString(url);
                }
                catch (Exception ex)
                {
                    lastEx = ex;
                }
            }
            throw lastEx;
        }
    }
}
