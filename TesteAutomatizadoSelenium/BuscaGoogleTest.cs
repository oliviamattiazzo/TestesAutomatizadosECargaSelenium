using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace TesteAutomatizadoSelenium
{
    [TestClass]
    public class BuscaGoogleTest
    {
        IWebDriver _driver;
        WebDriverWait _espera;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new InternetExplorerDriver(ConfigurationManager.AppSettings["URLDriverIE"]);
            _espera = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URLBuscaGoogleTest"]);
        }

        [TestMethod]
        public void BuscarSeleniuWebDriver_PrimeiroResultadoEnderecoSiteSelenium()
        {
            IWebElement caixaPesquisaGoogle = _driver.FindElement(By.XPath("//input[@title='Pesquisar']"));
            caixaPesquisaGoogle.SendKeys("Selenium WebDriver");

            IWebElement btnPesquisaGoogle = _driver.FindElement(By.XPath("//input[@name='btnK']"));
            btnPesquisaGoogle.SendKeys(Keys.Enter);

            IWebElement primeiroResultado = _espera.Until(ExpectedConditions.ElementExists(By.ClassName("rc")));

            Assert.IsNotNull(primeiroResultado.FindElement(By.ClassName("r")).FindElement(By.XPath("//a[@href='https://www.selenium.dev/projects/']")));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
