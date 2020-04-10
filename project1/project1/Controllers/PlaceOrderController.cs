using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project1.logic.Interfaces;

namespace project1.Controllers
{
    public class PlaceOrderController : Controller
    {
        public IRepository Repo { get; }


        public PlaceOrderController(IRepository repo)
        {
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        }
        [HttpPost]
        public ActionResult Index(string patron)
        {
            if (patron == null)
                return Redirect("../Customers");
            TempData["customer"] = patron;
            TempData.Keep();
            return View(Repo.GetMenuViewModel());
        }

        // GET: PlaceOrder
        public ActionResult Index()
        {
            return View();
        }




        // POST: PlaceOrder/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            
            
            var checkered = collection["isChecked"];
            var name = TempData["Customer"].ToString();
            bool place = Repo.PlaceOrder(checkered, name);

            if(place)
                return View();
            return Redirect("../MainMenu");
        }


    }
}