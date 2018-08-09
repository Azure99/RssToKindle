namespace RssToKindle.Model
{
    /// <summary>
    /// 新闻头，包含标题、描述、地址
    /// </summary>
    class NewsHeader
    {
        public string Title { get; }
        public string Description { get; }
        public string Url { get; }

        public NewsHeader(string title, string description, string url)
        {
            Title = title;
            Description = description;
            Url = url;
        }
    }
}