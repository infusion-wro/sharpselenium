namespace Selenium.By
{
    class ByFactory
    {
        public static OpenQA.Selenium.By Get(ByType locatorType, string expression, params string[] placeholders)
        {
            expression = string.Format(expression, placeholders);
            switch (locatorType.Name)
            {
                case "xpath":
                    return OpenQA.Selenium.By.XPath(expression);
                case "id":
                    return OpenQA.Selenium.By.Id(expression);
                case "name":
                    return OpenQA.Selenium.By.Name(expression);
                default:
                    return null;
            }
        }
    }
}
