using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.HTMLMailSender
{
    interface IMailSender
    {
        void Send(string mailer, string mailerPassword, string exchange, Dictionary<string, string> reciepent,string mail,string mailSubject);
    }
}
