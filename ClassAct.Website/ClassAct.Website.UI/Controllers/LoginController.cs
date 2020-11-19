using ClassAct.Website.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassAct.Website.UI.Models;
using ClassAct.Website.UI.ViewModels;
using System.Web.Security;

namespace ClassAct.Website.UI.Controllers
{
    public class LoginController : Controller
    {
        CHomePage oHomepage;
        // GET: Login
        public ActionResult Login()
        {
            Session["person"] = null;
            return View();
        }
        [HttpPost] // thai 10/6/17
        public ActionResult Login(CHomePage oPerson)
        {
            try
            {
                if (oPerson.Person.Login())
                {
                    Session["person"] = oPerson;
                    
                    //ViewBag.Message = "Welcome" + " " + oPerson.UserName + "!"; // thai

                    //TempData["LoggedIn"] = "Sucessfully Logged In" + " " + oPerson.Person.UserName;

                    //Terence REgan @Thai, I think you need a Logged in HomePage, and redirect to that;
                    //Terence Regan @Cale.  WE need the User Profile Page.

                    
                    ViewBag.Message = oPerson.Person.FullName;
                    return RedirectToAction("Index","Person");
                }
                else
                {
                    ViewBag.Message = "Username or Password is incorrect.";

                    // Thai: not returning as orginal dialog box, failed login page is rendered i believe
                    //return View();

                    //return View("loginModal");

                    //return View("Login", "Login");

                    //return PartialView("Login", oPerson); 

                    return RedirectToAction("Login", "Login");

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();

            }
        }

        // logout - Thai 11/8/17
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
