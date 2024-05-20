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
    public class UniversitesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UniversitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Universites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Universites.ToListAsync());
        }

        // GET: Universites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universite = await _context.Universites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universite == null)
            {
                return NotFound();
            }

            return View(universite);
        }

        // GET: Universites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Universites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Universite universite)
        {
      
            
                _context.Universites.Add(universite);
                 _context.SaveChangesAsync();
                return RedirectToAction("Index");
        
            
        }

        // GET: Universites/Edit/5
         public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universite =_context.Universites.Find(id);
            if (universite == null)
            {
                return NotFound();
            }
            return View(universite);
        }
        // POST: Universites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Universite universite)
        {
            _context.Update(universite);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Universites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universite = await _context.Universites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universite == null)
            {
                return NotFound();
            }

            return View(universite);
        }

        // POST: Universites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universite = await _context.Universites.FindAsync(id);
            if (universite != null)
            {
                _context.Universites.Remove(universite);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversiteExists(int id)
        {
            return _context.Universites.Any(e => e.Id == id);
        }
    }
}
