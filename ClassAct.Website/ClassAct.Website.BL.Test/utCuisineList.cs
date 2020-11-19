using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassAct.Website.BL.Test
{
    [TestClass]
    public class utCuisineList
    {
        [TestMethod]
        public void LoadfromDB()
        {
            CCuisineList oCuisineList = new CCuisineList();
            oCuisineList.load();

            Assert.AreNotEqual(oCuisineList.Count, 0);
        }
    }
}
