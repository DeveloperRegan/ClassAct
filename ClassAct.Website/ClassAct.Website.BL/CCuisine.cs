using ClassAct.Website.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.Website.BL
{
   public class CCuisine
    {
        public Guid CuisineID { get; set; }
        [DisplayName("Type of food you want")]
        public string Description { get; set; }
        //public Double Rating { get; set; }

        public CCuisine() { }

        public CCuisine(string _Description)
        {
            CuisineID = Guid.NewGuid();
            Description = _Description;
            //Rating = _Rating;
        }

        public void AddCuisineToDB()
        {
            try
            {

                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var loadTest = oDc.spDoesCuisineExist(Description).ToList();
                if (loadTest.Count == 0)
                {
                    oDc.spAddCuisineToCuisineTable(Description);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AddCuisineToDB(string Description)
        {
            CCuisine oCuisine = new CCuisine(Description);
            AddCuisineToDB();
        }
        
    }

    public class CCuisineList : List<CCuisine>
    {
        public void load()
        {

            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var rows = (from f in oDc.tblCuisines
                            orderby f.CuisineDescription
                            select f).ToList();
                foreach (var f in rows)
                {
                    //CPerson person = new CPerson(string _email, string _UserName, string _Password, string _FirstName, string _LastName, DateTime _DOB);
                    CCuisine oF = new CCuisine();
                    oF.CuisineID = f.CuisineID;
                    oF.Description = f.CuisineDescription;
                    Add(oF);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadUserCruisinebyUserID(Guid UserID)
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var rows = (from fup in oDc.tblPersonCuisines
                            join f in oDc.tblCuisines on fup.CuisineID equals f.CuisineID
                            where fup.PersonID == UserID
                            select fup).ToList();
                foreach (var f in rows)
                {
                    //CPerson person = new CPerson(string _email, string _UserName, string _Password, string _FirstName, string _LastName, DateTime _DOB);
                    CCuisine oF = new CCuisine();
                    oF.CuisineID = f.CuisineID;
                    oF.Description = f.tblCuisine.CuisineDescription;
                    //oF.Rating = (double)f.Rating;

                    Add(oF);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCuisineListByResturantID(Guid _ResturantID)
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var rows = (from fup in oDc.tblCuisineResturants
                            join f in oDc.tblCuisines on fup.CuisineID equals f.CuisineID
                            where fup.ResturantID == _ResturantID
                            select fup).ToList();
                foreach (var f in rows)
                {
                    //CPerson person = new CPerson(string _email, string _UserName, string _Password, string _FirstName, string _LastName, DateTime _DOB);
                    CCuisine oF = new CCuisine();
                    oF.CuisineID = f.CuisineID;
                    oF.Description = f.tblCuisine.CuisineDescription;
                    //oF.Rating = (double)f.Rating;

                    Add(oF);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}