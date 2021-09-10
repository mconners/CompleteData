using System;
using System.Data.Entity;
using CompleteData.Shared.Models;

namespace CompleteData.Server.Data
{
    public partial class NorthwindContext : DbContext
    {
       public NorthwindContext()
            : base("name=NorthwindContext")
        {
            Configuration.LazyLoadingEnabled = false;
            // Configuration.ProxyCreationEnabled = false;
            // Configuration.ValidateOnSaveEnabled = false;
            // Configuration.AutoDetectChangesEnabled = false;

        }

        //  public NorthwindContext(DbContextOptions<NorthwindContext> options)
        //     : base(options)
        // {
        // }

        public virtual DbSet<AlphabeticalListOfProducts> AlphabeticalListOfProducts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997 { get; set; }
        public virtual DbSet<CurrentProductList> CurrentProductList { get; set; }
        public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCity { get; set; }
        public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderDetailsExtended> OrderDetailsExtended { get; set; }
        public virtual DbSet<OrderSubtotals> OrderSubtotals { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersQry> OrdersQry { get; set; }
        public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997 { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrice { get; set; }
        public virtual DbSet<ProductsByCategory> ProductsByCategory { get; set; }
        public virtual DbSet<QuarterlyOrders> QuarterlyOrders { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<SalesByCategory> SalesByCategory { get; set; }
        public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmount { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarter { get; set; }
        public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYear { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Territories> Territories { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind");
//             }
//         }

protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Categories>().HasKey(e => e.CategoryId);
            modelBuilder.Entity<Orders>().HasKey(e=>e.OrderId);
            modelBuilder.Entity<Products>().HasKey(e=>e.ProductId);
            modelBuilder.Entity<Customers>().HasKey(e=>e.CustomerId);
            modelBuilder.Entity<CustomerDemographics>().HasKey(e=>e.CustomerTypeId);
            modelBuilder.Entity<Employees>().HasKey(e=>e.EmployeeId);
            modelBuilder.Entity<EmployeeTerritories>().HasKey(e=>e.TerritoryId);
            modelBuilder.Entity<OrderDetails>().HasKey(e => e.OrderId);
            modelBuilder.Entity<Territories>().HasKey(e => e.TerritoryId);
            modelBuilder.Entity<Shippers>().HasKey(e => e.ShipperId);
            modelBuilder.Entity<Suppliers>().HasKey(e => e.SupplierId);
            modelBuilder.Entity<CategorySalesFor1997>().HasKey(e => e.CategoryName);
            modelBuilder.Entity<CurrentProductList>().HasKey(e => e.ProductId);
            modelBuilder.Entity<CustomerAndSuppliersByCity>().HasKey(e => e.City);
            modelBuilder.Entity<CustomerCustomerDemo>().HasKey(e => new { e.CustomerId, e.CustomerTypeId });
            modelBuilder.Entity<Invoices>().HasKey(e => e.CustomerId);
            modelBuilder.Entity<OrderDetailsExtended>().HasKey(e => new { e.OrderId, e.ProductId });
            modelBuilder.Entity<OrdersQry>().HasKey(e => new { e.OrderId, e.CustomerId });
            modelBuilder.Entity<OrderSubtotals>().HasKey(e => e.OrderId);
            modelBuilder.Entity<ProductsAboveAveragePrice>().HasKey(e => e.ProductName);
            modelBuilder.Entity<ProductSalesFor1997>().HasKey(e => e.ProductName);
            modelBuilder.Entity<ProductsByCategory>().HasKey(e => e.ProductName);
            modelBuilder.Entity<QuarterlyOrders>().HasKey(e => e.CustomerId);
            modelBuilder.Entity<SalesByCategory>().HasKey(e => e.CategoryId);
            modelBuilder.Entity<SalesTotalsByAmount>().HasKey(e => e.OrderId);
            modelBuilder.Entity<SummaryOfSalesByQuarter>().HasKey(e => e.OrderId);
            modelBuilder.Entity<SummaryOfSalesByYear>().HasKey(e => e.OrderId);

            
            


            modelBuilder.Entity<CustomerDemographics>()
                .Property(e => e.CustomerTypeId)
                .IsFixedLength();

            modelBuilder.Entity<CustomerDemographics>()
                .HasMany(e => e.Customers)
                .WithMany(e => e.CustomerDemographics)
                .Map(m => m.ToTable("CustomerCustomerDemo").MapLeftKey("CustomerTypeID").MapRightKey("CustomerID"));

            modelBuilder.Entity<Customers>()
                .Property(e => e.CustomerId)
                .IsFixedLength();


            modelBuilder.Entity<Employees>()
                .HasMany(e => e.InverseReportsToNavigation)
                .WithOptional(e => e.ReportsToNavigation)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.EmployeeTerritories)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeeTerritories").MapLeftKey("EmployeeID").MapRightKey("TerritoryID"));

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orders>()
                .Property(e => e.CustomerId)
                .IsFixedLength();

            modelBuilder.Entity<Orders>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            

            modelBuilder.Entity<Products>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.RegionDescription)
                .IsFixedLength();

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Territories)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shippers>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Shipper)
                .HasForeignKey(e => e.ShipVia);

            modelBuilder.Entity<Territories>()
                .Property(e => e.TerritoryDescription)
                .IsFixedLength();

            modelBuilder.Entity<AlphabeticalListOfProducts>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CategorySalesFor1997>()
                .Property(e => e.CategorySales)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CustomerAndSuppliersByCity>()
                .Property(e => e.Relationship)
                .IsUnicode(false);

            modelBuilder.Entity<Invoices>()
                .Property(e => e.CustomerId)
                .IsFixedLength();

            modelBuilder.Entity<Invoices>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoices>()
                .Property(e => e.ExtendedPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoices>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetailsExtended>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetailsExtended>()
                .Property(e => e.ExtendedPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderSubtotals>()
                .Property(e => e.Subtotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrdersQry>()
                .Property(e => e.CustomerId)
                .IsFixedLength();

            modelBuilder.Entity<OrdersQry>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductSalesFor1997>()
                .Property(e => e.ProductSales)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductsAboveAveragePrice>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesByCategory>()
                .Property(e => e.ProductSales)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesTotalsByAmount>()
                .Property(e => e.SaleAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SummaryOfSalesByQuarter>()
                .Property(e => e.Subtotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SummaryOfSalesByYear>()
                .Property(e => e.Subtotal)
                .HasPrecision(19, 4);
 
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }
}
