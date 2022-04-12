

using OpenQA.Selenium;

namespace Baigiamasis.Page
{
    class BasePage
    {
        protected static IWebDriver Driver;
        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }
    }
}
