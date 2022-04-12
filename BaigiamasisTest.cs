using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Baigiamasis
{
    class BaigiamasisTest
    {
        private static IWebDriver driver;


        [SetUp]
        public static void OneTimeSetUP()
        {
            driver = new ChromeDriver();
            driver.Url = "https://autoplius.lt";
            driver.Manage().Window.Maximize();

            WebDriverWait laukimas = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            laukimas.Until(x => x.FindElement(By.Id("onetrust-accept-btn-handler")).Displayed);
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();



        }
        [TearDown]
        public static void OneTimeTearDown()
        {
           driver.Quit();
        
           if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }


      

        [TestCase("testas", "Klaidingai įvestas telefono numeris ar el.pašto adresas. Patikrinkite ir mėginkite dar kartą.", TestName = "neįvestas simbolis @")]
        [TestCase("testas@.gmail.com", "Klaidingai įvestas el.pašto adresas.", TestName = "klaidingo formato el paštas")]
        public static void Klaidingos(string vardas, string pranešimas)
        {
            RegistracijaPage page = new RegistracijaPage(driver);

            page.SpaustiPrisijungti();
            page.SpaustiRegistruotis();
            page.IvestiVartotoja(vardas);
            page.PatvirtintiRegistracija();
            page.PranesimoTikrinimas(pranešimas);        
        }

       
        [Test]
        public static void KET_BilietoSprendimas()
        {
            KETbilietasPage page = new KETbilietasPage(driver);

            page.KETpasirinkimas();
            page.BkategorijosPasirinkimas();
            page.PradetiKET_Testa();
            page.KET_testoTikrinimas();         
        }

      
        [TestCase("Honda", "Civic", "Honda Civic Automobiliai", TestName = "Auto Honda Civic paieska")]
        [TestCase("BMW", "118", "BMW 118 Automobiliai", TestName = "Auto BMW 118 paieska")]
        [TestCase("Audi", "", "Audi Naudoti automobiliai", TestName = "Visu Audi auto modeliu paieska")]
        public static void Automobilio_Paieška(string marke, string modelis, string paieskos_rezultatas)
        {
            AutoPaieškaPage page = new AutoPaieškaPage(driver);

            page.IeskotiAutoMarke(marke);
            page.IeskotiMarkesModeli(modelis);
            page.PradetiPaieska();
            page.AutoPaieskosTikrinimas(paieskos_rezultatas);
    
        }
      
        [Test]
        public static void IdetiSkelbima()
        {
            IdetiSkelbimaPage page = new IdetiSkelbimaPage(driver);

            page.SpaustiIdetiSkelbima();
            page.PasirinktiPadangasRatlankius();
            page.PasirinktiPadangas();
            page.PasirinktiSpecTechPadangas();
            page.TikrintiSkelbimoForma();
           
        }
    }
}
