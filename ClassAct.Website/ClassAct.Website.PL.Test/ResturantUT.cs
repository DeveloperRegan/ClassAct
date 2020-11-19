using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassAct.Website.PL;
using System.Linq;
using System.Collections.Generic;

namespace ClassAct.WebSite.PL.Test
{
    [TestClass]
    public class ResturantUT
    {
        [TestMethod]
        public void LoadFromDB()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            List<tblResturant> resturants = (from c in oDc.tblResturants
                                       select c).ToList();
            Assert.AreEqual(88, resturants.Count);
        }

        // INSERT RESTURANT TEST
        [TestMethod]
        public void InsertTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            //Create a new row in the table
            tblResturant otblResturant = new tblResturant();

            otblResturant.ResturantID = Guid.NewGuid();
            //Fixed the AddressID context
            otblResturant.AddressID = Guid.NewGuid();
            otblResturant.ResturantName = "Burger King";
            otblResturant.ResturantImagePath = "";
           

            oDc.tblResturants.InsertOnSubmit(otblResturant);

            oDc.SubmitChanges();

            tblResturant resturant = (from c in oDc.tblResturants
                                   where c.ResturantName == "Burger King"
                                   select c).FirstOrDefault();

            Assert.IsNotNull(resturant);
        }

        
        // UPDATE RESTURANT TEST
        //Updated the Resturant Update Terence 9/19/17
        [TestMethod]
        public void UpdateTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            tblResturant resturant = (from c in oDc.tblResturants
                                where c.ResturantName == "Burger King"
                                      select c).FirstOrDefault();

            //Change values
            resturant.ResturantName = "McDonalds";

            oDc.SubmitChanges();

            tblResturant UpdatedResturant = (from c in oDc.tblResturants
                                            where c.ResturantName == "McDonalds"
                                             select c).FirstOrDefault();

            Assert.IsNotNull(UpdatedResturant);
        }

        // DELETE RESTURANT TEST
        [TestMethod]
        public void DeleteTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            //retrive the row to delete

            tblResturant UpdatedResturant = (from c in oDc.tblResturants
                                             where c.ResturantName == "McDonalds"
                                             select c).FirstOrDefault();

            oDc.tblResturants.DeleteOnSubmit(UpdatedResturant);

            oDc.SubmitChanges();

            tblResturant DeletedResturant = (from c in oDc.tblResturants
                                             where c.ResturantName == "McDonalds"
                                             select c).FirstOrDefault();

            Assert.IsNull(DeletedResturant);
        }

        // stored proc load by cuisine type and location test Adam Rodewald 10/24/17
        [TestMethod]
        public void LoadByCuisineLocationTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            var results = oDc.spLoadRestaurantsByCuisineLocation("Pizza", "Appleton", "WI").ToList();

            Assert.AreEqual(4, results.Count);

        }

    }
}
