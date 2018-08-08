# SinaNewsToKindle
向Kindle推送适合其阅读的新浪新闻<br/>

# 首次使用
您可以先启动一次程序，它会自动创建配置模板。<br/>
随后请关闭程序，编辑根目录下的config.json，修改您的个人信息。<br/>
修改完成后，再次启动程序即可正常使用。<br/>
<br/>

# 配置文件说明
SendTime，每天推送新闻的时间，二十四小时制<br/>

RssUrls，新浪新闻的RSS地址，这是一个Json数组，用于个性化推送内容。您可以在[新浪新闻RSS](http://rss.sina.com.cn/news/)找到所有可用的RSS地址<br/>

ReceiverAddress，Kindle接收邮箱，此处填写您的Send To Kindle邮箱<br/>

SenderAddress，发信邮箱，可以是任意邮箱，<b>强烈建议使用Outlook</b><br/>
您必须在Amazon用户中心<b>内容和设备-设置-个人文档设置-已认可的发件人电子邮箱列表</b>中添加发信邮箱<br/>

SenderPassword，发信邮箱的密码<br/>

------若使用Outlook邮箱以下无需修改------<br/>

EmailServer，STMP地址<br/>

EmailPort，端口<br/>

EnableSSL，是否启用SSL<br/>

MaxDescriptionLength，最长描述长度，规定了显示摘要的最大长度<br/>

下面是一段模板示例
```Json
{
  "SendTime": "8:00",
  "RssUrls": [
    "http://rss.sina.com.cn/news/china/focus15.xml",
    "http://rss.sina.com.cn/news/world/focus15.xml"
  ],
  "ReceiverAddress": "xxx@kindle.com",
  "SenderAddress": "xxx@outlook.com",
  "SenderPassword": "123456",
  "EmailServer": "smtp.outlook.com",
  "EmailPort": 587,
  "EnableSSL": true,
  "MaxDescriptionLength": 65,
  "LastSendTime": "0001-01-01T00:00:00"
}
```
