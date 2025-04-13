using Bookify.DataAcess.Repository.IRepository;
using Bookify.Models;
using BookifyWeb.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.DataAcess.Repository
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

      

        public void Update(Category category)
        {
           _db.Categories.Update(category);
        }
    }
}
