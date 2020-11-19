using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassAct.Website.UI;
using ClassAct.Website.BL;
using ClassAct.Website.UI.Models;
using System.IO;
using ClassAct.Website.UI.ViewModels;

namespace ClassAct.Website.UI.Controllers
{
    public class PersonController : Controller
    {
        //THere is a problem with the password not being hashed.  

        // GET: Person
        public ActionResult Index()
        {
            if (Session["person"] != null)
            {
                CHomePage oHomePage = Session["person"] as CHomePage;
                CPerson operson = oHomePage.Person;
                CPerson testPerson = new CPerson(operson.PersonID);
                operson = testPerson;
                operson.LoadAllLists();

                return View(oHomePage);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [ChildActionOnly]
        public ActionResult Recommendations()
        {
            CResturantList restaurants = new CResturantList();
            restaurants.LoadRestaurantRecommendations("Pizza", "Appleton", "WI");

            CResturantList recommendations = new CResturantList();

            for (int i = 0; i < 6; i++)
            {
                restaurants[i].GetGooglePlacePhoto(370);
                recommendations.Add(restaurants[i]);
            }

            return PartialView(recommendations);
        }

        // GET: Person/Details/5
        public ActionResult EditProfile()
        {
            //Add a load person by ID method.
            if(Session["person"]!=null)
            {
                CHomePage oHomePage = Session["person"] as CHomePage;
                CPerson operson = oHomePage.Person;
                operson.LoadAllLists();

                return View(operson);
            }
           else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }

        // GET: Person/Create
        public ActionResult Create()
        {


            return View();
        }
        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(CPerson person)
        {
            try
            {
                //added the insert User  Terence Regan 9/28/17              
                person.InsertUser();
                TempData["RegisterSuccess"] = "Sucessfully Registered"; // let us know if it worked... Thai
                return RedirectToAction("Index", "Home");
                //return View();
            }
            catch
            {
                return View();
            }
        }     

        public ActionResult RateResturant()
        {

            return View();
        }

        /*
        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

    }
}
