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
    public class ProductImageRepository:Repository<ProductImage>,IProductImageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductImageRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(ProductImage obj)
        {
            _dbContext.Update(obj);
        }
    }
}
