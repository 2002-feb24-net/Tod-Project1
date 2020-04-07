using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project1.data.Entities;

namespace project1.Controllers
{
    public class AddCustomerController : Controller
    {
        // GET: AddCustomer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {

            var newCustomer = new Customer
            {
                Name = form["name"],
                Address = form["address"],
                Storenum = int.Parse(form["storeNum"]),
                Phone = form["phone"]
            };
            using (var context = new restaurantContext())
            {
                context.Customer.Add(newCustomer);
                context.SaveChanges();
            }
                /*
                public static void AddCustomer(Customers patron)
                {
                    var newCustomer = new Customer
                    {
                        Name = patron.name,
                        Address = patron.address,
                        Storenum = patron.storeNum,
                        Phone = patron.phone
                    };
                    using (var context = new restaurantContext())
                    {
                        context.Customer.Add(newCustomer);
                        context.SaveChanges();
                    }*/
                return View();
        }

        // GET: AddCustomer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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