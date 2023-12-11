using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Client.Extensions;

namespace Client.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void ToStringEx_To_Empty()
        {
            string strNull = null;
            var strNullEx = strNull.ToStringEx();
            Assert.IsTrue(strNullEx == string.Empty);
        }

        [TestMethod]
        public void TrimEx_To_Test()
        {
            string str = "   test   ";
            var strTrimeEx = str.TrimEx();
            Assert.AreEqual("test", strTrimeEx);
        }

        [TestMethod]
        public void GetOnlyNumbers_To_1234567890()
        {
            string str = "   test1a23456b789c0   ";
            var strRs = str.GetOnlyNumbers();
            Assert.AreEqual("1234567890", strRs);
        }

        [TestMethod]
        public void IsFullNameValid_To_True()
        {
            string str = "Firstname And Lastname";
            var strRs = str.IsFullNameValid();
            Assert.AreEqual(true, strRs);
        }

        [TestMethod]
        public void GetLastName_To_Lastname()
        {
            string str = "Firstname And Lastname";
            var strRs = str.GetLastName();
            Assert.AreEqual("Lastname", strRs);
        }

        [TestMethod]
        public void GetFirstName_To_Firstname()
        {
            string str = "Firstname And Lastname";
            var strRs = str.GetFirstName();
            Assert.AreEqual("Firstname And", strRs);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @".\Data\SoDienThoai.xml", "Row", DataAccessMethod.Sequential)]
        public void IsPhoneNumberValid()
        {
            string soDienThoai = TestContext.DataRow["SoDienThoai"].ToStringEx();
            bool expected = bool.Parse(TestContext.DataRow["Expected"].ToStringEx());
            var result = soDienThoai.IsPhoneNumberValid();
            Assert.AreEqual(expected, result, "Số điện thoại: " + soDienThoai);
        }
    }
}
