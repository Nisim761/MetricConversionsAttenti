using System;
using System.Xml;

using OpenQA.Selenium;

using WebPagesAutomation.Utils;

namespace WebPagesAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            String resourceFolderPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Resources");
            
            AutomationController aut = new AutomationController();
            aut.Initialize(resourceFolderPath);
            
            IWebDriver driver = WebDriverMaster.GetWebDriver(null);

            driver.Navigate().GoToUrl("https://www.metric-conversions.org/");

            System.Threading.Thread.Sleep(3000);
            if (null != driver)
                driver.Quit();           
        }
    }
}
