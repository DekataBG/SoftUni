using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        private string format = "{0} - {1} - {2}";

        public string Format => format;
    }
}
