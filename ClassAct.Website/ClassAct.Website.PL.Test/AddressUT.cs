using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ClassAct.Website.PL;
using System.Collections.Generic;

namespace ClassAct.WebSite.PL.Test
{
    [TestClass]
    public class AddressUT
    {
        [TestMethod]
        public void LoadFromDB()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            List<tblAddress> addresses = (from c in oDc.tblAddresses
                                             select c).ToList();
            Assert.AreEqual(88, addresses.Count);
        }

        // INSERT ADDRESS TEST
        [TestMethod]
        public void InsertTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            //Create a new row in the table
            tblAddress otblAddresses = new tblAddress();

            otblAddresses.AddressID = Guid.NewGuid();
            otblAddresses.City = "Appleton";
            otblAddresses.State = "WI";
            otblAddresses.StreetAddress = "1205 North BlueMound";
            otblAddresses.ZipCode = "54139";

            oDc.tblAddresses.InsertOnSubmit(otblAddresses);

            oDc.SubmitChanges();

            tblAddress address = (from c in oDc.tblAddresses
                                      where c.StreetAddress == "1205 North BlueMound"
                                  select c).FirstOrDefault();

            Assert.IsNotNull(address);
        }


        // UPDATE ADDRESS TEST
        //Updated the Resturant Update Terence 9/19/17
        [TestMethod]
        public void UpdateTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            tblAddress address = (from c in oDc.tblAddresses
                                  where c.StreetAddress == "1205 North BlueMound"
                                  select c).FirstOrDefault();
            //Change values
            address.StreetAddress = "1515 Mocking Bird Lane";
                

            oDc.SubmitChanges();


            tblAddress Updatedaddress = (from c in oDc.tblAddresses
                                  where c.StreetAddress == "1515 Mocking Bird Lane"
                                         select c).FirstOrDefault();

            Assert.IsNotNull(Updatedaddress);
        }

        // DELETE ADDRESS TEST
        [TestMethod]
        public void DeleteTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            //retrive the row to delete

            tblAddress Updatedaddress = (from c in oDc.tblAddresses
                                         where c.StreetAddress == "1515 Mocking Bird Lane"
                                         select c).FirstOrDefault();

            oDc.tblAddresses.DeleteOnSubmit(Updatedaddress);

            oDc.SubmitChanges();

            tblAddress DeletedAddress = (from c in oDc.tblAddresses
                                         where c.StreetAddress == "1515 Mocking Bird Lane"
                                         select c).FirstOrDefault();

            Assert.IsNull(DeletedAddress);
        }
    }
}
