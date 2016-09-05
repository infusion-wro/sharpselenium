using Selenium.By;
using Selenium.PageObject.Element.Impl;

namespace Selenium.PageObject.Impl.Main
{
    class MainPageElement : PageElement
    {
        public static readonly MainPageElement RESULTS_LINK = new MainPageElement(ByType.XPATH, "//a[.=':: Wyniki']");

        private MainPageElement(ByType byType, string expression) : base(byType, expression)
        {
        }
    }
}
