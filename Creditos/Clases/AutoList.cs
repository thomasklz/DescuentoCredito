using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Clases
{
    public class AutoList
    {
        public string label;
        public string value;
        public AutoList(string value, string label)
        {
            this.value = value;
            this.label = label;
        }
    }
}