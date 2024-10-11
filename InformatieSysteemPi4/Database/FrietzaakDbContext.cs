using InformatieSysteemPi4.Models;
using Microsoft.EntityFrameworkCore;

namespace InformatieSysteemPi4.Database
{
    public class FrietzaakDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PreviousOrder> PreviousOrders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public FrietzaakDbContext(DbContextOptions<FrietzaakDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the OrderDetail entity
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => od.OrderDetailID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Restrict); // Uitschakelen van cascade delete

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.Restrict); // Uitschakelen van cascade delete

            // Configure the Order entity
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Cascade); // Of een andere optie afhankelijk van je vereisten

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Discount)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DiscountID)
                .OnDelete(DeleteBehavior.Restrict); // Uitschakelen van cascade delete

            // Configure the PreviousOrder entity
            modelBuilder.Entity<PreviousOrder>()
                .HasOne(po => po.Customer)
                .WithMany(c => c.PreviousOrders)
                .HasForeignKey(po => po.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Definieer de relatie
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Product)
                .WithMany() // Aangezien CartItem geen navigatie terug naar Product heeft
                .HasForeignKey(c => c.ProductID);

            modelBuilder.Entity<Product>().HasData(
            new Product { ProductID = 4, Name = "Kleine friet", ImageURL = "/images/Kleine friet.jpeg", IsOnSale = true, Category = "Friet", IsAvailable = true, Price = 2.00m, SalePrice = 1.00m },
            new Product { ProductID = 5, Name = "Medium Friet", ImageURL = "/images/Medium.jpeg", IsOnSale = false, Category = "Friet", IsAvailable = true, Price = 2.00m, SalePrice = 175.00m },
            new Product { ProductID = 7, Name = "Grote Friet", ImageURL = "/images/Grote friet.jpeg", IsOnSale = true, Category = "Friet", IsAvailable = true, Price = 4.00m, SalePrice = 3.00m },
            new Product { ProductID = 8, Name = "Frikandel", ImageURL = "/images/Frikandel.jpg", IsOnSale = true, Category = "Snack", IsAvailable = true, Price = 2.00m, SalePrice = 1.00m },
            new Product { ProductID = 9, Name = "Kroket", ImageURL = "/images/kroket.png", IsOnSale = false, Category = "Snack", IsAvailable = true, Price = 2.00m, SalePrice = 1.00m },
            new Product { ProductID = 10, Name = "Bitterballen", ImageURL = "/images/Bitterball.jpg", IsOnSale = true, Category = "Snack", IsAvailable = true, Price = 4.00m, SalePrice = 3.00m },
            new Product { ProductID = 12, Name = "Kip nuggets (14 stuks)", ImageURL = "/images/Nuggets.jpg", IsOnSale = true, Category = "Snack", IsAvailable = false, Price = 3.00m, SalePrice = 2.00m },
            new Product { ProductID = 13, Name = "Bami schijf", ImageURL = "/images/bamihap.png", IsOnSale = false, Category = "Snack", IsAvailable = true, Price = 2.00m, SalePrice = 150.00m },
            new Product { ProductID = 14, Name = "Berenklauw", ImageURL = "/images/Berenklauw.png", IsOnSale = false, Category = "Snack", IsAvailable = true, Price = 2.00m, SalePrice = 150.00m },
            new Product { ProductID = 15, Name = "Friet saus", ImageURL = "/images/Frietsaus.jpeg", IsOnSale = false, Category = "saus", IsAvailable = true, Price = 1.00m, SalePrice = 12.00m },
            new Product { ProductID = 16, Name = "BBQ saus", ImageURL = "/images/BBQ.jpeg", IsOnSale = true, Category = "saus", IsAvailable = true, Price = 2.00m, SalePrice = 0.00m },
            new Product { ProductID = 18, Name = "Jappeleno saus", ImageURL = "/images/jalapeno saus.jpeg", IsOnSale = false, Category = "saus", IsAvailable = true, Price = 1.00m, SalePrice = 12.00m },
            new Product { ProductID = 19, Name = "Coca cola", ImageURL = "/images/Cola.png", IsOnSale = false, Category = "Drankje", IsAvailable = true, Price = 2.00m, SalePrice = 3.00m },
            new Product { ProductID = 20, Name = "Fanta", ImageURL = "/images/Fanta.png", IsOnSale = false, Category = "Drankje", IsAvailable = true, Price = 2.00m, SalePrice = 3.00m },
            new Product { ProductID = 21, Name = "Red bull", ImageURL = "/images/Red bull.jpg", IsOnSale = true, Category = "Drankje", IsAvailable = true, Price = 4.00m, SalePrice = 3.00m });
        }

    }
}
