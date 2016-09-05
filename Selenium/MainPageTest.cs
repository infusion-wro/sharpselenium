using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Selenium.PageObject.Impl.Main;

namespace Selenium
{
    [TestFixture]
    class MainPageTest
    {
        [Test]
        public void GoToResultsLink()
        {
            IWebDriver SESSION = new FirefoxDriver();
            MainPage mainPage = new MainPage(SESSION);
            mainPage.ClickResultsPage();
            SESSION.Close();
        }
    }
}
