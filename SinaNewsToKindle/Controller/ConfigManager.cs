using System;
using System.IO;

namespace SinaNewsToKindle
{
    static class ConfigManager
    {
        public static Config Config { get; private set; }
        static ConfigManager()
        {
            ReadConfig();
        }

        /// <summary>
        /// 检查配置合法性
        /// </summary>
        /// <returns></returns>
        public static bool CheckValidity()
        {
            if (Config.ReceiverAddress == "xxx@kindle.com" || Config.SenderAddress == "xxx@163.com")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public static void ReadConfig()
        {
            try
            {
                string json = File.ReadAllText("config.json");
                Config = JsonSerialization.DeSerialize<Config>(json);
            }
            catch (Exception ex)
            {
                LogManager.ShowException(ex, "Read config file fail!");
                LogManager.WriteLine("Creating config file...");
                Config = new Config();
                SaveConfig();
            }
        }

        /// <summary>
        /// 写入配置
        /// </summary>
        public static void SaveConfig()
        {
            try
            {
                string json = JsonSerialization.Serialize(Config);
                File.WriteAllText("config.json", json);
            }
            catch (Exception ex)
            {
                LogManager.ShowException(ex, "Cannot write config.json");
            }
        }
    }
}
