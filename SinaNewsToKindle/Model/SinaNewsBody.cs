namespace SinaNewsToKindle
{
    /// <summary>
    /// 新浪新闻主体，包含标题、描述、新闻
    /// </summary>
    class SinaNewsBody
    {
        public string Tittle { get; }
        public string Description { get; }
        public string Body { get; }

        public SinaNewsBody(string tittle, string description, string body)
        {
            Tittle = tittle;
            Description = description;
            Body = body;
        }
    }
}
