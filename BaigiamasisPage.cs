using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Baigiamasis
{
    public class BaigiamasisPage
    {
        private static IWebDriver driver;

        private IWebElement prisijungtiMygtukas => driver.FindElement(By.CssSelector("body > div.wrapper > div.page-header > div > div > ul > li.js-global-user-menu > a.js-login-btn > span.header-label"));
        private IWebElement registruotisMygtukas => driver.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > div.tabs > div:nth-child(3)"));
        private IWebElement vartotojoIvedimas => driver.FindElement(By.Id("registration-username"));
        private IWebElement regPatvritinimoMygtukas => driver.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > form.js-form-registration-lookup > div.login-button > button"));
        private IWebElement klaidosPranesimas => driver.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > form.js-form-registration-lookup > div.error-message.js-error"));
        private IWebElement ketMygtukas => driver.FindElement(By.CssSelector("body > div.wrapper > div.page-header > nav > div > ul.navigation-items > li.upper > a"));
        private IWebElement bKategorijosPasirinkimas => driver.FindElement(By.CssSelector("body > div.container > div.small-wrapper > div.content-wrapper > div.col_2_full > div.ket-form-content.ket-start-form > div > form > div.border.panel-light.fast-search-content > div > div.ket-start-category > a.ket-category.bcategory"));
        private IWebElement baigtiTestaMygtukas => driver.FindElement(By.CssSelector("#test_form > div.rel.fr.ket-navbar.navbart-bot > span.fr.ket-button.ket-button-grey.ket-button-larger.ket-button-inactive"));
        private IWebElement sprestiTestaMygtukas => driver.FindElement(By.CssSelector("body > div.container > div.small-wrapper > div.content-wrapper > div.col_2_full > div.ket-form-content.ket-start-form > div > form > div.border.panel-light.fast-search-content > div > div.ket-form-button > a.submit-link.submit-red.fr > strong > span"));
        private IWebElement autoMarke => driver.FindElement(By.CssSelector("body > div.wrapper > div.quick-search-valuation-ket > div > div.left-col > div.quick-search-container.searchbox-bosch-shadow > div.form-and-bookmarks-container > div.quick-search-form > form > div.form-row.make-and-model-row > div:nth-child(1) > div.input-select.js-make > div.display-input.js-placeholder"));
        private IWebElement autoModelis => driver.FindElement(By.CssSelector("body > div.wrapper > div.quick-search-valuation-ket > div > div.left-col > div.quick-search-container.searchbox-bosch-shadow > div.form-and-bookmarks-container > div.quick-search-form > form > div.form-row.make-and-model-row > div:nth-child(2) > div.input-select.js-model > div.dropdown.js-dropdown.show > div.dropdown-filter.js-filter > input[type=text]"));
        private IWebElement ieskotiMygtukas => driver.FindElement(By.CssSelector("body > div.wrapper > div.quick-search-valuation-ket > div > div.left-col > div.quick-search-container.searchbox-bosch-shadow > div.form-and-bookmarks-container > div.quick-search-form > form > div:nth-child(5) > div.form-col.form-col-2.form-buttons > button"));
        private IWebElement AutoPaieskosRezultatas => driver.FindElement(By.CssSelector("#autoplius > div.container > div.small-wrapper > div.content-wrapper > div.content > div.cntnt-box-fixed > div.search-list-header-container > div.search-list-title > h1 > span.js-search-title"));
        private IWebElement idetiSkelbimaMygtukas => driver.FindElement(By.CssSelector("body > div.wrapper > div.page-header > div > div > ul > li.js-global-user-menu > a.create-ann-btn.top"));
        private IWebElement padangosRatlankiaiMygtukas => driver.FindElement(By.CssSelector("#category-tree-0 > li:nth-child(6) > span"));
        private IWebElement padangosMygtukas => driver.FindElement(By.CssSelector("#category-tree-45 > li:nth-child(1) > span"));
        private IWebElement specTechnikosPadangos => driver.FindElement(By.CssSelector("#category-tree-46 > li:nth-child(6) > a"));
        private IWebElement padangosSkelbimoTikrinimas => driver.FindElement(By.CssSelector("#main_form > div.panel-grey.padd-textbox.panel-form.fix-box.box-first.rel > fieldset:nth-child(13) > label > strong"));
        


        public BaigiamasisPage(IWebDriver naujasDriver)
        {
            driver = naujasDriver;
        }


        public void SpaustiPrisijungti()
        {
            prisijungtiMygtukas.Click();
        }
        public void SpaustiRegistruotis()
        {
            WebDriverWait laukimas = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            laukimas.Until(x => x.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > div.tabs > div:nth-child(3)")).Displayed);
            registruotisMygtukas.Click();
        }
        public void IvestiVartotoja(string vardas)
        {
            vartotojoIvedimas.Clear();
            vartotojoIvedimas.SendKeys(vardas);
        }
        public void PatvirtintiRegistracija()
        {
            regPatvritinimoMygtukas.Click();
        }
        public void PranesimoTikrinimas(string pranešimas)
        {
            WebDriverWait laukimas = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            laukimas.Until(x => x.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > form.js-form-registration-lookup > div.error-message.js-error")).Displayed);
            Assert.AreEqual(pranešimas, klaidosPranesimas.Text, "Klaidingas pranešimas");
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
            WebDriverWait laukimas = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            laukimas.Until(x => x.FindElement(By.CssSelector("#test_form > div.rel.fr.ket-navbar.navbart-bot > span.fr.ket-button.ket-button-grey.ket-button-larger.ket-button-inactive")).Displayed);
            Assert.AreEqual("Baigti testą", baigtiTestaMygtukas.Text, "KET testas neatsidarė");
        }


        public void IeskotiAutoMarke(string marke)
        {
            WebDriverWait laukimas = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

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
            Assert.AreEqual(paieskos_rezultatas, AutoPaieskosRezultatas.Text, "Klaidinga paieska");
        }

        public void SpaustiIdetiSkelbima()
        {
            idetiSkelbimaMygtukas.Click();
        }
        public void PasirinktiPadangasRatlankius()
        {
            padangosRatlankiaiMygtukas.Click();
        }
        public void PasirinktiPadangas()
        {
            padangosMygtukas.Click();
        }
        public void PasirinktiSpecTechPadangas()
        {
            specTechnikosPadangos.Click();
        }
        public void TikrintiSkelbimoForma()
        {
            Assert.AreEqual("Padangos konstrukcija", padangosSkelbimoTikrinimas.Text, "Netinkama forma");
        }
      
       
        
     











    }
}
