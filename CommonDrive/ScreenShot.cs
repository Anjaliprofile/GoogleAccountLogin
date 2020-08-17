using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleLoginScreen.CommonDrive
{
    class ScreenShot
    {
        #region screenshots
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = ConstantHelper.ScreenshotPath;

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                //fileName.Append(DateTime.Now.ToString("_dd-MM-yyyy_mss"));
                fileName.Append(DateTime.Now.ToString("dd-mm-yyyy_mss"));
                fileName.Append(".png");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Png);
                return fileName.ToString();

            }
        }
        #endregion
    }
}
