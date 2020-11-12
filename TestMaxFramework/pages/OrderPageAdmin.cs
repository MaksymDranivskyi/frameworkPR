//using OpenQA.Selenium;
//using Serilog;

//namespace TestMaxFramework.pages
//{
//    class OrderPageAdmin : BasePageWP
//    {
//        private static OrderPageAdmin instance;
//        public static OrderPageAdmin Instance = (instance != null) ? instance : new OrderPageAdmin();

//        public OrderPageAdmin()
//        {
//            pageURL = "/wp-admin/post-new.php?post_type=shop_order";
//            pageTitle = "Add New ‹ Orders ‹ Dragon Shop — WooCommerce";
//        }

//        Checkout ord = new Checkout().FillIn();
//        /*----------Billing Data-----------*/
//        By firstNameB = By.Name("_billing_first_name");
//        By lastNameB = By.Name("_billing_last_name");
//        By emailB = By.Name("_billing_email");
//        By companyB = By.Name("_billing_company");
//        By countryB = By.CssSelector("span[aria-labelledby='select2-_billing_country-container']"); 
//        By countryInputB = By.CssSelector("input[aria-owns='select2-_billing_country-results']");
//        By streetB = By.Name("_billing_address_1");
//        By streetB2 = By.Name("_billing_address_2");
//        By cityB = By.Name("_billing_city");
//        By stateB = By.Name("_billing_state");
//        By stateDB = By.CssSelector("span[aria-labelledby='select2-_billing_state-container']");
//        By stateInputB = By.CssSelector("input[aria-owns='select2-_billing_state-results']");
//        By postcodeB = By.Name("_billing_postcode");

//        /*----------Shipping Data-----------*/
//        By firstNameS = By.Name("_shipping_first_name");
//        By lastNameS = By.Name("_shipping_last_name");
//        By emailS = By.Name("_shipping_email");
//        By companyS = By.Name("_shipping_company");
//        By countryS = By.XPath("//*[@id='select2-_shipping_country-container']");
//        By countryInputS = By.XPath ("/html/body/span/span/span[1]/input");
//        By streetS = By.Name("_shipping_address_1");
//        By streetS2 = By.Name("_shipping_address_2");
//        By cityS = By.Name("_shipping_city");
//        By stateS = By.Name("_shipping_state");
//        By stateDS = By.CssSelector("span[aria-labelledby='select2-_shipping_state-container']");
//        By stateInputS = By.CssSelector("input[aria-owns='select2-_shipping_state-results']");
//        By postcodeS = By.Name("_shipping_postcode");

//        /*----------Order Data-----------*/
//        By paymentMethod = By.Name("_payment_method");
//        By transId = By.Name("_transaction_id");
//        By massage = By.Name("excerpt");
//        By placeOrder = By.Name("save");

//        /*----------Customer Data-----------*/
//        By status = By.Id("order_status");
//        By statusInput = By.ClassName("select2-results__option");
//        By customer = By.Id("select2-customer_user-container");
//        By customerInput = By.CssSelector("input[aria-owns='select2-customer_user-results']");

//        /*----------Add Product Data-----------*/
//        By addItem = By.CssSelector("button[class='button add-line-item']");
//        By addProduct = By.CssSelector("button[class='button add-order-item']");
//        By addProductInput = By.CssSelector("body>span>span>span.select2-search.select2-search--dropdown>input.select2-search__field");
//        //By addProductInput = By.XPath("//input[@type='text']");
//        By addBtn = By.Id("btn-ok");
//        By selectProduct = By.XPath("//div[@id='wc-backbone-modal-dialog']/div/div/section/article/form/table/tbody/tr/td/span/span/span/span");
//        //By selectProduct = By.XPath("//*[@id='select2-selection__rendered']");
//         By enterProduct = By.CssSelector("button[class='class='select2-search__field']");
//        By qtyProduct = By.Name("item_qty");


