using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest1
{
    public static class WebDriverHelper
    {
        public static void MouseHoverByJavaScript(IWebDriver driver, IWebElement targetElement)
        {

            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                                "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                                "arguments[0].dispatchEvent(evObj);";
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript(javaScript, targetElement);
        }

        public static IWebDriver AddJQuery(this IWebDriver driver)
        {
            driver.LoadJQuery();
            return driver;
        }

        public static IWebElement FindElementByJs(this IWebDriver driver, string jsCommand)
        {
            return (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(jsCommand);
        }

        public static IWebElement FindElementByJsWithWait(this IWebDriver driver, string jsCommand, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(d => d.FindElementByJs(jsCommand));
            }
            return driver.FindElementByJs(jsCommand);
        }

        public static T Execute<T>(this IWebDriver driver, string script)
        {
            return (T)((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        public static void RunScript(this IWebDriver driver, string scriptText, params object[] args)
        {
            var jsEngine = driver as IJavaScriptExecutor;

            if (jsEngine != null)
            {
                jsEngine.ExecuteScript(scriptText, args);
            }
        }
    }
}
