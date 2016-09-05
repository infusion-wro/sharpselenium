using Selenium.PageObject.Element.Impl;

namespace Selenium.PageObject.Impl.Results.Element.DropDown
{
    class TournamentDropDownValue : DropDownValue
    {
        public static readonly TournamentDropDownValue OFFICIAL_MATCHES = new TournamentDropDownValue("Mecze oficjalne");
        public static readonly TournamentDropDownValue UNOFFICIAL_MATCHES = new TournamentDropDownValue("Mecze nieoficjalne");

        private TournamentDropDownValue(string value) : base(value)
        {
        }
    }
}
