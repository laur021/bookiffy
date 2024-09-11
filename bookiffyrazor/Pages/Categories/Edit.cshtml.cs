using bookiffyrazor.Data;
using bookiffyrazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bookiffyrazor.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        // Bind the Category object
        //meaning, if the user submit data thru method=post, it automatically binded in here.
        //so no need parameter for onPost method
        public Category Category { get; set; } 
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Category = await _db.Categories.FindAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page(); // Return the same page with the Category data loaded
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return the form with validation errors if ModelState is invalid
            }

            var categoryInDb = await _db.Categories.FindAsync(Category.Id);

            if (categoryInDb == null)
            {
                return NotFound();
            }

            // Update the category
            categoryInDb.Name = Category.Name;
            categoryInDb.DisplayOrder = Category.DisplayOrder;

            await _db.SaveChangesAsync();

            TempData["message"] = "Category updated successfully";
            TempData["alertType"] = "info";

            return RedirectToPage("Index");
        }
    }
}
