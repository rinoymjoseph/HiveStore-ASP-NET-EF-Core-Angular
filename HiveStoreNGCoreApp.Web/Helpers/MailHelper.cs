using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HiveStoreNGCoreApp.Web.Helpers
{
    public class MailHelper : IMailHelper
    {
        private static string site = string.Empty;
        private static string requestuseremail = string.Empty;
        private static string controllerName = string.Empty;
        private static string actionName = string.Empty;
        private static string url = string.Empty;
        private static string mailsubject = string.Empty;
        private static string attachmentFileContent = string.Empty;
        private static string exceptionindetails = string.Empty;
        private readonly IConfiguration _configuration;
        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SendMailMessage(string from, string to, string cc, string bcc, string subject, string body, List<Attachment> lst)
        {
            string result = "";
            try
            {
                var smtpAddr = _configuration?.GetSection("AppSettings")?["SMTPAddress"];

                var mailMessage = new MailMessage();

                mailMessage.From = new MailAddress(from);
                if (!string.IsNullOrEmpty(to))
                {
                    var toemail = to.Split(',');
                    foreach (var email in toemail)
                    {
                        mailMessage.To.Add(new MailAddress(email));
                    }
                }

                if (!string.IsNullOrEmpty(bcc))
                {
                    // Set the Bcc address of the mail message
                    mailMessage.Bcc.Add(new MailAddress(bcc));
                }      // Check if the cc value is null or an empty value
                if (!string.IsNullOrEmpty(cc))
                {
                    // Set the CC address of the mail message
                    var ccemail = cc.Split(',');
                    foreach (var email in ccemail)
                    {
                        mailMessage.CC.Add(new MailAddress(email));
                    }
                }
                mailMessage.Subject = subject;

                if (lst != null)
                {
                    foreach (var att in lst)
                    {
                        mailMessage.Attachments.Add(att);
                    }
                }
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                SmtpClient smtpClient = new SmtpClient(smtpAddr);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Send(mailMessage);

                result = "Success";
            }
            catch (Exception ex)
            {
                result = "Failure";
            }
            return result;
        }

    }
}
