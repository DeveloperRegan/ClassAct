using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.Website.BL
{
   public class CPersonResturantFeatureResturant
    {
        // Thai Thao 9/19/17
        public int PersonID { get; set; }
        public int ResturantID { get; set; }


        public int FeatureID { get; set; }
        public DateTime Date { get; set; }
        public int RATING { get; set; }
    }
}
