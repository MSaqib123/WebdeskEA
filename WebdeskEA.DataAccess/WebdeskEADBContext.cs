using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebdeskEA.Models.ExternalModel;
using WebdeskEA.Models.DbModel;

namespace WebdeskEA.DataAccess;

public partial class WebdeskEADBContext : IdentityDbContext<IdentityUser>//DbContext
{
    public WebdeskEADBContext()
    {
    }

    public WebdeskEADBContext(DbContextOptions<WebdeskEADBContext> options)
        : base(options)
    {
    }
    public DbSet<UserRight> UserRights { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<CompanyUser> CompanyUsers { get; set; }
    public DbSet<ErrorLog> ErrorLogs { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<BusinessCategory> BusinessCategories { get; set; }
    public virtual DbSet<Coa> Coas { get; set; }
    public virtual DbSet<Coatype> Coatypes { get; set; }
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
    public virtual DbSet<User> Users { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=SAQIB\\MSSQLSERVER01;Initial Catalog=WebdeskEA_20240706;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        modelBuilder.Entity<CompanyUser>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<BusinessCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Business__3214EC07AF33CC4E");

            entity.ToTable("BusinessCategory");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Coa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COA__3214EC0720B061A1");

            entity.ToTable("COA");

            entity.Property(e => e.AccountCode).HasMaxLength(50);
            entity.Property(e => e.AccountName).HasMaxLength(100);
            entity.Property(e => e.CoatypeId).HasColumnName("COATypeId");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Credit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Debit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.OpeningBlnc).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Coatype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COAType__3214EC07CFCE9A6D");

            entity.ToTable("COAType");

            entity.Property(e => e.CoatypeName)
                .HasMaxLength(50)
                .HasColumnName("COAType");
        });

   

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC07DD00884E");

            entity.ToTable("Company");

            entity.Property(e => e.Name).HasMaxLength(100);
        });



        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07D5F35AD0");

            entity.ToTable("Product");

            entity.Property(e => e.DesignNumber).HasMaxLength(50);
            entity.Property(e => e.DiscCoaid).HasColumnName("DiscCOAId");
            entity.Property(e => e.ExpenseCoaid).HasColumnName("ExpenseCOAId");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Ppq)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PPQ");
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.PurchaseCoaid).HasColumnName("PurchaseCOAId");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReturnCoaid).HasColumnName("ReturnCOAId");
            entity.Property(e => e.SaleCoaid).HasColumnName("SaleCOAId");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("SKU");
            entity.Property(e => e.WholeSalePrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Sysdiagram>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sysdiagrams");

            entity.Property(e => e.Definition).HasColumnName("definition");
            entity.Property(e => e.DiagramId)
                .ValueGeneratedOnAdd()
                .HasColumnName("diagram_id");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.PrincipalId).HasColumnName("principal_id");
            entity.Property(e => e.Version).HasColumnName("version");
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0777F7C2EF");

            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
