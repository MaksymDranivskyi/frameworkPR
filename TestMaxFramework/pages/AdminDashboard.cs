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
    class AdminDashboard : BasePagePR
    {
        private static AdminDashboard instance;
        public static AdminDashboard Instance = (instance != null) ? instance : new AdminDashboard();
        Checkout chkout = new Checkout().FillIn();

        public AdminDashboard()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "Dashboard • diplom";

           
        }


        // Table SECTION



        // SEARCH

        By search = By.Name("filter_column_name");




        public void GoToProducts()
        {
            clickOnElement(By.XPath("/html/body/nav/ul/li[4]/a"));
            clickOnElement(By.XPath("/html/body/nav/ul/li[4]/ul/li[1]/a"));

        }

        public void GoToCategories()
        {
            clickOnElement(By.XPath("/html/body/nav/ul/li[4]/a"));
            clickOnElement(By.XPath("/html/body/nav/ul/li[4]/ul/li[2]/a"));

        }

        public void GoToOrders()
        {

            clickOnElement(By.XPath("/html/body/nav/ul/li[3]/a"));
            clickOnElement(By.XPath("/html/body/nav/ul/li[3]/ul/li[1]/a"));

        }

        public void GoToCustomers()
        {
            clickOnElement(By.XPath("/html/body/nav/ul/li[5]/a"));
            clickOnElement(By.XPath("/html/body/nav/ul/li[5]/ul/li[1]/a"));
        }

       





    }

}
