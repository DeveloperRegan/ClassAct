using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassAct.Website.PL;

namespace ClassAct.Website.BL
{
    //Does not work yet. It is because I am a terrible programmer.  Terence
    public class CRecommendation
    {
        public CResturantList Recommendations { get; set; }

        public CResturantList LikedResturants { get; set; }
        public CResturantList DislikedResturants { get; set; }

        public CFeatureList PositveFeatures { get; set; }
        public CFeatureList NegativeFeatures { get; set; }

        public CCuisineList PostiveCuisineList { get; set; }
        public CCuisineList NEgativeCuisineList { get; set; }

        public CCuisineList NormalizedCuisineList { get; set; }
        public CFeatureList NormalizedFeatureList { get; set; }

        CCuisineList AddressCuisineList { get; set; }
        CFeatureList FeatureAddressList { get; set; }

        public CRecommendation(CPerson operson)
        {
            NormalizeFeatureandCuisineCounts(operson);
        }

        public CRecommendation(CPersonList personList)
        {
            foreach (CPerson person in personList)
            {
                NormalizeFeatureandCuisineCounts(person);
            }
        }

        //Does a bunch of math stuff that normalizes the Cusine and Feature List;
        public void NormalizeFeatureandCuisineCounts(CPerson person)
        {
            Recommendations = new CResturantList();

            LikedResturants = new CResturantList();
            DislikedResturants = new CResturantList();
            if (PostiveCuisineList == null || PositveFeatures == null
                || NEgativeCuisineList == null || NegativeFeatures == null)
            {
                PositveFeatures = new CFeatureList();
                NegativeFeatures = new CFeatureList();

                PostiveCuisineList = new CCuisineList();
                NEgativeCuisineList = new CCuisineList();
            }
            List<Tuple<Guid, string, int>> ListOfPostiveRating = new List<Tuple<Guid, string, int>>();
            List<Tuple<Guid, string, int>> ListOfNEgaitveRating = new List<Tuple<Guid, string, int>>();


            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            NormalizePErsonData(person, ListOfPostiveRating, ListOfNEgaitveRating, oDc);

        }

