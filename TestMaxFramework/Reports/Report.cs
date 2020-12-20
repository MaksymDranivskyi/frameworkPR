using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using Serilog.Events;
using TestMaxFramework.utils;
using TestMaxFramework.pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Interactions;
using NSelene;
using static NSelene.Selene;

using System.Threading;





namespace TestMaxFramework.Reports
{
    //-- This is the class to generate reports and create screenshots of failed tests. 
    //-- These methods are executed before all tests start and after they are completed.
    public class Report
    {

        public ExtentReports extent;


        ExtentHtmlReporter htmlReporter;
        ExtentLoggerReporter loggerReporter;
        public static ExtentTest test;
        string currentDateTime = DateTime.Now.ToString("dd-MM-yyyy-(hh-mm-ss)");
        private readonly string folderName = "Logs";

        [SetUp]
        public void startReport()
        {

            var method = MethodBase.GetCurrentMethod();
            test = extent.CreateTest(string.IsNullOrEmpty(NUnit.Framework.TestContext.CurrentContext.Test.Name)
                    ? "Test system"
                    : NUnit.Framework.TestContext.CurrentContext.Test.Name);
            string tauthor = NUnit.Framework.TestContext.CurrentContext.Test.Properties.Get("Author").ToString();
            string category = NUnit.Framework.TestContext.CurrentContext.Test.Properties.Get("Category").ToString();
            try
            {
                test.AssignAuthor(tauthor);
                test.AssignCategory(category);
                test.AssignDevice(DriverProvider.GetOS());
                Log.Information("Test set up");
                test.Log(Status.Info, "Test case description: <pre>" + NUnit.Framework.TestContext.CurrentContext.Test.Properties.Get("Description").ToString() + "</pre>");
            }

            catch (NullReferenceException)
            {
            }
        }

        [TearDown]
        public void endReport()
        {

            var status = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(NUnit.Framework.TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", NUnit.Framework.TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = string.IsNullOrEmpty(NUnit.Framework.TestContext.CurrentContext.Result.Message)
                ? ""
                    : string.Format("<pre>{0}</pre>", NUnit.Framework.TestContext.CurrentContext.Result.Message);

            Status logstatus;


            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    test.Fail("Screenshot was created").AddScreenCaptureFromPath(DriverProvider.TakeScreen(Path.Combine($@"c:\repos\Framework\TestMaxFramework\bin\Debug\Reports\{currentDateTime}", NUnit.Framework.TestContext.CurrentContext.Test.Name.ToString())));
                    //test.Fail("Screenshot utworzono").AddScreenCaptureFromPath(DriverProvider.TakeScreen(Path.Combine($@"Reports/{currentDateTime}", NUnit.Framework.TestContext.CurrentContext.Test.Name.ToString())));

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;

                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;

                    break;
                default:
                    logstatus = Status.Pass;


                    break;
            }

            test.Log(logstatus, "The test ended with status" + "<pre>" + logstatus + "<br>" + errorMessage + "<br>" + stacktrace + "</pre>");

            Log.Information("Test tear down");
        }


        [OneTimeSetUp]
        public void beginReportExecution()
        {
          
            htmlReporter = new ExtentHtmlReporter($@"c:\repos\Framework\TestMaxFramework\bin\Debug\Reports\{currentDateTime}\Html\");
            loggerReporter = new ExtentLoggerReporter($@"c:\repos\Framework\TestMaxFramework\bin\Debug\Reports\{currentDateTime}\Logger\");
            //htmlReporter = new ExtentHtmlReporter($@"Reports/{currentDateTime}/Html/");
            //loggerReporter = new ExtentLoggerReporter($@"Reports/{currentDateTime}/Logger/");

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AttachReporter(loggerReporter);

            DriverProvider.Init();
            var pathToLog = Path.Combine(NUnit.Framework.TestContext.CurrentContext.WorkDirectory, $"{folderName}", $"{currentDateTime}", "InfoLog.txt");
            string pathToDetailedLog =
            Path.Combine(NUnit.Framework.TestContext.CurrentContext.WorkDirectory, $"{folderName}", $"{currentDateTime}", "DetailedLog.txt");

            var template = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: template)
                .WriteTo.File(pathToLog, Serilog.Events.LogEventLevel.Information, outputTemplate: template)
                .WriteTo.File(pathToDetailedLog, Serilog.Events.LogEventLevel.Debug, outputTemplate: template)
                .CreateLogger();
            Log.Information("One Time Setup finished");
            Log.Information("Setup completed successfully");
        }

        [OneTimeTearDown]
        public void finishReportExecution()
        {


            extent.Flush();
            //Open($@"file:///Users/apiko-327/Documents/Diplom/Frameworks-Versja11.03.20/TestMaxFramework/bin/Debug/Reports/{currentDateTime}/Html/index.html");
            Open($@"c:\repos\Framework\TestMaxFramework\bin\Debug\Reports\{currentDateTime}\Html\index.html");
            Log.Information("One Time Tear Down");
          //  Open($@"c:\repos\Framework\TestMaxFramework\bin\Debug\Reports\{currentDateTime}\Html\index.html");
            


        }

    }


}
