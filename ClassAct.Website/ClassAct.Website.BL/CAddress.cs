using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassAct.Website.PL;
using System.ComponentModel;

namespace ClassAct.Website.BL
{
   public class CAddress
    {
        // Thai Thao 9/19/17
        public Guid AddressID { get; set; }
        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string description { get; set; }

        //Terence 9/26
        public CAddress(string _StreetAddress, string _City, string _state, string _Zipcode)
        {
            AddressID = Guid.NewGuid();
            StreetAddress = _StreetAddress;
            City = _City;
            State = _state;
            ZipCode = _Zipcode;
        }

        public CAddress(string _StreetAddress, string _City, string _state, string _Zipcode, string _Description)
        {
            AddressID = Guid.NewGuid();
            StreetAddress = _StreetAddress;
            City = _City;
            State = _state;
            ZipCode = _Zipcode;
            description = _Description;
        }

        public CAddress()
        {

        }
    }

    // ADDRESS LIST - Thai Thao 9/26/17
    public class CAddressList: List<CAddress>
    {
        public void Load()
        {
            try
            {
                ClassAct_WebsiteDataContext oDc = new ClassAct_WebsiteDataContext();
                var rows = (from a in oDc.tblAddresses
                            select a).ToList();
                foreach (var a in rows)
                {
                    CAddress address = new CAddress();
                    address.StreetAddress = a.StreetAddress;
                    address.City = a.City;
                    address.State = a.State;
                    address.ZipCode = a.ZipCode;
                    Add(address);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