        private void NormalizePErsonData(CPerson person, List<Tuple<Guid, string, int>> ListOfPostiveRating, List<Tuple<Guid, string, int>> ListOfNEgaitveRating, ClassAct_WebsiteDataContext oDc)
        {
            CResturant resturant;
            var temp = oDc.spLoadRatingsByUser(person.PersonID).ToList();

            foreach (var res in temp)
            {
                resturant = new CResturant();
                resturant.CusinesServed = new CCuisineList();
                resturant.FeatureRatings = new CFeatureList();
                resturant.CusinesServed.LoadCuisineListByResturantID(res.ResturantID);
                resturant.FeatureRatings.LoadFeatureListByResturantID(res.ResturantID);
                if (res.Rating == false)
                {
                    foreach (CCuisine cusine in resturant.CusinesServed)
                    {
                        NEgativeCuisineList.Add(cusine);
                    }
                    foreach (CFeature feature in resturant.FeatureRatings)
                    {
                        NegativeFeatures.Add(feature);
                    }
                }
                else
                {
                    foreach (CCuisine cusine in resturant.CusinesServed)
                    {
                        PostiveCuisineList.Add(cusine);
                    }
                    foreach (CFeature feature in resturant.FeatureRatings)
                    {
                        PositveFeatures.Add(feature);
                    }
                }

                CFeatureList tempFeatureList = new CFeatureList();
                tempFeatureList.LoadAllFeatures();


                foreach (CFeature tempfeature in tempFeatureList)
                {
                    int negativecount = 0;
                    int postiveCount = 0;
                    foreach (CFeature ofeature in NegativeFeatures)
                    {
                        if (tempfeature.FeatureDescription == ofeature.FeatureDescription)
                        {
                            negativecount++;
                        }
                    }
                    foreach (CFeature ofeature in PositveFeatures)
                    {
                        if (tempfeature.FeatureDescription == ofeature.FeatureDescription)
                        {
                            postiveCount++;
                        }
                    }
                    if (negativecount > 0)
                    {
                        ListOfNEgaitveRating.Add(new Tuple<Guid, string, int>(tempfeature.FeatureID, tempfeature.FeatureDescription, negativecount));
                    }
                    if (postiveCount > 0)
                    {
                        ListOfPostiveRating.Add(new Tuple<Guid, string, int>(tempfeature.FeatureID, tempfeature.FeatureDescription, postiveCount));
                    }
                }

                int tempcount = ListOfNEgaitveRating.Count;
                List<Tuple<Guid, float>> RatedFeatures = new List<Tuple<Guid, float>>();

                foreach (var rating in ListOfPostiveRating)
                {
                    int counts = rating.Item3;
                    float x = 1f;
                    for (float i = 1; i < rating.Item3; i++)
                    {
                        x += 1f / x;
                    }
                    foreach (var disliked in ListOfNEgaitveRating)
                    {
                        if (disliked.Item1 == rating.Item1)
                        {
                            float y = 1f;
                            for (float j = 1; j < disliked.Item3; j++)
                            {
                                y += 1f / y;
                            }
                            x -= y;
                        }
                    }
                    RatedFeatures.Add(new Tuple<Guid, float>(rating.Item1, x));
                }

                ListOfNEgaitveRating.Clear();
                ListOfPostiveRating.Clear();
                List<Tuple<Guid, float>> RatedCuisines = new List<Tuple<Guid, float>>();
                CCuisineList tempCuisine = new CCuisineList();
                tempCuisine.load();
                foreach (CCuisine ocuisine in tempCuisine)
                {
                    int neg = 0;
                    int pos = 0;
                    foreach (CCuisine ocuisine2 in PostiveCuisineList)
                    {
                        if (ocuisine.Description == ocuisine2.Description)
                        {
                            pos++;
                        }

                    }
                    foreach (CCuisine ocuisine2 in NEgativeCuisineList)
                    {
                        if (ocuisine.Description == ocuisine2.Description)
                        {
                            neg++;
                        }
                    }
                    if (pos > 0)
                    {
                        ListOfPostiveRating.Add(new Tuple<Guid, string, int>(ocuisine.CuisineID, ocuisine.Description, pos));
                    }
                    if (neg > 0)
                    {
                        ListOfPostiveRating.Add(new Tuple<Guid, string, int>(ocuisine.CuisineID, ocuisine.Description, neg));
                    }


                }

                foreach (var rating in ListOfPostiveRating)
                {
                    int counts = rating.Item3;
                    float x = 1f;
                    for (float i = 1; i < rating.Item3; i++)
                    {
                        x += 1f / x;
                    }
                    foreach (var disliked in ListOfNEgaitveRating)
                    {
                        if (disliked.Item1 == rating.Item1)
                        {
                            float y = 1f;
                            for (float j = 1; j < disliked.Item3; j++)
                            {
                                y += 1f / y;
                            }
                            x -= y;
                        }
                    }
                    RatedCuisines.Add(new Tuple<Guid, float>(rating.Item1, x));
                }
                NormalizedCuisineList = new CCuisineList();
                NormalizedFeatureList = new CFeatureList();
                foreach (var ratedCuisine in RatedCuisines)
                {
                    for (int i = 0; i < ratedCuisine.Item2; i++)
                    {
                        CCuisine cCuisine = new CCuisine();
                        cCuisine.CuisineID = ratedCuisine.Item1;
                        NormalizedCuisineList.Add(cCuisine);
                    }
                }

                foreach (var ratedFEature in RatedFeatures)
                {
                    for (int i = 0; i < ratedFEature.Item2; i++)
                    {
                        CFeature ofeature = new CFeature();
                        ofeature.FeatureID = ratedFEature.Item1;
                        NormalizedFeatureList.Add(ofeature);
                    }
                }


            }


        }

