using System;
using RssToKindle.Controller;

namespace RssToKindle
{
    class Program
    {
        public static MainService MainService { get; } = new MainService();
        static void Main(string[] args)
        {
            LogManager.WriteLine("----------");
            LogManager.WriteLine("RSS to Kindle");
            LogManager.WriteLine("Starting service...");
            LogManager.WriteLine("Checking configuration...");

            if (!ConfigManager.CheckValidity())//检查配置文件正确性
            {
                LogManager.WriteLine("Config is invalid.");
                LogManager.WriteLine("Please edit your information in config.json. And restart service.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            MainService.StartService();

            LogManager.WriteLine("Startup successfully!");
            LogManager.WriteLine("----------");

            while (true)
            {
                string command = Console.ReadLine();
                if (command.ToLower() == "exit")//退出
                {
                    break;
                }
                else if (command.ToLower() == "stop")//停止服务
                {
                    MainService.StopService();
                    LogManager.WriteLine("Stopped!");
                }
                else if (command.ToLower() == "start")//启动服务
                {
                    MainService.StartService();
                    LogManager.WriteLine("Started!");
                }
                else if (command.ToLower() == "push")//立即推送
                {
                    LogManager.WriteLine("Pushing news to Kindle...");
                    MainService.GetNewsAndSendToKindle();
                }
                else if (command.ToLower() == "reload config") //重新读入配置文件
                {
                    ConfigManager.ReadConfig();
                    ParseRulesManager.ReadRules();
                    LogManager.WriteLine("Reload ok!");
                }
                else
                {
                    LogManager.WriteLine("Wrong Command!");
                    Console.WriteLine("You can use this commands:");
                    Console.WriteLine("exit:\tExit RssToKindle");
                    Console.WriteLine("start:\tStart service");
                    Console.WriteLine("stop\tStop service");
                    Console.WriteLine("push:\tPush news immediately");
                    Console.WriteLine("reload config:\tReLoad configuration");
                }
            }
        }
    }
}
