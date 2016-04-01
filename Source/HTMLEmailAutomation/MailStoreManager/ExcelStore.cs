using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.MailStoreManager
{
    class ExcelStore : IMailStoreManager
    {
        private string _excelPath = string.Empty;
        public ExcelStore(string path)
        {
            _excelPath = path;
        }

        string IMailStoreManager.FetchMailBody()
        {
            throw new NotImplementedException();
        }

        string IMailStoreManager.FetchMailBodyTitle()
        {
            throw new NotImplementedException();
        }

        string IMailStoreManager.FetchMailFooter()
        {
            throw new NotImplementedException();
        }

        string IMailStoreManager.FetchMailFooter(DateTime date)
        {
            throw new NotImplementedException();
        }

        string IMailStoreManager.FetchMailHeader()
        {
            throw new NotImplementedException();
        }

        string IMailStoreManager.FetchMailHeader(DateTime date)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, string> IMailStoreManager.FetchMailingList()
        {
            throw new NotImplementedException();
        }
    }
}
