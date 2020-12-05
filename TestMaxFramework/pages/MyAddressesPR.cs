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
    class MyAddressesPR : BasePagePR
    {
        private static MyAddressesPR instance;
        public static MyAddressesPR Instance = (instance != null) ? instance : new MyAddressesPR();
        

        public MyAddressesPR()
        {
            pageURL = "addresses";
            pageTitle = "Addresses";
        }

        
        By createNewAddress = By.PartialLinkText("Create new address");

        




        public void UpdateAddress(int id)
        {
            clickOnElement(By.XPath($"//div/section/section/div[{id}]/article/div[2]/a[1]"));
        }

        public void DeleteAddress(int id)
        {
            clickOnElement(By.XPath($"//div/section/section/div[{id}]/article/div[2]/a[2]"));
        }


        public void CreateNewAddress()
        {
            clickOnElement(createNewAddress);
        }


    }
}
