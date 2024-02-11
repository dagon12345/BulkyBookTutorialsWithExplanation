using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index() // Displaying all the data in our database form Model Category
        {
            IEnumerable<Category> objCategoryList = await _db.Categories.ToListAsync();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create() // For getting the view with input textboxes and getting Creat and Back to list buttons.
        {
            return View();
        }

        //POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Category obj) //For Inserting data into database
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The Display Order cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Editing Section

        //GET(Once we click the Edit link it will populate the textboxes Name and DisplayOrder)
        public async Task<IActionResult> Edit(int? id) // For getting the view with input textboxes and getting Create and Back to list buttons.
        {
            if(id == null || id == 0 )
            {
                return NotFound();
            }
            var categoryFromDb = await _db.Categories.FindAsync(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
           if(categoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category obj) //For Updating data into database
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Deleting Section

        //GET(Once we click the Edit link it will populate the textboxes Name and DisplayOrder)
        public async Task<IActionResult> Delete(int? id) // For getting the view with input textboxes and getting Create and Back to list buttons.
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = await _db.Categories.FindAsync(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")] // Action name is delete because in our Delete View the action method that we named was "Delete"
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id) //For Deleting data into database
        {
            var obj = await _db.Categories.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
