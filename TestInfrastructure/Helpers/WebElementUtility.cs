using Jiminny.UITests.TestInfrastructure.Constants;
using Jiminny.UITests.TestInfrastructure.Extensions;
using Jiminny.UITests.TestInrastructure.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jiminny.UITests.TestInfrastructure.Helpers
{
    public static class WebElementUtility
    {
       

        public static IWebElement WaitForElementToBeDisplayed(Func<IWebElement> element)
        {
            var wait = Browser.Instance.Wait;

            wait.Until(condition =>
            {
                try
                {
                    var isDisplayed = element.Invoke().Displayed;

                    if (isDisplayed == false)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Type exType = e.GetType();

                    if (exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(NoSuchElementException))
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
            });

            return element.Invoke();
        }

        public static IWebElement WaitForElementToExistInDom(Func<IWebElement> element)
        {
            var wait = Browser.Instance.Wait;

            wait.Until(condition =>
            {
                try
                {
                    if (DoesElementExistInDom(element))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Type exType = e.GetType();

                    if (exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(NoSuchElementException))
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
            });

            return element.Invoke();
        }

        public static IEnumerable<IWebElement> WaitForElementsToExistInDom(Func<IEnumerable<IWebElement>> elements)
        {
            var wait = Browser.Instance.Wait;

            wait.Until(condition =>
            {
                try
                {
                    if (DoElementsExistInDom(elements))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Type exType = e.GetType();

                    if (exType == typeof(StaleElementReferenceException) ||
                        exType == typeof(NoSuchElementException))
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
            });

            return elements.Invoke();
        }

        public static bool DoesElementExistInDom(Func<IWebElement> webElement)
        {
            var doesExist = false;
            try
            {
                var element = webElement.Invoke();
                if (element != null)
                    doesExist = true;
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (InvalidElementStateException)
            {
            }
            catch (InvalidOperationException)
            {
            }
            catch (NoSuchElementException)
            {
            }
            catch (NullReferenceException)
            {
            }

            return doesExist;
        }

        public static bool DoElementsExistInDom(Func<IEnumerable<IWebElement>> webElements)
        {
            var doesExist = false;
            try
            {
                var elements = webElements.Invoke();
                if (elements != null && elements.Any())
                    doesExist = true;
            }
            catch (StaleElementReferenceException)
            {
                doesExist = false;
            }
            catch (NoSuchElementException)
            {
                doesExist = false;
            }
            catch (NullReferenceException){}

            return doesExist;
        }

        public static void MoveCursorOverElement(IWebElement element)
        {
            var builder = new Actions(Browser.Instance.WebDriver);

            element.WaitForElementToBeClickable();           
            builder.MoveToElement(element).Build().Perform();
        }
    }
}
