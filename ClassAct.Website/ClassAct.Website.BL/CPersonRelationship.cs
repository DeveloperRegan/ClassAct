using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.Website.BL
{
    public class CPersonRelationship
    {
        // Thai Thao 9/19/17
        public Guid MainPersonID { get; set; }
        public Guid SecondPersonID { get; set; }
        public Guid RelationshipTypeID { get; set; }

        //Terence 10/8/17
        public string SecondPersonUserName { get; set; }
        public DateTime SecondPersonDOB { get; set; }
        public string secondPersonFirstName { get; set; }
        public string SecondPersonLastName { get; set; }
        public string RelationshipDescription { get; set; }
    }
    public class CPersonRelationshipList: List<CPersonRelationship>
    {

    }
    
}
