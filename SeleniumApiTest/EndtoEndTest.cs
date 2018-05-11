using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumApiTest
{
    [TestClass]
    public class EndtoEndTest
    {
        private IWebDriver chrome;
        private IWebDriver firefox;

        [TestInitialize]
        public void Init()
        {
            chrome = new ChromeDriver();
            firefox = new FirefoxDriver();
        }

        [TestMethod]
        public void EndToEndTest()
        {

            chrome.Url = "http://localhost:60421/api/Alumno.json";
            firefox.Url = "http://localhost:60421/api/Alumno.json";
        }


        [TestCleanup]
        public void Exit()
        {
            //firefox.Quit();
            //chrome.Quit();
        }
    }
}
