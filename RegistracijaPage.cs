using System;
using Baigiamasis.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Baigiamasis
{
    class RegistracijaPage :BasePage
    {
        private IWebElement prisijungtiMygtukas => Driver.FindElement(By.CssSelector("body > div.wrapper > div.page-header > div > div > ul > li.js-global-user-menu > a.js-login-btn > span.header-label"));
        private IWebElement registruotisMygtukas => Driver.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > div.tabs > div:nth-child(3)"));
        private IWebElement vartotojoIvedimas => Driver.FindElement(By.Id("registration-username"));
        private IWebElement regPatvritinimoMygtukas => Driver.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > form.js-form-registration-lookup > div.login-button > button"));
        private IWebElement klaidosPranesimas => Driver.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > form.js-form-registration-lookup > div.error-message.js-error"));
     
        
        public RegistracijaPage(IWebDriver naujasDriver) :base(naujasDriver)
        {              
        } 
       

        public void SpaustiPrisijungti()
        {
            prisijungtiMygtukas.Click();
        }
        public void SpaustiRegistruotis()
        {
            WebDriverWait laukimas = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
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
            WebDriverWait laukimas = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            laukimas.Until(x => x.FindElement(By.CssSelector("body > div.ap-modal.ap-popup > div > div > div.ap-modal-content > div > div > form.js-form-registration-lookup > div.error-message.js-error")).Displayed);
           
            Assert.AreEqual(pranešimas, klaidosPranesimas.Text, "Klaidingas pranešimas");
        }
    }
}
