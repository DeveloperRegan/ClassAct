using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassAct.Website.PL;
using System.Linq;
using System.Collections.Generic;

namespace ClassAct.WebSite.PL.Test
{  //Person PL Test is Complete
    [TestClass]
    public class PersonUT
    {
        [TestMethod]
        public void LoadFromDB()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            List < tblPerson > persons = (from c in oDc.tblPersons
                                          select c).ToList();

            Assert.AreEqual(3, persons.Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            //Create a new row in the table
            tblPerson otblPerson = new tblPerson();
            otblPerson.PersonDOB = DateTime.Now;
            otblPerson.PersonFirstName = "John";
            otblPerson.PersonID = Guid.NewGuid();
            otblPerson.PersonLastName = "Smith";
            otblPerson.PersonsEmail = "John.Smith@yahoo.com";
            otblPerson.PersonsPassword = "Password";
            otblPerson.PersonsUserName = "JohnSmithLovesFood";

            oDc.tblPersons.InsertOnSubmit(otblPerson);

            oDc.SubmitChanges();

            tblPerson person = (from c in oDc.tblPersons
                                where c.PersonsUserName == "JohnSmithLovesFood"
                                select c).FirstOrDefault();

            Assert.IsNotNull(person);
        }

        [TestMethod]
        public void UpdateTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            tblPerson person = (from c in oDc.tblPersons
                                where c.PersonsUserName == "JohnSmithLovesFood"
                                select c).FirstOrDefault();

            //Change values
            person.PersonsUserName = "John Smith Hates Food";

            oDc.SubmitChanges();

            tblPerson UpdatedPerson = (from c in oDc.tblPersons
                                       where c.PersonsUserName == "John Smith Hates Food"
                                     select c).FirstOrDefault();

            Assert.IsNotNull(UpdatedPerson);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            //retrive the row to delete
            tblPerson UpdatedPerson = (from c in oDc.tblPersons
                                       where c.PersonsUserName == "test3"
                                       select c).FirstOrDefault();


            oDc.tblPersons.DeleteOnSubmit(UpdatedPerson);

            oDc.SubmitChanges();

            tblPerson DeletedPerson = (from c in oDc.tblPersons
                                       where c.PersonsUserName == "test3"
                                       select c).FirstOrDefault();


            Assert.IsNull(DeletedPerson);
        }
    }
}
