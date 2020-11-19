//This is for testing purposes before we put it into the proper place.
//  This will allow us to have more creative functionality, but not worry about screwing up the builds.
//

using ClassAct.Website.BL;
using ClassAct.Website.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassAct.Website.UI.Controllers
{
    public class TestingController : Controller
    {
        CPerson operson;
        CResturant cResturant;

        CResturantList oResturantList;
        // GET: Testing
        public ActionResult Index()
        {
            //   if(Session["person"]==null)
            // {
            //   return View("Home", "Index");
            // }
             oResturantList = new CResturantList();
            oResturantList.Load();
            Session["Resturants"] = oResturantList;
            Random rand = new Random();

            double x = rand.NextDouble() * oResturantList.Count;
            int y = Convert.ToInt32(x);
          Session["resturant"]=  cResturant = oResturantList[y];
            if(Session["person"]!=null)
            {
              CHomePage   sess = Session["person"] as CHomePage;
                operson = sess.Person;
                cResturant.LikeResturant(operson.PersonID); }
            
            return View(cResturant);
        }

        [ChildActionOnly]
        public ActionResult ResturantRankings(CResturant resturant)
        {
            /*
           oResturantList = Session["Resturants"] as CResturantList;
            Random rand = new Random();

            double x = rand.NextDouble() * oResturantList.Count;
            int y = Convert.ToInt32(x);
            cResturant = oResturantList[y];
            */

            resturant = Session["resturant"] as CResturant;
            return PartialView(cResturant);

          
        }
        // GET: Testing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Testing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Testing/Create
        [ChildActionOnly]
        [HttpPost]
        public ActionResult Create(CResturant resturant)
        {
            try
            {
                if(Session["person"]==null)
                {
                    return RedirectToAction("Index", "Home");
                }
                CPerson oPerson = Session["person"] as CPerson;

                resturant.LikeResturant(oPerson.PersonID);

                return PartialView(resturant);
            }
            catch
            {
                return View();
            }
        }

        // GET: Testing/Edit/5
        
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Testing/Edit/5
        [ChildActionOnly]
        [HttpPost]
        public ActionResult Edit(CResturant resturant)
        {
            {
                try
                {
                    if (Session["person"] == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    CHomePage oPerson = Session["person"] as CHomePage;

                    resturant.LikeResturant(oPerson.Person.PersonID);

                    return PartialView(resturant);
                }
                catch
                {
                    return View();
                }
            }
        }

        // GET: Testing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Testing/Delete/5
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
    }
}
