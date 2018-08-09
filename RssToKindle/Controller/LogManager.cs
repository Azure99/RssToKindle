using System;
using System.IO;
using System.Text;

namespace RssToKindle.Controller
{
    static class LogManager
    {
        public static void WriteLine(string message)
        {
            message = DateTime.Now.ToShortTimeString() + ":" + message;
            Console.WriteLine(message);
            try
            {
                File.AppendAllText("Messages.txt", message + Environment.NewLine);
            }
            catch { }
        }

        public static void ShowMessage(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine("Message:" + message);
            sb.AppendLine("--------------------");
            sb.AppendLine("");

            message = sb.ToString();
            Console.WriteLine(message);
            try
            {
                File.AppendAllText("Messages.txt", message);
            }
            catch { }
        }
        public static void ShowException(Exception ex, string appendMessage = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine("Exception:" + appendMessage);
            sb.AppendLine(ex.ToString());
            sb.AppendLine("--------------------");
            sb.AppendLine("");

            string message = sb.ToString();
            Console.WriteLine(message);
            try
            {
                File.AppendAllText("Error.txt", message);
            }
            catch { }
        }

        public static void ShowExceptionImplicitly(Exception ex, string appendMessage = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine("Exception:" + appendMessage);
            sb.AppendLine(ex.ToString());
            sb.AppendLine("--------------------");
            sb.AppendLine("");

            string message = sb.ToString();
            try
            {
                File.AppendAllText("Error.txt", message);
            }
            catch { }
        }
    }
}
