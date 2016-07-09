namespace iep_projekat_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_enum_state : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auctions", "state", c => c.Int());
            AlterColumn("dbo.Orders", "status", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "status", c => c.String());
            AlterColumn("dbo.Auctions", "state", c => c.String());
        }
    }
}
