using Baigiamasis.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Baigiamasis
{
    class IdetiSkelbimaPage :BasePage
    {        
        private IWebElement idetiSkelbimaMygtukas => Driver.FindElement(By.CssSelector("body > div.wrapper > div.page-header > div > div > ul > li.js-global-user-menu > a.create-ann-btn.top"));
        private IWebElement padangosRatlankiaiMygtukas => Driver.FindElement(By.CssSelector("#category-tree-0 > li:nth-child(6) > span"));
        private IWebElement padangosMygtukas => Driver.FindElement(By.CssSelector("#category-tree-45 > li:nth-child(1) > span"));
        private IWebElement specTechnikosPadangos => Driver.FindElement(By.CssSelector("#category-tree-46 > li:nth-child(6) > a"));
        private IWebElement padangosSkelbimoTikrinimas => Driver.FindElement(By.CssSelector("#main_form > div.panel-grey.padd-textbox.panel-form.fix-box.box-first.rel > fieldset:nth-child(13) > label > strong"));


        public IdetiSkelbimaPage(IWebDriver naujasDriver) : base(naujasDriver)
        {
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
