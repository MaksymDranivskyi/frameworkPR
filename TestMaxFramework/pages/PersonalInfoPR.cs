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

        By male = By.Id("id_gender1");
        By female = By.Id("id_gender2");
        By firstName = By.Name("firstname");
        By lastName = By.Name("lastname");
        By email = By.Name("email");
        By oldPassword = By.Name("old_passwd");
        By newPassword = By.Name("passwd");
        By confirmation = By.Name("confirmation");
        By save = By.Name("submitIdentity");




        public void ChangePersonalInfo()
        {

            Log.Information("Start updating user profile...");
            S(email).Clear();
            S(firstName).Clear();
            S(lastName).Clear();
            Log.Debug("Previous data was cleaned");
            //clickOnElement(male);
            S(email).SendKeys("maximdran@gmail.com");
            S(firstName).SendKeys(prf.FirstName);
            S(lastName).SendKeys(prf.LastName);
            S(oldPassword).SendKeys("qwerty123");
            S(newPassword).SendKeys("qwerty123");
            S(confirmation).SendKeys("qwerty123");
            //Log.Information($"User {msg.Name} created massage '{msg.Massage}'");

        }

        public void SaveChanges()
        {
            clickOnElement(save);
        }

    }
}
