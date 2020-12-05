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
            pageURL = "cart?action=show";
            pageTitle = "Cart";
        }

        By next = By.XPath("//*[@id='main']/div/div[2]/div[1]/div[2]/div/a");
        By continueShop = By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button-exclusive.btn.btn-default");

        // SHOPPING-CART SUMMARY
        By deleteBtn = By.XPath("//div/div[1]/div/div[2]/ul/li[1]/div/div[3]/div/div[3]/div/a/i");
        By plusBtn = By.XPath("//div/div[1]/div/div[2]/ul/li[1]/div/div[3]/div/div[2]/div/div[1]/div/span[3]/button[1]");
        By minusBtn = By.XPath("//div/div[1]/div/div[2]/ul/li[1]/div/div[3]/div/div[2]/div/div[1]/div/span[3]/button[2]");
        By qty = By.XPath("//div/div[1]/div/div[2]/ul/li[1]/div/div[3]/div/div[2]/div/div[1]/div/input");
        // deleteBtn index need

        // ADDRESSES
        By message = By.Name("delivery_message");
        By nextAddress= By.Name("confirm-addresses");
        // SHIPPING
        By nextCarrier = By.Name("confirmDeliveryOption");

        // PLEASE CHOOSE YOUR PAYMENT METHOD
        By payByCheck = By.XPath("//div[@id='payment-option-1-container']/span");
        By payByBank = By.Id("//div[@id='payment-option-2-container']/span");
        By termsService = By.Id("conditions_to_approve[terms-and-conditions]");

        // ORDER SUMMARY
        By confirmOrder = By.XPath("//*[@id='payment-confirmation']/div[1]/button");






        [Obsolete]
        public void ConfirmOrder()
        {
            sleepFor(300);
            clickOnElement(next);
            clickOnElement(nextAddress);
            clickOnElement(nextCarrier);
            // WaitUntilElementClickable(payByCheck, 5000);
            sleepFor(2000);
            findElement(payByCheck).Click();
            sleepFor(2000);
            checkElement(termsService);
            clickOnElement(confirmOrder);
        }


        public void AddMassage()
        {
            //clickOnElement(sendMessage);
        }

    }
}
