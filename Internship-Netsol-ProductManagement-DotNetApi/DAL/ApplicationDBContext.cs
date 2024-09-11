using Microsoft.EntityFrameworkCore; // Imports the Entity Framework Core library for working with databases.
using Internship_Netsol_ProductManagement_DotNetApi.Models; // Imports the models, specifically the Product class.

namespace Internship_Netsol_ProductManagement_DotNetApi.DAL // Defines the namespace for the data access layer.
{
    public class ApplicationDBContext : DbContext // Inherits from DbContext, which provides methods for database operations.
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) // Constructor that receives the options for the database context.
            : base(dbContextOptions) // Passes the options to the base DbContext class.
        {
        }


        public DbSet<Product> Products { get; set; } // Represents the "Products" table in the database.
        public DbSet<User> Users { get; set; }
    }
}
