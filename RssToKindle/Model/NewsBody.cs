namespace RssToKindle.Model
{
    /// <summary>
    /// 新闻主体，包含标题、描述、新闻
    /// </summary>
    class NewsBody
    {
        public string Title { get; }
        public string Description { get; }
        public string Content { get; }

        public NewsBody(string title, string description, string content)
        {
            Title = title;
            Description = description;
            Content = content;
        }
    }
}
