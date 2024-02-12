using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Controllers
{
    public class LibraryAssessmentsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public LibraryAssessmentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: LibraryAssessments
        public async Task<IActionResult> Index()
        {
              return _context.lib_assessment != null ? 
                          View(await _context.lib_assessment.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.lib_assessment'  is null.");
        }

        // GET: LibraryAssessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.lib_assessment == null)
            {
                return NotFound();
            }

            var libraryAssessment = await _context.lib_assessment
                .FirstOrDefaultAsync(m => m.ID == id);
            if (libraryAssessment == null)
            {
                return NotFound();
            }

            return View(libraryAssessment);
        }

        // GET: LibraryAssessments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibraryAssessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Assessment,isArchived")] LibraryAssessment libraryAssessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryAssessment);
                await _context.SaveChangesAsync();
                TempData["success"] = "Library assessment created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(libraryAssessment);
        }

        // GET: LibraryAssessments/Edit/5
        //GET(Once we click the Edit link it will populate the textboxes Name and DisplayOrder)
        public async Task<IActionResult> Edit(int? id) // For getting the view with input textboxes and getting Create and Back to list buttons.
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var libraryAssessment = await _context.lib_assessment.FindAsync(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (libraryAssessment == null)
            {
                return NotFound();
            }

            return View(libraryAssessment);
        }

        // POST: LibraryAssessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Assessment,isArchived")] LibraryAssessment libraryAssessment)
        {
            if (id != libraryAssessment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryAssessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryAssessmentExists(libraryAssessment.ID))
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
            return View(libraryAssessment);
        }

        // GET: LibraryAssessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.lib_assessment == null)
            {
                return NotFound();
            }

            var libraryAssessment = await _context.lib_assessment
                .FirstOrDefaultAsync(m => m.ID == id);
            if (libraryAssessment == null)
            {
                return NotFound();
            }

            return View(libraryAssessment);
        }

        // POST: LibraryAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.lib_assessment == null)
            {
                return Problem("Entity set 'ApplicationDBContext.lib_assessment'  is null.");
            }
            var libraryAssessment = await _context.lib_assessment.FindAsync(id);
            if (libraryAssessment != null)
            {
                _context.lib_assessment.Remove(libraryAssessment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryAssessmentExists(int id)
        {
          return (_context.lib_assessment?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
