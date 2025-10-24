using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Models;

namespace SupermarketAPI.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración del modelo Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(p => p.Description)
                    .HasMaxLength(500);
                
                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                
                entity.Property(p => p.Category)
                    .IsRequired()
                    .HasMaxLength(50);
                
                entity.Property(p => p.Stock)
                    .IsRequired();
                
                entity.Property(p => p.Barcode)
                    .HasMaxLength(50);
                
                entity.Property(p => p.CreatedAt)
                    .IsRequired();
                
                entity.Property(p => p.UpdatedAt)
                    .IsRequired();
                
                entity.Property(p => p.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);

                // Índices
                entity.HasIndex(p => p.Name);
                entity.HasIndex(p => p.Category);
                entity.HasIndex(p => p.Barcode).IsUnique();
            });

            // Datos de prueba
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Leche Entera 1L",
                    Description = "Leche entera pasteurizada en envase de cartón de 1 litro",
                    Price = 2.50m,
                    Category = "Lácteos",
                    Stock = 50,
                    Barcode = "7501234567890",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Pan de Molde Integral",
                    Description = "Pan de molde integral con semillas, 500g",
                    Price = 3.25m,
                    Category = "Panadería",
                    Stock = 25,
                    Barcode = "7501234567891",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Manzanas Rojas (kg)",
                    Description = "Manzanas rojas frescas, precio por kilogramo",
                    Price = 4.80m,
                    Category = "Frutas",
                    Stock = 100,
                    Barcode = "7501234567892",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            );
        }
    }
}