using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.HTMLMailSender
{
    internal class MailSender : IMailSender
    {
        void IMailSender.Send(string mailer, string mailerPassword, string exchange, Dictionary<string, string> reciepent, string mail)
        {
            throw new NotImplementedException();
        }
    }
}
