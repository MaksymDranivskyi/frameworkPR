﻿using System;
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
using System.Collections.Generic;

namespace TestMaxFramework.pages
{
    class MyAccountPR : BasePagePR
    {
        private static MyAccountPR instance;
        public static MyAccountPR Instance = (instance != null) ? instance : new MyAccountPR();
        Contact msg = new Contact().FillIn();
        

        public MyAccountPR()
        {
            pageURL = "my-account";
            pageTitle = "My Account – My Store";
        }

        //By orderHistory = By.XPath("//div/div[3]/div/div/div/ul/li[1]/a");
        //By myCreditSlips = By.XPath("//div/div[3]/div/div/div/ul/li[2]/a");
        //By myAdresses = By.XPath("//div/div[3]/div/div/div/ul/li[3]/a");
        //By myPersonalInfo = By.XPath("//div/div[3]/div/div/div/ul/li[4]/a");

        By orderHistory = By.Id("history-link");
        By myCreditSlips = By.Id("order-slips-link");
        By myAdresses = By.Id("addresses-link");
        By myPersonalInfo = By.Id("identity-link");
        By gdprPersonalData = By.Id("psgdpr-link");




        public void OdredHistory()
        {

            clickOnElement(orderHistory);

        }

        public void MyCreditSlips()
        {
            clickOnElement(myCreditSlips);
        }

        public void MyAddresses()
        {
            clickOnElement(myAdresses);
        }

        public void MyPersonalInfo()
        {
            clickOnElement(myPersonalInfo);
        }

        public void GDPR()
        {
            clickOnElement(gdprPersonalData);
        }

        public void VerifyMyAccountElements()
        {
            List<By> footerElements = new List<By> { orderHistory, myCreditSlips, myAdresses, myPersonalInfo, gdprPersonalData };
            foreach (By element in footerElements)
            {
                clickOnElement(element);
                sleepFor(500);
                GetWebDriver().Navigate().Back();
            }
        }
    }
}
