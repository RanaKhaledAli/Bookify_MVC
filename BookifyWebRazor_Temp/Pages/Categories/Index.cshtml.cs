using BookifyWebRazor_Temp.Data;
using BookifyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookifyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public List<Category> CategoriesList { get; set; }

        public IndexModel(ApplicationDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public void OnGet()
        {
            CategoriesList=_dbContext.Categories.ToList();
        }
    }
}
