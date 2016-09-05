using OpenQA.Selenium;
using Selenium.PageObject.Impl.Results.Element;
using Selenium.PageObject.Impl.Results.Element.DropDown;

namespace Selenium.PageObject.Impl.Results
{
    class ResultsPage : PageObject<ResultsPageElement>
    {
        public ResultsPage(IWebDriver session) : base(session)
        {
        }

        public void SelectTournament(TournamentDropDownValue value)
        {
            SetSelectedOption(ResultsPageElement.TOURNAMENT_DROP_DOWN, value);
        }

        public void SelectSeason(SeasonDropDownValue value)
        {
            SetSelectedOption(ResultsPageElement.SEASON_DROP_DOWN, value);
        }
    }
}
