using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;
using System.Collections.Generic;
using System.Linq;
using TJS.VIMS.Controllers;

namespace UnitTest
{
    [TestClass]
    public class AdministrationControllerTest
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

        public void CreateDeleteUndoOrganization()
        {
            AdministrationController controller = new AdministrationController();
            // todo
        }

    }
}
