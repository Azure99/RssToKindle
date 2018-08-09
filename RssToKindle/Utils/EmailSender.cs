using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace RssToKindle.Utils
{
    class EmailSender
    {
        private SmtpClient _sc;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account">邮箱账号</param>
        /// <param name="password">邮箱密码</param>
        /// <param name="host">主机</param>
        /// <param name="port">端口</param>
        /// <param name="enableSSL">是否启用SSL</param>
        public EmailSender(string account, string password, string host, int port, bool enableSSL)
        {
            _sc = new SmtpClient(host, port)
            {
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(account, password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = enableSSL
            };
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="receiver">接收者</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="file">附件</param>
        public void SendMail(string receiver, string subject, string body, string file)
        {
            MailMessage mMessage = new MailMessage();

            string sender = ((NetworkCredential)_sc.Credentials).UserName;

            mMessage.From = new MailAddress(sender);
            mMessage.To.Add(receiver);
            mMessage.Subject = subject;
            mMessage.Body = body;
            mMessage.Priority = MailPriority.High;

            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                ContentType ct = new ContentType
                {
                    MediaType = MediaTypeNames.Text.Html,
                    Name = Path.GetFileName(file)
                };

                mMessage.Attachments.Add(new Attachment(fs, ct));

                _sc.Send(mMessage);
            }
        }
    }
}
