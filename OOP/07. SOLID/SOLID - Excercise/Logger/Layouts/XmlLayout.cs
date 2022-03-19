using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        private string format =
@"<log>
<date>{0}</date>
<level>{1}</level>
<message>{2}</message>
</log>";

        public string Format => format;
    }
}
