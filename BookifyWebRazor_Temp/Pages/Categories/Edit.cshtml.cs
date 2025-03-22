using BookifyWebRazor_Temp.Data;
using BookifyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookifyWebRazor_Temp.Pages.Categories
{// The BindProperty attribute will automatically bind form data to this Category object
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        
      
        public Category category { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void OnGet(int? id)
        {
          if(id != null && id != 0)
            {
                category = _dbContext.Categories.Find(id);
            }
            
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
               TempData["Success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
