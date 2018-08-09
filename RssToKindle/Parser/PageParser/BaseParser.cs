using System;
using System.Collections.Generic;
using System.Text;
using RssToKindle.Utils;

namespace RssToKindle.Parser.PageParser
{
    class BaseParser
    {
        public virtual string Parse(string html)
        {
            return HtmlHelper.RemoveMultiplyNewLine(
                HtmlHelper.GetPureText(html));
        }
    }
}
