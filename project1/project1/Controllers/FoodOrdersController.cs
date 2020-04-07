using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project1.data.Entities;

namespace project1.Controllers
{
    public class FoodOrdersController : Controller
    {
        private readonly restaurantContext _context;

        public FoodOrdersController(restaurantContext context)
        {
            _context = context;
        }


        // GET: FoodOrders
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.FoodOrder.Include(f => f.NameNavigation);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: FoodOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.FoodOrder
                .Include(f => f.NameNavigation)
                .FirstOrDefaultAsync(m => m.Ordernum == id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            return View(foodOrder);
        }

        // GET: FoodOrders/Create
        public IActionResult Create()
        {
            ViewData["Name"] = new SelectList(_context.Customer, "Name", "Name");
            return View();
        }

        // POST: FoodOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Ordernum,Ordertime")] FoodOrder foodOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Name"] = new SelectList(_context.Customer, "Name", "Name", foodOrder.Name);
            return View(foodOrder);
        }

        // GET: FoodOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.FoodOrder.FindAsync(id);
            if (foodOrder == null)
            {
                return NotFound();
            }
            ViewData["Name"] = new SelectList(_context.Customer, "Name", "Name", foodOrder.Name);
            return View(foodOrder);
        }

        // POST: FoodOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Ordernum,Ordertime")] FoodOrder foodOrder)
        {
            if (id != foodOrder.Ordernum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodOrderExists(foodOrder.Ordernum))
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
            ViewData["Name"] = new SelectList(_context.Customer, "Name", "Name", foodOrder.Name);
            return View(foodOrder);
        }

        // GET: FoodOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.FoodOrder
                .Include(f => f.NameNavigation)
                .FirstOrDefaultAsync(m => m.Ordernum == id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            return View(foodOrder);
        }

        // POST: FoodOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodOrder = await _context.FoodOrder.FindAsync(id);
            _context.FoodOrder.Remove(foodOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodOrderExists(int id)
        {
            return _context.FoodOrder.Any(e => e.Ordernum == id);
        }
    }
}
