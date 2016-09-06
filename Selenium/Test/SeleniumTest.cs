using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium.Test
{
    class SeleniumTest
    {
        protected static IWebDriver SESSION;

        [SetUp]
        public void SetUp()
        {
            SESSION = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()
        {
            SESSION.Quit();
        }
    }
}
