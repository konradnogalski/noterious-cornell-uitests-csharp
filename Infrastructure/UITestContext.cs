using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Infrastructure
{
   public class UITestContext
   {
      private static IWebDriver _driver;
      public static IWebDriver Driver 
      {
         get 
         {
            if (_driver != null){
                return _driver;
            } 

            _driver = new ChromeDriver();
            return _driver;
         } 
      }
   }
}