using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ScreenshotTaker
    {
        private readonly ITakesScreenshot _screenshotTaker;
        private string _screenshotsDirectory;
        public ScreenshotTaker(ITakesScreenshot screenshotTaker, string screenshotDirectory)
        {
            _screenshotTaker = screenshotTaker;
            _screenshotsDirectory = screenshotDirectory;
        }

        public void TakeScreenshot(string fileName)
        {
            var screenShot = _screenshotTaker.GetScreenshot();
            screenShot.SaveAsFile(string.Join(@"/", _screenshotsDirectory, fileName));
        }
    }
}
