using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest1
{
    public class _By : OpenQA.Selenium.By
    {
        public static _JQuerySelector JQuerySelector(string selector)
        {
            return new _JQuerySelector(selector);
        }
    }
}
