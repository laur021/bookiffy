using bookiffyrazor.Data;
using bookiffyrazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bookiffyrazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public List<Category>? Categories { get; set; }

        [BindProperty]
        public Category? Category { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Categories.ToList();
            Category = new Category();
        }

        // This method handles the form submission for creating a new category.
        public IActionResult OnPostCreate()
        {
            if (Category == null || !ModelState.IsValid)
            {
                TempData["message"] = "An error occurred while processing your request. Please try again.";
                TempData["alertType"] = "danger";
                Categories = _db.Categories.ToList(); // reload categories to display
                return Page();
            }

            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["message"] = "Category added successfully!";
            TempData["alertType"] = "success";

            return RedirectToPage("Index"); // Reload the page after successful submission
        }

        public async Task<IActionResult> OnPostDelete()
        {
            Category? obj = _db.Categories.Find(Category?.Id);
            
            if (obj is null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            TempData["message"] = "Category deleted successfully";
            TempData["alertType"] = "danger";

            return RedirectToPage("Index");
        }
    }
}
