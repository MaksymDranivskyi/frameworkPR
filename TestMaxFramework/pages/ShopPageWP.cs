//using System;
//using System.IO;
//using System.Threading;
//using System.Configuration;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.PageObjects;
//using Serilog;
//using Serilog.Events;
//using TestMaxFramework.pages;
//using TestMaxFramework.utils;

//namespace TestMaxFramework.pages
//{
//    class ShopPageWP : BasePageWP
//    {
//        private static ShopPageWP instance;
//        public static ShopPageWP Instance = (instance != null) ? instance : new ShopPageWP();

//        public ShopPageWP()
//        {
//            pageURL = "";
//            pageTitle = "Dragon Shop";
//        }

//        By addToCart = By.XPath("//ul/li[2]/a[2]");
//        By compare = By.XPath("//ul/li[2]/a[3]");
//        By added = By.XPath("//ul/li[2]/a[3]");
//        By title = By.CssSelector("button[class='woocommerce-loop-product__title']");
//        By viewCart = By.XPath("//*[@id='main']/ul/li[2]/a[3]");


//        public void AddToCart()
//        {
//            Log.Information("Add product to cart");
//            clickOnElement(addToCart);
//            isElementPresentAndDisplay(viewCart);
//            Log.Information("Product is added to cart");
//        }

//        public void ViewCart()
//        {
//            Log.Information("View cart");
//            isElementPresentAndDisplay(viewCart);
//            clickOnElement(viewCart);
//        }

//        public void OpenProduct()
//        {
//            Log.Information("Open product page");
//            isElementPresentAndDisplay(title);
//            clickOnElement(title);
//        }

//        public void CompareProduct()
//        {
//            Log.Information("Open product page");
//            isElementPresentAndDisplay(compare);
//            clickOnElement(compare);
//            isElementPresentAndDisplay(added);
//        }


//    }
//}
