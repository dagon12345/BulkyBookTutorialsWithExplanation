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
    public class MasterListsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MasterListsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: MasterLists
        public async Task<IActionResult> Index()
        {
            IEnumerable<MasterList> obj = await _context.tbl_masterlist.Take(50).ToListAsync();
            return View(obj);
        }

        // GET: MasterLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tbl_masterlist == null)
            {
                return NotFound();
            }

            var masterList = await _context.tbl_masterlist
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masterList == null)
            {
                return NotFound();
            }

            return View(masterList);
        }

        // GET: MasterLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MasterLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,MiddleName,ExtName,Citizenship,MothersMaiden,PSGCRegion,PSGCProvince,PSGCityMun,PSGCBrgy,Address,BirthDate,SexID,MaritialStatusID,Religion,BirthPlace,EducAttain,IDTypeID,IDNumber,IDDatesIssued,Pantawid,Indigenous,SocialPensionID,HouseholdID,ContactNum,HealthStatusID,HealthStatusRemarks,DateTimeEntry,EntryBy,DatatSourceID,StatusID,Remarks,RegTypeID,InclusionBatch,InclusionDate,ExculsionBatch,ExclustionDate,DateDeceased,DateTimeModified,ModifiedBy,DateTimeDeleted,DeletedBy,WaitlistedRepordID,WithPhoto")] MasterList masterList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(masterList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masterList);
        }

        // GET: MasterLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tbl_masterlist == null)
            {
                return NotFound();
            }

            var masterList = await _context.tbl_masterlist.FindAsync(id);
            if (masterList == null)
            {
                return NotFound();
            }
            return View(masterList);
        }

        // POST: MasterLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,MiddleName,ExtName,Citizenship,MothersMaiden,PSGCRegion,PSGCProvince,PSGCityMun,PSGCBrgy,Address,BirthDate,SexID,MaritialStatusID,Religion,BirthPlace,EducAttain,IDTypeID,IDNumber,IDDatesIssued,Pantawid,Indigenous,SocialPensionID,HouseholdID,ContactNum,HealthStatusID,HealthStatusRemarks,DateTimeEntry,EntryBy,DatatSourceID,StatusID,Remarks,RegTypeID,InclusionBatch,InclusionDate,ExculsionBatch,ExclustionDate,DateDeceased,DateTimeModified,ModifiedBy,DateTimeDeleted,DeletedBy,WaitlistedRepordID,WithPhoto")] MasterList masterList)
        {
            if (id != masterList.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(masterList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasterListExists(masterList.ID))
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
            return View(masterList);
        }

        // GET: MasterLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tbl_masterlist == null)
            {
                return NotFound();
            }

            var masterList = await _context.tbl_masterlist
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masterList == null)
            {
                return NotFound();
            }

            return View(masterList);
        }

        // POST: MasterLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tbl_masterlist == null)
            {
                return Problem("Entity set 'ApplicationDBContext.tbl_masterlist'  is null.");
            }
            var masterList = await _context.tbl_masterlist.FindAsync(id);
            if (masterList != null)
            {
                _context.tbl_masterlist.Remove(masterList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasterListExists(int id)
        {
          return (_context.tbl_masterlist?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
