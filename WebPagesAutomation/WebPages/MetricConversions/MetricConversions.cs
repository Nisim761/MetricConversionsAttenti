using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

using WebPagesAutomation.Enums;

namespace WebPagesAutomation.WebPages.MetricConversions
{
    public class MetricConversions
    {
        # region members

        protected IWebDriver _driver; // reference to the web-driver
        protected String _mainWindow = null; // handle of main window
        protected Actions _actions = null; // actions object
        protected IJavaScriptExecutor _executor = null; // java-script object
        private String _url = "https://www.metric-conversions.org/";

        # endregion

        # region public methods

        public void Initialize(IWebDriver driver)
        {
            _driver = driver;
            _actions = new Actions(_driver);
            _executor = (IJavaScriptExecutor)_driver;
        }

        public String GetUrl()
        {
            return _url;
        }
        
        public void ClickOnTemperatureButton()
        {
            IWebElement temperatureButton = MetricConversionsMapping.TemperatureButton(_driver);
            if (null != temperatureButton)
            {
                temperatureButton.Click();
            }
        }

        public void ClickOnCelsiusToFahrenheit()
        {
            IWebElement celsiusToFahrenheitButton = MetricConversionsMapping.CelsiosToFahrenheitButton(_driver);
            if (null != celsiusToFahrenheitButton)
            {
                celsiusToFahrenheitButton.Click();
            }
        }

        public void ClickOnLengthButton()
        {
            IWebElement lengthButton = MetricConversionsMapping.LengthButton(_driver);
            if (null != lengthButton)
            {
                lengthButton.Click();
            }
        }

        public void ClickOnMetersToFeet()
        {
            IWebElement metersToFeetButton = MetricConversionsMapping.MetersToFeetButton(_driver);
            if (null != metersToFeetButton)
            {
                metersToFeetButton.Click();
            }
        }

        public void ClickOnWeightButton()
        {
            IWebElement weightButton = MetricConversionsMapping.WeightButton(_driver);
            if (null != weightButton)
            {
                weightButton.Click();
            }
        }

        public void ClickOnOuncesToGrams()
        {
            IWebElement ouncesToGramsButton = MetricConversionsMapping.OuncesToGramsButton(_driver);
            if (null != ouncesToGramsButton)
            {
                ouncesToGramsButton.Click();
            }
        }

        public void FillValueInInputField(double value)
        {
            IWebElement inputField = MetricConversionsMapping.InputField(_driver);
            if (null != inputField)
            {
                inputField.Click();
                inputField.Clear();
                inputField.SendKeys(value.ToString());
            }
        }

        public double RetrieveValueResultField(EConversionType conversionType)
        {
            IWebElement resultField = MetricConversionsMapping.ResultField(_driver);
            double value = double.MinValue;
            if (null != resultField)
            {
                String answer = resultField.Text;
                answer = answer.Substring(answer.IndexOf("=") + 1);
                answer = answer.Substring(0, answer.Length - 2);
                answer = answer.Trim();
                switch (conversionType)
                {
                    case EConversionType.CelsiusToFahrenheit:
                        value = double.Parse(answer);
                        break;

                    case EConversionType.MetersToFeet:
                        value = ParseFeetString(answer);
                        break;

                    case EConversionType.OuncesToGrams:
                        value = double.Parse(answer);
                        break;
                }                
            }
            return value;
        }

        private double ParseFeetString(String str)
        {
            // need to cut the substring "ft"
            String feetStr = str.Split('f')[0];
            double feet = double.Parse(feetStr);
            String inchesStr = str.Split('t')[1];
            double inches = double.Parse(inchesStr);
            double answer = feet + (inches / 12.0);
            return answer; // according to the formula: 1 feet = 12 inches
        }

        # endregion
    }
}
