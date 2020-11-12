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
    class CartPR : BasePagePR
    {
        private static CartPR instance;
        public static CartPR Instance = (instance != null) ? instance : new CartPR();
        Contact msg = new Contact().FillIn();

        public CartPR()
        {
            pageURL = "order";
            pageTitle = "Order – My Store";
        }

        
        By next = By.XPath("//div[2]/div/div[3]/div/p[2]/a[1]");

        //processCarrier
        By continueShop = By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button-exclusive.btn.btn-default");

        // SHOPPING-CART SUMMARY
        By deleteBtn = By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[6]/div/a");
        By plusBtn = By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[5]/div/a[2]");
        By minusBtn = By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[5]/div/a[1]");
        By qty = By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr[1]/td[5]/input[2]");
        // deleteBtn index need

        // ADDRESSES
        By message = By.Name("message");
        By nextAddress= By.Name("processAddress");
        // SHIPPING
        By termsService = By.Id("cgv");
        By nextCarrier = By.Name("processCarrier");

        // PLEASE CHOOSE YOUR PAYMENT METHOD
        By payByCheck = By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[3]/div[2]/div/p/a");
        By payByBank = By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[3]/div[1]/div/p/a");

        // ORDER SUMMARY
        By confirmOrder = By.XPath("//div[2]/div/div[3]/div/form/p/button");

        // /html/body/div/div[2]/div/div[3]/div/div/div[3]/div[1]/div/p/a
        //By email = By.Id("email");
        //By orderRefeernce = By.Name("id_order");
        //By message = By.Name("message");
        //By sendMessage = By.Name("submitMessage");
        //By productId = By.Name("id_product");




        [Obsolete]
        public void ConfirmOrder()
        {
            sleepFor(300);
            S(next).Click();
            S(nextAddress).Click();
            checkElement(termsService);
            S(nextCarrier).Click();
            S(payByCheck).Click();
            S(confirmOrder).Click();
        }


        public void AddMassage()
        {
            //clickOnElement(sendMessage);
        }

    }
}
