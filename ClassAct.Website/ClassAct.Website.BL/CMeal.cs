using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.Website.BL
{
  public  class CMeal
    {
        // Thai Thao 9/19/17
        public int PersonID { get; set; }
        public int ResturantID { get; set; }
        public int CuisinID { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }

        public string UserName { get; set; }
        public string ResutantName { get; set; }

    }

    //Added a list of meal class
    public class CMealList : List<CMeal>
    {

    }
}
