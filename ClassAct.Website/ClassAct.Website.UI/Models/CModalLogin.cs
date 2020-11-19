using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassAct.Website.BL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassAct.Website.UI.Models
{
    //Added to make views easier to edit.
    //Also provides a layer of seperation from the BL;
    public class CModalLogin
    {
        [DisplayName("User Name")]
        public string UserName { get; set; }


        [DisplayName("First Name")]
        public string FirstName { get; set; }
       
        public string Password { get; set; }

        public bool Login()
        {
            CPerson operson = new CPerson(UserName, Password);
            return operson.Login();
        }
    }
}