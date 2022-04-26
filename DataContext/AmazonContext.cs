using System;
using Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

#nullable disable

namespace Admin.Data
{
    public partial class AmazonContext : IdentityDbContext<IdentityUser>
    {

        public AmazonContext(DbContextOptions<AmazonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        //public virtual DbSet<CustomerProduct> CustomerProducts { get; set; }
        public virtual DbSet<CustomerProductsRate> CustomerProductsRates { get; set; }
        //public virtual DbSet<List> Lists { get; set; }
        //public virtual DbSet<ListProduct> ListProducts { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }

        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<SellerContact> SellerContacts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=AmazonClone;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Admin
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.adminProfile);

            });
            #endregion


            #region Cart 
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id);
            });
            #endregion


            #region Cart Product Relation 
            modelBuilder.Entity<CartProduct>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ProductId });

                entity.ToTable("Cart_Products");

                entity.Property(e => e.CartId).HasColumnName("Cart_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartProducts)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Products_Cart");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Products_Product");
            });
            #endregion


            #region Category 
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id);

                entity.Property(e => e.Description)
                    .HasMaxLength(220);

                entity.Property(e => e.Description_AR)
                    .HasMaxLength(220);

                entity.Property(e => e.Name)
                    .HasMaxLength(100);

                entity.Property(e => e.Name_AR)
                    .HasMaxLength(100);

                entity.Property(e => e.Picture)
                    .HasMaxLength(1000);

                //entity.Property(e => e.parentId).HasColumnName("parentCatID");

                entity.HasOne(d => d.parentCategory)
                    .WithMany(p => p.subCategories)
                    .HasForeignKey(d => d.parentId)
                    .HasConstraintName("parentCatID");
            });
            #endregion


            #region Contact (reports)
            //modelBuilder.Entity<Contact>(entity =>
            //{
            //    entity.ToTable("Contact");

            //    entity.Property(e => e.Id);

            //    entity.Property(e => e.AdminId).HasColumnName("Admin_id");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.Message)
            //        .IsRequired()
            //        .HasMaxLength(220)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Phone)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Admin)
            //        .WithMany(p => p.Contacts)
            //        .HasForeignKey(d => d.AdminId)
            //        .HasConstraintName("FK_Contact_Admin");
            //});
            #endregion


            #region Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id);

                entity.Property(e => e.CartId).HasColumnName("Cart_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10);

                entity.Property(e => e.City)
                    .HasMaxLength(20);

                entity.Property(e => e.Street)
                    .HasMaxLength(50);

                entity.HasOne(d => d.profile);
                

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_Customer_Cart");
            });
            #endregion


            #region Customer Contact Relation ( Customer Report )
            modelBuilder.Entity<CustomerContact>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(220);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100);

                //entity.HasKey(e => new { e.ContactId, e.CustomerId });

                entity.ToTable("Customer_contacts");

                //entity.Property(e => e.ContactId).HasColumnName("Contact_id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                //entity.HasOne(d => d.Contact)
                //    .WithMany(p => p.CustomerContacts)
                //    .HasForeignKey(d => d.ContactId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Customer_contacts_Contact");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_contacts_Customer");
            });
            #endregion


            #region Customer Product Relation
            //modelBuilder.Entity<CustomerProduct>(entity =>
            //{
            //    entity.HasKey(e => new { e.CustomerId, e.ProductId });

            //    entity.ToTable("Customer_Products");

            //    entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

            //    entity.Property(e => e.ProductId).HasColumnName("Product_id");

            //    entity.HasOne(d => d.Customer)
            //        .WithMany(p => p.CustomerProducts)
            //        .HasForeignKey(d => d.CustomerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Customer_Products_Customer");

            //    entity.HasOne(d => d.Product)
            //        .WithMany(p => p.CustomerProducts)
            //        .HasForeignKey(d => d.ProductId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Customer_Products_Product");
            //});
            #endregion


            #region CustomerProductsRate
            modelBuilder.Entity<CustomerProductsRate>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProductId });

                entity.ToTable("Customer_Products_Rates");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.Feedback)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.RateNumber).HasColumnName("Rate_number");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerProductsRates)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Products_Rates_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CustomerProductsRates)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Products_Rates_Product");
            });
            #endregion


            #region List 
            //modelBuilder.Entity<List>(entity =>
            //{
            //    entity.ToTable("List");

            //    entity.Property(e => e.Id);

            //    entity.Property(e => e.CustomerId).HasColumnName("customer_id");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Privacy)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Customer)
            //        .WithMany(p => p.Lists)
            //        .HasForeignKey(d => d.CustomerId)
            //        .HasConstraintName("FK_List_Customer");
            //});
            #endregion


            #region List Product
            //modelBuilder.Entity<ListProduct>(entity =>
            //{
            //    entity.HasKey(e => new { e.ListId, e.ProductId });

            //    entity.ToTable("List_products");

            //    entity.Property(e => e.ListId).HasColumnName("List_id");

            //    entity.Property(e => e.ProductId).HasColumnName("Product_id");

            //    entity.HasOne(d => d.products)
            //          .WithMany(p => p.listproduct)
            //            .HasForeignKey(d => d.ProductId);

            //    entity.HasOne(d => d.lists)
            //        .WithMany(p => p.listproduct)
            //        .HasForeignKey(d => d.ListId);
            //});
            #endregion


            #region Option
            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("options");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.OptionName)
                    .HasMaxLength(50)
                    //.IsUnicode(false)
                    .HasColumnName("option_name");
            });
            #endregion


            #region Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id);


                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");

                entity.Property(e => e.EstimatedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Estimated_Delivery_Date");

                entity.Property(e => e.OrderAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Order_address");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_date");


                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customer");
            });
            #endregion


            #region  OrderProduct
            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("Order_products");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.orders)
                    .WithMany(p => p.orderproduct)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.products)
                    .WithMany(p => p.orderproduct)
                    .HasForeignKey(d => d.ProductId);

            });
            #endregion


            #region Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id);

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Brand_AR)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(5000);

                entity.Property(e => e.Description_AR)
                    .IsRequired()
                    .HasMaxLength(5000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name_AR)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.SellerId).HasColumnName("Seller_id");

                entity.Property(e => e.Shipping)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Shipping_AR)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.categoryId).HasColumnName("category_id");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Seller");

                entity.HasOne(d => d.category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.categoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_category");
            });
            #endregion


            #region ProductOption
            modelBuilder.Entity<ProductOption>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OptionId });

                entity.ToTable("product_options");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.OptionId).HasColumnName("option_id");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.ProductOptions)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_options_options");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductOptions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_options_Product");
            });
            #endregion


            #region Seller
            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Seller");

                entity.Property(e => e.Id);

                entity.Property(e => e.Address)
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode).HasColumnName("Postal_Code");
            });
            #endregion


            #region SellerContact
            modelBuilder.Entity<SellerContact>(entity =>
            {

                entity.Property(e => e.Id);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(220);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100);

                //entity.HasKey(e => new { e.ContactId, e.SellerId });

                entity.ToTable("Seller_contacts");

                //entity.Property(e => e.ContactId).HasColumnName("Contact_id");

                entity.Property(e => e.SellerId).HasColumnName("Seller_id");

                //entity.HasOne(d => d.Contact)
                //    .WithMany(p => p.SellerContacts)
                //    .HasForeignKey(d => d.ContactId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Seller_contacts_Contact");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.SellerContacts)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seller_contacts_Seller");
            });
            #endregion



            base.OnModelCreating(modelBuilder);
        }
    }
}
