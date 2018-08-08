namespace SinaNewsToKindle
{
    /// <summary>
    /// 新浪新闻头，包含标题、描述、地址
    /// </summary>
    class SinaNewsHeader
    {
        public string Tittle { get; }
        public string Description { get; }
        public string Url { get; }

        public SinaNewsHeader(string tittle, string description, string url)
        {
            Tittle = tittle;
            Description = description;
            Url = url;
        }
    }
}