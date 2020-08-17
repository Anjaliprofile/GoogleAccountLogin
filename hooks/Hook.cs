using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace GoogleLoginScreen.Hooks
{
    [Binding]
    public class Hook
    {
        public IWebDriver Driver;
        private readonly IObjectContainer objectContainer;

        public Hook(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InititalizeTest()
        {
            if (Driver == null)
            {
                // intialize chrome driver
                Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                //Driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                objectContainer.RegisterInstanceAs<IWebDriver>(Driver);
                // Maximize browser
                Driver.Manage().Window.Maximize();
                //navigate to URL
                Driver.Navigate().GoToUrl(CommonDrive.ConstantHelper.Url);
            }
            else 
            { 
                throw new Exception("Couldn't initialize the driver"); 
            }
        }
        [AfterScenario]
        public void CleanUp()
        {
            // Close the driver 
            //Driver.Close();
            if (Driver != null)
            {
                Driver.Quit();
            }
            else throw new Exception("There was an error while trying to close the driver");
        }
    }
}
