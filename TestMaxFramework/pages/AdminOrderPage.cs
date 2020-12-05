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
    class AdminOrderPage : BasePagePR
    {
        private static AdminOrderPage instance;
        public static AdminOrderPage Instance = (instance != null) ? instance : new AdminOrderPage();
        Checkout chkout = new Checkout().FillIn();

        public AdminOrderPage()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "Dashboard • diplom";
        }


        // Table SECTION

        By addOrder = By.XPath("//div[1]/div/div/div/div/ul/li[1]/a");
        By selectStatus = By.Id("id_order_state");


        // SEARCH


        // 

        By bulkActions = By.Id("bulk_action_menu_order");
        By selectAll = By.XPath("//*[@id='form-order']/div/div[3]/div/div/ul/li[1]/a");
        By unselectAll = By.XPath("//*[@id='form-order']/div/div[3]/div/div/ul/li[2]/a");
        By changeStatus = By.XPath("//*[@id='form-order']/div/div[3]/div/div/ul/li[4]/a");
        By updateStatus = By.XPath("//div/div[2]/div/form/div[2]/button[2]");
        

        public void ViewOrder(int id)
        {
            clickOnElement(By.XPath($"//div/div[2]/table/tbody/tr[{id}]/td[12]/div/a"));
        }

        public void SelectOrders(int[] listId)
        {
            foreach (int element in listId)
            {
                sleepFor(1000);
                clickOnElement(By.XPath($"//div/div[2]/table/tbody/tr[{element}]/td[1]/input"));
            }
        }

        public void SelectAll()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(selectAll, 3000);
            clickOnElement(selectAll);
        }

        public void UnselectAll()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(unselectAll, 3000);
            clickOnElement(unselectAll);
        }

        public void ChangeStatusSeveral()
        {
            clickOnElement(bulkActions);
            WaitUntilElementVisible(changeStatus, 3000);
            clickOnElement(changeStatus);
        }


        public void SelectStatusAndUpdate(string id = "2" )
        {
            selectByString(selectStatus, id, 300);
            clickOnElement(updateStatus);
        }

        


        public void AddNewOrder()
        {
            clickOnElement(addOrder);
        }


    }

}


