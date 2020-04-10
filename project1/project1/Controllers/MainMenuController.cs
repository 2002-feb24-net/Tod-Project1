using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project1.logic.Interfaces;
using project1.logic.Models;

namespace project1.Controllers
{
    public class MainMenuController : Controller
    {
        // GET: MainMenu
        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult Index(string hidden)
        {
            TempData[
            return View();
        }*/

        public ActionResult ChangeMenu(string main)
        {
            
            if (main == "customerList")
                return Redirect("../Customers");
            else if (main == "addCustomer")
                return Redirect("../AddCustomer");
            else if (main == "displayMenu")
                return Redirect("../DisplayMenu");
            else
                return Redirect("../FoodOrders");
        }
        [HttpPost]
        public ActionResult Index(string locale)
        {
            int storenum;
            string location = "";
            try
            {
                location = locale.Substring(1);
            }
            catch
            {
                return Redirect("../Locations");
            }
            try
            {
                storenum = int.Parse(locale[0].ToString());
            }
            catch
            {
                storenum = 1; 
            }


            TempData["location"] = location;
            TempData["storeNum"] = storenum;
            TempData.Keep();
            Locations model = new Locations(location, storenum); 
            return View(model);
        }

        // GET: MainMenu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MainMenu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainMenu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainMenu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainMenu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainMenu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainMenu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}