using System;

namespace SinaNewsToKindle
{
    class Config
    {
        /// <summary>
        /// 每天发送的时间
        /// </summary>
        public string SendTime { get; set; } = "8:00";
        /// <summary>
        /// 新浪新闻的RSS地址，可自定义感兴趣的内容
        /// </summary>
        public string[] RssUrls { get; set; } = new string[2] {
            "http://rss.sina.com.cn/news/china/focus15.xml",
            "http://rss.sina.com.cn/news/world/focus15.xml"
        };
        /// <summary>
        /// 是否使用动态邮件标题
        /// </summary>
        public bool DynamicTitle { get; set; } = true;
        /// <summary>
        /// 最大新闻描述长度
        /// </summary>
        public int MaxDescriptionLength { get; set; } = 65;
        /// <summary>
        /// 接收地址(Kindle信箱)
        /// </summary>
        public string ReceiverAddress { get; set; } = "xxx@kindle.com";
        /// <summary>
        /// 发件邮箱
        /// </summary>
        public string SenderAddress { get; set; } = "xxx@outlook.com";
        /// <summary>
        /// 发件邮箱密码
        /// </summary>
        public string SenderPassword { get; set; } = "123456";
        /// <summary>
        /// SMTP地址
        /// </summary>
        public string EmailServer { get; set; } = "smtp.outlook.com";
        /// <summary>
        /// 端口
        /// </summary>
        public int EmailPort { get; set; } = 587;
        /// <summary>
        /// 是否启用SSL
        /// </summary>
        public bool EnableSSL { get; set; } = true;

        /// <summary>
        /// 上次推送时间
        /// </summary>
        public DateTime LastSendTime { get; set; } = DateTime.MinValue;
    }
}
