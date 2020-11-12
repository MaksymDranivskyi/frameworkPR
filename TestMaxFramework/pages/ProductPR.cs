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

        By plusQty = By.XPath("//form/div/div[2]/p[1]/a[2]/span");
        By minusQty = By.XPath("//form/div/div[2]/p[1]/a[1]/span");
        By addToCart = By.XPath("//*[@id='add_to_cart']/button");
        // //*[@id="add_to_cart"]/button/span
        //By deleteBtn = By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[6]/div/a");
        //By plusBtn = By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[5]/div/a[2]");
        //By minusBtn = By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[5]/div/a[1]");
        //By qty = By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[5]/input[2]");

        //// deleteBtn index need

        //By email = By.Id("email");
        //By orderRefeernce = By.Name("id_order");
        //By message = By.Name("message");
        //By sendMessage = By.Name("submitMessage");
        //By productId = By.Name("id_product");




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
            clickOnElement(addToCart);
        }

    }
}
