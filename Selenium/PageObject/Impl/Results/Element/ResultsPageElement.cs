using Selenium.By;
using Selenium.PageObject.Element.Impl;

namespace Selenium.PageObject.Impl.Results.Element
{
    class ResultsPageElement : PageElement
    {
        public static readonly ResultsPageElement TOURNAMENT_DROP_DOWN = new ResultsPageElement(ByType.ID, "rozgrywki");
        public static readonly ResultsPageElement SEASON_DROP_DOWN = new ResultsPageElement(ByType.ID, "sezon");
        public static readonly ResultsPageElement GO_BUTTON = new ResultsPageElement(ByType.XPATH, "//input[@value='OK']");
        public static readonly ResultsPageElement RESULTS_ROW = new ResultsPageElement(ByType.XPATH, "//table[@class='tab mecz']//tr[(td[1] = '{0}') and (td[2] = '{1}')  and (td[3]/a = '{2}')]");

        private ResultsPageElement(ByType byType, string expression) : base(byType, expression)
        {
        }
    }
}
