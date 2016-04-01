using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.MailBodyConstructor
{
    class HtmlMailBuilder : IHtmlMaiBuilder
    {
        string IHtmlMaiBuilder.ConstructMail(string mailHeader, string mailBody, string mailBodyTitle, string mailFooter)
        {
            string id = "28";
            string footer = string.Format(mailFooter, id);
            string body= string.Format(mailHeader, "header","Body","Footer");
            return body;
        }
    }
}
