using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;
using TestMaxFramework.utils;
using TestMaxFramework.pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Configuration;
using NUnit.Framework.Interfaces;
using TestMaxFramework.Reports;


namespace TestMaxFramework
{
    
   
     class BaseTestPR : Report
    {

    [OneTimeSetUp]
        public void beginExecution()
        {
                     
            LoginPagePR login = LoginPagePR.Instance;
            login.open();
            login.loginUserPR("maximdran@gmail.com", "qwerty123");


        }


    }
}
