using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassAct.Website.BL;

namespace ClassAct.Website.BL.Test
{
    [TestClass]
    public class utRestaurant
    {
        [TestMethod]
        public void LoadRestaurantsByCuisineLocationTest()
        {
            CResturantList restaurants = new CResturantList();
            restaurants.LoadByCuisineLocation("Pizza", "Appleton", "WI");

            Assert.AreEqual(4, restaurants.Count);
        }

        [TestMethod]
        public void GetGooglePlacePhotoTest()
        {
            CResturantList restaurants = new CResturantList();
            restaurants.LoadByCuisineLocation("American", "Appleton", "WI");
            foreach(CResturant restaurant in restaurants)
            {
                restaurant.GetGooglePlacePhoto(370);
            }


        }
    }
}
