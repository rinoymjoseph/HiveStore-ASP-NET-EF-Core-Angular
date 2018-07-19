using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HiveStoreNGCoreApp.Web.Helpers
{
    public interface IMailHelper
    {
        string SendMailMessage(string from, string to, string cc, string bcc, string subject, string body, List<Attachment> lst);
    }
}
