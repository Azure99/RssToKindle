namespace SinaNewsToKindle
{
    /// <summary>
    /// 新浪新闻主体，包含标题、描述、新闻
    /// </summary>
    class SinaNewsBody
    {
        public string Title { get; }
        public string Description { get; }
        public string Body { get; }

        public SinaNewsBody(string title, string description, string body)
        {
            Title = title;
            Description = description;
            Body = body;
        }
    }
}
