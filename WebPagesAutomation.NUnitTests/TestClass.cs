using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using WebPagesAutomation.Utils;
using WebPagesAutomation.WebPages.MetricConversions;
using WebPagesAutomation.Enums;

namespace WebPagesAutomation.NUnitTests
{
    [TestFixture]
    public class TestClass
    {
        # region members

        private String _resourcesPath = Path.Combine(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.Parent.FullName, @"WebPagesAutomation\Resources");
        private AutomationController _controller = null;
        
        # endregion

        # region tests

        [SetUp]
        public void Init()
        {
            _controller = new AutomationController();
        }

        [TearDown]
        public void Terminate()
        {
            _controller.Dismiss();
            _controller = null;
        }

        [TestCase("https://www.metric-conversions.org/", -100)]
        public void ConvertTemperatureCelsiusToFahrenheit(String url, double input)
        {
            try
            {
                // initialize
                _controller.Initialize(_resourcesPath);
                MetricConversions mc = new MetricConversions();
                mc.Initialize(_controller.Driver);

                // load the web-page
                _controller.LoadPage(mc.GetUrl());

                // click on temperature button
                mc.ClickOnTemperatureButton();

                // choose option celsius to fahrenheit
                mc.ClickOnCelsiusToFahrenheit();

                // fill in value in celsuis
                mc.FillValueInInputField(input);

                // retrieve value in fahrenheit
                double answer = mc.RetrieveValueResultField(EConversionType.CelsiusToFahrenheit);

                // use formula to calcule answer: °F =°C * 1.8000 + 32.00
                double expectedAnswer = (input * 1.8) + 32.0;
                String message = "Test: " + GetCurrentMethodName() + " Passed, input = " + input + ", result = " + answer;
                Assert.AreEqual(expectedAnswer, answer, 0.5, message);
            }
            catch (Exception e)
            {
                Assert.Fail("Test " + GetCurrentMethodName() + " Failed" + Environment.NewLine + e.Message);
            }
            finally
            {
                _controller.ClearSession();
                _controller.Dismiss();
            }
        }

        [TestCase("https://www.metric-conversions.org/", 100)]
        public void ConvertLengthMetersToFeet(String url, double input)
        {
            try
            {
                // initialize
                _controller.Initialize(_resourcesPath);
                MetricConversions mc = new MetricConversions();
                mc.Initialize(_controller.Driver);

                // load the web-page
                _controller.LoadPage(mc.GetUrl());

                // click on length button
                mc.ClickOnLengthButton();

                // choose option meters to feet
                mc.ClickOnMetersToFeet();

                // fill in value in meters
                mc.FillValueInInputField(input);

                // retrieve value in feet
                double answer = mc.RetrieveValueResultField(EConversionType.MetersToFeet);

                // use formula to calcule answer: ft = m * 3.2808
                double expectedAnswer = (input * 3.2808);
                String message = "Test: " + GetCurrentMethodName() + " Passed, input = " + input + ", result = " + answer;
                Assert.AreEqual(expectedAnswer, answer, 0.5, message);
            }
            catch (Exception e)
            {
                Assert.Fail("Test " + GetCurrentMethodName() + " Failed" + Environment.NewLine + e.Message);
            }
            finally
            {
                _controller.ClearSession();
                _controller.Dismiss();
            }
        }

        [TestCase("https://www.metric-conversions.org/", 100)]
        public void ConvertWeightOuncesToGrams(String url, double input)
        {
            try
            {
                // initialize
                _controller.Initialize(_resourcesPath);
                MetricConversions mc = new MetricConversions();
                mc.Initialize(_controller.Driver);

                // load the web-page
                _controller.LoadPage(mc.GetUrl());

                // click on weight button
                mc.ClickOnWeightButton();

                // choose option ounces to grams
                mc.ClickOnOuncesToGrams();

                // fill in value in meters
                mc.FillValueInInputField(input);

                // retrieve value in feet
                double answer = mc.RetrieveValueResultField(EConversionType.OuncesToGrams);

                // use formula to calcule answer: oz = g / 0.035274
                double expectedAnswer = (input / 0.035274);
                String message = "Test: " + GetCurrentMethodName() + " Passed, input = " + input + ", result = " + answer;
                Assert.AreEqual(expectedAnswer, answer, 0.5, message);
            }
            catch (Exception e)
            {
                Assert.Fail("Test " + GetCurrentMethodName() + " Failed" + Environment.NewLine + e.Message);
            }
            finally
            {
                _controller.ClearSession();
                _controller.Dismiss();
            }
        }

        # endregion

        # region Helper methods

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
