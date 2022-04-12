using System;
using Baigiamasis.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Baigiamasis
{
    class KETbilietasPage :BasePage
    {        
        private IWebElement ketMygtukas => Driver.FindElement(By.CssSelector("body > div.wrapper > div.page-header > nav > div > ul.navigation-items > li.upper > a"));
        private IWebElement bKategorijosPasirinkimas => Driver.FindElement(By.CssSelector("body > div.container > div.small-wrapper > div.content-wrapper > div.col_2_full > div.ket-form-content.ket-start-form > div > form > div.border.panel-light.fast-search-content > div > div.ket-start-category > a.ket-category.bcategory"));
        private IWebElement baigtiTestaMygtukas => Driver.FindElement(By.CssSelector("#test_form > div.rel.fr.ket-navbar.navbart-bot > span.fr.ket-button.ket-button-grey.ket-button-larger.ket-button-inactive"));
        private IWebElement sprestiTestaMygtukas => Driver.FindElement(By.CssSelector("body > div.container > div.small-wrapper > div.content-wrapper > div.col_2_full > div.ket-form-content.ket-start-form > div > form > div.border.panel-light.fast-search-content > div > div.ket-form-button > a.submit-link.submit-red.fr > strong > span"));


        public KETbilietasPage(IWebDriver naujasDriver) : base(naujasDriver)
        {
        }


        public void KETpasirinkimas()
        {
            ketMygtukas.Click();
        }
        public void BkategorijosPasirinkimas()
        {
            bKategorijosPasirinkimas.Click();
        }

        public void PradetiKET_Testa()
        {
            sprestiTestaMygtukas.Click();
        }
        public void KET_testoTikrinimas()
        {
            WebDriverWait laukimas = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            laukimas.Until(x => x.FindElement(By.CssSelector("#test_form > div.rel.fr.ket-navbar.navbart-bot > span.fr.ket-button.ket-button-grey.ket-button-larger.ket-button-inactive")).Displayed);
           
            Assert.AreEqual("Baigti testą", baigtiTestaMygtukas.Text, "KET testas neatsidarė");
        }
    }
}
