using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest1
{
    public static class _WebDriverExtensions
    {
        public static void LoadJQuery(this IWebDriver driver, string version = "latest", TimeSpan? timeout = null)
        {
            var javaScriptDriver = (IJavaScriptExecutor)driver;

            const string CheckScript = "return typeof window.jQuery !== 'function'";
            var exists = (bool)javaScriptDriver.ExecuteScript(CheckScript);
            if (exists)
            {
                var path = string.Format(CultureInfo.InvariantCulture, "jq.src = '//code.jquery.com/jquery-{0}.min.js';", version);
                var loadScript = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", "var jq = document.createElement('script');",
                    path, "document.getElementsByTagName('head')[0].appendChild(jq);");
                javaScriptDriver.ExecuteScript(loadScript);
                var wait = new WebDriverWait(driver, timeout ?? TimeSpan.FromSeconds(3));
                wait.Until(d =>
                {
                    return ((IJavaScriptExecutor)d).ExecuteScript(CheckScript);
                });
            }
        }

        public static IWebElement FindElement(this IWebDriver driver, _JQuerySelector by)
        {
            if (by == null) throw new ArgumentNullException("by");

            driver.LoadJQuery();

            var javaScriptDriver = (IJavaScriptExecutor)driver;
            var script = string.Format(CultureInfo.InvariantCulture, "return jQuery('{0}').get(0);", by.Selector);
            var result = javaScriptDriver.ExecuteScript(script) as IWebElement;

            if (result == null)
            {
                throw new NoSuchElementException("No element found with jQuery command: " + by.Selector);
            }

            return result;
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, _JQuerySelector by)
        {
            if (by == null) throw new ArgumentNullException("by");

            driver.LoadJQuery();

            var javaScriptDriver = (IJavaScriptExecutor)driver;
            var script = string.Format(CultureInfo.InvariantCulture, "return jQuery('{0}').get();", by.Selector);
            return javaScriptDriver.ExecuteScript(script) as ReadOnlyCollection<IWebElement>
                ?? new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }
    }
}
