using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            var ffTest = new FirefoxTest(driver);
            ffTest.SeleniumFirefoxTest1();

        }
    }
}
