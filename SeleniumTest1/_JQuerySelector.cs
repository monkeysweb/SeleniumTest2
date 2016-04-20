using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest1
{
    public class _JQuerySelector
    {
        public _JQuerySelector(string selector)
        {
            this.Selector = selector;
        }

        public string Selector { get; set; }
    }
}
