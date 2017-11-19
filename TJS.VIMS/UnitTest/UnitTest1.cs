using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                List<Country> list = context.Countries.ToList();
                Assert.IsNotNull(context);
                Assert.IsNotNull(list);
            }
        }
    }
}
