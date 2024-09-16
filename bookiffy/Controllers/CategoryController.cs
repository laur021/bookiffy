using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using bookiffy.Models;
using bookiffy.DataAccess.Data;

namespace mvc.Controllers;
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; 
        public CategoryController(ApplicationDbContext db){
            _db = db;
        }
        public async Task<IActionResult> Index(){

            var CategoryViewModel = new CategoryViewModel 
            {
                Categories = await _db.Categories.ToListAsync(),
                Category = new Category()
            };

            return View(CategoryViewModel);

        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel viewModel)
        {

            if (viewModel == null || viewModel.Category == null)
            {
                TempData["message"] = "An error occurred while processing your request. Please try again.";
                TempData["alertType"] = "danger";

                var model = new CategoryViewModel
                {
                    Categories = _db.Categories.ToList(),
                    Category = new Category() 
                };
                
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(viewModel.Category);
                _db.SaveChanges();
                TempData["message"] = "Category added successfully!";
                TempData["alertType"] = "success";
                return RedirectToAction("Index");
            }

            viewModel.Categories = _db.Categories.ToList(); 
            return View("Index", viewModel);
        }

         public async Task<IActionResult> Edit(int? Id)
        {
            if(Id == null || Id == 0){
                return NotFound();
            }

           Category? categoryObject = await _db.Categories.FindAsync(Id);

           if (categoryObject is null){
            return NotFound();
           }

           return View(categoryObject);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category obj)
        {


            if(ModelState.IsValid) {
                _db.Categories.Update(obj);
                await _db.SaveChangesAsync();
                TempData["message"] = "Category updated successfully";
                TempData["alertType"] = "info";
                return RedirectToAction("Index","Category"); 
            }
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
            Category? obj = _db.Categories.Find(Id);
            
            if (obj is null) {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            TempData["message"] = "Category deleted successfully";
            TempData["alertType"] = "danger";
            return RedirectToAction("Index","Category"); 
        }
}