using Selenium.By;

namespace Selenium.PageObject.Element.Impl
{
    class PageElement : IPageElement
    {
        private readonly ByType byType;
        private readonly string expression;

        protected PageElement(ByType byType, string expression)
        {
            this.byType = byType;
            this.expression = expression;
        }

        public string Expression
        {
            get { return expression; }
        }

        public string Type
        {
            get { return byType.Name; }
        }

        public OpenQA.Selenium.By GetBy(params string[] placeholders)
        {
            return ByFactory.Get(byType, expression, placeholders);
        }
    }
}
