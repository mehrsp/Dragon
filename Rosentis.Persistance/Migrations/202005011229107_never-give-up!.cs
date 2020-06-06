namespace Rosentis.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nevergiveup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "gen.BlobDescriptionMap",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gen.BlobMap",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileName = c.String(),
                        FileStorageName = c.String(),
                        Extension = c.String(),
                        BlobDescriptionId = c.Long(nullable: false),
                        FileType = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gen.BlobDescriptionMap", t => t.BlobDescriptionId)
                .Index(t => t.BlobDescriptionId);
            
            CreateTable(
                "prd.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Logo = c.String(),
                        Priority = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gen.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "gen.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Summary = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "shp.Carts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        CheckedOut = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "shp.CartItems",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        ParentId = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CartId = c.Guid(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("shp.Carts", t => t.CartId)
                .ForeignKey("shp.CartItems", t => t.ParentId)
                .ForeignKey("prd.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ParentId)
                .Index(t => t.CartId);
            
            CreateTable(
                "prd.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        LatestPriceModified = c.DateTime(),
                        Price = c.Int(nullable: false),
                        Discontinued = c.Boolean(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Description = c.String(),
                        Specifications = c.String(),
                        BrandId = c.Int(),
                        SupplierId = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Long(nullable: false),
                        ProductCategoryId = c.Int(),
                        Ranking = c.Double(nullable: false),
                        SoldCount = c.Long(),
                        LikeCount = c.Long(),
                        FavoritCount = c.Long(),
                        IsRemoved = c.Boolean(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Orderable = c.Boolean(nullable: false),
                        Time = c.Long(nullable: false),
                        Picture = c.String(),
                        ParentId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prd.Brands", t => t.BrandId)
                .ForeignKey("sec.Users", t => t.CreatedById)
                .ForeignKey("prd.Products", t => t.ParentId)
                .ForeignKey("prd.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("prj.Suppliers", t => t.SupplierId)
                .Index(t => t.BrandId)
                .Index(t => t.SupplierId)
                .Index(t => t.CreatedById)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "prd.ProductCatalogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        ProductId = c.Long(nullable: false),
                        File = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prd.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "prd.Comments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        ParentId = c.Long(),
                        ProductId = c.Long(nullable: false),
                        MemberId = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prj.Members", t => t.MemberId)
                .ForeignKey("prd.Comments", t => t.ParentId)
                .ForeignKey("prd.Products", t => t.ProductId)
                .Index(t => t.ParentId)
                .Index(t => t.ProductId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "prj.Members",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.String(),
                        MemberType = c.Int(nullable: false),
                        Email = c.String(),
                        NationalCode = c.String(),
                        Phone = c.String(),
                        Description = c.String(),
                        FavoriteColor = c.String(),
                        ProvinceId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gen.Cities", t => t.CityId)
                .ForeignKey("gen.Provinces", t => t.ProvinceId)
                .ForeignKey("sec.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.ProvinceId)
                .Index(t => t.CityId);
            
            CreateTable(
                "gen.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gen.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "gen.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "prj.MemberImportantDates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MemberId = c.Long(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prj.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "sec.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Phone = c.Long(nullable: false),
                        Email = c.String(),
                        UserName = c.String(),
                        DisplayName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LastLoggedIn = c.DateTime(),
                        Password = c.String(),
                        SerialNumber = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Role_Id = c.Int(),
                        Message_Id = c.Guid(),
                        Message_Id1 = c.Guid(),
                        Message_Id2 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Roles", t => t.Role_Id)
                .ForeignKey("msg.MessageMap", t => t.Message_Id)
                .ForeignKey("msg.MessageMap", t => t.Message_Id1)
                .ForeignKey("msg.MessageMap", t => t.Message_Id2)
                .Index(t => t.Role_Id)
                .Index(t => t.Message_Id)
                .Index(t => t.Message_Id1)
                .Index(t => t.Message_Id2);
            
            CreateTable(
                "sec.Permissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Parent_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Permissions", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "sec.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "prd.ProductImages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        ProductId = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prd.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "prd.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(),
                        Priority = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Users", t => t.CreatedById)
                .ForeignKey("prd.ProductCategories", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "prd.ProductCategoryTechnicals",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductCategoryId = c.Int(nullable: false),
                        TechnicalId = c.Int(),
                        BrandId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prd.Brands", t => t.BrandId)
                .ForeignKey("prd.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("prd.Technicals", t => t.TechnicalId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.TechnicalId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "prd.Technicals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prd.Technicals", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "prd.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        TypeId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Product_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prd.TagTypes", t => t.TypeId)
                .ForeignKey("prd.Products", t => t.Product_Id)
                .Index(t => t.TypeId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "prd.TagTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "prd.ProductTechinicals",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ProductId = c.Long(nullable: false),
                        TechnicalId = c.Int(),
                        Description = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prd.Products", t => t.ProductId)
                .ForeignKey("prd.Technicals", t => t.TechnicalId)
                .Index(t => t.ProductId)
                .Index(t => t.TechnicalId);
            
            CreateTable(
                "shp.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Long(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                        CityName = c.String(),
                        ProvinceName = c.String(),
                        Phone = c.Long(nullable: false),
                        Cell = c.Long(nullable: false),
                        Email = c.String(),
                        Notes = c.String(),
                        ProvinceId = c.Int(),
                        CityId = c.Int(),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        Gender = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gen.Cities", t => t.CityId)
                .ForeignKey("shp.Invoices", t => t.Id)
                .ForeignKey("gen.Provinces", t => t.ProvinceId)
                .ForeignKey("sec.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.UserId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CityId);
            
            CreateTable(
                "shp.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        InvoiceNumber = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Notes = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        Paid = c.Boolean(nullable: false),
                        PurchaseType = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "shp.InvoiceDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        InvoiceId = c.Guid(nullable: false),
                        ProductId = c.Long(),
                        ProductInvoiceTypeId = c.Int(nullable: false),
                        ProductNumber = c.String(),
                        ProductName = c.String(),
                        Qauntity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("shp.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("prd.Products", t => t.ProductId)
                .ForeignKey("shp.ProductInvoiceTypes", t => t.ProductInvoiceTypeId)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductInvoiceTypeId);
            
            CreateTable(
                "shp.ProductInvoiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "msg.EmailMap",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreatedById = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Users", t => t.CreatedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "exp.ExceptionCategotys",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "exp.Exceptions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("exp.ExceptionCategotys", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "msg.MessageMap",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        IsFinal = c.Boolean(nullable: false),
                        userId = c.Long(nullable: false),
                        Subject = c.String(),
                        Body = c.String(),
                        IsAction = c.Boolean(nullable: false),
                        ActionDateTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        MessageTypeId = c.Int(nullable: false),
                        ScanId = c.Long(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("msg.MessageTypeMap", t => t.MessageTypeId)
                .ForeignKey("gen.BlobDescriptionMap", t => t.ScanId)
                .ForeignKey("sec.Users", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.MessageTypeId)
                .Index(t => t.ScanId);
            
            CreateTable(
                "msg.MessageTypeMap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gen.Notifications",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        Content = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CheckedDate = c.DateTime(),
                        IsChecked = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "gen.Pages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        PageName = c.String(),
                        Data = c.String(),
                        Metatags = c.String(),
                        Metadescription = c.String(),
                        ItemScope = c.String(),
                        LinkPhoto = c.String(),
                        Votes = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gen.PageUrls",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RawUrl = c.String(),
                        PageTitle = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Count = c.Long(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "prd.ProductRelateds",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Link = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prd.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "shp.Providers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SupplierId = c.Long(nullable: false),
                        SupplierName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Cell = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prj.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "shp.Purchases",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProductNumber = c.String(),
                        ProductName = c.String(),
                        Qauntity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProviderId = c.Guid(nullable: false),
                        CommisionPercentage = c.Int(nullable: false),
                        Notes = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        PurchaseTypeId = c.Int(nullable: false),
                        InvoiceId = c.Guid(nullable: false),
                        CheckedOut = c.Boolean(nullable: false),
                        CheckedOutDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("shp.Invoices", t => t.InvoiceId)
                .ForeignKey("shp.Providers", t => t.ProviderId)
                .ForeignKey("shp.PurchaseTypes", t => t.PurchaseTypeId)
                .Index(t => t.ProviderId)
                .Index(t => t.PurchaseTypeId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "shp.PurchaseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "sec.Sessions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Imei = c.String(),
                        MemberId = c.Long(nullable: false),
                        Token = c.String(),
                        DeviceType = c.String(),
                        DeviceToken = c.String(),
                        LastLoginDate = c.DateTime(),
                        LastOnlineDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prj.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "gen.SlideShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Photo = c.String(),
                        Link = c.String(),
                        Priority = c.Int(nullable: false),
                        CreatedById = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Users", t => t.CreatedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "sec.UserTokens",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        OwnerUserId = c.Long(nullable: false),
                        AccessTokenHash = c.String(),
                        AccessTokenExpirationDateTime = c.DateTime(nullable: false),
                        RefreshTokenIdHash = c.String(),
                        Subject = c.String(),
                        RefreshTokenExpiresUtc = c.DateTime(nullable: false),
                        RefreshToken = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "sec.UserVerifications",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Phone = c.Long(nullable: false),
                        Code = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsValidCode = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gen.VisitorPages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Ip = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        PageUrl_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gen.PageUrls", t => t.PageUrl_Id)
                .Index(t => t.PageUrl_Id);
            
            CreateTable(
                "gen.Visitors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Ip = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "msg.SmsMap",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreatedById = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        To = c.String(),
                        Text = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sec.Users", t => t.CreatedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "prj.MemberProductsFavorite",
                c => new
                    {
                        ProductId = c.Long(nullable: false),
                        MemberId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.MemberId })
                .ForeignKey("prj.Members", t => t.ProductId)
                .ForeignKey("prd.Products", t => t.MemberId)
                .Index(t => t.ProductId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "prj.MemberProductsLike",
                c => new
                    {
                        ProductId = c.Long(nullable: false),
                        MemberId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.MemberId })
                .ForeignKey("prj.Members", t => t.ProductId)
                .ForeignKey("prd.Products", t => t.MemberId)
                .Index(t => t.ProductId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "sec.UserPermissions",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        PermissionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PermissionId })
                .ForeignKey("sec.Users", t => t.UserId)
                .ForeignKey("sec.Permissions", t => t.PermissionId)
                .Index(t => t.UserId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "sec.RolePermissions",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        PermissionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.PermissionId })
                .ForeignKey("sec.Roles", t => t.RoleId)
                .ForeignKey("sec.Permissions", t => t.PermissionId)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "sec.UserRoles",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("sec.Users", t => t.UserId)
                .ForeignKey("sec.Roles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "prj.Suppliers",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        NationalID = c.String(),
                        EconomicCode = c.String(),
                        PostalCode = c.String(),
                        Fax = c.Long(),
                        Website = c.String(),
                        Notes = c.String(),
                        PaymentMethod = c.String(),
                        Logo = c.String(),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        CompanyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prj.Members", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("prj.Suppliers", "Id", "prj.Members");
            DropForeignKey("msg.SmsMap", "CreatedById", "sec.Users");
            DropForeignKey("gen.VisitorPages", "PageUrl_Id", "gen.PageUrls");
            DropForeignKey("gen.SlideShows", "CreatedById", "sec.Users");
            DropForeignKey("sec.Sessions", "MemberId", "prj.Members");
            DropForeignKey("shp.Providers", "SupplierId", "prj.Suppliers");
            DropForeignKey("shp.Purchases", "PurchaseTypeId", "shp.PurchaseTypes");
            DropForeignKey("shp.Purchases", "ProviderId", "shp.Providers");
            DropForeignKey("shp.Purchases", "InvoiceId", "shp.Invoices");
            DropForeignKey("prd.ProductRelateds", "ProductId", "prd.Products");
            DropForeignKey("gen.Notifications", "UserId", "sec.Users");
            DropForeignKey("sec.Users", "Message_Id2", "msg.MessageMap");
            DropForeignKey("msg.MessageMap", "userId", "sec.Users");
            DropForeignKey("msg.MessageMap", "ScanId", "gen.BlobDescriptionMap");
            DropForeignKey("sec.Users", "Message_Id1", "msg.MessageMap");
            DropForeignKey("msg.MessageMap", "MessageTypeId", "msg.MessageTypeMap");
            DropForeignKey("sec.Users", "Message_Id", "msg.MessageMap");
            DropForeignKey("exp.Exceptions", "CategoryId", "exp.ExceptionCategotys");
            DropForeignKey("msg.EmailMap", "CreatedById", "sec.Users");
            DropForeignKey("shp.Customers", "UserId", "sec.Users");
            DropForeignKey("shp.Customers", "ProvinceId", "gen.Provinces");
            DropForeignKey("shp.Customers", "Id", "shp.Invoices");
            DropForeignKey("shp.Invoices", "UserId", "sec.Users");
            DropForeignKey("shp.InvoiceDetails", "ProductInvoiceTypeId", "shp.ProductInvoiceTypes");
            DropForeignKey("shp.InvoiceDetails", "ProductId", "prd.Products");
            DropForeignKey("shp.InvoiceDetails", "InvoiceId", "shp.Invoices");
            DropForeignKey("shp.Customers", "CityId", "gen.Cities");
            DropForeignKey("shp.Carts", "UserId", "sec.Users");
            DropForeignKey("shp.CartItems", "ProductId", "prd.Products");
            DropForeignKey("prd.ProductTechinicals", "TechnicalId", "prd.Technicals");
            DropForeignKey("prd.ProductTechinicals", "ProductId", "prd.Products");
            DropForeignKey("prd.Tags", "Product_Id", "prd.Products");
            DropForeignKey("prd.Tags", "TypeId", "prd.TagTypes");
            DropForeignKey("prd.Products", "SupplierId", "prj.Suppliers");
            DropForeignKey("prd.Products", "ProductCategoryId", "prd.ProductCategories");
            DropForeignKey("prd.ProductCategoryTechnicals", "TechnicalId", "prd.Technicals");
            DropForeignKey("prd.Technicals", "ParentId", "prd.Technicals");
            DropForeignKey("prd.ProductCategoryTechnicals", "ProductCategoryId", "prd.ProductCategories");
            DropForeignKey("prd.ProductCategoryTechnicals", "BrandId", "prd.Brands");
            DropForeignKey("prd.ProductCategories", "ParentId", "prd.ProductCategories");
            DropForeignKey("prd.ProductCategories", "CreatedById", "sec.Users");
            DropForeignKey("prd.Products", "ParentId", "prd.Products");
            DropForeignKey("prd.ProductImages", "ProductId", "prd.Products");
            DropForeignKey("prd.Products", "CreatedById", "sec.Users");
            DropForeignKey("prd.Comments", "ProductId", "prd.Products");
            DropForeignKey("prd.Comments", "ParentId", "prd.Comments");
            DropForeignKey("prd.Comments", "MemberId", "prj.Members");
            DropForeignKey("prj.Members", "Id", "sec.Users");
            DropForeignKey("sec.UserRoles", "RoleId", "sec.Roles");
            DropForeignKey("sec.UserRoles", "UserId", "sec.Users");
            DropForeignKey("sec.Users", "Role_Id", "sec.Roles");
            DropForeignKey("sec.RolePermissions", "PermissionId", "sec.Permissions");
            DropForeignKey("sec.RolePermissions", "RoleId", "sec.Roles");
            DropForeignKey("sec.UserPermissions", "PermissionId", "sec.Permissions");
            DropForeignKey("sec.UserPermissions", "UserId", "sec.Users");
            DropForeignKey("sec.Permissions", "Parent_Id", "sec.Permissions");
            DropForeignKey("prj.Members", "ProvinceId", "gen.Provinces");
            DropForeignKey("prj.MemberProductsLike", "MemberId", "prd.Products");
            DropForeignKey("prj.MemberProductsLike", "ProductId", "prj.Members");
            DropForeignKey("prj.MemberImportantDates", "MemberId", "prj.Members");
            DropForeignKey("prj.MemberProductsFavorite", "MemberId", "prd.Products");
            DropForeignKey("prj.MemberProductsFavorite", "ProductId", "prj.Members");
            DropForeignKey("prj.Members", "CityId", "gen.Cities");
            DropForeignKey("gen.Cities", "ProvinceId", "gen.Provinces");
            DropForeignKey("prd.ProductCatalogs", "ProductId", "prd.Products");
            DropForeignKey("prd.Products", "BrandId", "prd.Brands");
            DropForeignKey("shp.CartItems", "ParentId", "shp.CartItems");
            DropForeignKey("shp.CartItems", "CartId", "shp.Carts");
            DropForeignKey("prd.Brands", "CountryId", "gen.Countries");
            DropForeignKey("gen.BlobMap", "BlobDescriptionId", "gen.BlobDescriptionMap");
            DropIndex("prj.Suppliers", new[] { "Id" });
            DropIndex("sec.UserRoles", new[] { "RoleId" });
            DropIndex("sec.UserRoles", new[] { "UserId" });
            DropIndex("sec.RolePermissions", new[] { "PermissionId" });
            DropIndex("sec.RolePermissions", new[] { "RoleId" });
            DropIndex("sec.UserPermissions", new[] { "PermissionId" });
            DropIndex("sec.UserPermissions", new[] { "UserId" });
            DropIndex("prj.MemberProductsLike", new[] { "MemberId" });
            DropIndex("prj.MemberProductsLike", new[] { "ProductId" });
            DropIndex("prj.MemberProductsFavorite", new[] { "MemberId" });
            DropIndex("prj.MemberProductsFavorite", new[] { "ProductId" });
            DropIndex("msg.SmsMap", new[] { "CreatedById" });
            DropIndex("gen.VisitorPages", new[] { "PageUrl_Id" });
            DropIndex("gen.SlideShows", new[] { "CreatedById" });
            DropIndex("sec.Sessions", new[] { "MemberId" });
            DropIndex("shp.Purchases", new[] { "InvoiceId" });
            DropIndex("shp.Purchases", new[] { "PurchaseTypeId" });
            DropIndex("shp.Purchases", new[] { "ProviderId" });
            DropIndex("shp.Providers", new[] { "SupplierId" });
            DropIndex("prd.ProductRelateds", new[] { "ProductId" });
            DropIndex("gen.Notifications", new[] { "UserId" });
            DropIndex("msg.MessageMap", new[] { "ScanId" });
            DropIndex("msg.MessageMap", new[] { "MessageTypeId" });
            DropIndex("msg.MessageMap", new[] { "userId" });
            DropIndex("exp.Exceptions", new[] { "CategoryId" });
            DropIndex("msg.EmailMap", new[] { "CreatedById" });
            DropIndex("shp.InvoiceDetails", new[] { "ProductInvoiceTypeId" });
            DropIndex("shp.InvoiceDetails", new[] { "ProductId" });
            DropIndex("shp.InvoiceDetails", new[] { "InvoiceId" });
            DropIndex("shp.Invoices", new[] { "UserId" });
            DropIndex("shp.Customers", new[] { "CityId" });
            DropIndex("shp.Customers", new[] { "ProvinceId" });
            DropIndex("shp.Customers", new[] { "UserId" });
            DropIndex("shp.Customers", new[] { "Id" });
            DropIndex("prd.ProductTechinicals", new[] { "TechnicalId" });
            DropIndex("prd.ProductTechinicals", new[] { "ProductId" });
            DropIndex("prd.Tags", new[] { "Product_Id" });
            DropIndex("prd.Tags", new[] { "TypeId" });
            DropIndex("prd.Technicals", new[] { "ParentId" });
            DropIndex("prd.ProductCategoryTechnicals", new[] { "BrandId" });
            DropIndex("prd.ProductCategoryTechnicals", new[] { "TechnicalId" });
            DropIndex("prd.ProductCategoryTechnicals", new[] { "ProductCategoryId" });
            DropIndex("prd.ProductCategories", new[] { "CreatedById" });
            DropIndex("prd.ProductCategories", new[] { "ParentId" });
            DropIndex("prd.ProductImages", new[] { "ProductId" });
            DropIndex("sec.Permissions", new[] { "Parent_Id" });
            DropIndex("sec.Users", new[] { "Message_Id2" });
            DropIndex("sec.Users", new[] { "Message_Id1" });
            DropIndex("sec.Users", new[] { "Message_Id" });
            DropIndex("sec.Users", new[] { "Role_Id" });
            DropIndex("prj.MemberImportantDates", new[] { "MemberId" });
            DropIndex("gen.Cities", new[] { "ProvinceId" });
            DropIndex("prj.Members", new[] { "CityId" });
            DropIndex("prj.Members", new[] { "ProvinceId" });
            DropIndex("prj.Members", new[] { "Id" });
            DropIndex("prd.Comments", new[] { "MemberId" });
            DropIndex("prd.Comments", new[] { "ProductId" });
            DropIndex("prd.Comments", new[] { "ParentId" });
            DropIndex("prd.ProductCatalogs", new[] { "ProductId" });
            DropIndex("prd.Products", new[] { "ParentId" });
            DropIndex("prd.Products", new[] { "ProductCategoryId" });
            DropIndex("prd.Products", new[] { "CreatedById" });
            DropIndex("prd.Products", new[] { "SupplierId" });
            DropIndex("prd.Products", new[] { "BrandId" });
            DropIndex("shp.CartItems", new[] { "CartId" });
            DropIndex("shp.CartItems", new[] { "ParentId" });
            DropIndex("shp.CartItems", new[] { "ProductId" });
            DropIndex("shp.Carts", new[] { "UserId" });
            DropIndex("prd.Brands", new[] { "CountryId" });
            DropIndex("gen.BlobMap", new[] { "BlobDescriptionId" });
            DropTable("prj.Suppliers");
            DropTable("sec.UserRoles");
            DropTable("sec.RolePermissions");
            DropTable("sec.UserPermissions");
            DropTable("prj.MemberProductsLike");
            DropTable("prj.MemberProductsFavorite");
            DropTable("msg.SmsMap");
            DropTable("gen.Visitors");
            DropTable("gen.VisitorPages");
            DropTable("sec.UserVerifications");
            DropTable("sec.UserTokens");
            DropTable("gen.SlideShows");
            DropTable("sec.Sessions");
            DropTable("shp.PurchaseTypes");
            DropTable("shp.Purchases");
            DropTable("shp.Providers");
            DropTable("prd.ProductRelateds");
            DropTable("gen.PageUrls");
            DropTable("gen.Pages");
            DropTable("gen.Notifications");
            DropTable("msg.MessageTypeMap");
            DropTable("msg.MessageMap");
            DropTable("exp.Exceptions");
            DropTable("exp.ExceptionCategotys");
            DropTable("msg.EmailMap");
            DropTable("shp.ProductInvoiceTypes");
            DropTable("shp.InvoiceDetails");
            DropTable("shp.Invoices");
            DropTable("shp.Customers");
            DropTable("prd.ProductTechinicals");
            DropTable("prd.TagTypes");
            DropTable("prd.Tags");
            DropTable("prd.Technicals");
            DropTable("prd.ProductCategoryTechnicals");
            DropTable("prd.ProductCategories");
            DropTable("prd.ProductImages");
            DropTable("sec.Roles");
            DropTable("sec.Permissions");
            DropTable("sec.Users");
            DropTable("prj.MemberImportantDates");
            DropTable("gen.Provinces");
            DropTable("gen.Cities");
            DropTable("prj.Members");
            DropTable("prd.Comments");
            DropTable("prd.ProductCatalogs");
            DropTable("prd.Products");
            DropTable("shp.CartItems");
            DropTable("shp.Carts");
            DropTable("gen.Countries");
            DropTable("prd.Brands");
            DropTable("gen.BlobMap");
            DropTable("gen.BlobDescriptionMap");
        }
    }
}
