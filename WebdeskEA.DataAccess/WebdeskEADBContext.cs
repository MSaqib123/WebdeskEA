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

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<BusinessCategory> BusinessCategories { get; set; }

    public virtual DbSet<Coa> Coas { get; set; }

    public virtual DbSet<Coatype> Coatypes { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<InvoiceType> InvoiceTypes { get; set; }

    public virtual DbSet<Ledger> Ledgers { get; set; }

    public virtual DbSet<LedgerDetail> LedgerDetails { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Pi> Pis { get; set; }

    public virtual DbSet<Pidetail> Pidetails { get; set; }

    public virtual DbSet<Po> Pos { get; set; }

    public virtual DbSet<Podetail> Podetails { get; set; }

    public virtual DbSet<Pr> Prs { get; set; }

    public virtual DbSet<Prdetail> Prdetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ReturnType> ReturnTypes { get; set; }

    public virtual DbSet<Si> Sis { get; set; }

    public virtual DbSet<Sidetail> Sidetails { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Sr> Srs { get; set; }

    public virtual DbSet<Srdetail> Srdetails { get; set; }

    public virtual DbSet<StockLedger> StockLedgers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblMainMenu> TblMainMenus { get; set; }

    public virtual DbSet<TblModule> TblModules { get; set; }

    public virtual DbSet<TblPermission> TblPermissions { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VoucherDetail> VoucherDetails { get; set; }

    public virtual DbSet<VoucherType> VoucherTypes { get; set; }

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

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brand__3214EC0785F5EEF5");

            entity.ToTable("Brand");

            entity.Property(e => e.Name).HasMaxLength(100);
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

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Color__3214EC07725BFBBA");

            entity.ToTable("Color");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC07DD00884E");

            entity.ToTable("Company");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07C3F65463");

            entity.ToTable("Customer");

            entity.Property(e => e.Coaid).HasColumnName("COAId");
            entity.Property(e => e.CreditLimit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNo).HasMaxLength(15);
        });

        modelBuilder.Entity<InvoiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceT__3214EC07E12AFFFC");

            entity.ToTable("InvoiceType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Ledger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ledger__3214EC07EA774E83");

            entity.ToTable("Ledger");

            entity.Property(e => e.InvoiceNo).HasMaxLength(50);
        });

        modelBuilder.Entity<LedgerDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LedgerDe__3214EC07820254C7");

            entity.ToTable("LedgerDetail");

            entity.Property(e => e.Coaid).HasColumnName("COAId");
            entity.Property(e => e.CrAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DrAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DrCr).HasMaxLength(2);
            entity.Property(e => e.Remarks).HasMaxLength(255);
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentT__3214EC075B18EC2E");

            entity.ToTable("PaymentType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Pi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PI__3214EC07E0586D5D");

            entity.ToTable("PI");

            entity.Property(e => e.Disc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Poid).HasColumnName("POId");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Pidetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PIDetail__3214EC07984C8F3C");

            entity.ToTable("PIDetail");

            entity.Property(e => e.Piid).HasColumnName("PIId");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Po>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PO__3214EC0756F913E4");

            entity.ToTable("PO");

            entity.Property(e => e.Disc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Podetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PODetail__3214EC07F0237FDA");

            entity.ToTable("PODetail");

            entity.Property(e => e.Poid).HasColumnName("POId");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Pr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PR__3214EC0762F52C1C");

            entity.ToTable("PR");

            entity.Property(e => e.Disc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Prdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRDetail__3214EC07676E54D5");

            entity.ToTable("PRDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Prid).HasColumnName("PRId");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
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

        modelBuilder.Entity<ReturnType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReturnTy__3214EC0754F1B3FD");

            entity.ToTable("ReturnType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Si>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SI__3214EC072FB5BDF8");

            entity.ToTable("SI");

            entity.Property(e => e.Disc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Sidetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SIDetail__3214EC0700AACA42");

            entity.ToTable("SIDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Siid).HasColumnName("SIId");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sizes__3214EC07F8F606BB");

            entity.Property(e => e.Size1)
                .HasMaxLength(50)
                .HasColumnName("Size");
        });

        modelBuilder.Entity<Sr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SR__3214EC073D5957C3");

            entity.ToTable("SR");

            entity.Property(e => e.Disc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Srdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SRDetail__3214EC07747D39CD");

            entity.ToTable("SRDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Srid).HasColumnName("SRId");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<StockLedger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockLed__3214EC07124E6DB3");

            entity.ToTable("StockLedger");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceCode).HasMaxLength(50);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07F948742B");

            entity.ToTable("Supplier");

            entity.Property(e => e.Coaid).HasColumnName("COAId");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNo).HasMaxLength(15);
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

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Department");

            entity.Property(e => e.Department)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TblMainMenu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_MainMenu");

            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.MenuId).ValueGeneratedOnAdd();
            entity.Property(e => e.MenuName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UrlAction)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UrlController)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<TblModule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Module");

            entity.Property(e => e.Icon)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ModuleId).ValueGeneratedOnAdd();
            entity.Property(e => e.ModuleName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<TblPermission>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Permissions");

            entity.Property(e => e.PermissionId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Roles");

            entity.Property(e => e.RoleId).ValueGeneratedOnAdd();
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Users");

            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("Create_at");
            entity.Property(e => e.CreateBy).HasColumnName("Create_by");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastModifiedUserEmail)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("LastModified_UserEmail");
            entity.Property(e => e.LoginEmail)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("login_Email");
            entity.Property(e => e.LoginEnabled).HasColumnName("login_Enabled");
            entity.Property(e => e.LoginId)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("login_Id");
            entity.Property(e => e.LoginName)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("login_Name");
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("login_Password");
            entity.Property(e => e.LoginPhone)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("login_Phone");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("Modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("Modified_by");
            entity.Property(e => e.PasswordChangeDate)
                .HasColumnType("datetime")
                .HasColumnName("password_Change_Date");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Unit__3214EC07E2251808");

            entity.ToTable("Unit");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0777F7C2EF");

            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<VoucherDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VoucherD__3214EC07A78E7233");

            entity.ToTable("VoucherDetail");

            entity.Property(e => e.FromCoa).HasColumnName("FromCOA");
            entity.Property(e => e.InvoiceNo).HasMaxLength(50);
            entity.Property(e => e.ToCoa).HasColumnName("ToCOA");
        });

        modelBuilder.Entity<VoucherType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VoucherT__3214EC07B9CE29F4");

            entity.ToTable("VoucherType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
