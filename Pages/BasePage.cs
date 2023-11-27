using System;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TibaEvaluationExercise.Utilities;

namespace TibaEvaluationExercise.Pages
{

    public abstract class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        protected IWebElement FindElement(By locator, int timeout, bool elementNone = false)
        {
            try
            {
                Logger.Info($"Attempting to find element with locator: {locator}");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));

                // Wait for the element to be present
                IWebElement element = wait.Until(ExpectedConditions.ElementExists(locator));

                // Wait for the element to be visible and interactable
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (NoSuchElementException ex)
            {
                Logger.Error($"Element with locator: {locator} was not found after {timeout} seconds. Exception: {ex.Message}");
                if (elementNone)
                {
                    Logger.Error($"Element with locator: {locator} not found. elementNone = {elementNone} return null");
                    return null;
                }
                Logger.Error($"Element with locator: {locator} was not visible or interactable after {timeout} seconds. Exception: {ex.Message}");
                throw new NoSuchElementException($"Element with locator: {locator} was not found after {timeout} seconds.");
            }
            catch (WebDriverTimeoutException)
            {
                if (elementNone)
                {
                    Logger.Error($"Element with locator: {locator} not found. elementNone = {elementNone} return null");
                    return null;
                }
                throw new WebDriverTimeoutException($"Element with locator: {locator} was not visible or interactable after {timeout} seconds.");
            }
            catch (Exception ex)
            {
                Logger.Error($"Unexpected error occurred while trying to find the element with locator: {locator}. Exception: {ex.Message}");
                throw new Exception($"Unexpected error occurred while trying to find the element: {ex.Message}", ex);
            }
        }



        protected IWebElement FindElementInElement(IWebElement parent, By locator, int timeout)
        {
            try
            {
                Logger.Info($"Attempting to find element {parent} in element with locator: {locator}");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(drv => parent.FindElement(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Unexpected error occurred while trying to find the element with locator: {locator}. Exception: {ex.Message}");
                throw new NoSuchElementException($"Element with locator: {locator} was not found within parent element after {timeout} seconds.", ex);
            }
        }


        protected IReadOnlyCollection<IWebElement> FindElements(By locator, int timeout)
        {
            try
            {
                Logger.Info($"Attempting to find elements with locator: {locator}");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(drv =>
                {
                    var elements = drv.FindElements(locator);
                    return elements.Count > 0 ? elements : throw new NoSuchElementException();
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Unexpected error occurred while trying to find the elements with locator: {locator}. Exception: {ex.Message}");
                throw new NoSuchElementException($"Elements with locator: {locator} were not found after {timeout} seconds.", ex);
            }
        }

        protected IReadOnlyCollection<IWebElement> FindDisplayedElements(By locator, int timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(drv =>
                {
                    var elements = drv.FindElements(locator).Where(e => e.Displayed).ToList();
                    return elements.Any() ? elements : throw new NoSuchElementException();
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NoSuchElementException($"Displayed elements with locator: {locator} were not found after {timeout} seconds.", ex);
            }
        }


        protected void Click(By locator, int timeout)
        {
            try
            {
                Logger.Info($"Attempting to click in element with locator: {locator}");
                FindElement(locator, timeout).Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Unexpected error occurred while trying click on element with locator: {locator}. Exception: {ex.Message}");
                throw new NoSuchElementException($"Unable to find element to click with locator: {locator} after {timeout} seconds.", ex);
            }
            catch (ElementClickInterceptedException ex)
            {
                Logger.Error($"Unexpected error occurred while trying click on element with locator: {locator}. Exception: {ex.Message}");
                throw new InvalidOperationException($"Element with locator: {locator} was not clickable.", ex);
            }
        }

        protected void ClickElement(IWebElement element)
        {
            try
            {
                Logger.Info($"Attempting to click in element");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(drv => element.Displayed && element.Enabled);

                // Click the element
                element.Click();
            }
            catch (Exception ex) when (ex is ElementClickInterceptedException ||
                                        ex is NoSuchElementException ||
                                        ex is WebDriverTimeoutException)
            {
                Logger.Error($"Unexpected error occurred while trying click on element. Exception: {ex.Message}");
                throw new InvalidOperationException($"Error occurred while clicking on the element: {ex.Message}", ex);
            }
        }


        protected void EnterText(By locator, string text, int timeout)
        {
            try
            {
                Logger.Info($"Attempting to get text in element with locator: {locator}");
                IWebElement element = FindElement(locator, timeout);
                element.Clear();
                element.SendKeys(text);
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Unexpected error occurred while trying to get text from element. Exception: {ex.Message}");
                throw new NoSuchElementException($"Unable to find element to enter text with locator: {locator} after {timeout} seconds.", ex);
            }
            catch (InvalidElementStateException ex)
            {
                Logger.Error($"Unexpected error occurred while trying to get text from element. Exception: {ex.Message}");
                throw new InvalidOperationException($"Unable to enter text in the element with locator: {locator}. Element might not be enabled or visible.", ex);
            }
        }

        protected string GetText(By locator, int timeout)
        {
            try
            {
                Logger.Info($"Attempting to get text form an element");
                return FindElement(locator, timeout).Text;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Unexpected error occurred while trying to get text from element. Exception: {ex.Message}");
                throw new NoSuchElementException($"Unable to find element to get text with locator: {locator} after {timeout} seconds.", ex);
            }
        }

        protected string GetTextFromElement(IWebElement element)
        {
            try
            {
                Logger.Info("Attempting to get text from an element");
                string text = element.GetAttribute("innerText");
                text = Regex.Replace(text, @"\s+", "");
                Logger.Info($"Element text: {text}");
                return text;
            }
            catch (Exception ex)
            {
                Logger.Error($"Unexpected error occurred while trying to get text from element. Exception: {ex.Message}");
                throw new InvalidOperationException("Error while retrieving text from element.", ex);
            }
        }


        public void ScrollToElementWithActions(IWebElement element)
        {
            Logger.Info($"Attempting to scroll to an element");
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }


        protected void NavigateTo(string url)
        {
            try
            {
                Logger.Info($"Attempting to navigate to {url}");
                Driver.Navigate().GoToUrl(url);
            }
            catch (WebDriverException ex)
            {
                Logger.Error($"Unable to navigate to URL: {url}. {ex}");
                throw new InvalidOperationException($"Unable to navigate to URL: {url}.", ex);
            }
        }

        protected void WaitForElementToDisappear(By locator, int timeout)
        {
            try
            {
                Logger.Info($"Attempting to wait for element to disappear with locator: {locator}");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error($"Element with locator: {locator} did not disappear after {timeout} seconds. ex: {ex}");
                throw new Exception($"Element with locator: {locator} did not disappear after {timeout} seconds.", ex);
            }
        }


    }
}