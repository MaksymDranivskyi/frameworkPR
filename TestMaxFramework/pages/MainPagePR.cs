using OpenQA.Selenium;
using Serilog;

namespace TestMaxFramework.pages
{
    class MainPagePR : BasePagePR
    {
        private static MainPagePR instance;
        public static MainPagePR Instance = (instance != null) ? instance : new MainPagePR();
        Checkout chkout = new Checkout().FillIn();

        public MainPagePR()
        {
            pageURL = "";
            pageTitle = "My Store";
        }

        By saveAddress = By.Name("save_address");
        By firstName = By.Name("billing_first_name");
        By lastName = By.Name("billing_last_name");
        By email = By.Name("billing_email");
        By country = By.Id("select2-billing_country-container");
        By street = By.Name("billing_address_1");
        By city = By.Name("billing_city");
        By state = By.Name("billing_state");
        By postcode = By.Name("billing_postcode");




        public void SetBillingData()
        {

            Log.Information("Start updating user profile...");
            findElement(firstName).Clear();
            findElement(lastName).Clear();
            findElement(email).Clear();
            // findElement(country).Clear();
            findElement(street).Clear();
            findElement(city).Clear();
            findElement(state).Clear();
            findElement(postcode).Clear();
            Log.Debug("Previous data was cleaned");
            findElement(firstName).SendKeys(chkout.FirstName);
            findElement(lastName).SendKeys(chkout.LastName);
            findElement(email).SendKeys(chkout.Email);
            //findElement(country).SendKeys(chkout.Country);
            findElement(street).SendKeys(chkout.Street);
            findElement(city).SendKeys(chkout.City);
            findElement(state).SendKeys(chkout.State);
            findElement(postcode).SendKeys(chkout.Postcode);
            //Log.Information($"User {msg.Name} created massage '{msg.Massage}'");

        }

        public void SaveAddress()
        {
            scrollToView(saveAddress);
            sleepFor(1000);
            clickOnElementIgnoreException(saveAddress);
        }

    }
}
