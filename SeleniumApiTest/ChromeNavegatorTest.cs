using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumApiTest
{
    [TestClass]
    public class ChromeNavegatorTest
    {
        private IWebDriver chrome;

        [TestInitialize]
        public void Init()
        {
            chrome = new ChromeDriver();
        }

        [TestMethod]
        public void ChromeGetAllJson_ApiTest()
        {

            var url = "http://localhost:60421/api/Alumno.json";
            chrome.Navigate().GoToUrl(url);
            var responseElement = chrome.FindElement(By.TagName("pre"));
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
        public void ChromeGetAllXml_ApiTest()
        {
            var url = "http://localhost:60421/api/Alumno.xml";
            chrome.Navigate().GoToUrl(url);
            var responseElement = chrome.FindElement(By.ClassName("pretty-print"));
            var resultXml = responseElement.Text;

            Assert.IsTrue(resultXml.Contains("Guid"));
            Assert.IsTrue(resultXml.Contains("Id"));
            Assert.IsTrue(resultXml.Contains("Dni"));
            Assert.IsTrue(resultXml.Contains("Nombre"));
            Assert.IsTrue(resultXml.Contains("Apellidos"));
            Assert.IsTrue(resultXml.Contains("Edad"));
            Assert.IsTrue(resultXml.Contains("Nacimiento"));
            Assert.IsTrue(resultXml.Contains("Registro"));


            Assert.IsTrue(resultXml.Contains("ArrayOfAlumno"));
        }

        [TestCleanup]
        public void Exit()
        {
            chrome.Quit();
        }
    }
}
