using System;
using System.IO;
using System.Threading;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Serilog;
using Serilog.Events;
using TestMaxFramework.pages;
using TestMaxFramework.Reports;
using AventStack.ExtentReports;
using NSelene;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using NUnit;


namespace TestMaxFramework.pages
{
    public class BasePagePR:Report
    {
        public string BASE_URL = "http://localhost/prestashop_1.7.6.8/";
        public string pageURL = "";
        public string pageTitle = "";

        public static ThreadLocal<IWebDriver> thread = new ThreadLocal<IWebDriver>();
        public static IWebDriver driver() { return thread.Value; }

        public static int DEFAULT_TIMEOUT = getTimeout();
        public static int SHORT_TIMEOUT = getShortTimeout();
        public static int STATIC_TIMEOUT = getStaticTimeout();

        public static string
        mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover',true, false); " +
            "arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}",
        mouseOverScript2 = "var evObj = document.createEvent('MouseEvents'); " +
            "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null); arguments[0].dispatchEvent(evObj);",
        ///clickScript = "arguments[0].click();",
        DragNdropScript = "var ball = document.getElementById('ball'); ball.style.position = 'absolute'; moveAt(e); ";


        private static int getTimeout()
        {
            Log.Debug("Gets the timeout");
            string timeout = "15";
            if (timeout == null)
            {
                Console.WriteLine("DefaultTimeoutInSeconds parameter was not found");
                timeout = "15";
            };

            return Int32.Parse(timeout);
        }


        private static int getShortTimeout()
        {
            Log.Debug("Gets the short timeout");
            string timeout = "3";
            if (timeout == null)
            {
                timeout = "3";
            };

            return Int32.Parse(timeout);
        }


        private static int getStaticTimeout()
        {
            Log.Debug("Gets the static timeout");
            string timeout = "3";
            if (timeout == null)
            {
                timeout = "1000";
            };
            return Int32.Parse(timeout);
        }



        /*--------------------------------------------------------------------------*
         *----------------------------Basic assertion---------------------------------*
         *--------------------------------------------------------------------------*/

        public bool isPageLoaded()
        {
            Log.Debug("Check that the page is loaded");
            //bool result = false;
            try
            {
                Report.test.Log(Status.Info, "Check that the page is loaded");
            }

            catch (NullReferenceException)
            {
            }
            bool result = false;
            if (GetWebDriver().Title.Contains(pageTitle))
                result = true;
            else
            {
                result = false;
            }

            if (GetWebDriver().Url.Contains(pageURL))
                result = true;
            else
            {
                result = false;
            }
            return result;
        }



        public bool isElementPresentAndDisplay(By by)
        {
            Log.Debug("Check that the element is present and display");
            try
            {
                return S(by).Displayed;

            }
            catch (Exception)
            {
                return false;
            }

        }



        /*--------------------------------------------------------------------------*
         *----------------------------Basic actions---------------------------------*
         *--------------------------------------------------------------------------*/

