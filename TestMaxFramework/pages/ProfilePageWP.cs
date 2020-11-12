//using OpenQA.Selenium;
//using Serilog;

//namespace TestMaxFramework.pages
//{
//    class ProfilePageWP : BasePageWP
//    {
//        private static ProfilePageWP instance;
//        public static ProfilePageWP Instance = (instance != null) ? instance : new ProfilePageWP();
//        Profile profile = new Profile().FillIn();

//        public ProfilePageWP()
//        {
//            pageURL = "/my-account/edit-account";
//            pageTitle = "My account – Dragon Shop";
//        }

//        By saveAccount = By.Name("save_account_details");
//        By firstName = By.Name("account_first_name");
//        By lastName = By.Name("account_last_name");
//        By nickName = By.Name("account_display_name");




//        public void SetAccountData()
//        {

//            Log.Information("Start updating user profile...");
//            findElement(firstName).Clear();
//            findElement(lastName).Clear();
//            findElement(nickName).Clear();
//            Log.Debug("Previous data was cleaned");
//            findElement(firstName).SendKeys(profile.FirstName);
//            findElement(lastName).SendKeys(profile.LastName);
//            findElement(nickName).SendKeys(profile.NickName);
//       //Log.Information($"User {msg.Name} created massage '{msg.Massage}'");

//        }

//        public void SaveAccount()
//        {
//            scrollToView(saveAccount);
//            sleepFor(1000);
//            clickOnElementIgnoreException(saveAccount);
//        }

//    }
//}
