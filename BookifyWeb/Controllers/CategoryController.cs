using BookifyWeb.Data;
using BookifyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookifyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _dbContext.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category categoryObj)
        {
            if (categoryObj.Name == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder canot exatly match the Name");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(categoryObj);
                _dbContext.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
        return View();
        }
        public IActionResult Edit(int ?id)
        {

            if (id == 0 || id == null) 
            { 
                return NotFound();
            }
            Category? categoryFromDb=_dbContext.Categories.Find(id);

            //Category? categoryFromDb1 = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            //Category? categoryFromDb2 = _dbContext.Categories.Where(c=>c.Id==id).FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null) 
            { 
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category categoryObj)
        {
           
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(categoryObj);
                _dbContext.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? categoryFromDb = _dbContext.Categories.Find(id);

            
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int ?id)
        {
            Category? category = _dbContext.Categories.Find(id);
            if(category== null) 
            { 
                return NotFound();
            }

            
                _dbContext.Categories.Remove(category );
                _dbContext.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }
            
        }
    }
