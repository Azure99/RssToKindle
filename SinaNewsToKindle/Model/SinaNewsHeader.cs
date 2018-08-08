namespace SinaNewsToKindle
{
    /// <summary>
    /// 新浪新闻头，包含标题、描述、地址
    /// </summary>
    class SinaNewsHeader
    {
        public string Title { get; }
        public string Description { get; }
        public string Url { get; }

        public SinaNewsHeader(string title, string description, string url)
        {
            Title = title;
            Description = description;
            Url = url;
        }
    }
}