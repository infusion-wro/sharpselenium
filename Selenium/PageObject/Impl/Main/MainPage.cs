using OpenQA.Selenium;

namespace Selenium.PageObject.Impl.Main
{
    class MainPage : PageObject<MainPageElement>
    {
        public MainPage(IWebDriver session) : base(session)
        {
            SESSION.Navigate().GoToUrl(URL);
        }

        public void ClickResultsPage()
        {
            Click(MainPageElement.RESULTS_LINK);
        }
    }
}
