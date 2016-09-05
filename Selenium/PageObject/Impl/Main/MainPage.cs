using OpenQA.Selenium;
using Selenium.PageObject.Impl.Results;

namespace Selenium.PageObject.Impl.Main
{
    class MainPage : PageObject<MainPageElement>
    {
        public MainPage(IWebDriver session) : base(session)
        {
            SESSION.Navigate().GoToUrl(URL);
        }

        public ResultsPage ClickResultsPage()
        {
            Click(MainPageElement.RESULTS_LINK);
            return new ResultsPage(SESSION);
        }
    }
}
