using ClassAct.Website.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ClassAct.Website.BL
{
    public class CPerson
    {
        
        //Add a load person by ID method.


        //Properties of CPerson  Terence Regan 9/19/2017

        public Guid PersonID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        // Changes the Birthday field to be a date time.
        [DisplayName("Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public CAddress Address { get; set; }

        

        #region Lists of a person 
        public CCuisineList cuisines { get; set; }

        public CMealList MealList { get; set; }

        public CPersonRelationshipList Relationships { get; set; }

        public CFeatureList FeaturePreferences { get; set; }

        public CAddressList AddressList { get; set; }
        #endregion

        public string Description { get; set; }

        
        //This is to save pictures to the Database.  It is not working.  We need to add an image serializer to the PL.  
        //It is possible that the parameters of the signiture needs to be changed, but I am not sure.
        public void SaveImage(HttpPostedFileBase oImage)
        {
            try
            {
                if(oImage!=null)
                {
                //    ImageSerilaizer.imgageToDB(oImage.);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        [DisplayName("Full Name")] // Thai Thao 9/26/17
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        // DEFAULT CONSTRUCTOR Thai Thao 9/26/17

            //Terence Added a if statement to see if the user can sign in, if they cannot it should do a sign in.
        public CPerson()
        {
             
                    PersonID = Guid.NewGuid();
           

        
            //Added the custom ID tag.  Terence

        }

        //Constructor added Terence Regan 9/19/2017
        public CPerson(string _email, string _UserName, string _Password, string _FirstName, string _LastName, DateTime _DOB)
        {
            PersonID = Guid.NewGuid();
            Email = _email;
            UserName = _UserName;
            Password = Getpasscode();
            FirstName = _FirstName;
            LastName = _LastName;
            DOB = _DOB;
        }

        public CPerson(string _UserName, string _Password)
        {
            UserName = _UserName;
            Password = _Password;

            cuisines = new CCuisineList();
            MealList = new CMealList();
            FeaturePreferences = new CFeatureList();
            Relationships = new CPersonRelationshipList();

        }

        public CPerson (Guid _personID)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            var person = oDc.spLoadUserByUserID(_personID).FirstOrDefault();

            Email = person.PersonsEmail;
            
            
        }

        public string Getpasscode()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public bool Login()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            tblPerson oTblPerson = (from p in oDc.tblPersons
                                    where p.PersonsUserName == UserName
                                    select p).FirstOrDefault();

            if (oTblPerson != null)
            {
                if (oTblPerson.PersonsPassword == Getpasscode())
                {
                    FirstName = oTblPerson.PersonFirstName;
                    LastName = oTblPerson.PersonLastName;
                    UserName = oTblPerson.PersonsUserName;
                    DOB = (DateTime)oTblPerson.PersonDOB;
                    PersonID = oTblPerson.PersonID;

                    Email = oTblPerson.PersonsEmail;
                    

                    LoadCuisineToUser();
                    LoadAddresses();
                    LoadRelationships();
                    
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        
        public void LoadCuisineToUser()
        {
            if(cuisines==null)
            {
                cuisines = new CCuisineList();
            }
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            var results = oDc.spLoadUserCuisines(PersonID).ToList();

            foreach (var result in results)
            {
                CCuisine oCuisine = new CCuisine();
                oCuisine.CuisineID = result.CuisineID;
                oCuisine.Description = result.CuisineDescription;
                //oCuisine.Rating = result.Rating;

                cuisines.Add(oCuisine);
            }
        }

        public void LoadAddresses()
        {
            if (AddressList == null)
            {
                AddressList = new CAddressList();
            }

            AddressList.Clear();
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            var result = oDc.spLoadUserAddresses(PersonID).ToList();

            foreach (var address in result)
            {
                CAddress oAddress = new CAddress();
                oAddress.AddressID = address.AddressID;
                oAddress.City = address.City;
                oAddress.State = address.State;
                oAddress.StreetAddress = address.StreetAddress;
                oAddress.ZipCode = address.ZipCode;
                oAddress.description = address.AddressDescription;

                AddressList.Add(oAddress);
            }
        }

        public void LoadRelationships()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
           var results = oDc.spLoadRelationshipToUser(PersonID).ToList();
            foreach (var result in results)
            {
                CPersonRelationship oPersonRelationship = new CPersonRelationship();
                oPersonRelationship.SecondPersonDOB = (DateTime)result.PersonDOB;
                oPersonRelationship.secondPersonFirstName = result.PersonLastName;
                oPersonRelationship.SecondPersonUserName = result.PersonsUserName;
                oPersonRelationship.secondPersonFirstName = result.PersonLastName;
                oPersonRelationship.RelationshipDescription = result.Description;
                Relationships.Add(oPersonRelationship);
            }
        }

     

        public void MapUser(tblPerson otblPerson)
        {
            otblPerson.PersonID = PersonID;
            otblPerson.PersonsEmail = Email;
            otblPerson.PersonsUserName = UserName;

            otblPerson.PersonDOB = DOB;
            otblPerson.PersonFirstName = FirstName;
            otblPerson.PersonLastName = LastName;

            otblPerson.PersonsPassword = Getpasscode();
        }

        // INSERT
        public void InsertUser()
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                tblPerson oNewPerson = new tblPerson();
                MapUser(oNewPerson);
                oDc.tblPersons.InsertOnSubmit(oNewPerson);
                oDc.SubmitChanges();
                oDc = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // UPDATE - Thai Thao 9/25/17
        public void UpdateUser()
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                tblPerson person = (from p in oDc.tblPersons
                                    where p.PersonID == PersonID
                                    select p).FirstOrDefault();
                person.PersonFirstName = this.FirstName;
                person.PersonLastName = this.LastName;
                person.PersonsUserName = this.UserName;
                person.PersonsEmail = this.Email;
                person.PersonDOB = this.DOB;
            
                //oDc.SaveChanges();
                oDc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE - Thai Thao 9/25/17
        public void DeleteUser(int id)
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                tblPerson person = (from p in oDc.tblPersons
                                    where p.PersonID == PersonID
                                    select p).FirstOrDefault();
                oDc.tblPersons.DeleteOnSubmit(person);
                //oDc.SaveChanges();
                oDc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // LOAD PERSON BY ID Thai Thao 9/26/17
        public void LoadCustomerById(int id)
        {
            try
            {
                // Load one CDegreeType object by Id
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                tblPerson tablerow = (from p in oDc.tblPersons
                                      where p.PersonID == PersonID
                                      select p).FirstOrDefault();
                this.PersonID = tablerow.PersonID;
                this.UserName = tablerow.PersonsUserName;
                this.Email = tablerow.PersonsEmail;
                this.Password = tablerow.PersonsPassword;
                this.FirstName = tablerow.PersonFirstName;
                this.LastName = tablerow.PersonLastName;
                //this.PersonDOB = tablerow.PersonDOB;
                //this.PersonIncome = tablerow.PersonIncome;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCustomerByID(Guid id)
        {
            try
            {
                //Load Person from db.  Load their addresses, Load their cuisines and feature preferences.

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void AddCuisineToUser(CCuisine ocuisine)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            var result = oDc.spDoesCuisineExistInPersonCuisineTable(ocuisine.CuisineID, PersonID).ToList();
            if (result.Count>=1)
            {
                throw new Exception(ocuisine.Description +" is already in " + this.FullName + "'s table" );
            }
            else
            {
                try
                {
                    oDc.spAddCuisineToUser(PersonID, ocuisine.CuisineID, 10);
                }
                catch (Exception e)
                {

                    throw e;
                }
             
            }
        }
        public void LoadAllLists()
        {
            LoadCuisineToUser();
         
            LoadRelationships();
           //Add Method to load user Addresses LoadAddesses();
        }

   

    }

    
    // PERSON LIST Thai Thao 9/26/17
    public class CPersonList : List<CPerson>
    {
        public void Load()
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var rows = (from p in oDc.tblPersons
                            select p).ToList();
                foreach (var p in rows)
                {
                    CPerson person = new CPerson();
                    person.PersonID = p.PersonID;
                    person.Email = p.PersonsEmail;
                    person.UserName = p.PersonsUserName;
                    person.Password = p.PersonsPassword;
                    person.FirstName = p.PersonFirstName;
                    person.LastName = p.PersonLastName;
                    person.DOB = (DateTime)p.PersonDOB;
                    Add(person);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
