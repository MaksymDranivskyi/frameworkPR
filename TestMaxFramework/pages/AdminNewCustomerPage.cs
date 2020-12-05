using OpenQA.Selenium;
using Serilog;
using System.Collections.Generic;

using System;
using System.IO;
using System.Threading;
using System.Configuration;
using NUnit.Framework;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Serilog.Events;
using TestMaxFramework.pages;
using TestMaxFramework.utils;
using NSelene;
using static NSelene.Selene;

namespace TestMaxFramework.pages
{
    class AdminNewCustomerPage : BasePagePR
    {
        private static AdminNewCustomerPage instance;
        public static AdminNewCustomerPage Instance = (instance != null) ? instance : new AdminNewCustomerPage();
        Profile profile = new Profile().FillIn();

        public AdminNewCustomerPage()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "Dashboard • diplom";
        }



        By firstName = By.Name("customer[first_name]");
        By lastName = By.Name("customer[last_name]");
        By email = By.Name("customer[email]");
        By password = By.Name("customer[password]");

        By save = By.XPath("//div[2]/div/div[2]/div/form/div/div[2]/button");



        public void AddCustomer()
        {
            List<By> customerElements = new List<By> { firstName, lastName, email, password };
            foreach (By element in customerElements)
            {
                findElement(element).Clear();
            }
            findElement(firstName).SendKeys(profile.FirstName);
            findElement(lastName).SendKeys(profile.LastName);
            findElement(email).SendKeys(profile.Email);
            findElement(password).SendKeys(profile.Password);
            findElement(save).Click();

        }
 


    }

}
