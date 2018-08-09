using HtmlAgilityPack;

namespace RssToKindle.Parser.PageParser
{
    class SspaiParser : BaseParser
    {
        public override string Parse(string html)
        {
            HtmlDocument hDoc = new HtmlDocument();
            hDoc.LoadHtml(html);

            HtmlNode node = hDoc.DocumentNode.SelectSingleNode("//div[@ref='content']");

            string content = node.InnerHtml;

            return content;
        }
    }
}