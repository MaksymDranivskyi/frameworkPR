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
    class AdminCategoryPage : BasePagePR
    {
        private static AdminCategoryPage instance;
        public static AdminCategoryPage Instance = (instance != null) ? instance : new AdminCategoryPage();
        Checkout chkout = new Checkout().FillIn();

        public AdminCategoryPage()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "Dashboard • diplom";
        }



        // SEARCH

        By bulkActions = By.XPath("//div[5]/div/div[1]/div[2]/div/div/div[1]/div/div[1]/div/div/button");
        By enableSelection = By.XPath("//div/div[1]/div[2]/div/div/div[1]/div/div[1]/div/div/div/button[1]");
        By disableSelection = By.XPath("//div/div[1]/div[2]/div/div/div[1]/div/div[1]/div/div/div/button[2]");
        By deleteSelection = By.XPath("//div/div[1]/div[2]/div/div/div[1]/div/div[1]/div/div/div/button[3]");
       

        By deleteNow = By.XPath($"//div[5]/div/div[2]/div/div/div[3]/button[2]");
        By addcategory = By.XPath("//div[1]/div[1]/div/div/div/div/a[1]");


        public void ChangeCategoryStatus(int[] listId)
        {

            foreach (int element in listId)
            {
                clickOnElement(By.XPath($"//div/div[2]/div/form/table/tbody/tr[{element}]/td[6]/div/i"));
            }

        }

        public void PreviewCategory(int id)
        {
            clickOnElement(By.XPath($"//div/div/div[2]/div/form/table/tbody/tr[{id}]/td[7]/div/div/a[1]"));
        }

        public void DeleteCategory(int element)
        {
            clickOnElement(By.XPath($"//div/div[2]/div/form/table/tbody/tr[{element}]/td[7]/div/div/a[2]"));
            clickOnElement(By.XPath($"//div/div[2]/div/form/table/tbody/tr[{element}]/td[7]/div/div/div/a[2]"));
            clickOnElement(deleteNow);
        }

        public void EditCategory(int element)
        {
            clickOnElement(By.XPath($"//div/div[2]/div/form/table/tbody/tr[{element}]/td[7]/div/div/a[2]"));
            clickOnElement(By.XPath($"//div/div[2]/div/form/table/tbody/tr[{element}]/td[7]/div/div/div/a[1]"));
        }

        public void SelectCategories(int[] listId)
        {
            foreach (int element in listId)
            {
                sleepFor(1000);
                clickOnElement(By.XPath($"//div[2]/div/form/table/tbody/tr[{element}]/td[2]/div"));
            }
        }

        public void EnableSelected()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(enableSelection, 3000);
            clickOnElement(enableSelection);
        }

        public void DisableSelected()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(disableSelection, 3000);
            clickOnElement(disableSelection);
        }

        public void DeleteSelected()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(deleteSelection, 3000);
            clickOnElement(deleteSelection);
            clickOnElement(deleteNow);
        }

        public void AddNewCategory()
        {
            sleepFor(1000);
            clickOnElement(addcategory);
        }

    }

}