        public void AddRecommendationsToDatabase(CPerson oPerson, int batches, int amountPerBatch, CAddress address)
        {
            NormalizeFeatureandCuisineCounts(oPerson);

            Recommendations = new CResturantList();
            if (address == null)
            {
                for (int i = 0; i < amountPerBatch * batches; i++)
                {
                    GetRecommendation();
                }
            }
            else
            {
                for (int i = 0; i < amountPerBatch * batches; i++)
                {
                    GetRecommendation(address);
                }
            }


            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            for (int i = 0; i < batches; i++)
            {
                Guid batchID = Guid.NewGuid();
                for (int j = 0; j < amountPerBatch; j++)
                {
                    if (address == null)
                    {
                        oDc.spAddRecommendation(oPerson.PersonID, Recommendations[i + j].ResturantID, batchID, "Every Where");
                    }
                    else
                    {
                        oDc.spAddRecommendation(oPerson.PersonID, Recommendations[i + j].ResturantID, batchID, address.description);
                    }
                    oDc.SubmitChanges();


                }

            }
        }

        public void AddRecommendationsToDatabase(CPerson operson)
        {
            operson.LoadAddresses();
            Recommendations = new CResturantList();
            for (int i = 0; i < 100; i++)
            {
                GetRecommendation();
            }

            int count = Recommendations.Count;
            int index = 0;
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
            for (int i = 0; i < (count / 5); i++)
            {
                if (count - 1 >= index)
                {
                    Guid batchID = Guid.NewGuid();
                    for (int j = 0; j < 5; j++)
                    {
                        if (count - 1 >= index)
                        {
                            oDc.spAddRecommendation(operson.PersonID, Recommendations[index].ResturantID, batchID, "Every Where");

                            index++;
                            oDc.SubmitChanges();

                        }
                    }


                }
            }

            if (operson.AddressList.Count > 0)
            {
                foreach (CAddress address in operson.AddressList)
                {

                    ClassAct_WebsiteDataContext oDC;


                    AddressCuisineList = new CCuisineList();

                    FeatureAddressList = new CFeatureList();

                    foreach (CCuisine cuisine in NormalizedCuisineList)
                    {
                        oDC = new ClassAct_WebsiteDataContext();
                        var temp = oDC.spLoadResturantbyLocationCuisineID(cuisine.CuisineID, address.City, address.State).ToList();
                        if (temp.Count >= 1)
                        {
                            AddressCuisineList.Add(cuisine);
                        }
                    }

                    foreach (CFeature feature in NormalizedFeatureList)
                    {
                        oDC = new ClassAct_WebsiteDataContext();
                        var temp = oDC.spLoadResturantsByLocationFeatureID(address.City, address.State, feature.FeatureID).ToList();

                        if (temp.Count >= 1)
                        {
                            FeatureAddressList.Add(feature);
                        }

                    }


                    Recommendations = new CResturantList();
                    while(Recommendations.Count < 100)
                    {
                        GetRecommendation(address);

                    }

                    //  ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

                    AddRecommendationsToDB(Recommendations, address, operson);

                    }
                }

            


        }

        private void AddRecommendationsToDB(CResturantList recommendation, CAddress oAddress, CPerson person)
        {
            int count = 0;
            Guid batch = Guid.NewGuid();
            foreach(CResturant res in recommendation)
            {
                if(count % 5 ==0)
                {
                    batch = Guid.NewGuid();
                }
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                oDc.spAddRecommendation(person.PersonID, res.ResturantID, batch, oAddress.description);
                count++;
            }
        }

