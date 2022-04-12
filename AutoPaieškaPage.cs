using System;
using System.Threading;
using Baigiamasis.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Baigiamasis
{
    class AutoPaieškaPage :BasePage
    {
        private IWebElement autoMarke => Driver.FindElement(By.CssSelector("body > div.wrapper > div.quick-search-valuation-ket > div > div.left-col > div.quick-search-container.searchbox-bosch-shadow > div.form-and-bookmarks-container > div.quick-search-form > form > div.form-row.make-and-model-row > div:nth-child(1) > div.input-select.js-make > div.display-input.js-placeholder"));
        private IWebElement autoModelis => Driver.FindElement(By.CssSelector("body > div.wrapper > div.quick-search-valuation-ket > div > div.left-col > div.quick-search-container.searchbox-bosch-shadow > div.form-and-bookmarks-container > div.quick-search-form > form > div.form-row.make-and-model-row > div:nth-child(2) > div.input-select.js-model > div.dropdown.js-dropdown.show > div.dropdown-filter.js-filter > input[type=text]"));
        private IWebElement ieskotiMygtukas => Driver.FindElement(By.CssSelector("body > div.wrapper > div.quick-search-valuation-ket > div > div.left-col > div.quick-search-container.searchbox-bosch-shadow > div.form-and-bookmarks-container > div.quick-search-form > form > div:nth-child(5) > div.form-col.form-col-2.form-buttons > button"));
        private IWebElement autoPaieskosRezultatas => Driver.FindElement(By.CssSelector("#autoplius > div.container > div.small-wrapper > div.content-wrapper > div.content > div.cntnt-box-fixed > div.search-list-header-container > div.search-list-title > h1 > span.js-search-title"));


        public AutoPaieškaPage(IWebDriver naujasDriver) : base(naujasDriver)
        {
        }


        public void IeskotiAutoMarke(string marke)
        {
            WebDriverWait laukimas = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            laukimas.Until(x => x.FindElement(By.CssSelector("body > div.wrapper > div.quick-search-valuation-ket > div > div.left-col > div.quick-search-container.searchbox-bosch-shadow > div.form-and-bookmarks-container > div.quick-search-form > form > div.form-row.make-and-model-row > div:nth-child(1) > div.input-select.js-make > div.display-input.js-placeholder > div.placeholder")).Displayed);

            autoMarke.SendKeys(marke + Keys.Enter);
        }
        public void IeskotiMarkesModeli(string modelis)
        {
            Thread.Sleep(500);
            autoModelis.SendKeys(modelis + Keys.Enter);
        }
        public void PradetiPaieska()
        {
            ieskotiMygtukas.Click();
        }
        public void AutoPaieskosTikrinimas(string paieskos_rezultatas)
        {
            Assert.AreEqual(paieskos_rezultatas, autoPaieskosRezultatas.Text, "Klaidinga paieska");
        }
    }
}
