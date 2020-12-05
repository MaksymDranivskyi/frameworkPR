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
using NSelene;
using static NSelene.Selene;

namespace TestMaxFramework.pages
{
    class MyOrdersPR : BasePagePR
    {
        private static MyOrdersPR instance;
        public static MyOrdersPR Instance = (instance != null) ? instance : new MyOrdersPR();
        

        public MyOrdersPR()
        {
            pageURL = "order-history";
            pageTitle = "Order history";
        }

        
      




        public void OrderDetails(int id)
        {
            clickOnElement(By.XPath($"//div/div/section/section/table/tbody/tr[{id}]/td[6]/a[1]"));
        }

        public void Reorder(int id)
        {
            clickOnElement(By.XPath($"//div/div/section/section/table/tbody/tr[{id}]/td[6]/a[2]"));
        }



    }
}
