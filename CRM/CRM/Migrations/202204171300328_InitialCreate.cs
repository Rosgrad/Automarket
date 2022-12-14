namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Targets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        task = c.String(),
                        timestart = c.DateTime(nullable: false),
                        timecom = c.String(),
                        fine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        timeend = c.DateTime(nullable: false),
                        coment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Targets");
        }
    }
}
