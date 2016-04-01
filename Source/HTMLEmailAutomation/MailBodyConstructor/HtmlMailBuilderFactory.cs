using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLEmailAutomation.MailBodyConstructor
{
    internal static class HtmlMailBuilderFactory
    {
        internal static IHtmlMaiBuilder Get()
        {
            return new HtmlMailBuilder();
        }
    }
}
