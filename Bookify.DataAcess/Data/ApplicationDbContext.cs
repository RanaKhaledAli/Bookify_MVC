using Bookify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookifyWeb.DataAcess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //// Ensure Identity tables exist
            //modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
            //modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
            //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1,Name="Action",DisplayOrder=1 },
                new Category { Id = 2, Name = "Science Fiction", DisplayOrder = 2 },
                 new Category { Id = 3, Name = "History", DisplayOrder = 3 },
                 new Category { Id = 4, Name = "Fantasy", DisplayOrder = 4 },
                 new Category { Id = 5, Name = "Adventure", DisplayOrder = 5 },
                 new Category { Id = 6, Name = "Philosophy", DisplayOrder = 6 }
                
                );
            modelBuilder.Entity<Company>().HasData(
    new Company
    {
        Id = 1,
        Name = "Tech Innovations Inc.",
        StreetAddress = "1234 Innovation Drive",
        City = "Silicon Valley",
        State = "CA",
        PostalCode = "94043",
        PhoneNumber = "123-456-7890"
    },
    new Company
    {
        Id = 2,
        Name = "Creative Solutions Ltd.",
        StreetAddress = "4567 Creativity Blvd.",
        City = "Los Angeles",
        State = "CA",
        PostalCode = "90001",
        PhoneNumber = "987-654-3210"
    },
    new Company
    {
        Id = 3,
        Name = "Future Enterprises",
        StreetAddress = "7890 Future Parkway",
        City = "New York",
        State = "NY",
        PostalCode = "10001",
        PhoneNumber = "555-123-4567"
    }
);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Title = "Fortune of Time",
                Author = "Billy Spark",
                Description = "In a world where time is both the greatest asset and the most elusive commodity, one man’s journey to uncover the true meaning of success leads him to unexpected discoveries. The 'Fortune of Time' is not measured in wealth, but in the moments that define us. This gripping narrative weaves together the challenges of life, love, and ambition, leaving readers to question what truly matters.",
                ISBN = "SWD9999001",
                ListPrice = 99,
                Price = 90,
                Price50 = 85,
                Price100 = 80,
                CategoryId=6

            },
new Product
{
    Id = 2,
    Title = "Dark Skies",
    Author = "Nancy Hoover",
    Description = "Beneath the oppressive clouds of a small town, secrets stir and truths are hidden in the shadows. 'Dark Skies' follows the intertwining lives of individuals facing personal struggles as they try to escape their pasts. As a storm brews in the sky, a storm of revelations emerges, threatening to unravel everything they’ve worked to protect.",
    ISBN = "CAW777777701",
    ListPrice = 40,
    Price = 30,
    Price50 = 25,
    Price100 = 20,
    CategoryId = 1
  
},
new Product
{
    Id = 3,
    Title = "Vanish in the Sunset",
    Author = "Julian Button",
    Description = "A tale of escape and reinvention, 'Vanish in the Sunset' follows a woman running from a life she no longer recognizes. As she seeks solace in a faraway place, the beauty of the sunset mirrors her journey of self-discovery. But the question remains—can one truly leave the past behind, or does it always follow us like the fading light of day?",
    ISBN = "RITO5555501",
    ListPrice = 55,
    Price = 50,
    Price50 = 40,
    Price100 = 35,
    CategoryId = 2
   

},
new Product
{
    Id = 4,
    Title = "Cotton Candy",
    Author = "Abby Muscles",
    Description = "Sweet, fluffy, and full of color, 'Cotton Candy' takes readers on an unforgettable ride through a world of wonder and innocence. In a whimsical narrative that explores childhood dreams and the joys of discovery, this story reminds us that even the most fleeting moments in life can be the sweetest. Can we hold onto these moments before they disappear like sugar in the air?",
    ISBN = "WS3333333301",
    ListPrice = 70,
    Price = 65,
    Price50 = 60,
    Price100 = 55,
    CategoryId = 4
},
new Product
{
    Id = 5,
    Title = "Rock in the Ocean",
    Author = "Ron Parker",
    Description = "A tale of resilience in the face of overwhelming forces, 'Rock in the Ocean' tells the story of a man who faces both literal and metaphorical storms in a quest to find his purpose. As he battles the ocean's ruthless waves, he must also confront his inner demons and fight for the life he's always wanted. The ocean may crash, but the rock will stand firm.",
    ISBN = "SOTJ1111111101",
    ListPrice = 30,
    Price = 27,
    Price50 = 25,
    Price100 = 20,
    CategoryId = 5
},
new Product
{
    Id = 6,
    Title = "Leaves and Wonders",
    Author = "Laura Phantom",
    Description = "In 'Leaves and Wonders,' nature itself becomes the canvas for a beautiful exploration of life’s intricate seasons. Set in an enchanted forest, the protagonist embarks on a journey of healing, learning to find wonder in the smallest details of life. The turning of leaves symbolizes the changes that happen within us as we grow, adapt, and find peace in the unpredictable cycles of life.",
    ISBN = "FOT000000001",
    ListPrice = 25,
    Price = 23,
    Price50 = 22,
    Price100 = 20,
   CategoryId = 2

});

        }
    }
}
