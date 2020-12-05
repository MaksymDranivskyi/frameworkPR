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
    class AdminProductPage : BasePagePR
    {
        private static AdminProductPage instance;
        public static AdminProductPage Instance = (instance != null) ? instance : new AdminProductPage();
        Checkout chkout = new Checkout().FillIn();

        public AdminProductPage()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "Dashboard • diplom";
        }


        // Table SECTION




        // SEARCH

        By bulkActions = By.Id("product_bulk_menu");
        By activateSelected = By.XPath("//*[@id='catalog-actions']/div[1]/div/div[2]/div/div/a[1]");
        By deactivateSelected = By.XPath("//*[@id='catalog-actions']/div[1]/div/div[2]/div/div/a[2]");
        By duplicateSeected = By.XPath("//*[@id='catalog-actions']/div[1]/div/div[2]/div/div/a[3]");
        By deleteSelected = By.XPath("//*[@id='catalog-actions']/div[1]/div/div[2]/div/div/a[4]");
        By search = By.Name("filter_column_name");
        By deleteNow = By.XPath($"//div/div[7]/div/div/div[3]/button[2]");
        By addProduct = By.Id("page-header-desc-configuration-add");





        public void Search(string text)
        {
            findElement(search).SendKeys(text).PressEnter();
            Log.Information($"Searching '{text}' in the store");

        }

        public void ChangeProductStatus(int[] listId)
        {
            
            foreach (int element in listId)
            {
                clickOnElement(By.XPath($"//div/div[2]/div/form/div[2]/div/div/table/tbody/tr[{element}]/td[10]/a"));
            }

        }

        public void EditProduct(int id)
        {
                clickOnElement(By.XPath($"//div/div[2]/div/form/div[2]/div/div/table/tbody/tr[{id}]/td[11]/div/div/a"));
        }

        public void DeleteProduct(int element)
        {
                clickOnElement(By.XPath($"//div[2]/div/div/table/tbody/tr[{element}]/td[11]/div/div/button"));
                clickOnElement(By.XPath($"//div[2]/div/div/table/tbody/tr[{element}]/td[11]/div/div/div/a[3]"));
                clickOnElement(deleteNow);
        }

        public void PreviewProduct(int element)
        {
            clickOnElement(By.XPath($"//div[2]/div/div/table/tbody/tr[{element}]/td[11]/div/div/button"));
            clickOnElement(By.XPath($"//div[2]/div/div/table/tbody/tr[{element}]/td[11]/div/div/div/a[1]"));
        }

        public void DuplicateProduct(int element)
        {
            clickOnElement(By.XPath($"//div[2]/div/div/table/tbody/tr[{element}]/td[11]/div/div/button"));
            clickOnElement(By.XPath($"//div[2]/div/div/table/tbody/tr[{element}]/td[11]/div/div/div/a[2]"));
        }
        public void SelectProducts(int[] listId)
        {
            foreach (int element in listId)
            {
                sleepFor(1000);
                clickOnElement(By.XPath($"//div[2]/div/div/table/tbody/tr[{element}]/td[1]/div"));
            }
        }

        public void ActivateSelected()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(activateSelected, 3000);
            clickOnElement(activateSelected);
        }

        public void DeactivateSelected()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(deactivateSelected, 3000);
            clickOnElement(deactivateSelected);
        }

        public void DuplicateSelected()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(duplicateSeected,3000);
            clickOnElement(duplicateSeected);
        }

        public void DeleteSelected()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(deleteSelected, 3000);
            clickOnElement(deleteSelected);
            clickOnElement(deleteNow);
        }

        public void AddNewProduct()
        {
            clickOnElement(addProduct);
        }

    }

}

