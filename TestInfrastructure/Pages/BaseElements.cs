using Jiminny.UITests.TestInfrastructure.Extensions;
using Jiminny.UITests.TestInrastructure.Drivers;
using OpenQA.Selenium;

namespace Jiminny.UITests.TestInfrastructure.Pages
{
    public class BaseElements
    {
        protected readonly IWebDriver Driver;

        protected BaseElements()
        {
            Driver = Browser.Instance.WebDriver;
        }

        public IWebElement HomePageSection => Driver.FindElementWithExplicitWait(By.XPath("//section[@class='todoapp']"));
    }
}