        public void GetRecommendation(CAddress oAddress)
        {
            if (oAddress == null)
            {
                GetRecommendation();
            }
            else
            {

                float cuisinecount = AddressCuisineList.Count;
                float featureCount = FeatureAddressList.Count;

                float totalcount = cuisinecount + featureCount;

                float cuisinePercentage = (cuisinecount / totalcount) * 100;
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

                Random rand = new Random();
                int percentage = rand.Next(0, 100);
                if (percentage > cuisinePercentage)
                {
                    try
                    {

                        int FeatureIndex = 0;
                        int FeatureCount = FeatureAddressList.Count;

                        if (FeatureCount - 1 > 1)
                        {
                            FeatureIndex = rand.Next(0, (int)featureCount - 1);
                        }


                        var temp = oDc.spLoadResturantsByLocationFeatureID(oAddress.City, oAddress.State, FeatureAddressList[FeatureIndex].FeatureID).ToList();

                        if (temp.Count > 0)
                        {


                            int ResturantIndex = 0;
                            if (temp.Count - 1 > 1)
                            {
                                ResturantIndex = rand.Next(0, temp.Count - 1);
                            }

                            CResturant oResturant = new CResturant();
                            oResturant.ResturantID = temp[ResturantIndex].ResturantID;
                            Recommendations.Add(oResturant);

                        }
                    }

                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
                else
                {
                    if (cuisinecount > 0)
                    {
                        try
                        {

                            int CuisineIndex = 0;
                            int CuisineCount = AddressCuisineList.Count;
                            if (cuisinecount - 1 > 1)
                            {
                                CuisineIndex = rand.Next(0, (int)cuisinecount - 1);
                            }

                            var temp = oDc.spLoadResturantbyLocationCuisineID(AddressCuisineList[CuisineIndex].CuisineID, oAddress.City, oAddress.City).ToList();



                            if (temp.Count > 0)
                            {
                                int ResturantIndex = 0;
                                if (temp.Count - 1 > 1)
                                {
                                    ResturantIndex = rand.Next(0, temp.Count - 1);
                                }

                                CResturant cResturant = new CResturant();
                                cResturant.ResturantID = temp[ResturantIndex].ResturantID;
                                Recommendations.Add(cResturant);

                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }

                    }
                }
            }

        }



        public void GetRecommendation()
        {


            float cuisinecount = NormalizedCuisineList.Count;
            float featureCount = NormalizedFeatureList.Count;

            float totalcount = cuisinecount + featureCount;

            float cuisinePercentage = (cuisinecount / totalcount) * 100;
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            Random rand = new Random();
            int percentage = rand.Next(0, 100);
            if (percentage > cuisinePercentage)
            {
                try
                {

                    int FeatureIndex = 0;
                    if (featureCount - 1 > 1)
                    {
                        FeatureIndex = rand.Next(0, (int)featureCount - 1);
                    }

                    var temp = oDc.spLoadResturantsbyFeatureID(NormalizedFeatureList[FeatureIndex].FeatureID).ToList();

                    if (temp.Count > 0)
                    {


                        int ResturantIndex = 0;
                        if (temp.Count - 1 > 1)
                        {
                            ResturantIndex = rand.Next(0, temp.Count - 1);
                        }

                        CResturant oResturant = new CResturant();
                        oResturant.ResturantID = temp[ResturantIndex].ResturantID;
                        Recommendations.Add(oResturant);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            else
            {
                if (cuisinecount > 0)
                {
                    try
                    {

                        int CuisineIndex = 0;
                        if (cuisinecount - 1 > 1)
                        {
                            CuisineIndex = rand.Next(0, (int)cuisinecount - 1);
                        }

                        var temp = oDc.spLoadResturantsbyCuisineID(NormalizedCuisineList[CuisineIndex].CuisineID).ToList();

                        if (temp.Count > 0)
                        {
                            int ResturantIndex = 0;
                            if (temp.Count - 1 > 1)
                            {
                                ResturantIndex = rand.Next(0, temp.Count - 1);
                            }

                            CResturant cResturant = new CResturant();
                            cResturant.ResturantID = temp[ResturantIndex].ResturantID;
                            Recommendations.Add(cResturant);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
            }

        }
        public void LoadRecommendations(CPerson person, string location)
        {
            ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();

            var recs = oDc.spLoadRecommendationsByUserIDAndLocationDescription(location, person.PersonID).ToList();
            foreach (var rec in recs)
            {
                CResturant oResturant = new CResturant();
                oResturant.Address.City = rec.City;

                oResturant.Address.StreetAddress = rec.StreetAddress;

                oResturant.Address.State = rec.State;

                oResturant.ResturantName = rec.ResturantName;
                oResturant.phone = rec.ResturantPhoneNumber;

                Recommendations.Add(oResturant);

            }

        }

        public void LoadAllRecommendations(CPerson person)
        {
            Recommendations = new CResturantList();
            person.LoadAddresses();
            LoadRecommendations(person, "Every Where");
            foreach (CAddress address in person.AddressList)
            {
                LoadRecommendations(person, address.description);
            }

        }

    }
}