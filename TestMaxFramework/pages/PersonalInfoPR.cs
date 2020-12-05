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
    class PersonalInfoPR : BasePagePR
    {
        private static PersonalInfoPR instance;
        public static PersonalInfoPR Instance = (instance != null) ? instance : new PersonalInfoPR();
        Profile prf = new Profile().FillIn();

        public PersonalInfoPR()
        {
            pageURL = "identity";
            pageTitle = "Identity – My Store";
        }

        By male = By.XPath("//*[@id='customer-form']/section/div[1]/div[1]/label[1]/span");
        By female = By.XPath("//*[@id='customer-form']/section/div[1]/div[1]/label[2]/span");
        By firstName = By.Name("firstname");
        By lastName = By.Name("lastname");
        By email = By.Name("email");
        By oldPassword = By.Name("password");
        By newPassword = By.Name("new_password");
        By terms = By.XPath("//*[@id='customer-form']/section/div[10]/div[1]/span/label");
        By save = By.XPath("//*[@id='customer-form']/footer/button");
        //  //*[@id='customer-form']/section/div[10]/div[1]/span/label/input



        public void ChangePersonalInfo()
        {

            Log.Information("Start updating user profile...");
            findElement(email).Clear();
            findElement(firstName).Clear();
            findElement(lastName).Clear();
            Log.Debug("Previous data was cleaned");
            //clickOnElement(male);
            findElement(email).SendKeys("maximdran@gmail.com");
            findElement(firstName).SendKeys(prf.FirstName);
            findElement(lastName).SendKeys(prf.LastName);
            findElement(oldPassword).SendKeys("qwerty123");
            findElement(newPassword).SendKeys("qwerty123");
            clickOnElement(terms);
            //Log.Information($"User {msg.Name} created massage '{msg.Massage}'");

        }

        public void SaveChanges()
        {
            clickOnElement(save);
        }

    }
}
