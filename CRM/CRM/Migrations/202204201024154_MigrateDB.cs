namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Targets", "timestart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Targets", "timeend", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Targets", "timeend");
            DropColumn("dbo.Targets", "timestart");
        }
    }
}
