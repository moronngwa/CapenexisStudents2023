using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapenexisStudents2023.Data;
using CapenexisStudents2023.Models;

namespace CapenexisStudents2023.Controllers
{
    public class FacilitatorsController : Controller
    {
        private readonly CapenexisStudents2023Context _context;

        public FacilitatorsController(CapenexisStudents2023Context context)
        {
            _context = context;
        }

        // GET: Facilitators
        public async Task<IActionResult> Index()
        {
              return _context.Facilitator != null ? 
                          View(await _context.Facilitator.ToListAsync()) :
                          Problem("Entity set 'CapenexisStudents2023Context.Facilitator'  is null.");
        }

        // GET: Facilitators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.Facilitator
                .FirstOrDefaultAsync(m => m.FacilitatorId == id);
            if (facilitator == null)
            {
                return NotFound();
            }

            return View(facilitator);
        }

        // GET: Facilitators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facilitators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacilitatorId,FacilitatorName,FacilitatorSurname")] Facilitators facilitator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facilitator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facilitator);
        }

        // GET: Facilitators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.Facilitator.FindAsync(id);
            if (facilitator == null)
            {
                return NotFound();
            }
            return View(facilitator);
        }

        // POST: Facilitators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacilitatorId,FacilitatorName,FacilitatorSurname")] Facilitators facilitator)
        {
            if (id != facilitator.FacilitatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facilitator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilitatorExists(facilitator.FacilitatorId))
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
            return View(facilitator);
        }

        // GET: Facilitators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.Facilitator
                .FirstOrDefaultAsync(m => m.FacilitatorId == id);
            if (facilitator == null)
            {
                return NotFound();
            }

            return View(facilitator);
        }

        // POST: Facilitators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facilitator == null)
            {
                return Problem("Entity set 'CapenexisStudents2023Context.Facilitator'  is null.");
            }
            var facilitator = await _context.Facilitator.FindAsync(id);
            if (facilitator != null)
            {
                _context.Facilitator.Remove(facilitator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilitatorExists(int id)
        {
          return (_context.Facilitator?.Any(e => e.FacilitatorId == id)).GetValueOrDefault();
        }
    }
}
