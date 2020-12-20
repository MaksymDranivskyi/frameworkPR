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
    class AdminCustomerPage : BasePagePR
    {
        private static AdminCustomerPage instance;
        public static AdminCustomerPage Instance = (instance != null) ? instance : new AdminCustomerPage();

        public AdminCustomerPage()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "Dashboard • diplom";
        }



        // SEARCH

        By bulkActions = By.XPath("//*[@id='customer_grid']/div/div[1]/div/div[1]/div/div/button");
        //By enableSeletion = By.XPath("//div[2]/div/div/div[1]/div/div[1]/div/div/div/button[1]");
        //By disableSelection = By.XPath("//div[2]/div/div/div[1]/div/div[1]/div/div/div/button[2]");
        //By deleteSelection = By.XPath("//div[2]/div/div/div[1]/div/div[1]/div/div/div/button[3]");

        By enableSeletion = By.Id("customer_grid_bulk_action_enable_selection");
        By disableSelection = By.Id("customer_grid_bulk_action_disable_selection");
        By deleteSelection = By.Id("customer_grid_bulk_action_disable_selection");

        By deleteNow = By.XPath($"//div/div[4]/div/div[2]/div/div/div[3]/button[2]");
        By addCustomer = By.XPath("//div[1]/div/div/div/div/a[1]");




        public void ChangeCustomerStatus(int[] listId)
        {
            
            foreach (int element in listId)
            {
                clickOnElement(By.XPath($"/html/body/div[1]/div[2]/div[2]/div/div[4]/div/div[1]/div[2]/div/div/div[2]/div/form/table/tbody/tr[{element}]/td[8]/div/i"));
            }

        }

        public void EditCustomer(int id)
        {
                clickOnElement(By.XPath($"/html/body/div[1]/div[2]/div[2]/div/div[4]/div/div[1]/div[2]/div/div/div[2]/div/form/table/tbody/tr[{id}]/td[13]/div/div/a[1]"));
        }

        public void DeleteCustomer(int element)
        {
                clickOnElement(By.XPath($"//div/div/div[2]/div/form/table/tbody/tr[{element}]/td[13]/div/div/a[2]"));
                clickOnElement(By.XPath($"//div/div[2]/div/form/table/tbody/tr[{element}]/td[13]/div/div/div/a[2]"));
                clickOnElement(deleteNow);
        }

        public void PreviewCastomer(int element)
        {
            clickOnElement(By.XPath($"//div/div/div[2]/div/form/table/tbody/tr[{element}]/td[13]/div/div/a[2]"));
            clickOnElement(By.XPath($"//div/div[2]/div/form/table/tbody/tr[{element}]/td[13]/div/div/div/a[1]"));
        }

        public void SelectCustomers(int[] listId)
        {
            foreach (int element in listId)
            {
                sleepFor(1000);
                clickOnElement(By.XPath($"//div[1]/div[2]/div/div/div[2]/div/form/table/tbody/tr[{element}]/td[1]/div"));
            }
        }

        public void EnableSelected()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(enableSeletion, 3000);
            clickOnElement(enableSeletion);
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
            WaitUntilElementVisible(deleteSelection,3000);
            clickOnElement(deleteSelection);
        }

       
        public void AddNewCustomer()
        {
            clickOnElement(addCustomer);
        }

    }

}