        public void open()
        {
            Log.Debug($"Open this instance {BASE_URL}{pageURL}");
            try
            {
                Report.test.Log(Status.Info, $"Opening of the page <pre>{BASE_URL}{pageURL}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            Open(DriverProvider.baseURL + pageURL);
            if (!isPageLoaded())
            {
                waitForPageToLoad();
            }
            
        }

        public void search(string text)
        {
            Log.Debug($"Search text <pre>{text}</pre>");
            try
            {
                Report.test.Log(Status.Info, $"Search text <pre>{text}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            S(By.Name("search_query")).SendKeys(text).PressEnter();
        }


        public static void clickOnElement(By element, params int[] timeout)
        {
            Log.Debug($"Click on the {element}");
            try
            {
                Report.test.Log(Status.Info, $"Click on the <pre>{element}</pre>");
            }

            catch (NullReferenceException)
            {
            }

            try
            {
                S(element).Click();

            }
            catch (Exception)
            {
                throw new Exception("Error clicking item");
            }

        }


        public static void hoverAndClick(By toHover, By toClick, params int[] timeout)
        {
            Log.Debug($"Hover over {toHover} and click on the {toClick}");
            try
            {
                Report.test.Log(Status.Info, $"Hover over <pre>{toHover}</pre> and click on the <pre>{toClick}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                S(toHover).Hover();
                WaitUntilElementVisible(toClick, 300);
                sleepFor(1000);
                S(toClick).Click();

            }
            catch (Exception)
            {
                throw new Exception("Hover over and click on the element error");
            }
            waitForPageToLoad();
        }



        public static By hover(By element, params int[] timeout)
        {
            Log.Debug($"Hover over {element}");
            try
            {
                Report.test.Log(Status.Info, $"Hover over <pre>{element}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {

                ((IJavaScriptExecutor)GetWebDriver()).ExecuteScript(mouseOverScript, S(element));
            }
            catch (Exception)
            {
                throw new Exception("Hover error");
            }
            return element;
        }


        public static By dragNdrop(By element, params int[] timeout)
        {
            Log.Debug($"Drags and drop element {element}");
            try
            {
                Report.test.Log(Status.Info, $"Drags and drop element <pre>{element}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                ((IJavaScriptExecutor)GetWebDriver()).ExecuteScript(DragNdropScript, S(element));
            }
            catch (Exception)
            {
                throw new Exception("Drags and drop element error");
            }
            return element;
        }


        public static void waitForPageToLoad()
        {
            Log.Debug("Wait for the page to load");
            bool pageIsLoaded = ExecuteScript("return document.readyState").Equals("complete");

            IWait<IWebDriver> wait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(DEFAULT_TIMEOUT));
        }


        public static void sleepFor(int timeout)
        {
            Log.Debug($"Thread sleep {timeout}");

            try
            {
                Thread.Sleep(timeout);
            }
            catch (ThreadInterruptedException)
            {
            }
        }

        public static IWebElement findElementIgnoreException(By element, params int[] timeout)
        {
            Log.Debug($"Find element {element} ignore exception");
            try
            {
                Report.test.Log(Status.Info, $"Find element <pre>{element}</pre> , ignoring the exception");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
           // waitForPageToLoad();
            try
            {

                return S(element).Should(Be.InDom).Should(Be.Visible);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static void clickOnElementIgnoreException(By element, params int[] timeout)
        {
            Log.Debug($"Click on  the element {element}, ignoring the exception");
            try
            {
                Report.test.Log(Status.Info, $"Click on  the element <pre>{element}</pre> , ignoring the exception");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                (new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                       .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));

                findElementIgnoreException(element).Click();
            }
            catch (Exception)
            {
                Log.Information("error");
               // return null;
            }

        }


        public static void selectByIndex(By element, int value, params int[] timeout)
        {
            try
            {
                var passangersElement = GetDriver().FindElement(element);
                var passangersSelect = new SelectElement(passangersElement);
                passangersSelect.SelectByIndex(value);
            }


            catch (Exception)
            {
                Log.Information("Click on  the element error");
            }
        }

        public static void selectByString(By element, string value, params int[] timeout)
        {
            Log.Debug($"Select element {element} by value {value}");
            try
            {
                Report.test.Log(Status.Info, $"Select element <pre>{element}</pre> by value <pre>{value}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                (new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                var passangersElement = GetDriver().FindElement(element);
                var passangersSelect = new SelectElement(passangersElement);
                passangersSelect.SelectByValue(value);
            }
            catch (Exception)
            {
                Log.Information("Selecting element error");
            }
        }

        


        public static void selectByText(By element, string value, params int[] timeout)
        {

            Log.Debug($"Select element {element} by text {value}");
            try
            {
                Report.test.Log(Status.Info, $"Select element <pre>{element}</pre> by text <pre>{value}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                (new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                IWebElement passangersElement = findElement(element);
                SelectElement passangersSelect = new SelectElement(passangersElement);
                passangersSelect.SelectByText(value);
            }
            catch (Exception)
            {
                Log.Information("Error selecting element ");
            }
        }








        public static SeleneElement findElement(By element, params int[] timeout)
        {
            Log.Debug($"Find element {element}");
            try
            {
                Report.test.Log(Status.Info, $"Find element <pre>{element}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
            try
            {
                (new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(timeoutForFindElement)))
                        .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
                return S(element);
            }
            catch (Exception)
            {
                throw new Exception("Error finding element");
            }
        }





        public void switchToFrame(By xpath)
        {
            Log.Debug($"Switch to frame {xpath}");
            try
            {
                Report.test.Log(Status.Info, $"Switch to frame <pre>{xpath}</pre>");
            }
            catch (NullReferenceException)
            {
            }

            GetWebDriver().SwitchTo().Frame(S(xpath));
        }


        public void switchToDefaultContent()
        {
            Log.Debug("Switch to default content");
            try
            {
                Report.test.Log(Status.Info, "Switch to default content");
            }
            catch (NullReferenceException)
            {
            }
            GetWebDriver().SwitchTo().DefaultContent();
        }


        public void scrollTo(int xPosition = 0, int yPosition = 0)
        {
            Log.Debug($"Scroll to XY ({xPosition},{yPosition})");
            try
            {
                Report.test.Log(Status.Info, $"Scroll to XY ({xPosition},{yPosition})");
            }
            catch (NullReferenceException)
            {
            }
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            ExecuteScript(js);

        }


        public SeleneElement scrollToView(By selector)
        {
            Log.Debug($"Scroll to element {selector}");
            try
            {
                Report.test.Log(Status.Info, $"Scroll to element <pre>{selector}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            var element = S(selector);
            scrollToView(element);
            return element;
        }


        public void scrollToView(IWebElement element)
        {
            Log.Debug($"Scroll to element {element}");
            try
            {
                Report.test.Log(Status.Info, $"Scroll to element <pre>{element}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            if (element.Location.Y > 200)
            {
                scrollTo(0, element.Location.Y - 100);
            }

        }



        public static void checkElement(By element, params int[] timeout)
        {
            Log.Debug($"Mark the element  {element}");
            try
            {
                Report.test.Log(Status.Info, $"Mark the element <pre>{element}</pre> ");
            }
            catch (NullReferenceException)
            {
            }
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                if (!GetDriver().FindElement(element).Selected) { GetDriver().FindElement(element).Click(); }
                else { }

                
            }
            catch (Exception)
            {
                Log.Information("Error marking the element");
            }
        }

        public static void selectById(By element, int value, params int[] timeout)
        {
            try
            {
                Report.test.Log(Status.Info, $"Select element <pre>{element}</pre> by position <pre>{value}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                WaitUntilElementVisible(element, timeoutForFindElement);
                clickOnElement(element);
                clickOnElementIgnoreException(By.XPath($"//mat-option[{value}]/span"));
            }
            catch (Exception)
            {
                Log.Information("Error selecting the element");
            }
            waitForPageToLoad();
        }

        public static void selectYesOrNo(By element, string value, params int[] timeout)
        {
            try
            {
                Report.test.Log(Status.Info, $"Select element <pre>{element}</pre> by YES/NO <pre>{value}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];

            try
            {
                S(element).Should(Be.Visible).Click();
                if (value == "Yes" || value == "Tak") clickOnElementIgnoreException(By.XPath($"//mat-option[2]/span"));
                else if (value == "No" || value == "Nie") clickOnElementIgnoreException(By.XPath($"//mat-option[3]/span"));
                else clickOnElementIgnoreException(By.XPath($"//mat-option[1]/span"));
            }
            catch (Exception)
            {
                Log.Information("Error selecting the element");
            }
            waitForPageToLoad();

        }



        public static void typeAndSelect(By element, string value, params int[] timeout)
        {
            try
            {
                Report.test.Log(Status.Info, $"Select element <pre>{element}</pre>  by string <pre>{value}</pre>");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                WaitUntilElementVisible(element, timeoutForFindElement);
                S(element).Should(Be.Visible).SendKeys(value);
                WaitUntilElementVisible(By.XPath("//div/div/mat-option[1]/span"), timeoutForFindElement);
                S(By.XPath("//div/div/mat-option[1]/span")).Should(Be.Visible);
                clickOnElement(By.XPath("//div/div/mat-option[1]/span"));
                sleepFor(100);
            }
            catch (Exception)
            {
                Log.Information($"Select element <pre>{element}</pre> by string <pre>{value}</pre>");
            }
            waitForPageToLoad();
        }


        //public static void typeDecription(string language, By element, string value, params int[] timeout)
        //{

        //    int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
        //    try
        //    {
        //        By PolTextSkill = By.XPath("//mat-tab-group/div/mat-tab-body[1]/div/app-rich-text-edit/quill-editor/div[2]/div[1]");
        //        By EngTextSkill = By.XPath("//mat-tab-group/div/mat-tab-body[2]/div/app-rich-text-edit/quill-editor/div[2]/div[1]");


        //        WaitUntilElementClickable(element, 30);
        //        clickOnElement(element, 30);

        //        if (language == "English")
        //        {
        //            S(EngTextSkill).Set(value);
        //        }
        //        else
        //        {
        //            S(PolTextSkill).Set(value);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Log.Information($"W polu <pre>{element}</pre> wpisać tekst <pre>{value}</pre> w języku {language}");
        //    }
        //    waitForPageToLoad();
        //    try
        //    {
        //        Report.test.Log(Status.Info, $"W polu <pre>{element}</pre> wpisać tekst <pre>{value}</pre> w języku {language}");
        //    }
        //    catch (NullReferenceException)
        //    {
        //    }
        //}



        //-----------------------------------------WAIT-------------------------------------///

        public static IWebElement WaitUntilElementExists(By elementLocator, int timeout)
        {
            try
            {

                return S(elementLocator).Should(Be.InDom);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element: '" + elementLocator + "' not found");
                throw;
            }
        }

        public static SeleneElement WaitUntilElementVisible(By elementLocator, int timeout)
        {
            try
            {
                return S(elementLocator).Should(Be.Visible);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element: '" + elementLocator + "' not found");
                throw;
            }
        }


        public static IWebElement WaitUntilElementClickable(By elementLocator, int timeout)
        {

            try
            {
                S(elementLocator).Should(Be.Visible);
                var wait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element: '" + elementLocator + "' not found");
                throw;
            }

        }



    }
}
