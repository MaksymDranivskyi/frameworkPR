using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TestMaxFramework.utils;
using TestMaxFramework.pages;
using TestMaxFramework;
using OpenQA.Selenium.Support.PageObjects;
using Serilog;
using Serilog.Events;

namespace TestMaxFramework
{
    [TestFixture]
    class WPTestSuite : BaseTestPR
    {
        ApiFixture prestaApi = new ApiFixture();
        
        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Contact form")]
        public void ContactMsgWP()
        {
            prestaApi.CreateProduct();
            prestaApi.CreateCategory();
            Log.Information("Profile update test starting...");
            ContactUsPR contactmsg = ContactUsPR.Instance;
            contactmsg.open();
            contactmsg.CreateMassage();
            contactmsg.AddMassage();
            Log.Information("Profile update test finished");
        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Orders")]
        public void NewOrder()
        {
            
            Log.Information("Profile update test starting...");
           CategoryPR ctgWoman = CategoryPR.Instance;
            CartPR cart = CartPR.Instance;
            ctgWoman.open();
            //ctgWoman.switchToList();
            ctgWoman.AddProductsToCartById(new int[] {1});  
            cart.open();
            cart.ConfirmOrder();
            Log.Information("Profile update test finished");
        }


        //[Test]
        //[Order(2)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Contact form")]
        //public void CompareProducts()
        //{
        //    Log.Information("Profile update test starting...");
        //    CategoryPR ctgWoman = CategoryPR.Instance;
        //    ctgWoman.open();
        //    ctgWoman.switchToList();
        //    ctgWoman.AddProductToCartById(new int[] { 1, 3 });
        //    ctgWoman.AddToCompareById(new int[] { 1, 3 });
        //    ctgWoman.CompareProducts();
        //    Log.Information("Profile update test finished");
        //}

        //[Test]
        //[Order(2)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Contact form")]
        //public void OpenProduct()
        //{
        //    Log.Information("Profile update test starting...");
        //    CategoryPR ctgWoman = CategoryPR.Instance;
        //    ProductPR product = ProductPR.Instance;
        //    ctgWoman.open();
        //    ctgWoman.switchToList();
        //    ctgWoman.AddProductToCartById(new int[] { 1, 3 });
        //    ctgWoman.OpenProductDetails(new int[] { 1 });
        //    product.IncrementQty();
        //    product.AddToCart();

        //    Log.Information("Profile update test finished");
        //}


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("My account")]
        public void MyAccountCheck()
        {
            Log.Information("Profile update test starting...");
            MyAccountPR acc = MyAccountPR.Instance;

            acc.open();
            acc.VerifyMyAccountElements();

            Log.Information("Profile update test finished");
        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("My account")]
        public void CheckChangePersonalInfo()
        {
            Log.Information("Profile update test starting...");
            PersonalInfoPR pif = PersonalInfoPR.Instance;

            pif.open();
            pif.ChangePersonalInfo();
            pif.SaveChanges();
            Log.Information("Profile update test finished");
        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("My account")]
        public void CheckFooterLinks()
        {
            MainPagePR main = MainPagePR.Instance;
            main.open();
            main.VerifyFooter();

        }


        [Test]
        [Order(1)]
        [Author("Maksym Dranivskyi")]
        [Category("My account")]
        [Description("Add new address to your account")]
        public void CheckAddAddress()
        {
            MyAddressesPR addrss = MyAddressesPR.Instance;
            CreateAddressPR crtaddrs = CreateAddressPR.Instance;
            addrss.open();
            addrss.CreateNewAddress();
            crtaddrs.FillAddress();
           
            crtaddrs.SaveAddress();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("My account")]
        [Description("Add new address to your account")]
        public void CheckUpdateAddress()
        {
            MyAddressesPR addrss = MyAddressesPR.Instance;
            CreateAddressPR crtaddrs = CreateAddressPR.Instance;
            addrss.open();
            addrss.UpdateAddress(1);
            crtaddrs.FillAddress();
            crtaddrs.SaveAddress();

        }

