using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation_Foyer.Models;

namespace Reservation_Foyer.Controllers
{
    public class FoyersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoyersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Foyers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Foyer.ToListAsync());
        }

        // GET: Foyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foyer = await _context.Foyer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foyer == null)
            {
                return NotFound();
            }

            return View(foyer);
        }

        // GET: Foyers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Foyer foyer)
        {

            _context.Add(foyer);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        // GET: Foyers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foyer = _context.Foyer.Find(id);
            if (foyer == null)
            {
                return NotFound();
            }
            return View(foyer);
        }

        // POST: Foyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Foyer foyer)
        {

            _context.Update(foyer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Foyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foyer = await _context.Foyer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foyer == null)
            {
                return NotFound();
            }

            return View(foyer);
        }

        // POST: Foyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foyer = await _context.Foyer.FindAsync(id);
            if (foyer != null)
            {
                _context.Foyer.Remove(foyer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoyerExists(int id)
        {
            return _context.Foyer.Any(e => e.Id == id);
        }
    }
}