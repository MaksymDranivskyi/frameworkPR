using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using NSelene;
using static NSelene.Selene;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TestMaxFramework.utils;

namespace TestMaxFramework
{
    // In the app.config file, we specify one of the browsers that we want to run tests on
    // This class is responsible for operating systems, browser, and paths to screenshots
    public class DriverProvider
    {
        private static IWebDriver webDriver;
        SeleneDriver seleneDriver;
        public static string baseURL = ConfigurationManager.AppSettings["base_url"];
        public static string browser = ConfigurationManager.AppSettings["browser"];
        private static FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "/drivers"); // location of the geckdriver.exe file


        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver(service);
                    break;
            }
            SetWebDriver(webDriver);
            GetWebDriver().Manage().Window.Maximize();
            GetWebDriver().Manage().Cookies.DeleteAllCookies();
            GetWebDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static string Title
        {
            get { return webDriver.Title; }
        }



        public static void Close()
        {
            GetWebDriver().Quit();
        }

        public static void TakeScreen()
        {
            string screenshotPath = Path.Combine(@"E:\repos\Framework\TestMaxFramework\bin\Debug\Reports\screenshot.png");
            Screenshot scrsht = ((ITakesScreenshot)webDriver).GetScreenshot();
            scrsht.SaveAsFile(screenshotPath);
        }

        public static string TakeScreen(string path)
        {
            string screenshotPath = Path.Combine($"{path}.png");
            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            ss.SaveAsFile(screenshotPath);
            return screenshotPath;
        }

        /// Returns type of current OS
        public static string GetOS()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    return "Windows";
                case PlatformID.Unix:
                    return "Linux";
                case PlatformID.MacOSX:
                    return "Mac";
                default:
                    return "Windows";
            }
        }
    }
}