using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project1.data.Entities;
using project1.logic.Interfaces;

namespace project1.Controllers
{
    public class AddCustomerController : Controller
    {
        public IRepository Repo { get; }

        public AddCustomerController(IRepository repo)
        {
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
          
        }

        // GET: AddCustomer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name, string address, string phone)
        {
            //if (form == null) throw new ArgumentNullException("form");

           
            var store = TempData["storenum"];
            TempData["storeNum"] = store;
            TempData.Keep();
            string storeNum = store.ToString();
            TempData.Keep();
            if(store == null)
            {
                return Redirect("../Locations");
            }
            Repo.AddCustomer(name, address, storeNum, phone);
          
               
                return Redirect("../MainMenu");
            }

            

        // GET: AddCustomer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        /*
        // GET: AddCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddCustomer/Create
        
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
        */
        // GET: AddCustomer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddCustomer/Edit/5
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

        // GET: AddCustomer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddCustomer/Delete/5
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