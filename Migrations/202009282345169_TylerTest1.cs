namespace BurlOakMovers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TylerTest1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cals");
        }
    }
}
