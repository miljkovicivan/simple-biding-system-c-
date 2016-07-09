namespace iep_projekat_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsauctionorderbid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        creation_datetime = c.DateTime(nullable: false),
                        auction_Id = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.auction_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.auction_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        product_name = c.String(),
                        duration = c.Double(nullable: false),
                        price = c.Double(nullable: false),
                        creation_datetime = c.DateTime(nullable: false),
                        opening_datetime = c.DateTime(nullable: false),
                        closure_datetime = c.DateTime(nullable: false),
                        active = c.Boolean(nullable: false),
                        state = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tokens = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        status = c.String(),
                        creation_datetime = c.DateTime(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            AddColumn("dbo.AspNetUsers", "fname", c => c.String());
            AddColumn("dbo.AspNetUsers", "lname", c => c.String());
            AddColumn("dbo.AspNetUsers", "tokens", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bids", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bids", "auction_Id", "dbo.Auctions");
            DropIndex("dbo.Orders", new[] { "user_Id" });
            DropIndex("dbo.Bids", new[] { "user_Id" });
            DropIndex("dbo.Bids", new[] { "auction_Id" });
            DropColumn("dbo.AspNetUsers", "tokens");
            DropColumn("dbo.AspNetUsers", "lname");
            DropColumn("dbo.AspNetUsers", "fname");
            DropTable("dbo.Orders");
            DropTable("dbo.Auctions");
            DropTable("dbo.Bids");
        }
    }
}
