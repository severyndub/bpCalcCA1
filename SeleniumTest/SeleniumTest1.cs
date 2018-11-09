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
    public class SeleniumTest1
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public SeleniumTest1()
        { }

        [TestMethod]
        [TestCategory("Chrome")]
        public void HighPressureTest()
        {
            //ChromeOptions test = new ChromeOptions();
            //test.AddArgument("no - sandbox");
            driver.Navigate().GoToUrl(appURL + "/BloodPressure");
            //Clear the input fields
            driver.FindElement(By.Id("BP_Systolic")).Clear();
            //insert some test data
            driver.FindElement(By.Id("BP_Systolic")).SendKeys(systolicHigh);
            driver.FindElement(By.Id("BP_Diastolic")).Clear();
            driver.FindElement(By.Id("BP_Diastolic")).SendKeys(diastolicHigh);
            driver.FindElement(By.Id("BP_Systolic")).Click();
            string resultText = driver.FindElement(By.Id("bpCategoryResult")).Text;
            Assert.IsTrue(resultText.Equals("High Blood Pressure"));
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void PreHighTest()
        {
            //ChromeOptions test = new ChromeOptions();
            //test.AddArgument("no - sandbox");
            driver.Navigate().GoToUrl(appURL + "/BloodPressure");
            //Clear the input fields
            driver.FindElement(By.Id("BP_Systolic")).Clear();
            //insert some test data
            driver.FindElement(By.Id("BP_Systolic")).SendKeys(systolicPreHigh);
            driver.FindElement(By.Id("BP_Diastolic")).Clear();
            driver.FindElement(By.Id("BP_Diastolic")).SendKeys(diastolicPreHigh);
            driver.FindElement(By.Id("BP_Systolic")).Click();
            string resultText = driver.FindElement(By.Id("bpCategoryResult")).Text;           
            Assert.IsTrue(resultText.Equals("Pre-High Blood Pressure"));
            
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void NormalPressureTest()
        {
            ChromeOptions test = new ChromeOptions();
            //test.AddArgument("no - sandbox");
            //driver.Navigate().GoToUrl(appURL + "/BloodPressure");
            //Clear the input fields
            driver.FindElement(By.Id("BP_Systolic")).Clear();
            //insert some test data
            driver.FindElement(By.Id("BP_Systolic")).SendKeys(systolicNormal);
            driver.FindElement(By.Id("BP_Diastolic")).Clear();
            driver.FindElement(By.Id("BP_Diastolic")).SendKeys(diastolicNormal);
            driver.FindElement(By.Id("BP_Systolic")).Click();
            string resultText = driver.FindElement(By.Id("bpCategoryResult")).Text;
            Assert.IsTrue(resultText.Equals("Normal Blood Pressure"));
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void LowPressureTest()
        {
            ChromeOptions test = new ChromeOptions();
            //test.AddArgument("no - sandbox");
            //driver.Navigate().GoToUrl(appURL + "/BloodPressure");
            //Clear the input fields
            driver.FindElement(By.Id("BP_Systolic")).Clear();
            //insert some test data
            driver.FindElement(By.Id("BP_Systolic")).SendKeys(systolicLow);
            driver.FindElement(By.Id("BP_Diastolic")).Clear();
            driver.FindElement(By.Id("BP_Diastolic")).SendKeys(diastolicLow);
            driver.FindElement(By.Id("BP_Systolic")).Click();
            string resultText = driver.FindElement(By.Id("bpCategoryResult")).Text;
            Assert.IsTrue(resultText.Equals("Low Blood Pressure"));
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
            appURL = "https://bpcalctest-bpcalcqa.azurewebsites.net/";
            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));                  
                    break;
                case "Firefox":
                    driver = new FirefoxDriver(Environment.GetEnvironmentVariable("GeckoWebDriver"));
                    break;
                case "IE":
                    driver = new InternetExplorerDriver(Environment.GetEnvironmentVariable("IEWebDriver"));
                    break;
                default:
                    driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        //High pressure test parametrs
        private const String systolicHigh = "160";
        private const String diastolicHigh = "100";

        // Pre High pressure test parameters
        private const String systolicPreHigh = "120";
        private const String diastolicPreHigh = "80";

        //Normal pressure test parametrs
        private const String systolicNormal = "100";
        private const String diastolicNormal = "80";

        //Normal pressure test parametrs
        private const String systolicLow = "80";
        private const String diastolicLow = "60";
    }
}
