using ClassAct.Website.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;

namespace ClassAct.Website.UI.ViewModels
{
    public class CHomePage
    {
        //Updates by Adam Rodewald 10/28
        public CResturantList FeaturedRestaurants { get; set; }
        public CResturantList SearchedRestaurants { get; set; }
        public string SelectedLocation { get; set; }
        public CCuisineList Cuisines { get; set; }
        public CCuisine SelectedCuisine { get; set; }
        public CPerson Person { get; set; }

        public CHomePage()
        {
            Cuisines = new CCuisineList();
            Cuisines.load();

        }
    }
}
