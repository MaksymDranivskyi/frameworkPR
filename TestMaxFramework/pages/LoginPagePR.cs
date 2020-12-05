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
    class LoginPagePR:BasePagePR
    {
        private static LoginPagePR instance;
        public static LoginPagePR Instance = (instance != null) ? instance : new LoginPagePR();

        public LoginPagePR()
        {
            pageURL = "?controller=authentication&back=my-account";
            pageTitle = "Login - My store";
        }
        
        By email = By.Name("email");
        By password = By.Name("password");
        By loginBtn = By.Id("submit-login");

        public void LoginUserPR(string mail, string pwd)
        {
            findElement(email).SendKeys(mail);
            findElement(password).SendKeys(pwd);
            clickOnElement(loginBtn);
            Log.Information($"User {email} logined");

        }

    }
}
