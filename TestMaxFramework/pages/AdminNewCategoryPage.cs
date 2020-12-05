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
    class AdminNewCategoryPage : BasePagePR
    {
        private static AdminNewCategoryPage instance;
        public static AdminNewCategoryPage Instance = (instance != null) ? instance : new AdminNewCategoryPage();
        Category category = new Category().FillIn();

        public AdminNewCategoryPage()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "Dashboard • diplom";
        }



        By categoryName = By.Name("category[name][1]");
        By descrField = By.Id("tinymce");
        By save = By.XPath("//*[@id='main-div']/div[2]/div[2]/div/div[2]/div/form/div/div[2]/button");




        public void AddNewCategory()
        {
           
            findElement(categoryName).Clear();
            findElement(categoryName).SendKeys(category.CategoryName[0]);
            GetWebDriver().SwitchTo().Frame(0);
            findElement(descrField).SendKeys(category.CategoryDescr);
            GetWebDriver().SwitchTo().DefaultContent();
            sleepFor(1000);
            clickOnElement(save);
            sleepFor(5000);
        }


      


    }

}
