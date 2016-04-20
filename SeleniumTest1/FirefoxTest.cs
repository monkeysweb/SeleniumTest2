using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.WebDriver.Extensions

using By = OpenQA.Selenium.Extensions.By;

namespace SeleniumTest1
{
    public class FirefoxTest
    {
        private IWebDriver _driver;
        private string _emailAddress;
        private string _emailPassword;

        /* todo: make abstract: http://powerdotnetcore.com/selenium/tip-2-basic-installation-of-selenium-webdriver-in-visual-studio-c-sharp */
        public FirefoxTest(IWebDriver driver)
        {
            if (driver == null)
                throw new ArgumentNullException("driver");
            _driver = driver;
        }

        public void SeleniumFirefoxTest1()
        {
            _emailAddress = ConfigurationManager.AppSettings["EmailAddress"];
            _emailPassword = ConfigurationManager.AppSettings["EmailPassword"];

            /* todo: check for nulls & 'Displayed' property */

            // Initialize webdriver  
            //IWebDriver webDriver = new FirefoxDriver();
            //IWebDriver driver = new FirefoxDriver();

            // Navigate by url to website
            const string url1 = "https://www.bing.com";
            const string url2 = "https://mail.yahoo.com";
            const string url3 = "https://login.yahoo.com/config/login_verify2?.intl=ca&.src=ym";
            _driver.Navigate().GoToUrl(url3);   // url2 has been tested (this one used for less redirects)

            _driver.Manage().Window.Maximize();

            // diable/un-check checkbox
            IWebElement cbStayCheckedIn = _driver.FindElement(By.Id("persistent")) ??
                                          _driver.FindElement(By.ClassName(".persistent"));

            #region Comments - Hide Me 1
            //IWebElement cbStayCheckedIn = webDriver.FindElement(By.ClassName(".persistent"));
            //if (cbStayCheckedIn == null)
            //{
            //    for (IWebElement checkbox : selectElements)
            //    {
            //        // uncheck 'em all
            //        if (checkbox.isSelected())
            //        {
            //            checkbox.click();
            //        }
            //    }
            //}
            #endregion

            if (cbStayCheckedIn != null && cbStayCheckedIn.Displayed && cbStayCheckedIn.Selected)
                cbStayCheckedIn.Click();

            //FirefoxWebElement cbStayCheckedIn;
            //cbStayCheckedIn 

            /* todo: add to constructor, if constructor-injection is working */
            // find search field
            IWebElement tbLogin = _driver.FindElement(By.Id("login-username")) ??
                                  _driver.FindElement(By.ClassName("login-input"));
            if (tbLogin == null)
                throw new Exception("Login Id and/or Class does not exist");

            // set "login text"
            //tbLogin.SendKeys("jmr5380@yahoo.com");
            tbLogin.SendKeys(_emailAddress);

            /* todo: add to constructor, if constructor-injection is working */
            // find "Next/Submit button"
            IWebElement submitButton = _driver.FindElement(By.Id("login-signin")) ??
                                       _driver.FindElement(By.ClassName("mbr-buton-primary"));
            if (submitButton == null)
                throw new Exception("Next button does not exist");

            // click "Next/Submit button"
            submitButton.Click();

            Thread.Sleep(GetRandomInt(4, 6) * 1000);    // pause, just in case

            /* todo: add to constructor, if constructor-injection is working */
            /* todo: move this up and refactor */
            // find "password text"
            IWebElement tbPassword = _driver.FindElement(By.Id("login-passwd")) ??
                                  _driver.FindElement(By.ClassName("login-input"));
            if (tbPassword == null)
                throw new Exception("Password Id and/or Class does not exist");

            // set "password text"
            tbPassword.SendKeys(_emailPassword);

            // find "Submit/Login button"
            IWebElement loginButton = _driver.FindElement(By.Id("login-signin")) ??
                                       _driver.FindElement(By.ClassName("mbr-buton-primary"));
            if (loginButton == null)
                throw new Exception("Login/Sign-In button does not exist");

            Thread.Sleep(GetRandomInt(5, 6) * 1000);    // pause, just in case

            // click "login button"
            loginButton.Click();

            Thread.Sleep(GetRandomInt(6,9)*1000);   // pause, just in case

#if DEBUG
            // IN CASE OF YAHOO PHONE# INPUT OR CAPTCHA, PAUSE HERE TO ENTER CODE 
            Console.Write("PAUSE -- Press any key to continue...");
            Console.Read();
#endif

            try
            {
                var x = _driver.FindElement(By.Id("yucs-help_button"));
                //var y = _driver.FindElement(By.XPath("//i[@class='Va(m) W(a)! Fz(22px) Ycon YconSettings C(#32007f) Lts(n) M(-10px) P(10px)'"));
                IWebElement settingsMenu2 = _driver.FindElement(By.XPath("//*[@id='yucs-help_button']"));
                //var z = _driver.FindElement(By.XPath("//a[@class='Va(m) W(a)! Fz(22px) Ycon YconSettings C(#32007f) Lts(n) M(-10px) P(10px)'"));

                var settingsDropdown = _driver.FindElement(By.Id("yucs-help_button"));
                ////var settingsOption = _driver.FindElement(By.XPath("//span[contains(.,'Settings')]"));
                //var builder = new Actions(_driver);
                //builder.MoveToElement(settingsDropdown).Perform();
                //_driver.FindElement(By.XPath("//a[contains(text(),'Settings')]")).Click();
                ////builder.MoveToElement(settingsOption).Build().Perform();
                ////settingsOption.Click();

                var action2 = 4;

                var settingsLinkXPath = "//a[contains(text(),'Settings')]";
                settingsLinkXPath = "//a/span[contains(text(),'Settings')]";

                ////#yucs-help_inner li:eq(1)
                //var jqueryContext = By.JQuerySelector("div#yucs-help_inner");
                //var jquerySelect = By.JQuerySelector("li:eq(1)", jqueryContext);

                WebDriverHelper.MouseHoverByJavaScript(_driver, settingsDropdown);
                //Thread.Sleep(10);
                //_driver.FindElements(jquerySelect).FirstOrDefault();

                //$('#yucs-help_inner li:eq(1)').click()
                //WebDriverHelper.E
                //$("li.item-ii").find("li").css("background-color", "red");
                //var jqClick = "$('#yucs-help_inner.li.eq(1)')"


                var settingsFullXpath = "/html/body/div[6]/div[3]/table/tbody/tr/td[3]/ul/li[3]/div/div/div/ul[1]/li[2]/a";
                var settingsXPath = "//div['yucs-help_inner']/ul/li[2]/a";
                settingsXPath = "//*/ul/li[2]/a";
                settingsXPath = "//div['yucs-help_inner']/ul/li[2]/a/span[contains(text(),'Settings')]";

                if (action2==1)
                {
                    WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(10));
                    IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
                    {
                        //return d.FindElement(By.XPath(settingsLinkXPath));
                        //return d.FindElement(By.XPath(settingsFullXpath));
                        //var settingsSpan = d.FindElement(By.XPath("//div['yucs-help_inner']/ul/li[2]/a/span"));
                        //var settingsSpan = d.FindElement(By.XPath("//div['yucs-help_inner']/ul/li[2]/a"));
                        //var settingsSpan = d.FindElement(By.XPath("//div['yucs-help_inner']/ul/li[2]/a"));
                        //var settingsSpan = d.FindElement(By.XPath("//a/span[contains(text(), 'Settings')]"));
                        var settingsSpan = d.FindElement(By.XPath("//span[contains(.,'Settings')]"));
                        
                        return settingsSpan;
                        //return d.FindElement(By.XPath(settingsXPath));
                        //"//div['yucs-help_inner']/ul/li[2]/a/span"
                    });
                    myDynamicElement.Click();
                }
                else if (action2 == 3)
                {
                    WebDriverWait wait2 = new WebDriverWait(_driver, new TimeSpan(10));
                    //IWebElement settings = wait2.Until(ExpectedConditions.ElementToBeClickable(By.XPath(settingsLinkXPath)));
                    IWebElement settings = wait2.Until(ExpectedConditions.ElementToBeClickable(By.XPath(settingsXPath)));
                    settings.Click();
                }
                else if (action2 == 4)
                {
                    //#yucs-help_inner li:eq(1)
                    WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(10));
                    IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
                    {
                        var jqueryContext = By.JQuerySelector("div#yucs-help_inner");
                        var jquerySelect = By.JQuerySelector("li:eq(1)", jqueryContext);
                        var settingsSpan = d.FindElements(jquerySelect);
                        return settingsSpan[0];
                    });
                    myDynamicElement.Click();
                }

                #region Comments (hide me)
                //MouseHoverByJavaScript()
                //WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(10));
                //IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(settingsLinkXPath)));

                //_driver.Url = "http://somedomain/url_that_delays_loading";
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
                //{
                //    return d.FindElement(By.Id("someDynamicElement"));
                //});
                #endregion

                if (action2 == 0)
                {
                    Actions act = new Actions(_driver);
                    ////act.MoveToElement(_driver.FindElement(By.XPath("//img[contains(@class,'tab-icon')]"))).Perform();
                    act.MoveToElement(_driver.FindElement(By.Id("yucs-help_button"))).Perform();
                    //_driver.FindElement(By.XPath("//span[text()='Settings']")).Click();

                    var innerSettings = "/html/body/div[6]/div[3]/table/tbody/tr/td[3]/ul/li[3]/div/div/div/ul[1]/li[2]";
                    _driver.FindElement(By.XPath(innerSettings)).Click();
                }

                _driver.Close();

                //_driver.FindElement(By.Id("yucs-help_button")).Click();

                //_driver.FindElement(By.LinkText("Settings")).Click();
                //_driver.ExecuteScript("document.getElementById('option').click();")
                //((JavascriptExecutor)_driver).executeScript("document.getElementById('btn').click();");


                //var displayTest = _driver.FindElement(By.Id("yucs-help_button")).Displayed;

                var debugPoint3 = true;

                //new Actions(_driver).MoveToElement(_driver.FindElement(By.Id("yucs-help_button"))).Perform();

            }
            catch (Exception ex)
            {
                var debugPoint4 = true;
            }

            #region Comments - (previous attempts #1)
            //WebElement element = _driver.FindElement(By.id("Element id"));
            //Locatable hoverItem = (Locatable)element;
            //Mouse mouse = ((HasInputDevices)driver).getMouse();
            //mouse.mouseMove(hoverItem.getCoordinates());

            ////click Settings
            ////_driver.FindElement(By.XPath("//a[contains(text(),'Settings')]")).Click();
            //_driver.FindElement(By.XPath("//*[@id='yucs-help_button']")).Click();

            //_driver.AddJQuery();
            ////_driver.RunScript("$('#yucs-help_button').click(); $('a.btn-inbox')[1].click();");   // Settings
            //_driver.RunScript("$('#yucs-help_button').click(); $('a#yucs-help_button')[1].click();");   // Settings

            ////locate the menu to hover over using its xpath
            //IWebElement settingsMenu = _driver.FindElement(By.XPath("//*[@id='yucs-help_button']"));

            //////Initiate mouse action using Actions class
            //Actions builder = new Actions(_driver);

            ////// move the mouse to the earlier identified menu option
            //////builder.MoveToElement(settingsMenu).Build().Perform();
            //builder.MoveToElement(settingsMenu).Build();
            //builder.Perform();
            #endregion

            Thread.Sleep(GetRandomInt(1, 2) * 1000);

            #region Comments - (previous attempts #2)
            // wait for max of 5 seconds before proceeding. This allows sub menu appears properly before trying to click on it
            //WebDriverWait wait = new WebDriverWait(_driver,  new TimeSpan(500000);
            //wait.Until(ExpectedConditions.PresenceOfElementLocated(By.xpath("//*[@id='subNav_music_menu']/tbody/tr[2]/td[1]/a[1]")));  // until this submenu is found

            ////identify menu option from the resulting menu display and click
            ////IWebElement menuOption = _driver.FindElement(By.XPath("//*[@id='subNav_music_menu']/tbody/tr[2]/td[1]/a[1]"));
            ////IWebElement menuOption = _driver.FindElement(By.XPath("//*[data-mad='options']/div/"));
            ////var lookingForCheckMark = Driver.FindElements(By.XPath("//li[@data-action='switch_convview']//i"));
            //IWebElement menuOption = _driver.FindElement(By.XPath("//li[data-mad='options']//i"));
            ////IWebElement menuOption = _driver.FindElement(By.XPath("//*[data-mad='options']"));
            //////li[@data-action='switch_convview']//i
            //menuOption.Click(); // -See more at: http://logicandtricks.com/articles/hover-mouse-menu-and-click-resulting-dropdown-menu-option#sthash.0JTtZvAz.dpuf


            //new Actions(_driver).MoveToElement(_driver.FindElement(By.Id("yucs-help_button"))).Perform();

            //IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            //var jsFindSettings = "return document.getElementById('yucs-help_button');";
            //IWebElement settingsElement = (IWebElement)js.ExecuteScript(jsFindSettings);
            //string values = settingsElement.GetCssValue(); // this will return "Hello from executeautomation


            ////* METHOD 2 (JS) -- */
            ////_driver.FindElements(By.JQuerySelector("#yucs-help_button"));
            //var jsAction = "document.getElementById('yucs-help_button').Click();";
            ////var settingsOnHover = _driver.Execute<string>("return document.yucs-help_button");

            //var settingsOnHover = _driver.Execute<string>("return document.yucs-help_button");
            //new Actions(_driver).MoveToElement(settingsOnHover)
            ////_driver.Execute<>()


            //_driver.FindElementByJsWithWait(_driver, )
            //_driver.ExecuteJavaScript<>

            //var context = By.JQuerySelector("div.myClass");
            //var selector = By.JQuerySelector("ol li", context);
            //driver.FindElements(selector);

            ////_driver.AddJQuery();
            //_driver.ExecuteJavaScript() RunScript("$('#Inbox').click(); $('a.btn-inbox')[0].click();");
            //Thread.Sleep(GetRandomInt(4, 6) * 1000);

            //js.ExecuteScript("return $(\"a:contains('New')\").mouseover();");
            //js.ExecuteScript("return $(\"a:contains('Accounting')\").next(':eq(1)').mouseover();");
            ////js.ExecuteScript("return $(\"a:contains('Account')\").click();");

            /* METHOD #1 -- NOT WORKING (DRIVER ISSUE?) */
            ////Mouse over
            ////yucs-help_button
            ////Actions settingsMouseOver = new Actions(_driver).MoveToElement(_driver.FindElement(By.Id("yucs-profile_text"))).Perform(); ///.perform();
            //new Actions(_driver).MoveToElement(_driver.FindElement(By.Id("yucs-help_button"))).Perform();

            ////click Settings
            //_driver.FindElement(By.XPath("//a[contains(text(),'Settings')]")).Click();


            // var driver = new FirefoxDriver();
            // driver.get("https://login.yahoo.com/config/login_verify2?.intl=ca&.src=ym");
            // driver.manage().window().maximize();

            // WebElement element = driver.findElement(By.id("username"));
            // element.sendKeys("myid@yahoo.com");

            // driver.findElement(By.id("passwd")).sendKeys("mypassword");
            // element.submit();
            // Thread.sleep(40000);

            // driver.findElement(By.linkText("Sign Out")).click();
            // Thread.sleep(40);


            // IWebDriver driver;

            // Driver.Execute
            //(
            //    () => Driver.FindElements(By.Id("btn-conv-view")).FirstOrDefault(x => x.IsDisplayed()),
            //    el => el.Click()
            //);


            // //var c1 = Driver.FindElements(By.XPath("//li[@data-action='switch_convview']//i"));
            // //var c2 = Driver.FindElements(By.XPath("//input[@id='options-enableConv']"));
            // //var c3 = Driver.FindElements(By.XPath("//input[@id='options-enableConv' and @type ='checkbox' and @checked = '1']"));
            // //var c4 = Driver.FindElements(By.XPath("//input[@id='options-enableConv' and @type ='checkbox']"));
            // //Logger.Info(string.Format("c1: {0} / c2: {1} / c3: {2} / c4: {3}", c1, c2, c3, c4));

            // //var d1 =
            // //    Driver.FindElements(By.XPath("//li[@data-action='options-enableConv']//i"))
            // //        .FirstOrDefault(x => x.IsDisplayed());
            // //var d1a = Driver.FindElements(By.XPath("//li[@data-action='options-enableConv']//i")).FirstOrDefault(x => x.IsDisplayed());
            // //var d2 = Driver.FindElements(By.XPath("//input[@id='options-enableConv']")).FirstOrDefault(x => x.IsDisplayed());
            // //var d3 = Driver.FindElements(By.XPath("//input[@id='options-enableConv' and @type ='checkbox' and @checked = '1']")).FirstOrDefault(x => x.IsDisplayed());
            // //var d4 = Driver.FindElements(By.XPath("//input[@id='options-enableConv' and @type ='checkbox']"));
            // //Logger.Info(string.Format("d1: {0} / d1a: {1} / d2: {2} / d3: {3} / d4: {4}", d1, d1a, d2, d3, d4));
            #endregion

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        Random _rnd = new Random();
        protected int GetRandomInt(int min, int max)
        {
            return _rnd.Next(min, max);
        }

        #region Other Methods

        // no longer used (?)
        public void CheckBoxHelper(IWebElement ffCheckBox, bool clickCheckBox = false)
        {
            if (ffCheckBox == null || !ffCheckBox.Displayed) return;

            bool checkstatus = ffCheckBox.Selected; 
            if (checkstatus && clickCheckBox)
            {
                ffCheckBox.Click();
                Console.WriteLine("Checked the checkbox");
            }
            else
            {
                Console.WriteLine("Checkbox is already checked");
            }
        }

        public void CheckBoxHelper(FirefoxWebElement ffCheckBox, bool clickCheckBox = false)
        {
            if (ffCheckBox == null || !ffCheckBox.Displayed) return;

            bool checkstatus = ffCheckBox.Selected;
            if (checkstatus && clickCheckBox)
            {
                ffCheckBox.Click();
                Console.WriteLine("Checked the checkbox");
            }
            else
            {
                Console.WriteLine("Checkbox is already checked");
            }
        }

        #endregion
    }
}
