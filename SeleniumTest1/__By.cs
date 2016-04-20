using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest1
{
    public class By : OpenQA.Selenium.By
    {
        public static jQueryBy jQuery(string selector)
        {
            return new jQueryBy("jQuery(\"" + selector + "\")");
        }

        public class jQueryBy
        {
            private string Selector { get; set; }

            public jQueryBy(string selector)
            {
                this.Selector = selector;
            }

            public jQueryBy Find(string selector = "")
            {
                return this.Selector + ".find(\"" + selector + "\")";
            }
        }
    }
}
