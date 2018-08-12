# RssToKindle
RssToKindle是一款开源、跨平台、免费的Kindle资讯推送工具，支持自定义抓取RSS资讯，并每天定时推送到您的Kindle。<br/>
<img height="300" width="225" src="https://raw.githubusercontent.com/Azure99/RssToKindle/master/Images/screenshot1.png" />
<img height="300" width="225" src="https://raw.githubusercontent.com/Azure99/RssToKindle/master/Images/screenshot2.png" />
<img height="300" width="225" src="https://raw.githubusercontent.com/Azure99/RssToKindle/master/Images/screenshot3.png" />

# 基于最新源码简易安装
1. 根据[微软官方教程](https://www.microsoft.com/net/learn/get-started-with-dotnet-tutorial)安装.netcore sdk<br/>
2. 执行下列代码，克隆并运行
```Bash
git clone https://github.com/Azure99/RssToKindle.git
cd RssToKindle/RssToKindle
dotnet run -c Release
```
您可以在screen中启动服务以使其不被关闭，先运行命令[Screen](http://man.linuxde.net/screen) -S RssToKindle

# 首次使用
您可以先启动一次程序，它会自动创建配置模板。<br/>
随后请关闭程序，编辑根目录下的config.json，修改您的个人信息。<br/>
您必须在config.json中配置正确的**ReceiverAddress**、**SenderAddress**、**SenderPassword**字段，程序才可以正常工作。详情参见[配置说明](https://github.com/Azure99/RssToKindle/wiki/Config)<br/>
修改完成后，再次启动程序即可正常使用。<br/>
<br/>

# 教程文档
[安装教程](https://github.com/Azure99/RssToKindle/wiki/Install)<br/>
[配置说明](https://github.com/Azure99/RssToKindle/wiki/Config)<br/>
[解析规则说明](https://github.com/Azure99/RssToKindle/wiki/ParseRules)<br/>
[站点适配教程](https://github.com/Azure99/RssToKindle/wiki/Adapt)
