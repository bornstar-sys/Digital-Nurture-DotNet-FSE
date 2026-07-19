using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlite("Data Source=retail.db");

using var context = new AppDbContext(optionsBuilder.Options);
context.Database.EnsureCreated();

var electronics = new Category { Name = "Electronics" };
var groceries = new Category { Name = "Groceries" };
context.Categories.AddRange(electronics, groceries);

var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
context.Products.AddRange(product1, product2);

context.SaveChanges();

var products = context.Products.ToList();
foreach (var p in products)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");

var found = context.Products.Find(1);
Console.WriteLine($"Found: {found?.Name}");

var expensive = context.Products.FirstOrDefault(p => p.Price > 50000);
Console.WriteLine($"Expensive: {expensive?.Name}");

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public List<Product> Products { get; set; } = new();
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}

