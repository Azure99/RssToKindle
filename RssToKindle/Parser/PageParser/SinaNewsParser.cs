using HtmlAgilityPack;

namespace RssToKindle.Parser.PageParser
{
    class SinaNewsParser : BaseParser
    {
        public override string Parse(string html)
        {
            HtmlDocument hDoc = new HtmlDocument();
            hDoc.LoadHtml(html);

            HtmlNode node = hDoc.DocumentNode.SelectSingleNode("//div[@class='article']");

            string content = node.InnerHtml;

            return content;
        }
    }
}