using System;
using System.IO;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebPagesAutomation
{
    public static class WebDriverMaster
    {
        # region members

        private static readonly String _webDriverPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Resources");

        # endregion

        # region methods

        // return a driver for a browser
        public static IWebDriver GetWebDriver(String path = null)
        {
            try
            {
                return CreateChromeDriver(path);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Error creating a web-driver");
                Console.Out.WriteLine(e.Message);
                return null;
            }
        }

        # endregion

        # region helper methods

        // create a driver for Chrome
        private static IWebDriver CreateChromeDriver(String path = null)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArguments("--disable-infobars");

            ChromeDriver chromeDriver = null;
            if (null == path)
                chromeDriver = new ChromeDriver(_webDriverPath, options, TimeSpan.FromSeconds(30));
            else
                chromeDriver = new ChromeDriver(path, options);

            chromeDriver.Manage().Cookies.DeleteAllCookies();

            return chromeDriver;
        }

        # endregion
    }
}
