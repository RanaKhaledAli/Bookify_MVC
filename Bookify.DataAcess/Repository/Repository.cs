using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bookify.DataAcess.Repository.IRepository;
using BookifyWeb.DataAcess.Data;
using Microsoft.EntityFrameworkCore;

namespace Bookify.DataAcess.Repository.IRepository
{
    // The Repository class implements the IRepository interface, which provides common CRUD operations for the given entity type T.
    public class Repository<T> : IRepository<T> where T : class
    {
        // _db is the instance of ApplicationDbContext, which is used to interact with the database.
        private readonly ApplicationDbContext _db;

        // dbSet is a DbSet<T> which is a representation of the table for type T in the database.
        public DbSet<T> dbSet;

        // Constructor: Initializes the Repository with an ApplicationDbContext instance.
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();  // Assigns the DbSet for the given entity type T.
                                        //_db.Categories == dbSet // Example comment showing how this could map to a specific entity (e.g., Categories)
           // _db.Products.Include(u => u.Category).Include(u => u.CategoryId);

        }

        // Add: Adds a new entity to the database.
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        // Get: Retrieves the first entity that matches the given condition (predicate).
        public T Get(Expression<Func<T, bool>> predicate, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else { 
                query = dbSet.AsNoTracking();
            }
            query = query.Where(predicate);  // Filters the records based on the provided predicate.
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }


            }

            
            return query.FirstOrDefault();  // Returns the first entity that matches the condition, or null if not found.
        }

        // GetAll: Retrieves all entities from the table for type T.
        //category,coverType
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
        { // Step 1: Start with the DbSet for the entity type 'T'.
            IQueryable<T> query = dbSet;
            if (predicate != null)
            { query = query.Where(predicate); }
            // Step 2: If 'includeProperties' is not null or empty, we proceed to include related entities.
            if (!string.IsNullOrEmpty(includeProperties))
            {
                // Step 3: Split the 'includeProperties' string into individual property names (comma-separated).
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    // Step 4: Use the Include method to load the related property/field.
                    query = query.Include(property);
                }
            }

            // Step 5: Return the result as an IEnumerable of type T.
            return query.ToList(); // Converts the query results to a list and returns them.
        }
            // Remove: Removes a specific entity from the database.
            public void Remove(T entity)
            {
                dbSet.Remove(entity);
            }

            // RemoveRange: Removes a range of entities from the database.
            public void RemoveRange(IEnumerable<T> entities)
            {
                dbSet.RemoveRange(entities);  // Removes the list of entities from the database.
            }
        }
    } 
