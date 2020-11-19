using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassAct.Website.PL;
using System.Collections.Generic;
using System.Linq;

namespace ClassAct.WebSite.PL.Test
{
    [TestClass]
    public class CuisineUT
    {
        [TestMethod]
        public void LoadFromDB()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            List<tblCuisine> cuisines = (from c in oDc.tblCuisines select c).ToList();

            Assert.AreEqual(127, cuisines.Count);
        }

        // INSERT ADDRESS TEST
        [TestMethod]
        public void InsertTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            //Create a new row in the table
            tblCuisine otblCuisine = new tblCuisine();

            otblCuisine.CuisineID = Guid.NewGuid();
            otblCuisine.CuisineDescription = "Yummy";
     

            oDc.tblCuisines.InsertOnSubmit(otblCuisine);

            oDc.SubmitChanges();

            tblCuisine cuisine = (from c in oDc.tblCuisines
                                  where c.CuisineDescription == "Yummy"
                                  select c).FirstOrDefault();

            Assert.IsNotNull(cuisine);
        }


        // UPDATE ADDRESS TEST
        //Updated the Resturant Update Terence 9/19/17
        [TestMethod]
        public void UpdateTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            tblCuisine cuisine = (from c in oDc.tblCuisines
                                  where c.CuisineDescription == "Yummy"
                                  select c).FirstOrDefault();
            //Change values
            cuisine.CuisineDescription = "Tasty";


            oDc.SubmitChanges();


            tblCuisine Updatedaddress = (from c in oDc.tblCuisines
                                         where c.CuisineDescription == "Tasty"
                                         select c).FirstOrDefault();

            Assert.IsNotNull(Updatedaddress);
        }

        // DELETE ADDRESS TEST
        [TestMethod]
        public void DeleteTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            //retrive the row to delete

            tblCuisine updateCuisine = (from c in oDc.tblCuisines
                                         where c.CuisineDescription == "Tasty"
                                         select c).FirstOrDefault();

            oDc.tblCuisines.DeleteOnSubmit(updateCuisine);

            oDc.SubmitChanges();

            tblCuisine DeletedAddress = (from c in oDc.tblCuisines
                                         where c.CuisineDescription == "Tasty"
                                         select c).FirstOrDefault();

            Assert.IsNull(DeletedAddress);
        }
    }
}

