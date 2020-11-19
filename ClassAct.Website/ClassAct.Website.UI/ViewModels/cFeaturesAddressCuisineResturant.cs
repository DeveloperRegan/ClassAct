using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassAct.Website.BL;

namespace ClassAct.Website.UI.ViewModels
{
    public class cFeaturesAddressCuisineResturant
    {
        public CFeature features { get; set; }
        public CAddress Address { get; set; }

        public CCuisine cuisine { get; set; }

        public CResturant resturant { get; set; }
    }
}