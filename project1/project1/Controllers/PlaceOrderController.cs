using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project1.Controllers
{
    public class PlaceOrderController : Controller
    {
        // GET: PlaceOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: PlaceOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlaceOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaceOrder/Create
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

        // GET: PlaceOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlaceOrder/Edit/5
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

        // GET: PlaceOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlaceOrder/Delete/5
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