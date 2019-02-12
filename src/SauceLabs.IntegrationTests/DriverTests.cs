namespace SauceLabs.IntegrationTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Safari;
    using System;

    [TestClass]
    public class DriverTests
    {
        private static readonly Uri RemoteAddress = new Uri("http://ondemand.saucelabs.com:80/wd/hub");

        private string sauceUserName = Environment.GetEnvironmentVariable("sauceUserName");
        private string sauceAccessKey = Environment.GetEnvironmentVariable("sauceAccessKey");

        [TestMethod]
        public void ChromeDriverTest()
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability("username", sauceUserName, true);
            options.AddAdditionalCapability("accessKey", sauceAccessKey, true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);

            using (var driver = new RemoteWebDriver(RemoteAddress, options.ToCapabilities(), TimeSpan.FromSeconds(60)))
            {
                driver.Navigate().GoToUrl("https://login.live.com");
            }
        }

        [TestMethod]
        public void FirefoxDriverTest()
        {
            var options = new FirefoxOptions();
            options.AddAdditionalCapability("username", sauceUserName, true);
            options.AddAdditionalCapability("accessKey", sauceAccessKey, true);

            using (var driver = new RemoteWebDriver(RemoteAddress, options.ToCapabilities(), TimeSpan.FromSeconds(60)))
            {
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                driver.Navigate().GoToUrl("https://login.live.com");
            }
        }

        [TestMethod]
        public void SafariDriverTest()
        {
            var options = new SafariOptions();
            options.AddAdditionalCapability(CapabilityType.Version, "latest");
            options.AddAdditionalCapability(CapabilityType.Platform, "macOS 10.13");
            options.AddAdditionalCapability("username", sauceUserName);
            options.AddAdditionalCapability("accessKey", sauceAccessKey);

            using (var driver = new RemoteWebDriver(RemoteAddress, options.ToCapabilities(), TimeSpan.FromSeconds(60)))
            {
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                //driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
                driver.Navigate().GoToUrl("https://login.live.com");
            }
        }
    }
}