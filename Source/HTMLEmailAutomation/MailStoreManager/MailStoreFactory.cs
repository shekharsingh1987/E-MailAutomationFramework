using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.MailStoreManager
{
   internal static class MailStoreFactory
    {
        internal static IMailStoreManager Get(string storeName,string conString)
        {
            switch (storeName)
            {
                case "Sql":
                    return new SqlDBStore(conString);
                case "Excel":
                    return new ExcelStore(conString);
                default:
                    return null;
            }
        }
    }
}
