using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GoogleLoginScreen.CommonDrive
{
    class ConstantHelper
    {
        private IWebDriver driver;
        public ConstantHelper(IWebDriver _driver)
        {
            driver = _driver;
        }
        //Base Url
        public static string Url = "https://accounts.google.com/ServiceLogin";

        //ScreenshotPath
        public static string ScreenshotPath = Environment.CurrentDirectory + "\\Screenshots\\";
        // Excel data path
        public static string ExcelPath = Environment.CurrentDirectory + @"\ExcelData.xlsx";    
       

    }
}
