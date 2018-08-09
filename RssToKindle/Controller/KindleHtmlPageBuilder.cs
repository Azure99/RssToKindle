using System.Collections.Generic;
using System.Text;
using RssToKindle.Model;

namespace RssToKindle.Controller
{
    class KindleHtmlPageBuilder
    {
        private int _classCount;//共有多少分类
        private Dictionary<string, ClassBuilder> _dic;
        public KindleHtmlPageBuilder()
        {
            _classCount = 0;
            _dic = new Dictionary<string, ClassBuilder>();
        }

        public void AddNews(NewsBody newsBody)
        {
            if(!_dic.ContainsKey(newsBody.Class))
            {
                _dic.Add(newsBody.Class, new ClassBuilder(newsBody.Class, _classCount++));
            }

            _dic[newsBody.Class].AddNews(newsBody);
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

            sb.AppendLine(BuildBody());

            sb.AppendLine("</body>");
            sb.AppendLine("</head>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        private string BuildBody()
        {
            StringBuilder classSb = new StringBuilder();
            StringBuilder indexSb = new StringBuilder();
            StringBuilder bodySb = new StringBuilder();

            classSb.AppendLine("<div id=\"main\">");
            classSb.AppendLine("<h1>RSS To Kindle</h1>");
            classSb.AppendLine("<p>" + System.DateTime.Now.ToShortDateString() + "</p>");
            classSb.AppendLine("<br/><br/>");

            foreach(string name in _dic.Keys)
            {
                ClassBuilder cb = _dic[name];

                classSb.Append(string.Format("<a href=\"#class{0}\">" +
                    "<font size=\"5\">{1}({2})</font>" +
                    "</a>", cb.ID, cb.Name, cb.Count));
                classSb.AppendLine("<br/>");
                classSb.AppendLine("<br/>");

                indexSb.AppendLine("<hr/>");
                indexSb.AppendLine(string.Format("<div id=\"class{0}\">", cb.ID));
                indexSb.AppendLine("<h1>" + name + "</h1>");
                indexSb.AppendLine("<center><a href=\"#main\"><font size=\"5\">返回</font></a></center>");
                indexSb.AppendLine(cb.GetIndexHtml());

                indexSb.AppendLine("</div>");

                bodySb.AppendLine(cb.GetBodyHtml());
            }

            classSb.AppendLine("</div>");
            classSb.AppendLine("<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>");

            string body = classSb.ToString() + indexSb.ToString() + bodySb.ToString();
            return body;
        }
        private class ClassBuilder
        {
            private StringBuilder _index { get; }
            private StringBuilder _body { get; }
            public int Count { get; private set; }
            public string Name { get; }
            public int ID { get; }//此分类的唯一ID

            public ClassBuilder(string name, int id)
            {
                _index = new StringBuilder();
                _body = new StringBuilder();
                Count = 0;
                Name = name;
                ID = id;
            }

            public void AddNews(NewsBody newsBody)
            {
                int count = Count++;

                _index.AppendLine(string.Format("<a href=\"#{0}div{1}\">" +
                    "<font size=\"5\">{2}</font>" +
                    "</a>", ID,count, newsBody.Title));
                _index.AppendLine("<p style=\"font-size:13px;\">" + newsBody.Description + "</p>");
                _index.AppendLine("<br/>");

                _body.AppendLine(string.Format("<div id=\"{0}div{1}\">", ID, count));
                _body.AppendLine("<h1>" + newsBody.Title + "</h1>");

                //文章分类、当前第几篇、返回链接
                _body.Append("<p>" + newsBody.Class);
                _body.Append("&nbsp");
                _body.Append("第" + (count + 1) + "篇");
                _body.Append("&nbsp;&nbsp;");
                _body.Append(string.Format("<a href=\"#class{0}\">" +
                    "<font size=\"5\">返回</font>" +
                    "</a>", ID));
                _body.AppendLine("</p>");

                _body.AppendLine(newsBody.Content);
                _body.AppendLine("<br/><br/><br/><br/>");

                _body.AppendLine("</div>");
            }

            public string GetIndexHtml()
            {
                return _index.ToString() + "<br/><br/><br/>";
            }

            public string GetBodyHtml()
            {
                return _body.ToString();
            }
        }
    }
}