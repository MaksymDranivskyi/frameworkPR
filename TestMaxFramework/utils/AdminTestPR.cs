using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
using TestMaxFramework.Reports;

namespace TestMaxFramework
{

    public class AdminTestPR : Report
    {


        [OneTimeSetUp]
        public void beginExecution()
        {
            AdminLoginPage login = AdminLoginPage.Instance;
            login.open();
            login.LoginAdmin("maximdran@gmail.com", "qwerty123");
        }


    }
}
