using Jiminny.UITests.TestInfrastructure.Extensions;
using Jiminny.UITests.TestInfrastructure.Helpers;
using Jiminny.UITests.TestInfrastructure.Managers;
using Jiminny.UITests.TestInrastructure.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace Jiminny.UITests.TestInfrastructure.Pages
{
    public class BaseFacade<TElements, TValidator> where TElements : BaseElements, new()
        where TValidator : BaseValidator<TElements>, new()
    {
        public BaseFacade() { }

        protected TElements Elements => new();

        public TValidator Validate()
        {
            return new TValidator();
        }

        public void NavigateToHomePage()
        {
            string url = AppConfigManager.GetBaseUrl();

            NavigateToURL(url);
            WebElementUtility.WaitForElementToBeDisplayed(() => Elements.HomePageSection);
        }

        protected void NavigateToURL(string url)
        {
            Browser.Instance.WebDriver.Navigate().GoToUrl(url);
        }       

        protected void ClickOn(IWebElement element)
        {
            element.WaitForElementToBeClickable();
            element.Click();
        }

        protected void ClickOn(Func<IWebElement> action)
        {
            var element = WebElementUtility.WaitForElementToBeDisplayed(action);

            element.WaitForElementToBeClickable();
            element.Click();
        }

        protected void ClickOnWithActions(IWebElement element)
        {
            var actions = new Actions(Browser.Instance.WebDriver);

            actions.MoveToElement(element).Click().Perform();
        }

        protected void EnterTextInField(Func<IWebElement> element, string text)
        {
            var field = WebElementUtility.WaitForElementToBeDisplayed(element);

            field.Clear();
            field.SendKeys(text);
        }
    }
}
