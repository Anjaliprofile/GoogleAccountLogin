using GoogleLoginScreen.Hooks;
using GoogleLoginScreen.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace GoogleLoginScreen.Steps
{

    [Binding, Scope(Feature = "LoginScreen")]
    public class LoginScreenSteps
    {
        private IWebDriver driver;
        public LoginScreenSteps(IWebDriver _driver)
        {
            driver = _driver;
        }

       // private readonly LoginScreen loginScreen;
        //LoginScreen obj = new LoginScreen(IWebDriver _driver);
        [Given(@"User opens browser")]
        public void GivenUserOpensBrowser()
        {
            Console.WriteLine("Open browser");
        }
        
        [When(@"User has entered google account url in the browser")]
        public void WhenUserHasEnteredGoogleAccountUrlInTheBrowser()
        {
            //navigate to URL
            Console.WriteLine("Enter url");
        }

        [Then(@"Login page should be displayed")]
        public void ThenLoginPageShouldBeDisplayed()
        {
            Console.WriteLine("Login page displayed");
            LoginScreen obj = new LoginScreen(driver);
            obj.VerifyLoginScreen();
        }

        [Given(@"User opens browser and enter url")]
        public void GivenUserOpensBrowserAndEnterUrl()
        {
            // user opens browser and enter url 
            Console.WriteLine("Open browser and enter url");
        }
        [When(@"User click on forget email button")]
        public void WhenUserClickOnForgetEmailButton()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.ClickOnForgotBtn();
        }

        [Then(@"Forgot email screen should be displayed")]
        public void ThenForgotEmailScreenShouldBeDisplayed()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.VerifyForgotBtn();
        }
        [When(@"User click on Learn more link")]
        public void WhenUserClickOnLearnMoreLink()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.ClickOnLearmore();
        }
        [Then(@"Learn more page should be displayed")]
        public void ThenLearnMorePageShouldBeDisplayed()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.VerifyLearnmorePage();
        }
        [When(@"User click on Create accoun link and selete given options")]
        public void WhenUserClickOnCreateAccounLinkAndSeleteGivenOptions()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.ClickOnCreateAccount();
        }
        [Then(@"Create account page should be displayed")]
        public void ThenCreateAccountPageShouldBeDisplayed()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.verifyCreatePage();
        }
        [When(@"User enter valid email or phone")]
        public void WhenUserEnterValidEmailOrPhone()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.Enteremail();
        }
        [When(@"User click on the next button")]
        public void WhenUserClickOnTheNextButton()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.ClickOnNext();
        }
        [Then(@"Page to enter password should be displayed")]
        public void ThenPageToEnterPasswordShouldBeDisplayed()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.VerifyPasswordPage();
        }
        [When(@"User enter invalid email or phone")]
        public void WhenUserEnterInvalidEmailOrPhone()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.EnterInvalidEmail();
        }
        [Then(@"Enter valid email or phone message is displayed")]
        public void ThenEnterValidEmailOrPhoneMessageIsDisplayed()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.VerifyInValidErrorMsg();

        }
        [When(@"User enter null value email or phone")]
        public void WhenUserEnterNullValueEmailOrPhone()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.EnterNullEmail();
        }
        [Then(@"Enter email or phone message is displayed")]
        public void ThenEnterEmailOrPhoneMessageIsDisplayed()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.VerifyNullErrorMsg();
        }
        [When(@"User enter Non-Existing email or phone")]
        public void WhenUserEnterNon_ExistingEmailOrPhone()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.EnterNonExistEmail();
        }

        [Then(@"Couldn't find your google account message is displayed")]
        public void ThenCouldnTFindYourGoogleAccountMessageIsDisplayed()
        {
            LoginScreen obj = new LoginScreen(driver);
            obj.VerifyNonexistErrorMsg();
        }

    }
}
