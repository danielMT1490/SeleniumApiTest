using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumApiTest
{
    [TestClass]
    public class FireFoxNavegatorTest
    {
        private IWebDriver firefox;

        [TestInitialize]
        public void Init()
        {

            firefox = new FirefoxDriver();
        }

        [TestMethod]
        public void FireFoxGetAllJson_ApiTest()
        {
            var url = "http://localhost:60421/api/Alumno.json";

            firefox.Navigate().GoToUrl(url);
            firefox.FindElement(By.Id("tab-1")).Click();
            var responseElement = firefox.FindElement(By.TagName("pre"));
            var resultJson = responseElement.Text;

            Assert.IsTrue(resultJson.Contains("guid"));
            Assert.IsTrue(resultJson.Contains("id"));
            Assert.IsTrue(resultJson.Contains("dni"));
            Assert.IsTrue(resultJson.Contains("nombre"));
            Assert.IsTrue(resultJson.Contains("apellidos"));
            Assert.IsTrue(resultJson.Contains("edad"));
            Assert.IsTrue(resultJson.Contains("nacimiento"));
            Assert.IsTrue(resultJson.Contains("registro"));


            Assert.IsTrue(resultJson.Split('{').Length > 2);
        }

        [TestMethod]
        public void FireFoxGetAllXml_ApiTest()
        {
            var url = "http://localhost:60421/api/Alumno.xml";

            firefox.Navigate().GoToUrl(url);
            var responseElement = firefox.FindElement(By.TagName("Alumno")).Text;
            //var resultXml = responseElement.Text;
            
            Assert.IsTrue(firefox.FindElement(By.TagName("Guid")).Text!=null);
            Assert.IsTrue(firefox.FindElement(By.TagName("Id")).Text != null);
            Assert.IsTrue(firefox.FindElement(By.TagName("Dni")).Text != null);
            Assert.IsTrue(firefox.FindElement(By.TagName("Nombre")).Text != null);
            Assert.IsTrue(firefox.FindElement(By.TagName("Apellidos")).Text != null);
            Assert.IsTrue(firefox.FindElement(By.TagName("Edad")).Text != null);
            Assert.IsTrue(firefox.FindElement(By.TagName("Nacimiento")).Text != null);
            Assert.IsTrue(firefox.FindElement(By.TagName("Registro")).Text != null);


            Assert.IsTrue(firefox.FindElements(By.TagName("Alumno")).Count> 1);
        }

        [TestCleanup]
        public void Exit()
        {
            firefox.Quit();
        }
    }
}
