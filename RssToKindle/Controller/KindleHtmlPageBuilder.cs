using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RssToKindle.Model;

namespace RssToKindle.Controller
{
    /*  新闻页面由三部分构成
     * 1.分类索引(id=main)，包含所有分类，点击即可跳转到对应分类的目录
     * 2.分类目录(id=class %d)，包含此分类下所有新闻的标题与简介，点击标题即可进入新闻主体
     * 3.新闻主体(id=%d div %d)，包含标题与全文
     */

    class KindleHtmlPageBuilder
    {
        private int _classCount;//共有多少分类
        private Dictionary<string, ClassBuilder> _dic;//每个分类的构造器
        public KindleHtmlPageBuilder()
        {
            _classCount = 0;
            _dic = new Dictionary<string, ClassBuilder>();
        }

        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="newsBody">新闻对象</param>
        public void AddNews(NewsBody newsBody)
        {
            if(!_dic.ContainsKey(newsBody.Class))//确保分类存在
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

            string page = sb.ToString();
            page = Regex.Replace(page, @"<img[^>]*>", "");//去除图片

            return page;
        }

        private string BuildBody()
        {
            StringBuilder classSb = new StringBuilder();
            StringBuilder indexSb = new StringBuilder();
            StringBuilder bodySb = new StringBuilder();

            classSb.AppendLine("<div id=\"main\" style=\"width:100%; float:left;\">");
            classSb.AppendLine("<h1>RSS To Kindle</h1>");
            classSb.AppendLine("<p>" + System.DateTime.Now.ToShortDateString() + "</p>");
            classSb.AppendLine("<br/><br/>");

            foreach(string name in _dic.Keys)
            {
                ClassBuilder cb = _dic[name];

                classSb.Append(string.Format("<a href=\"#class{0}\">" +
                    "<font size=\"5\">{1}({2})</font>" +
                    "</a>", cb.ID, cb.Name, cb.Count));
                classSb.AppendLine("<br/><br/>");

                indexSb.AppendLine("<hr/>");
                indexSb.AppendLine(string.Format("<div id=\"class{0}\" style=\"width:100%;float:left;\">", cb.ID));
                indexSb.AppendLine(string.Format(
                    "<font size=\"8\">{0}</font><font size=\"2\">({1})</font><br/>", 
                    name, 
                    cb.Count));

                //indexSb.AppendLine("<a href=\"#front\"><font size=\"5\">返回</font></a><br/><br/>");
                indexSb.AppendLine("<br/>");
                indexSb.AppendLine(cb.GetIndexHtml());

                indexSb.AppendLine("</div>");

                bodySb.AppendLine(cb.GetBodyHtml());
            }

            classSb.AppendLine("<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>");
            classSb.AppendLine("</div>");

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

                if (count % 2 == 0)
                {
                    _index.AppendLine("<div style=\"" +
                        "overflow:hidden;" +
                        "\">");
                }

                string divFloat = (count % 2 == 0) ? "float:left;" : "float:right;";

                _index.AppendLine("<div style=\"" +
                    "width:47%; " +
                    divFloat +
                    "padding-bottom:400px; " +
                    "margin-bottom:-400px;\">");

                if (count > 1)
                {
                    _index.AppendLine("<hr/><br/>");
                }

                _index.AppendLine(string.Format(
                    "<a class=\"indexa\" href=\"#{0}div{1}\">" +
                    "<font size=\"4\">{2}</font>" +
                    "</a>" +
                    "<br/>", 
                    ID, count, newsBody.Title));

                _index.AppendLine(string.Format(
                    "<p style=\"font-size:13px;\">{0}</p>", newsBody.Description));

                _index.AppendLine("</div>");
                if (count % 2 == 1)
                {
                    _index.AppendLine("</div>");
                }

                _body.AppendLine(string.Format("<div id=\"{0}div{1}\" style=\"width:100%;float:left;\">", ID, count));
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
                if(Count % 2 == 1)
                {
                    _index.AppendLine("</div>");
                }
                _index.AppendLine("<br/><br/><br/><br/><br/><br/><br/><br/><br/>");
                return _index.ToString();
            }

            public string GetBodyHtml()
            {
                return _body.ToString();
            }
        }
    }
}