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
    class MainPagePR : BasePagePR
    {
        private static MainPagePR instance;
        public static MainPagePR Instance = (instance != null) ? instance : new MainPagePR();
        Checkout chkout = new Checkout().FillIn();

        public MainPagePR()
        {
            pageURL = "";
            pageTitle = "diplom";
        }


        // FOOTER SECTION
       
        By priceDrop = By.PartialLinkText("Prices drop");
        By newProducts = By.PartialLinkText("New products");
        By bestSales = By.PartialLinkText("Best sales");
        By delivery = By.PartialLinkText("Delivery");
        By legalNotice = By.PartialLinkText("Legal Notice");
        By termsConditions = By.PartialLinkText("Terms and conditions of use");
        By aboutUs = By.PartialLinkText("About us");
        By securePayment = By.PartialLinkText("Secure payment");
        By contactUs = By.PartialLinkText("Contact us");
        By sitemap = By.PartialLinkText("Sitemap");
        By stores = By.PartialLinkText("Stores");
        By personalInfo = By.PartialLinkText("Personal info");
        By orders = By.PartialLinkText("Orders");
        By creditSlips = By.PartialLinkText("Credit slips");
        By addresses = By.PartialLinkText("Addresses");
        
      
        // SEARCH

        By search = By.Name("s");


        //  /html/body/main/section/div/div/section/section/section/div/article[1]/div/div[1]/h3/a
        //By lastName = By.Name("billing_last_name");
        //By email = By.Name("billing_email");
        //By country = By.Id("select2-billing_country-container");
        //By street = By.Name("billing_address_1");
        //By city = By.Name("billing_city");
        //By state = By.Name("billing_state");
        //By postcode = By.Name("billing_postcode");




        public void Search( string text)
        {
            findElement(search).SendKeys(text).PressEnter();
           Log.Information($"Searching '{text}' in the store");
        
        }

        public void VerifyFooter()
        {
            List<By> footerElements = new List<By> { priceDrop, newProducts, bestSales, delivery, legalNotice, termsConditions, aboutUs, securePayment, contactUs, sitemap, stores, personalInfo, orders, creditSlips, addresses };
            foreach (By element in footerElements)
            {
                clickOnElement(element);
                GetWebDriver().Navigate().Back();
            }
        }

    }
}
