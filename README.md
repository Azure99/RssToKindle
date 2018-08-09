# RssToKindle
个性化抓取RSS新闻，并推送到Kindle<br/>
<img height="400" width="300" src="https://raw.githubusercontent.com/Azure99/RssToKindle/master/Images/screenshot1.png" />
<img height="400" width="300" src="https://raw.githubusercontent.com/Azure99/RssToKindle/master/Images/screenshot2.png" />

# 安装
1. 根据[微软官方教程](https://www.microsoft.com/net/learn/get-started-with-dotnet-tutorial)安装.netcore sdk<br/>
2. 执行下列代码，克隆并运行
```Bash
git clone https://github.com/Azure99/RssToKindle.git
cd RssToKindle/RssToKindle
dotnet run
```
您可以在screen中启动服务以使其不被关闭，先运行命令[Screen](http://man.linuxde.net/screen) -S SinaNews

# 首次使用
您可以先启动一次程序，它会自动创建配置模板。<br/>
随后请关闭程序，编辑根目录下的config.json，修改您的个人信息。<br/>
修改完成后，再次启动程序即可正常使用。<br/>
<br/>

# 配置文件说明
<b>SendTime</b>，每天推送新闻的时间，二十四小时制<br/>

<b>RssUrls</b>，新闻的RSS地址，这是一个Json数组，用于个性化推送内容。目前支持新浪新闻、知乎日报<br/>

<b>DynamicTitle</b>，发送邮件时使用动态标题，一定程度上防止被当做垃圾邮件<br/>

<b>MaxDescriptionLength</b>，最长描述长度，规定了显示摘要的最大长度<br/>

<b>ReceiverAddress</b>，Kindle接收邮箱，此处填写您的Send To Kindle邮箱<br/>

<b>SenderAddress</b>，发信邮箱，可以是任意邮箱，<b>强烈建议使用Outlook</b><br/>
您必须在Amazon用户中心<b>内容和设备-设置-个人文档设置-已认可的发件人电子邮箱列表</b>中添加发信邮箱<br/>

<b>SenderPassword</b>，发信邮箱的密码<br/>

------若使用Outlook邮箱以下无需修改------<br/>

<b>EmailServer</b>，STMP地址<br/>

<b>EmailPort</b>，端口<br/>

<b>EnableSSL</b>，是否启用SSL<br/>

下面是一段模板示例
```Json
{
  "SendTime": "8:00",
  "RssUrls": [
    "http://rss.sina.com.cn/news/china/focus15.xml",
    "http://rss.sina.com.cn/news/world/focus15.xml"
  ],
  "DynamicTitle": true,
  "MaxDescriptionLength": 65,
  "ReceiverAddress": "xxx@kindle.com",
  "SenderAddress": "xxx@outlook.com",
  "SenderPassword": "123456",
  "EmailServer": "smtp.outlook.com",
  "EmailPort": 587,
  "EnableSSL": true,
  "LastSendTime": "0001-01-01T00:00:00"
}
```
