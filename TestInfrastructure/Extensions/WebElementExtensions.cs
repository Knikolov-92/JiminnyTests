using Jiminny.UITests.TestInfrastructure.Constants;
using Jiminny.UITests.TestInrastructure.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Jiminny.UITests.TestInfrastructure.Extensions
{
    public static class WebElementExtensions
    {       
        public static void WaitForElementToBeClickable(this IWebElement element)
        {
            var wait = new WebDriverWait(Browser.Instance.WebDriver, TimeSpan.FromSeconds(Timeouts.DEFAULT_TIMEOUT_IN_SECONDS));
            wait.Until(ExpectedConditions.ElementSelectionStateToBe(element, false));
        }
    }
}
