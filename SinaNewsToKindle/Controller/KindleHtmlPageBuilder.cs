using System.Text;

namespace SinaNewsToKindle
{
    class KindleHtmlPageBuilder
    {
        private StringBuilder _index;
        private StringBuilder _body;
        private int _count;
        public KindleHtmlPageBuilder()
        {
            _index = new StringBuilder();
            _body = new StringBuilder();
            _count = 0;
        }

        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="sinaNewsBody"></param>
        public void AddNews(SinaNewsBody sinaNewsBody)
        {
            int count = _count++;

            _index.AppendLine(string.Format("<div id=\"idiv{0}\">", count));
            _index.AppendLine(string.Format("<a href=\"#div{0}\">" +
                "<h3>{1}</h3>" +
                "</a>", count, sinaNewsBody.Title));
            _index.AppendLine("<p>" + sinaNewsBody.Description + "</p>");
            _index.AppendLine("<br/>");
            _index.AppendLine("</div>");


            _body.AppendLine(string.Format("<div id=\"div{0}\">", count));
            _body.AppendLine("<h1>" + sinaNewsBody.Title + "</h1>");
            _body.AppendLine(string.Format("<a href=\"#idiv{0}\">" +
                "<font size=\"5\">返回</font>" +
                "</a>", count));
            _body.AppendLine(sinaNewsBody.Body);
            _body.AppendLine("<br/>");
            _body.AppendLine("<br/>");
            _body.AppendLine("<br/>");

            _body.AppendLine("</div>");
        }

        /// <summary>
        /// 生成HTML
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>News</title>");
            sb.AppendLine("<meta charset=\"utf-8\"/>");
            sb.AppendLine("<body>");

            sb.Append(_index.ToString());
            sb.Append(_body.ToString());

            sb.AppendLine("</body>");
            sb.AppendLine("</head>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
