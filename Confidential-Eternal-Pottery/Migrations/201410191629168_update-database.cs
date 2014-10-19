namespace ConfidentialEternalPottery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        Street = c.String(),
                        Number = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Bookings", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        BillingAddressId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Email = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BackAccount = c.String(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuestId)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Capacity = c.Byte(nullable: false),
                        Number = c.Int(nullable: false),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.PriceMoments",
                c => new
                    {
                        PriceMomentId = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PriceMomentId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.Bookings");
            DropForeignKey("dbo.PriceMoments", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Guests", "BookingId", "dbo.Bookings");
            DropIndex("dbo.PriceMoments", new[] { "RoomId" });
            DropIndex("dbo.Guests", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropIndex("dbo.Addresses", new[] { "AddressId" });
            DropTable("dbo.PriceMoments");
            DropTable("dbo.Rooms");
            DropTable("dbo.Guests");
            DropTable("dbo.Bookings");
            DropTable("dbo.Addresses");
        }
    }
}
