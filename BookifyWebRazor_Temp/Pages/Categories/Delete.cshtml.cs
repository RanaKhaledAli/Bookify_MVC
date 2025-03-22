using BookifyWebRazor_Temp.Data;
using BookifyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookifyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Category category { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            { category = _dbContext.Categories.Find(id);
            }


         
        }
       
        [HttpPost, ActionName("Delete")]
        public IActionResult OnPost()
        {
            Category? categoryobj = _dbContext.Categories.Find(category.Id);
            if (categoryobj == null)
            {
                return NotFound();
            }


            _dbContext.Categories.Remove(categoryobj);
            _dbContext.SaveChanges();
           TempData["Success"] = "Category Deleted Successfully";
            return RedirectToPage("Index");
        }
    }
}
