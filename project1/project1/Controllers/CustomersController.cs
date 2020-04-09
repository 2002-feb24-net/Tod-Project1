using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project1.data.Entities;
using project1.logic.Models;
using project1.logic.Interfaces;

namespace project1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly restaurantContext _context;

        public IRepository Repo { get; }

        public CustomersController(IRepository repo)
        {
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _context = new restaurantContext();
        }
        /*
        public CustomersController(restaurantContext context)
        {
            _context = context;
        }
        */
        // GET: Customers
        
        public IActionResult Index(string search = "")
        {
            var store = 1;
            if (search == null)
                search = "";
            try
            {
                store = int.Parse(TempData["storeNum"].ToString());
            }
            catch
            {
                return Redirect("../Locations");
            }
            TempData["storeNum"] = store;
            TempData.Keep();
            List<Customers> model = Repo.GetCustomerList(store, search);
            return View(model);
        }


        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.StorenumNavigation)
                .FirstOrDefaultAsync(m => m.Name == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["Storenum"] = new SelectList(_context.Location, "Storenum", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,Storenum,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Storenum"] = new SelectList(_context.Location, "Storenum", "Name", customer.Storenum);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["Storenum"] = new SelectList(_context.Location, "Storenum", "Name", customer.Storenum);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Address,Storenum,Phone")] Customer customer)
        {
            if (id != customer.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Storenum"] = new SelectList(_context.Location, "Storenum", "Name", customer.Storenum);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.StorenumNavigation)
                .FirstOrDefaultAsync(m => m.Name == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.Name == id);
        }
    }
}
