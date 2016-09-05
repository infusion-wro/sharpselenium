namespace Selenium.PageObject.Element.Impl
{
    class DropDownValue : IDropDownValue
    {
        private readonly string value;

        protected DropDownValue(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }
    }
}
