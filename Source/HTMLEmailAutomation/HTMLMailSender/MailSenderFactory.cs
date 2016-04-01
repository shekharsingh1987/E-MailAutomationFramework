using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.HTMLMailSender
{
    internal static class MailSenderFactory
    {
        internal static IMailSender Get()
        {
            return new MailSender();
        }
    }
}
