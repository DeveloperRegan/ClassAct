using ClassAct.Website.BL;
using ClassAct.Website.UI.Models;
using ClassAct.Website.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassAct.Website.BL.Helpers;
using System.Web.Mvc;
using ClassAct.Website.BL.GoogleAPI;

namespace ClassAct.Website.UI.Controllers
{
    public class HomeController : Controller
    {
        //Terence 11/2/17.  I moved this CHomePage to expand its scope.  I think this was the key problem with the login page.
        CHomePage model;
        public ActionResult Index()
        {
          
            model = new CHomePage();
            return View(model);
        }

        // Adam Rodewald 10/30/17
        // Terence Regan @Adam, do you think we can just do a City for a search term?
        //Terence Regan @Adam, Do you think we can limit the search to food types in the city?
        [HttpPost]
        public ActionResult Index(CHomePage model)
        {

            string[] locationValues = model.SelectedLocation.Split(',').Select(sValue => sValue.Trim()).ToArray();

            Session["City"] = locationValues[0].ToString();

                /*
                 *  Terence @Adam.  I am adding an if statement to test if the people used the City,STate or just City.  
                 *  If they just used the city, I am going to have the Session["State"] =WI, but we can change that later.  
                 *  Otherwise I am 90% sure we will get a null error if they just enter a city.
                 */

                if (locationValues.Length == 1)
                {
                    Session["state"] = "WI";
                }
                else
                {
                    Session["State"] = locationValues[1].ToString().ToUpper();
                }

            Session["Cuisine"] = model.SelectedCuisine.Description;//cuisine.Description;

            return RedirectToAction("BasicSearch", "Restaurant");
        }

        public ActionResult UserProfile(CModalLogin oPerson)
        {
           // thai 10/6/17
        if (Session["person"] != null)
          {
                //Terence Cast the Session to a CHomePage class. 11/2/17 
                CHomePage person = Session["person"] as CHomePage;
                //Add the person.Person.FullName instead of Person.Person.FullName because of Modeling issues;
           ViewBag.Message = "Welcome" + " " + person.Person.FullName + "!"; // thai

            return View();
          } 
         else
         {
                //Terence 11/2 If the person is not logged in, sends them to login page 

                return RedirectToAction("Login", "Login"); // "cshtml/view", "folder"

                //return View();

            }
        }
        
        public JsonResult AutoComplete(string term = "")
        {
            CCuisineList cuisines = new CCuisineList();
            cuisines.load();


            // Create title/proper case and lower case versions of the term
            // this ensures the search will get results even if the user types in the wrong case
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;

            string termProper = textInfo.ToTitleCase(term);
            string termLower = term.ToLower();

            var results = cuisines.Where(p => p.Description.Contains(termProper) ||
                                              p.Description.Contains(termLower)).ToList();

            return Json(results, JsonRequestBehavior.AllowGet);
        }

    }
}