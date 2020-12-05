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
    class AdminNewProductPage : BasePagePR
    {
        private static AdminNewProductPage instance;
        public static AdminNewProductPage Instance = (instance != null) ? instance : new AdminNewProductPage();
        Product product = new Product().FillIn();

        public AdminNewProductPage()
        {
            pageURL = "admin970a0n461/index.php";
            pageTitle = "Dashboard • diplom";
        }


        // Table SECTION




        // BASIC SETTINGS

        By productName = By.Name("form[step1][name][1]");
        By qtyProduct = By.Name("form[step1][qty_0_shortcut]");
        By reference = By.Name("form[step6][reference]");
        By descrFrame = By.XPath("//*[@id='form_step1_description_short_1_ifr']");
        By descrField = By.Id("tinymce");
        By price = By.Name("form[step1][price_shortcut]");
        By imageZone = By.Id("product-images-dropzone");

        //SHIPPING

        By shippingTab = By.XPath("//div/div[2]/div/form/div[3]/div[1]/ul/li[3]");
        By width = By.Name("form[step4][width]");
        By height = By.Name("form[step4][height]");
        By depth = By.Name("form[step4][depth]");
        By weight = By.Name("form[step4][weight]");
        By save = By.XPath("//*[@id='form']/div[4]/div[2]/div[2]/button[1]");



        public void AddBasicSettings()
        {
            List<By> addressElements = new List<By> { productName, qtyProduct, reference, price };
            foreach (By element in addressElements)
            {
                WaitUntilElementVisible(element, 3000);
                findElement(element).Clear();
            };
            findElement(productName).SendKeys(product.ProductName);
            findElement(qtyProduct).SendKeys(product.Qty);
            findElement(reference).SendKeys(product.ProductSku);
            findElement(price).SendKeys(product.SalePrice);
            clickOnElement(By.CssSelector("#mce_31 > div"));
            GetWebDriver().SwitchTo().Frame(0);
            findElement(descrField).SendKeys(product.ProductDescr);
            GetWebDriver().SwitchTo().DefaultContent();
            sleepFor(1000);
            clickOnElement(save);
            sleepFor(5000);
        }


        public void AddShipping()
        {
            scrollTo(0,0) ;
            clickOnElement(shippingTab);
            List<By> addressElements = new List<By> { weight, height, depth, width};
            foreach (By element in addressElements)
            {
                WaitUntilElementVisible(element, 3000);
                findElement(element).Clear();
            };
            findElement(weight).SendKeys(product.Weight);
            findElement(height).SendKeys(product.Height);
            findElement(depth).SendKeys(product.Length);
            findElement(width).SendKeys(product.Width);
            sleepFor(1000);
            clickOnElement(save);
        }



    }

}
