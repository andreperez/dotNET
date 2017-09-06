Notes - Installing Entity Framework Core

ContosoContext.cs

public class ContosoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Product> Products { get; set; }
}
Customer.cs

public class Customer
{
    [Key]
    public int ProductId { get; set; }

    public string Name { get; set; }
}
Program.cs

using (ContosoContext context = new ContosoContext())
{
    foreach(Customer customer in context.Customers)
    {
        Console.WriteLine($"[{customer.CustomerId}]\t{customer.FirstName} {customer.LastName}");
    }
}