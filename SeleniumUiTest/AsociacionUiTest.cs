using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumUiTest
{
    [TestClass]
    public class AsociacionUiTest
    {
        private string _websiteURL = "http://localhost:57466/tipoIngresos";
        private RemoteWebDriver _browserDriver;
        public TestContext testContext { get; set; }

        [TestInitialize]
        public void nitialize()
        {
            _websiteURL = (string) testContext.Properties["webAppUrl"];
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [DataRow("Tipo 1.1")]
        
        public void CreateIngreso(string TpIngreso)
        {
            _browserDriver = new ChromeDriver();
            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Navigate().GoToUrl(_websiteURL);
            //_browserDriver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(3));

            _browserDriver.FindElementById("descripcions").SendKeys(TpIngreso);

            var screenshot = _browserDriver.GetScreenshot();
            var fileName = $"{TpIngreso}.jpg";
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
            testContext.AddResultFile(fileName);

            _browserDriver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            //_browserDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(_browserDriver.PageSource.Contains(TpIngreso));

        }

    }
}
