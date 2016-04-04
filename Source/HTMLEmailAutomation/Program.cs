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
            const string storeConnString = @"Data Source=SEKHRU-PC\MSSQLSERVER2014;Initial Catalog=MailBody;Integrated Security=True";
            const string exchangeService = "smtp.office365.com";
            try
            {
                IMailStoreManager store = MailStoreFactory.Get(storeType, storeConnString);
                string mailBodyTitle = store.FetchMailBodyTitle();
                string mailBody = store.FetchMailBody();
                string mailHeader = store.FetchMailHeader();
                string mailFooter = store.FetchMailFooter();
                string mailSubject = "ORTIA:: Crizzal Automated Mail Test";
                Dictionary<string, string> reciepentList = store.FetchMailingList();

                IHtmlMaiBuilder mailBuilder = HtmlMailBuilderFactory.Get();
                string mail = mailBuilder.ConstructMail(mailHeader, mailBody,mailBodyTitle, mailFooter);

                IMailSender sender = MailSenderFactory.Get();
                sender.Send(mailerUser, mailerPassword, exchangeService, reciepentList,mail, mailSubject);

                Console.WriteLine("Message Sent");
            }
            catch(NotImplementedException)
            {
                Console.WriteLine("Methods called might have not been implemented yet.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();

        }
    }
}
