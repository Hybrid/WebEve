using WebEve;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace WebEve.Tests
{
    
    
    /// <summary>
    ///This is a test class for UtilsTest and is intended
    ///to contain all UtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtilsTest
    {


        private TestContext testContextInstance;

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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ReprocessTax
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ReprocessPerfect()
        {
            int quantity = 530; 
            int refiningLevel = 5; 
            int refineryEfficiencyLevel = 5;
            int scrapProcessingLevel = 2; 
            double standing = 9; 
            int expected = 530; 
            int actual;
            actual = Utils.ReprocessTax(quantity, refiningLevel, refineryEfficiencyLevel, scrapProcessingLevel, standing);
            Assert.AreEqual(expected, actual);

            standing = 0;
            expected = 504;
            actual = Utils.ReprocessTax(quantity, refiningLevel, refineryEfficiencyLevel, scrapProcessingLevel, standing);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ReprocessStanding()
        {
            int quantity = 530; 
            int refiningLevel = 5; 
            int refineryEfficiencyLevel = 5; 
            int scrapProcessingLevel = 2; 
            double standing = 0; 
            int expected = 504; 
            int actual;
            actual = Utils.ReprocessTax(quantity, refiningLevel, refineryEfficiencyLevel, scrapProcessingLevel, standing);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ReprocessSkill()
        {
            int quantity = 530; 
            int refiningLevel = 5; 
            int refineryEfficiencyLevel = 3; 
            int scrapProcessingLevel = 0; 
            double standing = 9; 
            int expected = 510; 
            int actual;
            actual = Utils.ReprocessTax(quantity, refiningLevel, refineryEfficiencyLevel, scrapProcessingLevel, standing);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ReprocessSkill2()
        {
            int quantity = 530;
            int refiningLevel = 5;
            int refineryEfficiencyLevel = 4;
            int scrapProcessingLevel = 0;
            double standing = 9;
            int expected = 519;
            int actual;
            actual = Utils.ReprocessTax(quantity, refiningLevel, refineryEfficiencyLevel, scrapProcessingLevel, standing);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SaleTax()
        {
            double value = 14033;
            int accountingLevel = 4;
            double expected = 84.20; ; 
            double actual;
            actual = double.Parse(String.Format("{0:0.00}", value * Utils.SaleTax(accountingLevel)));
            Assert.AreEqual(expected, actual);
        }
    }
}
