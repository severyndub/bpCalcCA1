using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;
using System.Linq;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLowPressure()
        {
            // Test Low pressure combination
            var testSystolicPressure = Enumerable.Range(70, 20);
            var testDiastolicPressure = Enumerable.Range(40, 20);
            foreach (int systolicUnit in testSystolicPressure)
            {
                foreach (int diastolicUnit in testDiastolicPressure)
                {
                    BloodPressure Bp = new BloodPressure() { Systolic = systolicUnit, Diastolic = diastolicUnit };
                    Assert.AreEqual(BPCategory.Low, Bp.Category);
                }
                
            }
        }
        [TestMethod]
        public void TestNormalPressure()
        {
            // Test Normal pressure combination
            var testSystolicPressure = Enumerable.Range(90, 30);
            var testDiastolicPressure = Enumerable.Range(60, 20);
            foreach (int systolicUnit in testSystolicPressure)
            {
                foreach (int diastolicUnit in testDiastolicPressure)
                {
                    BloodPressure Bp = new BloodPressure() { Systolic = systolicUnit, Diastolic = diastolicUnit };
                    Assert.AreEqual(BPCategory.Normal, Bp.Category);
                }

            }
        }
        [TestMethod]
        public void TestPreHighPressure()
        {
            // Test Normal pressure combination
            var testSystolicPressure = Enumerable.Range(120, 20);
            var testDiastolicPressure = Enumerable.Range(80, 10);
            foreach (int systolicUnit in testSystolicPressure)
            {
                foreach (int diastolicUnit in testDiastolicPressure)
                {
                    BloodPressure Bp = new BloodPressure() { Systolic = systolicUnit, Diastolic = diastolicUnit };
                    Assert.AreEqual(BPCategory.PreHigh, Bp.Category);
                }

            }
        }
        [TestMethod]
        public void TestHighPressure()
        {
            // Test Normal pressure combination
            var testSystolicPressure = Enumerable.Range(140, 50);
            var testDiastolicPressure = Enumerable.Range(90, 10);
            foreach (int systolicUnit in testSystolicPressure)
            {
                foreach (int diastolicUnit in testDiastolicPressure)
                {
                    BloodPressure Bp = new BloodPressure() { Systolic = systolicUnit, Diastolic = diastolicUnit };
                    Assert.AreEqual(BPCategory.High, Bp.Category);
                }

            }
        }
        [TestMethod]
        public void TestAbnormalPressure1()
        {
            // Test Normal pressure combination
            var testSystolicPressure = Enumerable.Range(0, 70);
            var testDiastolicPressure = Enumerable.Range(0, 40);
            foreach (int systolicUnit in testSystolicPressure)
            {
                foreach (int diastolicUnit in testDiastolicPressure)
                {
                    BloodPressure Bp = new BloodPressure() { Systolic = systolicUnit, Diastolic = diastolicUnit };
                    Assert.AreEqual(BPCategory.Abnormal, Bp.Category);
                }

            }
        }
        [TestMethod]
        public void TestAbnormalPressure2()
        {
            // Test Normal pressure combination
            var testSystolicPressure = Enumerable.Range(191, 10);
            var testDiastolicPressure = Enumerable.Range(101, 10);
            foreach (int systolicUnit in testSystolicPressure)
            {
                foreach (int diastolicUnit in testDiastolicPressure)
                {
                    BloodPressure Bp = new BloodPressure() { Systolic = systolicUnit, Diastolic = diastolicUnit };
                    Assert.AreEqual(BPCategory.Abnormal, Bp.Category);
                }

            }
        }
    }
}
