//using System;
//using System.IO;
//using System.Threading;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using TestMaxFramework.utils;
//using TestMaxFramework.pages;
//using OpenQA.Selenium.Support.PageObjects;
//using Serilog;
//using Serilog.Events;

//namespace TestMaxFramework
//{
//   [TestFixture]
    
//    class WPAdminSuite : AdminTestWP
//    {


//        [Test]
//        [Order(1)]
//        [Author("Maksym Dranivskyi")]
//        [Category("Admin panel tests")]
//        public void CreateOrder()
//        {
//            Log.Information("Create order test starting...");
//            OrderPageAdmin ordpage = OrderPageAdmin.Instance;
//            ordpage.open();
//            ordpage.SetCustomerData();
//            ordpage.ClearBillingData();
//            ordpage.ClearShippingData();
//            ordpage.SetBillingData();
//            ordpage.SetShippingData();
//            ordpage.SetTransactionId();
//            ordpage.SetNote();
//            ordpage.AddProduct("Paracord");
//            // ordpage.ChangeStatus();
//            ordpage.CreateOrder();
//            Log.Information("Create order test finished");
//        }

//        [Test]
//        [Order(2)]
//        [Author("Maksym Dranivskyi")]
//        [Category("Admin panel tests")]
//        public void NewProduct()
//        {
//            Log.Information("New product creation test starting...");
//            ProductPageAdmin prdpage = ProductPageAdmin.Instance;
//            prdpage.open();
//            prdpage.CreateProduct();
//            prdpage.SetGenetalData();
//            prdpage.SetInventoryData();
//            prdpage.SetShippingData();
//            prdpage.SetAdvancedData();
//            prdpage.PublishProduct();
//            Thread.Sleep(10000);
//            Log.Information("New product creation test finished");
//        }

//    }
//}
