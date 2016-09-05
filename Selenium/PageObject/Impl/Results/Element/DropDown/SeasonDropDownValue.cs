using Selenium.PageObject.Element.Impl;

namespace Selenium.PageObject.Impl.Results.Element.DropDown
{
    class SeasonDropDownValue : DropDownValue
    {
        public static readonly SeasonDropDownValue SEASON_2014_2015 = new SeasonDropDownValue("Sezon 2014/15");
        public static readonly SeasonDropDownValue SEASON_2015_2016 = new SeasonDropDownValue("Sezon 2015/16");

        private SeasonDropDownValue(string value) : base(value)
        {
        }        
    }
}
