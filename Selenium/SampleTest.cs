using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Selenium.PageObject.Impl.Main;
using Selenium.PageObject.Impl.Results;
using Selenium.PageObject.Impl.Results.Element;
using Selenium.PageObject.Impl.Results.Element.DropDown;

namespace Selenium
{
    [TestFixture]
    class SampleTest
    {
        private const string DATE = "2014.08.12";
        private const string TOURNAMENT = "Superpuchar Europy - Cardiff";
        private const string MATCH = "Real - Sevilla 2 : 0";

        private readonly IWebDriver SESSION = new FirefoxDriver();

        [Test]
        public void VerifyResult()
        {
            // given
            MainPage mainPage = new MainPage(SESSION);
            ResultsPage resultsPage = mainPage.ClickResultsPage();

            ResultRow.Builder resultRowBuilder = new ResultRow.Builder();
            resultRowBuilder.withDate(DATE).withTournament(TOURNAMENT).withMatch(MATCH);
            ResultRow resultRow = resultRowBuilder.create();

            // when
            resultsPage.SelectTournament(TournamentDropDownValue.OFFICIAL_MATCHES);
            resultsPage.SelectSeason(SeasonDropDownValue.SEASON_2014_2015);
            resultsPage.Click(ResultsPageElement.GO_BUTTON);

            // then
            resultsPage.ShouldHave(ResultsPageElement.RESULTS_ROW, resultRow);
        }
    }
}
