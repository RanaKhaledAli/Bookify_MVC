using Bookify.DataAcess.Repository.IRepository;
using BookifyWeb.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        // This is the database context that interacts with the database.
        private readonly ApplicationDbContext _dbContext;

        // The Category repository is exposed via this property to perform Category operations.
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }
       public ICompanyRepository Company { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
      public  IOrderHeaderRepository OrderHeader {  get; private set; }
       public IOrderDetailRepository OrderDetail {  get; private set; }
        public IProductImageRepository ProductImage { get; private set; }

        // Constructor initializes the UnitOfWork with the database context (ApplicationDbContext).
        // The Category repository is created here.
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; // Store the database context for later use.
            ApplicationUser=new ApplicationUserRepository(dbContext);
            // Initialize the Category repository and assign it to the Category property.
            Category = new CategoryRepository(_dbContext);
            Product = new ProductRepository(_dbContext);
            Company = new CompanyRepository(_dbContext);
            ShoppingCart = new ShoppingCartRepository(_dbContext);
            OrderHeader = new OrderHeaderRepository(_dbContext);
            OrderDetail = new OrderDetailRepository(_dbContext);
            ProductImage = new ProductImageRepository(_dbContext);

        }

        // The Save method is responsible for saving any changes made to the database.
        // This method is called to commit the changes made during the unit of work.
        public void Save()
        {
            _dbContext.SaveChanges(); // Save all changes in the database context to the database.
        }
    }
}