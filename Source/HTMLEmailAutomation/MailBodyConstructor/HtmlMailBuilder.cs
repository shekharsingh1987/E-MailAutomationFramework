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
            //Take the string betweeen <body> and </body>
            string bodyPart = ExtractBodyTagOfHtml(mailHeader, "<body>", @"</html>");
            string body = string.Format(bodyPart, mailBodyTitle, mailBody, footer);
            string contentBeforeBody = ExtractHeadContent(mailHeader, "<body>");
            return contentBeforeBody + body;
        }

        private string ExtractHeadContent(string value, string a)
        {
            int posA = value.LastIndexOf(a) + a.Length;
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        private string ExtractBodyTagOfHtml(string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }
    }
}
