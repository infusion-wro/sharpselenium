namespace Selenium.PageObject.Element
{
    interface IPageElement
    {
        OpenQA.Selenium.By GetBy(params string[] placeholders);
        string Type { get; }
        string Expression { get; }
    }
}
