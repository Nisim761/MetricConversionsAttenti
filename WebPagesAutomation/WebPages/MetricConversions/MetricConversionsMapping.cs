using System;

using OpenQA.Selenium;

namespace WebPagesAutomation.WebPages.MetricConversions
{
    public static class MetricConversionsMapping
    {
        // holds logic to locate web-elements in the specific web-page

        // return mapping for temperature button
        public static IWebElement TemperatureButton(IWebDriver driver)
        {
            IWebElement temperatureButton = null;
            temperatureButton = driver.FindElement(By.XPath("//a[@title = 'Temperature Conversion']"));

            return temperatureButton;
        }

        // return mapping for length button
        public static IWebElement LengthButton(IWebDriver driver)
        {
            IWebElement lengthButton = null;
            lengthButton = driver.FindElement(By.XPath("//a[@title = 'Length Conversion']"));

            return lengthButton;
        }

        // return mapping for weight button
        public static IWebElement WeightButton(IWebDriver driver)
        {
            IWebElement weightButton = null;
            weightButton = driver.FindElement(By.XPath("//a[@title = 'Weight Conversion']"));

            return weightButton;
        }

        // return mapping for main page button
        public static IWebElement MainPageButton(IWebDriver driver)
        {
            IWebElement mainPageButton = null;
            mainPageButton = driver.FindElement(By.XPath("//a[text() = 'Metric Conversion']"));

            return mainPageButton;
        }

        // return mapping for celsius to fahrenheit option
        public static IWebElement CelsiosToFahrenheitButton(IWebDriver driver)
        {
            IWebElement celsiosToFahrenheitButton = null;
            celsiosToFahrenheitButton = driver.FindElement(By.XPath("//a[text() = 'Celsius to Fahrenheit']"));

            return celsiosToFahrenheitButton;
        }

        // return mapping for meters to feet option
        public static IWebElement MetersToFeetButton(IWebDriver driver)
        {
            IWebElement metersToFeetButton = null;
            metersToFeetButton = driver.FindElement(By.XPath("//a[text() = 'Meters to Feet']"));

            return metersToFeetButton;
        }

        // return mapping for ounces to grams option
        public static IWebElement OuncesToGramsButton(IWebDriver driver)
        {
            IWebElement ouncesToGramsButton = null;
            ouncesToGramsButton = driver.FindElement(By.XPath("//a[text() = 'Ounces to Grams']"));

            return ouncesToGramsButton;
        }

        // return mapping for input field
        public static IWebElement InputField(IWebDriver driver)
        {
            IWebElement inputField = null;
            inputField = driver.FindElement(By.XPath("//input[@id = 'argumentConv']"));

            return inputField;
        }

        // return mapping for result field
        public static IWebElement ResultField(IWebDriver driver)
        {
            IWebElement resultField = null;
            resultField = driver.FindElement(By.XPath("//p[@id = 'answer']"));

            return resultField;
        }        
    }
}
