using ClassAct.Website.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassAct.Website.BL.GoogleAPI;

namespace ClassAct.Website.BL
{
    public class CResturant
    {

        // Thai Thao 9/19/17
        public Guid ResturantID { get; set; }
        public CAddress Address { get; set; }
        public string ResturantName { get; set; }
        public string phone { get; set; }
        //public string ResturantImagePath { get; set; }
        public string PhotoData { get; set; }
        public string GooglePlaceId { get; set; }
        public CCuisineList CusinesServed { get; set; }
        public CFeatureList FeatureRatings { get; set; }
        public string webaddress { get; set; }
        public string hours { get; set; }
/*
        public int OverallRating
        {
           get
           {
                // Sum all the ratings
                int total = 0;
                if (FeatureRatings==null)
                {
                    FeatureRatings = new CFeatureList();
                    FeatureRatings.LoadFeatureListByResturantID(ResturantID);
                }
                foreach (CFeature feature in FeatureRatings)
                {
                    total = total + feature.Rating;
                }

                // Convert the total ratings to a 100 point scale         
                int rating = (total / FeatureRatings.Count) * 100;

                return rating;
            }
        }
        */

        // DEFAULT CONSTRUCTOR - Thai Thao 9/26/17
        public CResturant()
        {
            
        }

        //Constructor to Load Resturant Data by Guid
        public CResturant(Guid id)
        {
            ClassAct_WebsiteDataContext odc = new ClassAct_WebsiteDataContext();
            
        }

     
        public void DislikeResturant(Guid UserID)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            oDc.spAddResturantDislike(UserID, ResturantID);

