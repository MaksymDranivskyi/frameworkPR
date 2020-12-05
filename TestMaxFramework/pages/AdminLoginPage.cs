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
using TestMaxFramework.utils;

namespace TestMaxFramework.pages
{
    class AdminLoginPage:BasePagePR
    {
        private static AdminLoginPage instance;
        public static AdminLoginPage Instance = (instance != null) ? instance : new AdminLoginPage();

        public AdminLoginPage()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "diplom  (PrestaShop™)";
        }
        
        By email = By.Name("email");
        By password = By.Name("passwd");
        By loginBtn = By.Id("submit_login");

        public void LoginAdmin(string mail, string pwd)
        {
            findElement(email).SendKeys(mail);
            findElement(password).SendKeys(pwd);
            clickOnElement(loginBtn);
            Log.Information($"User {email} logined");

        }

    }
}
