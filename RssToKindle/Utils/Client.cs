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
