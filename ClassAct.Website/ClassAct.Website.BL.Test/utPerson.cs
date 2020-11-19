using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ClassAct.Website.PL;
using System.Collections.Generic;

namespace ClassAct.Website.BL.Test
{
    [TestClass]
    public class utPerson
    {
        [TestMethod]
        public void AddUsertoDB()
        {

            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            List<tblPerson> personsAlpha = (from c in oDc.tblPersons
                                            select c).ToList();

            CPerson person = new CPerson();
            person.DOB = DateTime.Now;
            person.Email = "test@test.com";
            person.FirstName = "Test";
            person.LastName = "Test";
            person.Password = "test";
            person.UserName = "test";

            person.InsertUser();


            List<tblPerson> personsBeta = (from c in oDc.tblPersons
                                           select c).ToList();

            Assert.AreEqual(personsAlpha.Count + 1, personsBeta.Count);



        }

        // DELETE PERSON - Thai Thao 10/4/17
        // What are you testing?  Why are there no asserts?
        [TestMethod]
        public void DeletePersonTest()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            tblPerson otblPerson = (from p in oDc.tblPersons
                                    where p.PersonsUserName == "test"
                                    select p).FirstOrDefault();
            oDc.SubmitChanges();
            //if (otblPerson != null)
            //{
            //    oDc.tblPerson.DeleteOnSubmit(otblPerson);
            //    oDc.SubmitChanges();
            //    tblPerson DeletePerson = (from p in oDc.tblPerson
            //                        where p.PersonsUserName == "test"
            //                        select p).FirstOrDefault();
            //    Assert.IsNull(DeletePerson);
            //}
            //else
            //{
            //    Assert.Fail("User Exist.");
            //}
        }
    }
}
