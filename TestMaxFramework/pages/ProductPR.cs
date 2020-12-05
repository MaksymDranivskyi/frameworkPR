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
    class ProductPR : BasePagePR
    {
        private static ProductPR instance;
        public static ProductPR Instance = (instance != null) ? instance : new ProductPR();
        

        public ProductPR()
        {
            //pageURL = "order";
            //pageTitle = "Order – My Store";
        }

        By plusQty = By.XPath("//*[@id='add-to-cart-or-refresh']/div[2]/div/div[1]/div/span[3]/button[1]");
        By minusQty = By.XPath("//*[@id='add-to-cart-or-refresh']/div[2]/div/div[1]/div/span[3]/button[2]");
        By addToCart = By.XPath("//*[@id='add-to-cart-or-refresh']/div[2]/div/div[2]/button");





        public void IncrementQty()
        {
            clickOnElement(plusQty);
        }

        public void DecrementQty()
        {
            clickOnElement(minusQty);
        }

        public void AddToCart()
        {
            WaitUntilElementClickable(addToCart, 5000);
            clickOnElement(addToCart);
        }

    }
}
