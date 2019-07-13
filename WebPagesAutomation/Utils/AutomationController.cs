using System;
using System.Diagnostics;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

namespace WebPagesAutomation.Utils
{
    public class AutomationController
    {
        # region members

        private IWebDriver _driver = null; // web-driver, to control the browser
        
        # endregion

        # region properties

        public IWebDriver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }

        # endregion

        # region public methods

        public void Initialize(String resourcesPath)
        {
            // create web-driver object
            _driver = WebDriverMaster.GetWebDriver(resourcesPath);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);            
        }

        public void ClearSession()
        {
            ChromeDriver chromeDriver = (ChromeDriver)_driver;
            chromeDriver.ExecuteScript("window.sessionStorage.clear();");
            chromeDriver.ExecuteScript("window.localStorage.clear();");
            _driver = chromeDriver;
        }

        public void Dismiss()
        {
            if (null != _driver)
            {
                _driver.Quit();
            }
            _driver = null;
        }

        public void LoadPage(String url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        
        # endregion

        # region helper methods

        // get a method's name, for logging
        private String GetCurrentMethodName()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }

        # endregion
    }
}
