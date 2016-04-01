using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.MailStoreManager
{
    interface IMailStoreManager
    {
        string FetchMailHeader();
        string FetchMailHeader(DateTime date);        
        string FetchMailBody();
        string FetchMailBodyTitle();
        string FetchMailFooter();
        string FetchMailFooter(DateTime date);

        Dictionary<string,string> FetchMailingList();
    }
}
