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
    class ContactUsPR : BasePagePR
    {
        private static ContactUsPR instance;
        public static ContactUsPR Instance = (instance != null) ? instance : new ContactUsPR();
        Contact msg = new Contact().FillIn();

        public ContactUsPR()
        {
            pageURL = "contact-us";
            pageTitle = "Contact us";
        }

        By subjectHeading = By.Name("id_contact");
        By email = By.Name("from");
        By orderRefeernce = By.Name("id_order");
        By message = By.Name("message");
        By sendMessage = By.Name("submitMessage");
       




        public void CreateMassage()
        {

            Log.Information("Start updating user profile...");
            findElement(email).Clear();
            findElement(message).Clear();
            Log.Debug("Previous data was cleaned");
            selectByIndex(subjectHeading, 1, 30);
            findElement(email).SendKeys(msg.Email);
            selectByIndex(orderRefeernce, 1, 30);
            findElement(message).SendKeys(msg.Massage);
            Log.Information($"User {msg.Name} created massage '{msg.Massage}'");
           
        }

        public void AddMassage()
        {
            clickOnElement(sendMessage);
        }

    }
}
