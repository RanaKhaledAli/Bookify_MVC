using BookifyWebRazor_Temp.Data;
using BookifyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookifyWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        // The BindProperty attribute will automatically bind form data to this Category object
        [BindProperty]
        public Category category { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            TempData["Success"] = "Category Created Successfully";
            return RedirectToPage("Index");
        }
    }
}
