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
using System.Collections.Generic;

namespace TestMaxFramework.pages
{
    class CreateAddressPR : BasePagePR
    {
        private static CreateAddressPR instance;
        public static CreateAddressPR Instance = (instance != null) ? instance : new CreateAddressPR();
        

        public CreateAddressPR()
        {
           pageURL = "address";
           pageTitle = "Address";
        }

        By alias = By.Name("alias");
        By firstaname = By.Name("firstname");
        By lastname = By.Name("lastname");
        By company = By.Name("company");
        By address1 = By.Name("address1");
        By address2 = By.Name("address2");
        By postcode = By.Name("postcode");
        By city = By.Name("city");
        By id_country = By.Name("id_country");
        By phone = By.Name("phone");
        By save = By.XPath("//*[@id='content']/div/div/form/footer/button");

        Billing address = new Billing().FillIn();


        public void FillAddress()
        {
            List<By> addressElements = new List<By> { alias, firstaname, lastname, company, address1, address2, postcode, city, phone };
            foreach (By element in addressElements)
            {
                findElement(element).Clear();
            };
            findElement(firstaname).SendKeys(address.FirstName);
            findElement(lastname).SendKeys(address.LastName);
            findElement(company).SendKeys(address.Company);
            findElement(address1).SendKeys(address.Street);
            findElement(address2).SendKeys(address.Street);
            findElement(postcode).SendKeys(address.Postcode);
            findElement(city).SendKeys(address.City);
            selectByIndex(id_country, 1);
            findElement(phone).SendKeys(address.Phone);
            sleepFor(1000);
        }

        public void SaveAddress()
        {
           
            clickOnElement(save);
        }


        }
}