//        public void ClearBillingData()
//        {
//            Log.Information("Start updating user profile...");
//            findElement(firstNameB).Clear();
//            findElement(lastNameB).Clear();
//            findElement(companyB).Clear();
//            findElement(emailB).Clear();
//            findElement(streetB).Clear();
//            findElement(streetB2).Clear();
//            findElement(cityB).Clear();
//            if (isElementPresentAndDisplay(stateB)) { findElement(stateB).Clear(); }
//            if (isElementPresentAndDisplay(postcodeB)) { findElement(postcodeB).Clear(); }
//        }

//        public void ClearShippingData()
//        {
//            findElement(firstNameS).Clear();
//            findElement(lastNameS).Clear();
//            findElement(companyB).Clear();
//            findElement(streetS).Clear();
//            findElement(streetS2).Clear();
//            findElement(cityS).Clear();
//            if (isElementPresentAndDisplay(stateS)) { findElement(stateS).Clear(); }
//            if (isElementPresentAndDisplay(postcodeS)) { findElement(postcodeS).Clear(); }
//            Log.Debug("Previous data was cleared");
//        }

//        public void SetBillingData()
//        {

//            findElement(firstNameB).SendKeys(ord.FirstName);
//            findElement(lastNameB).SendKeys(ord.LastName);
//            findElement(companyB).SendKeys(ord.Company);
//            findElement(emailB).SendKeys(ord.Email);
//            selectByValue(countryB, countryInputB, ord.Country, 300);
//            if (isElementPresentAndDisplay(stateB)) { findElement(stateB).SendKeys(ord.State); }
//            else if (isElementPresentAndDisplay(stateDB)) { selectByValue(stateDB, stateInputB, "Ab", 300); }
//            if (isElementPresentAndDisplay(postcodeB)) { findElement(postcodeB).SendKeys(ord.Postcode); }
//            findElement(streetB).SendKeys(ord.Street);
//            findElement(streetB2).SendKeys(ord.Street);
//            findElement(cityB).SendKeys(ord.City);
//        }
//        public void SetShippingData()
//        {
           
//            findElement(firstNameS).SendKeys(ord.FirstName);
//            findElement(lastNameS).SendKeys(ord.LastName);
//            findElement(companyS).SendKeys(ord.Company);
//            findElement(streetS).SendKeys(ord.Street);
//            findElement(streetS2).SendKeys(ord.Street);
//            selectByValue(countryS, countryInputS, ord.Country, 300);
//            if (isElementPresentAndDisplay(stateS)) { findElement(stateS).SendKeys(ord.State); }
//            else if (isElementPresentAndDisplay(stateDS)) { selectByValue(stateDS, stateInputS, "Ab", 300); }
//            if (isElementPresentAndDisplay(postcodeS)) { findElement(postcodeS).SendKeys(ord.Postcode); }
//            findElement(cityS).SendKeys(ord.City);
//        }



//        public void CreateOrder()
//        {
//            scrollToView(placeOrder);
//            sleepFor(1000);
//            clickOnElementIgnoreException(placeOrder);
//        }

//        public void ChangeStatus()
//        {
//            scrollToView(status);
//            selectByText(status, ord.Status ,300);
//        }

//        public void SetTransactionId()
//        {
//            scrollToView(transId);
//            findElement(transId).SendKeys(ord.Transaction);
//        }

//        public void SetNote()
//        {
//            scrollToView(massage);
//            findElement(massage).SendKeys(ord.Massage);
//        }

//        public void SetCustomerData()
//        {
//           // clickOnElement(customer);
//            selectByValue(customer, customerInput, "max_dran@ukr.net", 7000);
//            sleepFor(5000);
//        }


//        public void AddProduct(string name)
//        {
//            scrollToView(addItem);
//            clickOnElement(addItem);
//            clickOnElement(addProduct);
//            selectByValue(selectProduct, addProductInput, name, 3000);
//            clickOnElement(addBtn);
//        }

//    }
//}
