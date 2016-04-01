using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.MailBodyConstructor
{
    internal interface IHtmlMaiBuilder
    {
        string ConstructMail(string mailHeader, string mailBody,string mailBodyTitle, string mailFooter);
    }
}
