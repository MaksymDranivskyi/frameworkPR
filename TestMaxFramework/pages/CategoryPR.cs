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
            pageURL = "8-home-accessories";
            pageTitle = "Home Accessories";

        }

     
        By productTitle = By.XPath("//*[@id='js-product-list']/div[1]/article[1]/div/div[1]/h2/a");
        By imageSection = By.XPath("//*[@id='js-product-list']/div[1]/article[1]/div/a");
        By quickView = By.XPath("//*[@id='js-product-list']/div[1]/article[1]/div/div[2]/a");

        // //*[@id='add-to-cart-or-refresh']/div[2]/div/div[1]/div/span[3]/button[1]
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


        public void OpenProductDetails(int element)
        {
           
                S(By.XPath($"//*[@id='js-product-list']/div[1]/article[{element}]/div/div[1]/h2/a")).Click();
            
        }

        public void AddProductsToCartById(int[] listId)
        {
            ProductPR product = ProductPR.Instance;
            foreach (int element in listId)
            {
                scrollToView(By.XPath($"//*[@id='js-product-list']/div[1]/article[{element}]/div/div[1]/h2/a"));
                hoverAndClick(By.XPath($"//*[@id='js-product-list']/div[1]/article[{element}]/div/a"), By.XPath($"//*[@id='js-product-list']/div[1]/article[{element}]/div/div[2]/a"), 300);
                product.AddToCart();
                sleepFor(300);
                clickOnElement(By.XPath("//div/div/div[2]/div/div[2]/div/div/button"));
            }

           

        }

    }
}
