using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TestMaxFramework.utils;
using TestMaxFramework.pages;
using OpenQA.Selenium.Support.PageObjects;
using Serilog;
using Serilog.Events;

namespace TestMaxFramework
{
    [TestFixture]
    class WPTestSuite : BaseTestPR
    {


        //[Test]
        //[Order(2)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Contact form")]
        //public void ContactMsgWP()
        //{
        //    Log.Information("Profile update test starting...");
        //    ContactUsPR contactmsg = ContactUsPR.Instance;
        //    contactmsg.open();
        //    contactmsg.CreateMassage();
        //    contactmsg.AddMassage();
        //    Log.Information("Profile update test finished");
        //}

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Contact form")]
        public void NewOrder()
        {
            Log.Information("Profile update test starting...");
            CategoryPR ctgWoman = CategoryPR.Instance;
            CartPR cart = CartPR.Instance;
            ctgWoman.open();
            ctgWoman.switchToList();
            ctgWoman.AddProductToCartById(new int[] { 1, 2 });      
            cart.open();
            cart.ConfirmOrder();
            Log.Information("Profile update test finished");
        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Contact form")]
        public void CompareProducts()
        {
            Log.Information("Profile update test starting...");
            CategoryPR ctgWoman = CategoryPR.Instance;
            ctgWoman.open();
            ctgWoman.switchToList();
           // ctgWoman.AddProductToCartById(new int [] { 1, 3 });
            ctgWoman.AddToCompareById(new int[] { 1, 3 });
            ctgWoman.CompareProducts();
            Log.Information("Profile update test finished");
        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Contact form")]
        public void OpenProduct()
        {
            Log.Information("Profile update test starting...");
            CategoryPR ctgWoman = CategoryPR.Instance;
            ProductPR product = ProductPR.Instance;
            ctgWoman.open();
            ctgWoman.switchToList();
            // ctgWoman.AddProductToCartById(new int [] { 1, 3 });
            ctgWoman.OpenProductDetails(new int[] {1});
            product.IncrementQty();
            product.AddToCart();
                       
            Log.Information("Profile update test finished");
        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Contact form")]
        public void MyAccountCheck()
        {
            Log.Information("Profile update test starting...");
            MyAccountPR acc = MyAccountPR.Instance;
            
            acc.open();
            acc.MyAddresses();
            acc.open();
            acc.MyCreditSlips();
            acc.open();
            acc.MyPersonalInfo();
            acc.open();
            acc.OdredHistory();

            Log.Information("Profile update test finished");
        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Contact form")]
        public void ChangePersonalInfo()
        {
            Log.Information("Profile update test starting...");
            PersonalInfoPR pif = PersonalInfoPR.Instance;

            pif.open();
            pif.ChangePersonalInfo();
            pif.SaveChanges();
            Log.Information("Profile update test finished");
        }

        //[Test]
        //[Order(3)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Product")]
        //public void AddToCartWP()
        //{
        //    Log.Information("Profile update test starting...");
        //    ShopPageWP shopPage = ShopPageWP.Instance;
        //    shopPage.open();
        //    shopPage.AddToCart();
        //    Log.Information("Profile update test finished");
        //}

        //[Test]
        //[Order(4)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Product")]
        //public void CompareWP()
        //{
        //    Log.Information("Profile update test starting...");
        //    ShopPageWP shopCmpPage = ShopPageWP.Instance;
        //    shopCmpPage.open();
        //    shopCmpPage.CompareProduct();
        //    Log.Information("Profile update test finished");
        //}

        //[Test]
        //[Order(5)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Checkout")]
        //public void ApplyCoupon()
        //{
        //    Log.Information("Profile update test starting...");
        //    AddToCartWP();
        //    CartWP cart = CartWP.Instance;
        //    cart.open();
        //    cart.SetCoupon();
        //    cart.ApplyCouponCode();
        //    cart.ProcessToChkout();
        //    Log.Information("Profile update test finished");
        //}


        //[Test]
        //[Order(8)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Checkout")]
        //public void CheckoutTestWP()
        //{
        //    Log.Information("Profile update test starting...");
        //    AddToCartWP();
        //    CheckoutWP chkoutPage = CheckoutWP.Instance;
        //    chkoutPage.open();
        //    chkoutPage.SetBillingData();
        //    chkoutPage.PlaceOrder();
        //    Log.Information("Profile update test finished");
        //}

        //[Test]
        //[Order(9)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Profile")]
        //public void ChangeDisplayName()
        //{
        //    Log.Information("Profile update test starting...");
        //    ProfilePageWP profileChg = ProfilePageWP.Instance;
        //    profileChg.open();
        //    profileChg.SetAccountData();
        //    profileChg.SaveAccount();
        //    Log.Information("Profile update test finished");
        //}

        //[Test]
        //[Order(10)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Profile")]
        //public void ChangeBillingAddress()
        //{
        //    Log.Information("Profile update test starting...");
        //    BillingWP billingChg = BillingWP.Instance;
        //    billingChg.open();
        //    billingChg.SetBillingData();
        //    billingChg.SaveAddress();
        //    Log.Information("Profile update test finished");
        //}

    }
}
