using System;
using System.Collections.Generic;

namespace SinaNewsToKindle
{
    static class TagParser
    {
        public static string[] GetTags(string text, string open, string close)
        {
            List<string> tags = new List<string>();
            int openP = text.IndexOf(open);
            try
            {
                while (openP != -1)
                {
                    int closeP = text.IndexOf(close, openP + open.Length);
                    if (closeP == -1)
                    {
                        break;
                    }


                    tags.Add(text.Substring(openP + open.Length, closeP - open.Length - openP));

                    openP = text.IndexOf(open, closeP + close.Length);
                }
            }
            catch (Exception ex)
            {
                LogManager.ShowException(ex);
            }

            return tags.ToArray();
        }

        public static string GetTag(string text, string open, string close, int index = 0)
        {
            try
            {
                return GetTags(text, open, close)[index];
            }
            catch (Exception ex)
            {
                LogManager.ShowException(ex);
                return "";
            }

        }
    }
}
