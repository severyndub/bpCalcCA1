using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumTest
{
    [TestClass]
    public class SeleniumTest2
    {
        private IWebDriver driver;
        private string appURL;

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://bpcalctest-bpcalcqa.azurewebsites.net/BloodPressure";

            driver = new ChromeDriver();
            
            
            DoSomething();



        }


        private void DoSomething()
        {
            driver.Navigate().GoToUrl(appURL);

            


        }



        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
