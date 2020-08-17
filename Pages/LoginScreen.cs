using GoogleLoginScreen.CommonDrive;
using GoogleLoginScreen.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static GoogleLoginScreen.CommonDrive.ScreenShot;

namespace GoogleLoginScreen.Pages
{
    public class LoginScreen
    {
        
        private IWebDriver driver;        
        public LoginScreen(IWebDriver _driver)
        {
            driver = _driver;            
            //Populate the excel data            
            ExcelLib.PopulateInCollection(ConstantHelper.ExcelPath, "LoginData");
        }
        private IWebElement SignInText => driver.WaitForElement(By.XPath("//h1//span[text()='Sign in']"));
        private IWebElement ClickOnForgot => driver.WaitForElement(By.XPath("//button[contains(text(), 'Forgot email?')]"));
        private IWebElement VerifyForgot => driver.WaitForElement(By.XPath("//h1"));
        private IWebElement Learnmore => driver.WaitForElement(By.XPath("//a[contains(text(), 'Learn more')]"));
        private IWebElement LearnmorePage => driver.WaitForElement(By.XPath("//h1"));
        private IWebElement CreateAccount => driver.WaitForElement(By.XPath("//span[contains(text(),'Create account')]"));        
        private IWebElement Option1 => driver.WaitForElement(By.XPath("//div/span/div[2]/div[contains(text(), 'For myself')]"));
        private IWebElement Option2 => driver.WaitForElement(By.XPath("//div/span/div[2]/div[contains(text(), 'To manage my business')]"));        
        private IWebElement email => driver.WaitForElement(By.XPath("//input[@type='email']"));
        //div[@class="o6cuMc"]
        public void VerifyLoginScreen()
        {        
           // Compare actual header text with expected text
            Assert.That(SignInText.Text, Is.EqualTo("Sign in"));
            Console.WriteLine("Sign In Header is correct");
        }
        public void ClickOnForgotBtn()
        {            
            // Click on Forgot link
            ClickOnForgot.Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
           Thread.Sleep(1000);
        }
        public void VerifyForgotBtn()
        {
            //Verify forgot page             
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Console.WriteLine(VerifyForgot.Text);
            Assert.That(VerifyForgot.Text, Is.EqualTo("Find your email"));
            SaveScreenShotClass.SaveScreenshot(driver, "VerifyForgotPage");
        }
        public void ClickOnLearmore()
        {
            Learnmore.Click();
        }
        public void VerifyLearnmorePage()
        {            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Console.WriteLine(LearnmorePage.Text);
            Assert.That(LearnmorePage.Text, Is.EqualTo("Browse Chrome as a guest"));
            SaveScreenShotClass.SaveScreenshot(driver, "VerifyLearnmorePage");
        }
        public void ClickOnCreateAccount()
        {
            Thread.Sleep(1000);
            CreateAccount.Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);            
            Thread.Sleep(1000);
            string value = ExcelLib.ReadData(2, "CreateAccount");
            IWebElement Option1 = driver.FindElement(By.XPath("//div/span/div[2]/div[contains(text(), 'For myself')]"));
            IWebElement Option2 = driver.FindElement(By.XPath("//div/span/div[2]/div[contains(text(), 'To manage my business')]"));
            if (Option1.Text == value)
            {
                Console.WriteLine("Create account for myself");
                Option1.Click();
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Create account for myself");                
                Option2.Click();
            }        
        }
        public void verifyCreatePage()
        {

            IWebElement CreateAccountPage = driver.FindElement(By.XPath("//h1"));
            Console.WriteLine(CreateAccountPage.Text);
            Assert.That(CreateAccountPage.Text, Is.EqualTo("Create your Google Account"));
            SaveScreenShotClass.SaveScreenshot(driver, "verifyCreatePage");
        }
        public void Enteremail()
        {
            email.SendKeys(ExcelLib.ReadData(2, "Email"));            
        }
        public void ClickOnNext()
        {         
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.WaitForElement(By.CssSelector("#identifierNext > div > button > div.VfPpkd-Jh9lGc"))).Click().Perform();
            Thread.Sleep(2000);
        }
        public void VerifyPasswordPage()
        {
            IWebElement passwordPage = driver.WaitForElement(By.XPath("//h1"));
            //driver.waitElementIsVisible(passwordPage.Text);
            Console.WriteLine(passwordPage.Text);
            Assert.That(passwordPage.Text, Is.EqualTo("Couldn't sign you in"));
            SaveScreenShotClass.SaveScreenshot(driver, "VerifyPasswordPage");
        }
        public void EnterInvalidEmail()
        {
            email.SendKeys(ExcelLib.ReadData(2, "invalidEmail"));
        }
        public void VerifyInValidErrorMsg()
        {
            string msg = driver.FindElement(By.XPath("//div[@class='o6cuMc']")).Text;
            Console.WriteLine(msg);
            Assert.That(msg, Is.EqualTo("Enter a valid email or phone number"));
            SaveScreenShotClass.SaveScreenshot(driver, "VerifyInvaildMsg");
        }
        public void EnterNonExistEmail()
        {
            email.SendKeys(ExcelLib.ReadData(2, "Non-existing"));
        }
        public void VerifyNonexistErrorMsg()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            string msg = driver.FindElement(By.XPath("//div[@class='o6cuMc']")).Text;
            Console.WriteLine(msg);
            Assert.That(msg, Is.EqualTo("Couldn't find your Google Account"));
            SaveScreenShotClass.SaveScreenshot(driver, "CheckErrorMsg");
        }
        public void EnterNullEmail()
        {
            email.SendKeys(ExcelLib.ReadData(2, "Null"));
        }
        public void VerifyNullErrorMsg()
        {
            string msg = driver.FindElement(By.XPath("//div[@class='o6cuMc']")).Text;
            Console.WriteLine(msg);
            Assert.That(msg, Is.EqualTo("Enter an email or phone number"));
            SaveScreenShotClass.SaveScreenshot(driver, "VerifyNullEmailMsg");
        }
    }
}
