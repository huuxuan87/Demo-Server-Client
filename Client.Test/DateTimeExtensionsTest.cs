using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Client.Extensions;

namespace Client.Test
{
    [TestClass]
    public class DateTimeExtensionsTest
    {
        [TestMethod]
        public void GetValueEx_To_Ok()
        {
            DateTime? dtNull = null;
            var dtNullEx = dtNull.GetValueEx();
            Assert.AreEqual(dtNullEx, DateTime.Now);

            DateTime? dt = new DateTime(2023, 12, 14);
            var dtEx = dt.GetValueEx();
            Assert.AreEqual(dt, dtEx);
        }
    }
}
