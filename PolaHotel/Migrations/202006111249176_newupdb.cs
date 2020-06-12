namespace PolaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newupdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        phone_Number = c.Int(nullable: false),
                        NationalID = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChickIn = c.DateTime(nullable: false),
                        choutOut = c.DateTime(nullable: false),
                        ReserveDate = c.DateTime(nullable: false),
                        Period = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomNumber, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.RoomNumber);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Room_Number = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        isavailble = c.Boolean(nullable: false),
                        NumberOfBeeds = c.Int(nullable: false),
                        Room_Categ_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Room_Number)
                .ForeignKey("dbo.Room_Category", t => t.Room_Categ_ID, cascadeDelete: true)
                .Index(t => t.Room_Categ_ID);
            
            CreateTable(
                "dbo.Room_Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category_Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomServices",
                c => new
                    {
                        RoomID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        IsAvailble = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomID, t.ServiceID })
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.RoomID)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reservations", "RoomNumber", "dbo.Rooms");
            DropForeignKey("dbo.RoomServices", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.RoomServices", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Room_Categ_ID", "dbo.Room_Category");
            DropForeignKey("dbo.Reservations", "CustomerID", "dbo.Customers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RoomServices", new[] { "ServiceID" });
            DropIndex("dbo.RoomServices", new[] { "RoomID" });
            DropIndex("dbo.Rooms", new[] { "Room_Categ_ID" });
            DropIndex("dbo.Reservations", new[] { "RoomNumber" });
            DropIndex("dbo.Reservations", new[] { "CustomerID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Services");
            DropTable("dbo.RoomServices");
            DropTable("dbo.Room_Category");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.Customers");
        }
    }
}
