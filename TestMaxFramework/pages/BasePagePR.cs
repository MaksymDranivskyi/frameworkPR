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
        clickScript = "arguments[0].click();",
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
            Log.Debug($"Kliknąć element {element}");
            try
            {
                Report.test.Log(Status.Info, $"Kliknąć element <pre>{element}</pre>");
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
                throw new Exception("Błąd kliknięcia elementu");
            }

        }


        public static void hoverAndClick(By toHover, By toClick, params int[] timeout)
        {
            Log.Debug($"Najechać myszą na element {toHover} i kliknąć element {toClick}");
            try
            {
                Report.test.Log(Status.Info, $"Najechać myszą na element <pre>{toHover}</pre> i kliknąć element <pre>{toClick}</pre>");
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

                //((IJavaScriptExecutor)GetWebDriver()).ExecuteScript(mouseOverScript, S(toHover));
               // WaitUntilElementClickable(toClick,3000);
                //((IJavaScriptExecutor)GetWebDriver()).ExecuteScript(clickScript, S(toClick));
            }
            catch (Exception)
            {

            }
            waitForPageToLoad();
        }



        public static By hover(By element, params int[] timeout)
        {
            Log.Debug($"Najechać myszą na element {element}");
            try
            {
                Report.test.Log(Status.Info, $"Najechać myszą na element <pre>{element}</pre>");
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
                throw new Exception("Błąd najechania");
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
                throw new Exception("Błąd przenoszenia elementu");
            }
            return element;
        }


        public static void waitForPageToLoad()
        {
            Log.Debug("Oczekiwanie na wczytanie strony");
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
            Log.Debug($"Wyszukiwanie elementu {element} ignorując exception");
            try
            {
                Report.test.Log(Status.Info, $"Wyszukiwanie elementu <pre>{element}</pre> ignorując exception");
            }
            catch (NullReferenceException)
            {
            }
            waitForPageToLoad();
            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            waitForPageToLoad();
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
            Log.Debug($"Kliknąć element {element} ignorując exception");
            try
            {
                Report.test.Log(Status.Info, $"Kliknąć element <pre>{element}</pre> ignorując exception");
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

                S(element).Click();
            }
            catch (Exception)
            {
                Log.Information("error");
            }

        }


        public static void selectByIndex(By element, int value, params int[] timeout)
        {
                var passangersElement = GetDriver().FindElement(element);
                var  passangersSelect = new SelectElement(passangersElement);
                passangersSelect.SelectByIndex(value);
            

        }

        public static void selectByString(By element, string value, params int[] timeout)
        {
            Log.Debug($"Wybrać element {element} według stringu {value}");
            try
            {
                Report.test.Log(Status.Info, $"Wybrać element <pre>{element}</pre> według stringu <pre>{value}</pre>");
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
                Log.Information("Błąd wydoru elementu");
            }
        }

        


        public static void selectByText(By element, string value, params int[] timeout)
        {

            Log.Debug($"Wybrać element {element} według textu {value}");
            try
            {
                Report.test.Log(Status.Info, $"Wybrać element <pre>{element}</pre> według textu <pre>{value}</pre>");
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
                Log.Information("Błąd wydoru elementu");
            }
        }








        public static SeleneElement findElement(By element, params int[] timeout)
        {
            Log.Debug($"Wyszukiwanie elementu {element}");
            try
            {
                Report.test.Log(Status.Info, $"Wyszukiwanie elementu <pre>{element}</pre>");
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
                throw new Exception("Błąd wyszukiwania elementu");
            }
        }





        public void switchToFrame(By xpath)
        {
            Log.Debug($"Przełączyć do framu {xpath}");
            try
            {
                Report.test.Log(Status.Info, $"Przełączyć do framu <pre>{xpath}</pre>");
            }
            catch (NullReferenceException)
            {
            }

            GetWebDriver().SwitchTo().Frame(S(xpath));
        }


        public void switchToDefaultContent()
        {
            Log.Debug("Przełączyć do defaultnego contentu");
            try
            {
                Report.test.Log(Status.Info, "Przełączyć do defaultnego contentu");
            }
            catch (NullReferenceException)
            {
            }
            GetWebDriver().SwitchTo().DefaultContent();
        }


        public void scrollTo(int xPosition = 0, int yPosition = 0)
        {
            Log.Debug($"Przewija do pozycji XY ({xPosition},{yPosition})");
            try
            {
                Report.test.Log(Status.Info, $"Przewijać do pozycji XY ({xPosition},{yPosition})");
            }
            catch (NullReferenceException)
            {
            }
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            ExecuteScript(js);

        }


        public SeleneElement scrollToView(By selector)
        {
            Log.Debug($"Przewija do widoku elementu {selector}");
            try
            {
                Report.test.Log(Status.Info, $"Przewijać do widoku elementu <pre>{selector}</pre>");
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
            Log.Debug($"Przewija do widoku elementu {element}");
            try
            {
                Report.test.Log(Status.Info, $"Przewijać do widoku elementu <pre>{element}</pre>");
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
            Log.Debug("Wybrać element z listy checkbox");
            try
            {
                Report.test.Log(Status.Info, $"Zaznaczyć element <pre>{element}</pre> ");
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
                Log.Information("Błąd zaznaczenia elementu");
            }
        }

        public static void selectById(By element, int value, params int[] timeout)
        {
            try
            {
                Report.test.Log(Status.Info, $"Wybrać element <pre>{element}</pre> według pozycji <pre>{value}</pre>");
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
                Log.Information("Błąd wyboru elementu");
            }
            waitForPageToLoad();
        }

        public static void selectYesOrNo(By element, string value, params int[] timeout)
        {
            try
            {
                Report.test.Log(Status.Info, $"Wybrać element <pre>{element}</pre> według znaczenia <pre>{value}</pre>");
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
                Log.Information("Błąd wyboru elementu");
            }
            waitForPageToLoad();

        }



        //public static void calendarDate(By element, string date)
        //{
        //    try
        //    {
        //        Report.test.Log(Status.Info, $"Okreśić datę <pre>{date}</pre> w kalendarzu <pre>{element}</pre>");
        //    }
        //    catch (NullReferenceException)
        //    {
        //    }
        //    waitForPageToLoad();
        //    try
        //    {
        //        sleepFor(100);
        //        clickOnElement(element);

        //        while (isElementPresentAndDisplay(By.XPath($"//td[@aria-label='{date}']")) == false)
        //        {

        //            S(By.CssSelector(".mat-calendar-previous-button")).Click();
        //        }


        //        S(By.CssSelector($"td[aria-label='{date}']")).Click();

        //    }
        //    catch (Exception)
        //    {
        //        Log.Information("Błąd określenia daty");
        //    }
        //}



        public static void typeAndSelect(By element, string value, params int[] timeout)
        {
            try
            {
                Report.test.Log(Status.Info, $"Wybrać elemnt <pre>{element}</pre> według stringu <pre>{value}</pre>");
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
                Log.Information($"Wybrać elemnt <pre>{element}</pre> według stringu <pre>{value}</pre>");
            }
            waitForPageToLoad();
        }


        public static void typeDecription(string language, By element, string value, params int[] timeout)
        {

            int timeoutForFindElement = timeout.Length < 1 ? DEFAULT_TIMEOUT : timeout[0];
            try
            {
                By PolTextSkill = By.XPath("//mat-tab-group/div/mat-tab-body[1]/div/app-rich-text-edit/quill-editor/div[2]/div[1]");
                By EngTextSkill = By.XPath("//mat-tab-group/div/mat-tab-body[2]/div/app-rich-text-edit/quill-editor/div[2]/div[1]");


                WaitUntilElementClickable(element, 30);
                clickOnElement(element, 30);

                if (language == "English")
                {
                    S(EngTextSkill).Set(value);
                }
                else
                {
                    S(PolTextSkill).Set(value);
                }
            }
            catch (Exception)
            {
                Log.Information($"W polu <pre>{element}</pre> wpisać tekst <pre>{value}</pre> w języku {language}");
            }
            waitForPageToLoad();
            try
            {
                Report.test.Log(Status.Info, $"W polu <pre>{element}</pre> wpisać tekst <pre>{value}</pre> w języku {language}");
            }
            catch (NullReferenceException)
            {
            }
        }



        //-----------------------------------------WAIT-------------------------------------///

        public static IWebElement WaitUntilElementExists(By elementLocator, int timeout)
        {
            try
            {

                return S(elementLocator).Should(Be.InDom);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element z locatorem: '" + elementLocator + "'nie został znaleziony.");
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
                Console.WriteLine("Element z lokalizatorem: '" + elementLocator + "' nie został znaleziony.");
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
                Console.WriteLine("Element z lokalizatorem: '" + elementLocator + "' nie został znaleziony.");
                throw;
            }

        }



    }
}
