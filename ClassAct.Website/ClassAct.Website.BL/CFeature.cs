using ClassAct.Website.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.Website.BL
{
    public class CFeature
    {
        // Thai Thao 9/19/17
        public Guid FeatureID { get; set; }
        public string FeatureDescription { get; set; }
        public int Rating { get; set; }

        public void AddFeatureToDB()
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
              var LoadTest =  oDc.spDoesFeatureExist(FeatureDescription).ToList();

                if (LoadTest.Count == 0)
                {
                    oDc.spAddFeaturetoFeatureTable(FeatureDescription);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AddFeatureToDB(string Description)
        {
            FeatureDescription = Description;
            AddFeatureToDB();
        }
    }

    public class CFeatureList : List<CFeature>
    {

        public void LoadUserFeaturebyUserID(Guid UserID)
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var rows = (from fup in oDc.tblPersonFeaturePreferences
                            join f in oDc.tblFeatures on fup.FeatureID equals f.FeatureID
                            where fup.PersonID == UserID
                            select fup).ToList();
                foreach (var f in rows)
                {
                    //CPerson person = new CPerson(string _email, string _UserName, string _Password, string _FirstName, string _LastName, DateTime _DOB);
                    CFeature oF = new CFeature();
                    oF.FeatureID = f.FeatureID;
                    oF.FeatureDescription = f.tblFeature.FeatureDescription;
                    oF.Rating = Convert.ToInt32(f.Rating);
                      
                    Add(oF);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadFeatureListByResturantID(Guid _ResturantID)
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var rows = (from fup in oDc.tblResturantFeatures
                            join f in oDc.tblFeatures on fup.FeatureID equals f.FeatureID
                            where fup.ResturantID == _ResturantID
                            select fup).ToList();
                foreach (var f in rows)
                {
                    //CPerson person = new CPerson(string _email, string _UserName, string _Password, string _FirstName, string _LastName, DateTime _DOB);
                    CFeature oF = new CFeature();
                    oF.FeatureID = f.FeatureID;
                    oF.FeatureDescription = f.tblFeature.FeatureDescription;
                    oF.Rating = Convert.ToInt32(f.Rating);

                    Add(oF);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void LoadAllFeatures()
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var rows = (from f in oDc.tblFeatures
                          
                            select f).ToList();
                foreach (var f in rows)
                {
                    //CPerson person = new CPerson(string _email, string _UserName, string _Password, string _FirstName, string _LastName, DateTime _DOB);
                    CFeature oF = new CFeature();
                    oF.FeatureID = f.FeatureID;
                    oF.FeatureDescription = f.FeatureDescription;

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