            oDc.SubmitChanges();


        }
#region GoogleAPI done by Adam Rodewald 11/8/17.  
        //Adam Rodewald 11/8/17
        public void GetGooglePlacePhoto(int maxwidth)
        {
            try
            {
                CAPIConnector api = new CAPIConnector();

                if (string.IsNullOrWhiteSpace(this.GooglePlaceId))
                {
                    this.GooglePlaceId = api.GetPlaceId(ConstructGoogleApiQuery());

                    if (GooglePlaceId != "empty" && GooglePlaceId != "APIError")
                    {
                        //Save GooglePlaceId in the database Adam Rodewald 11/21/17 - Not tested
                        ClassAct_WebsiteDataContext oDC = new ClassAct_WebsiteDataContext();
                        var address = oDC.tblAddresses.FirstOrDefault(a => a.AddressID == this.Address.AddressID);
                        address.GooglePlaceID = this.GooglePlaceId;
                        oDC.SubmitChanges();
                        oDC.Dispose();
                        oDC = null;
                    }
                }

                string PhotoReference;

                if(GooglePlaceId != "empty" && GooglePlaceId != "APIError")
                {
                    PhotoReference = api.GetPhotoReference(this.GooglePlaceId);
                }
                else
                {
                    if(GooglePlaceId == "APIError")
                    {
                        PhotoReference = "APIError";
                    }
                    else
                    {
                        PhotoReference = "empty";
                    }
                }
                
                if (PhotoReference != "empty" && PhotoReference != "APIError")
                {
                    this.PhotoData = api.GetPhoto(PhotoReference, maxwidth);
                }
                else
                {
                    this.PhotoData = "empty";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string ConstructGoogleApiQuery()
        {
            string query = this.ResturantName + "+" + this.Address.StreetAddress + "+" + this.Address.City + "+" + this.Address.State;
            query = query.Replace(" ", "+");
            return query;
        }

        public void AddResturanttoDB()
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            oDc.spAddResturant(ResturantName, phone, Address.StreetAddress, Address.City, Address.State, Address.ZipCode, Address.AddressID, ResturantID, null, Address.Latitude, Address.Longitude, webaddress, hours);
            oDc.SubmitChanges();
        }

        public void AddCuisineToResturantCuisineTableByName(string cuisine)
        {
            ClassAct_WebsiteDataContext oDC = new ClassAct_WebsiteDataContext();
            var result = oDC.spDoesCuisineExistInCuisineResturantbyNAme(cuisine, ResturantID).ToList();

            if (result.Count ==0)
            {
                try
                {
                    var result2 = oDC.spDoesCuisineExist(cuisine).ToList();
                    if(result2.Count == 0)
                    {
                        CCuisine oCuisine = new CCuisine(cuisine);
                        oCuisine.AddCuisineToDB();
                    }

                   var result3 = oDC.spDoesCuisineExist(cuisine).FirstOrDefault();

                    oDC.spAddCuisineToResturant(ResturantID, result3.CuisineID, 5);
                    oDC.SubmitChanges();
                    
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

#endregion

        public void AddCuisineToResturantCuisineTable(CCuisine cuisine)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            var result = oDc.spDoesCuisineExisitInResturantCuisine(ResturantID, cuisine.CuisineID).ToList() ;

            if (result.Count <=0)
            {
                try
                {
                    oDc.spAddCuisineToResturant(ResturantID, cuisine.CuisineID, 1);

                    oDc.SubmitChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        
        }

        public void AddFeatureToResturantByName(string Feature)
        {

            ClassAct_WebsiteDataContext oDC = new ClassAct_WebsiteDataContext();
            var result = oDC.spDoesFeatureByNameExistInResturantFeature(Feature, ResturantID).ToList();

            if (result.Count == 0)
            {
                try
                {
                    var result2 = oDC.spDoesFeatureExist(Feature).ToList();
                    if (result2.Count == 0)
                    {
                        oDC.spAddFeaturetoFeatureTable(Feature);
                    }

                    var result3 = oDC.spDoesFeatureExist(Feature).FirstOrDefault();

                    oDC.spAddFeatureToREsturstantFeatureTable(ResturantID, result3.FeatureID);
                    oDC.SubmitChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

        }
        public void AddFeatureToResturantNoCheck(CFeature f)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            try
            {
                oDc.spAddFeatureToREsturstantFeatureTable(f.FeatureID, ResturantID);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public void AddFeatureToResturant(CFeature f)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
        var result =    oDc.spDoesFeatureExistInResturantFeatureTable(f.FeatureID, ResturantID).ToList();
            if (result.Count == 0)
            {
                try
                {
                    oDc.spAddFeatureToREsturstantFeatureTable(f.FeatureID, ResturantID);
                }
                catch (Exception e)
                {

                    throw e;
                }
       
            }
            else
            {
                throw new Exception(string.Format("The {} is in the {} already",f.FeatureDescription, ResturantName));
            }
        }

        public void LikeResturant(CPerson operson)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            oDc.spAddResturantLike(operson.PersonID, ResturantID);
            oDc.SubmitChanges();
        }

        public void LikeResturant(Guid personID)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            oDc.spAddResturantLike(personID, ResturantID);
            oDc.SubmitChanges();
        }

    }

    // LOAD LIST OF RESTRAUNTS - Thai Thao 9/26/17
    //Loaded the Addresses too.  Terence 10/24/17
    public class CResturantList : List<CResturant>
    {
        public void Load()
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

                var resturants = oDc.spLoadAllRestaurants().ToList();

                foreach (var r in resturants)
                {
                    CResturant oResturant = new CResturant();
                    oResturant.Address = new CAddress();
                    oResturant.Address.City = r.City;
                    oResturant.Address.State = r.State;
                    oResturant.Address.ZipCode = r.ZipCode;
                    oResturant.Address.StreetAddress = r.StreetAddress;
                    oResturant.phone = r.ResturantPhoneNumber;
                    oResturant.ResturantID = r.ResturantID;
                    oResturant.ResturantName = r.ResturantName;
                    //oResturant.ResturantImagePath = r.ResturantImagePath;
                    Add(oResturant);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadResutrantByFeatureID(Guid featureID)
        {

        }

        public void LoadResturantByCuisineID(Guid cuisineID)
        {

        } 

        public void LoadByCuisineLocation(string cuisine, string city, string state)
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

                // Updated by Adam Rodewald 10/24/17
                var data = oDc.spLoadRestaurantsByCuisineLocation(cuisine, city, state);

                foreach(var entity in data)
                {
                    CResturant restaurant = new CResturant();
                    restaurant.ResturantID = entity.ResturantID;
                    restaurant.ResturantName = entity.ResturantName;

                    CAddress address = new CAddress();
                    address.AddressID = entity.AddressID;
                    address.StreetAddress = entity.StreetAddress;
                    address.City = entity.City;
                    address.State = entity.State;
                    address.ZipCode = entity.ZipCode;
                    restaurant.Address = address;

                    CCuisineList cuisines = new CCuisineList();
                    cuisines.LoadCuisineListByResturantID(restaurant.ResturantID);
                    restaurant.CusinesServed = cuisines;

                    //CFeatureList features = new CFeatureList();
                    //features.LoadFeatureListByResturantID(restaurant.ResturantID);
                    //restaurant.FeatureRatings = features;

                    this.Add(restaurant);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Adam Rodewald 11/13/17
        // This loads a sample of restaurants for the user profile page.
        // TODO: replace with recommendations by algorithm
        public void LoadRestaurantRecommendations(string cuisine, string city, string state)
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

                var data = oDc.spLoadRestaurantsByCuisineLocation(cuisine, city, state);

                foreach (var entity in data)
                {
                    CResturant restaurant = new CResturant();
                    restaurant.ResturantID = entity.ResturantID;
                    restaurant.ResturantName = entity.ResturantName;

                    CAddress address = new CAddress();
                    address.StreetAddress = entity.StreetAddress;
                    address.City = entity.City;
                    address.State = entity.State;
                    address.ZipCode = entity.ZipCode;
                    restaurant.Address = address;

                    CCuisineList cuisines = new CCuisineList();
                    cuisines.LoadCuisineListByResturantID(restaurant.ResturantID);
                    restaurant.CusinesServed = cuisines;

                    //CFeatureList features = new CFeatureList();
                    //features.LoadFeatureListByResturantID(restaurant.ResturantID);
                    //restaurant.FeatureRatings = features;

                    this.Add(restaurant);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
