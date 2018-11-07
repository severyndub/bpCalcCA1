using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SelenuimTest
{
    [TestClass]
    public class SeleniumTest1
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public SeleniumTest1()
        { }

        [TestMethod]
        [TestCategory("Firefox")]
        public void PreHighTest()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            //Clear the input fields
            driver.FindElement(By.Id("BP_Systolic")).Clear();
            //insert some test data
            driver.FindElement(By.Id("BP_Systolic")).SendKeys("120");
            driver.FindElement(By.Id("BP_Diastolic")).Clear();
            driver.FindElement(By.Id("BP_Diastolic")).SendKeys("80");
            string resultText = driver.FindElement(By.Id("bpCategoryResult")).Text;           
            Assert.IsTrue(resultText.Equals("Pre-High Blood Pressure"));
            //Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://bpcalctest.azurewebsites.net/BloodPressure";
            //appURL = "http://localhost:40328/bloodpressure";
            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
