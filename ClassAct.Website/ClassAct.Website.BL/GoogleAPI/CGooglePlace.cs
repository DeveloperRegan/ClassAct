using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.Website.BL.GoogleAPI
{
    class CGooglePlace
    {
        public List<object> Html_attributions { get; set; }
        public List<Result> Results { get; set; }
        public string Status { get; set; }
    }

    public class Result
    {
        public string Formatted_address { get; set; }
        public Geometry Geometry { get; set; }
        public string Icon { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public OpeningHours Opening_hours { get; set; }
        public List<Photo> Photos { get; set; }
        public string Place_id { get; set; }
        public int Price_level { get; set; }
        public double Rating { get; set; }
        public string Reference { get; set; }
        public List<string> Types { get; set; }
    }

}