        [Test]
        [Order(3)]
        [Author("Maksym Dranivskyi")]
        [Category("My account")]
        [Description("Add new address to your account")]
        public void CheckDeleteAddress()
        {
            MyAddressesPR addrss = MyAddressesPR.Instance;
            addrss.open();
            addrss.DeleteAddress(1);
        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Orders")]
        [Description("Check order history details")]
        public void CheckOrderHistory()
        {
            MyOrdersPR order = MyOrdersPR.Instance;
            order.open();
            order.OrderDetails(1);
        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Orders")]
        [Description("Reorder the order")]
        public void CheckReorder()
        {
            MyOrdersPR order = MyOrdersPR.Instance;
            order.open();
            order.Reorder(1);

        }

        
        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Products")]
        [Description("Add product to the cart")]
        public void CheckAddToCart()
        {
            CategoryPR categ = CategoryPR.Instance;
            ProductPR prod = ProductPR.Instance;
            categ.open();
            categ.AddProductsToCartById( new int[] { 1});
            categ.OpenProductDetails(1);
            prod.AddToCart();
        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Products")]
        [Description("Increase qty of selected products")]
        public void CheckIncrementQty()
        {
            CategoryPR categ = CategoryPR.Instance;
            ProductPR prod = ProductPR.Instance;
            categ.open();
            categ.OpenProductDetails( 1 );
            prod.IncrementQty();
            prod.AddToCart();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Products")]
        [Description("Decrease qty of selected product")]
        public void CheckDecrementQty()
        {
            CategoryPR categ = CategoryPR.Instance;
            ProductPR prod = ProductPR.Instance;
            categ.open();
            categ.OpenProductDetails( 1 );
            prod.IncrementQty();
            prod.DecrementQty();
            prod.AddToCart();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Orders")]
        [Description("Add several products to cart")]
        public void CheckAddSeveralProductsToCart()
        {
            CategoryPR categ = CategoryPR.Instance;
            ProductPR prod = ProductPR.Instance;
            categ.open();
            categ.AddProductsToCartById(new int[] { 1, 2, 3 });
            categ.OpenProductDetails(1);
            prod.AddToCart();

        }

        // **************** ADMIN - GENERAL******************* //
        //[Test]
        //[Order(2)]
        //[Author("Maksym Dranivskyi")]
        //[Category("Admin - General")]
        //[Description("Incorrect Login")]
        //public void TestCase10()
        //{
        //    AdminLoginPage admin = AdminLoginPage.Instance;
        //    admin.LoginAdmin("maxidran@mail.com", "qwerty123");

        //}

        // **************** ADMIN - PRODUCTS ******************* //

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Products")]
        [Description("Change product status")]
        public void CheckChangeProductStatus()
        {
            AdminProductPage product = AdminProductPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToProducts();
            product.ChangeProductStatus(new int[] { 1 });


        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Products")]
        [Description("Preview peroduct")]
        public void CheckPreviewProduct()
        {
            AdminProductPage product = AdminProductPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToProducts();
            product.PreviewProduct(1);
        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Products")]
        [Description("Dublicate product")]
        public void CheckDublicateProduct()
        {
            AdminProductPage product = AdminProductPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToProducts();
            product.DuplicateProduct(1);

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Products")]
        [Description("Delete product")]

        public void CheckDeleteProduct()
        {
            AdminProductPage product = AdminProductPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToProducts();
            product.DeleteProduct(1);

        }
        

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Products")]
        [Description("Dublicate several products")]
        public void CheckDulpicateSeveralProducts()
        {
            AdminProductPage product = AdminProductPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToProducts();
            product.SelectProducts( new int[] { 2, 3});
            product.DuplicateSelected();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Products")]
        [Description("Delete several products")]
        public void CheckDeleteSeveralProducts()
        {
            AdminProductPage product = AdminProductPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToProducts();
            product.SelectProducts(new int[] {  2, 3 });
            product.DeleteSelected();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Products")]
        [Description("Deactivate several products")]
        public void CheckDeactivateSeveralProducts()
        {
            AdminProductPage product = AdminProductPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToProducts();
            product.SelectProducts(new int[] {  2, 3 });
            product.DeactivateSelected();

        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Products")]
        [Description("Create simple product")]
        public void AddNewProduct()
        {
            AdminProductPage product = AdminProductPage.Instance;
            AdminNewProductPage newprod = AdminNewProductPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
           
            dash.open();
            dash.GoToProducts();
            product.AddNewProduct();
            newprod.AddBasicSettings();
            newprod.AddShipping();
        }

        // **************** ADMIN - CATEGORIES ******************* //


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Categories")]
        [Description("Change category status")]
        public void CheckChangeCategoryStatus()
        {
            AdminCategoryPage category = AdminCategoryPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCategories();
            category.ChangeCategoryStatus(new int[] { 2, 3 });

        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Categories")]
        [Description("View/Edit category")]
        public void CheckEditCategory()
        {
            AdminCategoryPage category = AdminCategoryPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCategories();
            category.PreviewCategory(1);

        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Categories")]
        [Description("Delete category")]
        public void CheckDeleteCategory()
        {
            // Preconditions
            prestaApi.CreateCategory();

            // Steps
            AdminCategoryPage category = AdminCategoryPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCategories();
            category.DeleteCategory(1);

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Categories")]
        [Description("Delete several categories")]
        public void CheckDeleteSeveralCategories()
        {
            AdminCategoryPage category = AdminCategoryPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCategories();
            category.SelectCategories(new int[] { 2, 3 });
            category.DeleteSelected();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Categories")]
        [Description("Delete several categories")]
        public void CheckEnableSeveralCategories()
        {
            AdminCategoryPage category = AdminCategoryPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCategories();
            category.SelectCategories(new int[] { 1 });
            category.EnableSelected();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Categories")]
        [Description("Delete several categories")]
        public void CheckDisableSeveralCategories()
        {
            AdminCategoryPage category = AdminCategoryPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCategories();
            category.SelectCategories(new int[] { 1 });
            category.DisableSelected();

        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Categories")]
        [Description("Create category")]
        public void CheckAddNewCategory()
        {
            AdminCategoryPage category = AdminCategoryPage.Instance;
            AdminNewCategoryPage newctgr = AdminNewCategoryPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;

            dash.open();
            dash.GoToCategories();
            category.AddNewCategory();
            newctgr.AddNewCategory();
           
        }

        // **************** ADMIN - CUSTOMERS ******************* //


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Customers")]
        [Description("View customer")]
        public void CheckViewCustomer()
        {
            AdminCustomerPage castomer = AdminCustomerPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCustomers();
            castomer.PreviewCastomer(1);

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Customers")]
        [Description("Edit customer")]
        public void CheckEditCustomer()
        {
            AdminCustomerPage castomer = AdminCustomerPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCustomers();
            castomer.EditCustomer(1);

        }


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Customers")]
        [Description("Delete customer")]
        public void CheckDeleteCustomer()
        {
            AdminCustomerPage castomer = AdminCustomerPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCustomers();
            castomer.DeleteCustomer(3);

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Customers")]
        [Description("Delete  several customers")]
        public void CheckDeleteSeveralCustomers()
        {
            
            AdminCustomerPage customer = AdminCustomerPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCustomers();
            customer.SelectCustomers(new int[] { 2, 3 });
            customer.DeleteSelected();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Customers")]
        [Description("Enable  several customers")]
        public void CheckEnableSeveralCustomers()
        {
            AdminCustomerPage customer = AdminCustomerPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCustomers();
            customer.SelectCustomers(new int[] { 2, 3 });
            customer.EnableSelected();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Customers")]
        [Description("Disable  several customers")]
        public void CheckDisableSeveralCustomers()
        {
            AdminCustomerPage customer = AdminCustomerPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCustomers();
            customer.SelectCustomers(new int[] { 2, 3 });
            customer.DisableSelected();

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Customers")]
        [Description("Add new customer")]
        public void CheckAddCustomer()
        {

            AdminCustomerPage customer = AdminCustomerPage.Instance;
            AdminNewCustomerPage profile = AdminNewCustomerPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;
            dash.open();
            dash.GoToCustomers();
            customer.AddNewCustomer();
            profile.AddCustomer();

        }

        // **************** ADMIN - ORDERS ******************* //


        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Orders")]
        [Description("View order")]
        public void CheckViewOrder()
        {
            AdminOrderPage order = AdminOrderPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;

            dash.open();
            dash.GoToOrders();
            order.ViewOrder(2);


        }
         
        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Orders")]
        [Description("Update order status")]
        public void CheckUpdateOrderStatus()
        {
            AdminOrderPage order = AdminOrderPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;

            dash.open();
            dash.GoToOrders();
            order.SelectOrders( new int[] {1, 2, 4 });
            order.ChangeStatusSeveral();
            order.SelectStatusAndUpdate("4");

        }

        [Test]
        [Order(2)]
        [Author("Maksym Dranivskyi")]
        [Category("Admin - Orders")]
        [Description("Update status of several orders")]
        public void CheckUpdateStatusSeveralProducts()
        {
            AdminOrderPage order = AdminOrderPage.Instance;
            AdminDashboard dash = AdminDashboard.Instance;

            dash.open();
            dash.GoToOrders();
            order.SelectAll();
            order.ChangeStatusSeveral();
            order.SelectStatusAndUpdate();

        }
    }
}
