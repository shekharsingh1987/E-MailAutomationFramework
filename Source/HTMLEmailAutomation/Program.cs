using HTMLEmailAutomation.HTMLMailSender;
using HTMLEmailAutomation.MailBodyConstructor;
using HTMLEmailAutomation.MailStoreManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            const string mailerUser = "shekhark@orioninc.com";
            const string mailerPassword = "pwd";
            const string storeType = "Sql"; 
            const string storeConnString = @"Data Source=SHEKHAR\SQL2012DEV;Initial Catalog=MailBody;Integrated Security=True";
            const string exchangeService = "";
            try
            {
                IMailStoreManager store = MailStoreFactory.Get(storeType, storeConnString);
                string mailBodyTitle = store.FetchMailBodyTitle();
                string mailBody = store.FetchMailBody();
                string mailHeader = store.FetchMailHeader();
                string mailFooter = store.FetchMailFooter();
                Dictionary<string, string> reciepentList = store.FetchMailingList();

                IHtmlMaiBuilder mailBuilder = HtmlMailBuilderFactory.Get();
                string mail = mailBuilder.ConstructMail(mailHeader, mailBody,mailBodyTitle, mailFooter);

                IMailSender sender = MailSenderFactory.Get();
                sender.Send(mailerUser, mailerPassword, exchangeService, reciepentList,mail);
            }
            catch(NotImplementedException)
            {
                Console.WriteLine("Methods called might have not been implemented yet.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
