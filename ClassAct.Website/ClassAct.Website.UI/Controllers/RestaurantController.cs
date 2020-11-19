using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassAct.Website.BL;
using ClassAct.Website.BL.GoogleAPI;
using ClassAct.Website.UI.ViewModels;
using System.Net;

namespace ClassAct.Website.UI.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        //Adam Rodewald 10/30/17
        [HttpPost]
        public ActionResult SetSearchParamaters(CHomePage model)
        {
            //CCuisine cuisine = model.Cuisines.Where(q => q.CuisineID == model.SelectedCuisine.CuisineID).FirstOrDefault();

            if (model.SelectedLocation != null)
            {
                string[] locationValues = model.SelectedLocation.Split(',').Select(sValue => sValue.Trim()).ToArray();


                Session["City"] = locationValues[0].ToString();
                if (locationValues.Length == 1)
                {
                    Session["state"] = "WI";
                }
                else
                {
                    Session["State"] = locationValues[1].ToString().ToUpper();
                }
            }
            Session["Cuisine"] = model.SelectedCuisine.Description;//cuisine.Description;

            return RedirectToAction("BasicSearch");
        }

        //Adam Rodewald 10/30/17
        public ActionResult BasicSearch()
        {
            CHomePage model = new CHomePage();
            CResturantList restaurants = new CResturantList();

            restaurants.LoadByCuisineLocation(Session["Cuisine"].ToString(), Session["City"].ToString(), Session["State"].ToString());

            Session["APIStatus"] = "APIOK";

            foreach (CResturant restaurant in restaurants)
            {
                if (Session["APIStatus"].ToString() != "APIError")
                {
                    restaurant.GetGooglePlacePhoto(370);

                    if(restaurant.GooglePlaceId == "APIError")
                    {
                        Session["APIStatus"] = "APIError";
                        restaurant.PhotoData = "empty";
                    }
                }
                else
                {
                    restaurant.PhotoData = "empty";
                }
            }


            model.SearchedRestaurants = restaurants;

            return View(model);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
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

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
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
