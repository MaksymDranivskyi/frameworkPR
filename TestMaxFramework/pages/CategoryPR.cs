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
    class CategoryPR : BasePagePR
    {

        private static CategoryPR instance;
        public static CategoryPR Instance = (instance != null) ? instance : new CategoryPR();


        public CategoryPR()
        {
            pageURL = "3-women";
            pageTitle = "Woman – My Store";
        }

        By listGridBtn = By.XPath("//div[2]/div/div[3]/div[2]/div[3]/div[1]/ul/li[3]/a");
        By compareProductsBtn = By.XPath("//div[2]/div/div[3]/div[2]/div[3]/div[2]/form/button");
        By productTitle = By.XPath("//div[3]/div[2]/ul/li[1]/div/div[2]/h5/a");
        //html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]/div/div[2]/div[2]/a[1]/span
        ///html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]/div/div[2]/div[2]/a[2]/span
        ///html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]/div/div[3]/div/a
        ////html/body/div/div[2]/div/div[3]/div[2]/ul/li[2]/div/div[3]/div/a
        //By firstName = By.Name("billing_first_name");
        //By lastName = By.Name("billing_last_name");
        //By email = By.Name("billing_email");
        //By country = By.Id("select2-billing_country-container");
        //By street = By.Name("billing_address_1");
        //By city = By.Name("billing_city");
        //By state = By.Name("billing_state");
        //By postcode = By.Name("billing_postcode");

        public void switchToList()
        {
            S(listGridBtn).Click();

        }

        public void CompareProducts()
        {
            S(compareProductsBtn).Click();

        }


        public void AddProductToCartById(int[] listId)
        {
            foreach (int element in listId)
                S(By.XPath($"//div/div[3]/div[2]/ul/li[{element}]/div/div/div[3]/div/div[2]/a[1]/span")).Click();

        }

        public void MoreProductById(int[] listId)
        {
            foreach (int element in listId)
                S(By.XPath($"//div[2]/div/div[3]/div[2]/ul/li[{element}]/div/div/div[3]/div/div[2]/a[2]/span")).Click();
        }

        public void AddToCompareById(int[] listId)
        {
            foreach (int element in listId)
                S(By.XPath($"//div[3]/div[2]/ul/li[{element}]/div/div/div[3]/div/div[3]/div/a")).Click();
        }

        public void OpenProductDetails(int[] listId)
        {
            foreach (int element in listId)
                S(By.XPath($"//div[3]/div[2]/ul/li[{element}]/div/div/div[2]/h5/a")).Click();
        }

        //public void AddProductToCartByName(int listId)
        //{
        //    S(By.XPath($"//div[3]/div[2]/ul/li[{listId}]/div/div[2]/div[2]/a[1]/span")).Click();
        //div[3]/div[2]/ul/li[1]/div/div/div[2]/h5/a
        //}


        public void SetBillingData()
        {

           // Log.Information("Start updating user profile...");
           // findElement(firstName).Clear();
           // findElement(lastName).Clear();
           // findElement(email).Clear();
           //// findElement(country).Clear();
           // findElement(street).Clear();
           // findElement(city).Clear();
           // findElement(state).Clear();
           // findElement(postcode).Clear();
           // Log.Debug("Previous data was cleaned");
           // findElement(firstName).SendKeys(chkout.FirstName);
           // findElement(lastName).SendKeys(chkout.LastName);
           // findElement(email).SendKeys(chkout.Email);
           // //findElement(country).SendKeys(chkout.Country);
           // findElement(street).SendKeys(chkout.Street);
           // findElement(city).SendKeys(chkout.City);
           // findElement(state).SendKeys(chkout.State);
           // findElement(postcode).SendKeys(chkout.Postcode);
           // //Log.Information($"User {msg.Name} created massage '{msg.Massage}'");

        }

        public void SaveAddress()
        {
            //scrollToView(saveAddress);
            //sleepFor(1000);
            //clickOnElementIgnoreException(saveAddress);
        }

    }
}
