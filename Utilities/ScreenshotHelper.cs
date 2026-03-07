using OpenQA.Selenium;
using System;
using System.IO;

namespace AutomationFramework.Utilities
{
    public class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();

                string folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Screenshots");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(
                    folderPath,
                    testName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");

                screenshot.SaveAsFile(filePath);

                return filePath;
            }
            catch (Exception)
            {
                return ""; // important: always return something
            }
        }

    }
}

