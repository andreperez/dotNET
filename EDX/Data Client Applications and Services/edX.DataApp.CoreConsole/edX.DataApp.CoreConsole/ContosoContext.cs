using Microsoft.EntityFrameworkCore;

namespace edX.DataApp.CoreConsole
{
    public class ContosoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }
    }
}