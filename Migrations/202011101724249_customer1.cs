namespace BurlOakMovers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        custid = c.Int(nullable: false, identity: true),
                        custname = c.String(),
                        custlname = c.String(),
                        custaddress = c.String(),
                        custcity = c.String(),
                        custpostal = c.String(),
                        custemail = c.String(),
                        custphone = c.String(),
                        custcellphone = c.String(),
                    })
                .PrimaryKey(t => t.custid);
            
            CreateTable(
                "dbo.workorders",
                c => new
                    {
                        workorderid = c.Int(nullable: false, identity: true),
                        custid = c.Int(),
                        numvans = c.Int(),
                        numworker = c.Int(),
                        numhours = c.Double(),
                        payrate = c.Double(),
                        furnishtotal = c.Double(),
                        washer = c.Int(nullable: false),
                        dryer = c.Int(nullable: false),
                        fridge = c.Int(nullable: false),
                        stove = c.Int(nullable: false),
                        dishwasher = c.Int(nullable: false),
                        mircowave = c.Int(nullable: false),
                        freezer = c.Int(nullable: false),
                        pianotype = c.String(),
                        wadrobe = c.String(),
                        mirrorcartons = c.String(),
                        proposalother = c.String(),
                        appliancetotal = c.Double(),
                        deductible = c.Boolean(),
                        deductibleamount = c.Double(),
                        specialins = c.String(),
                        labourhrs = c.Int(),
                        carton2 = c.Int(),
                        carton4 = c.Int(),
                        carton5 = c.Int(),
                        smmirror = c.Int(),
                        lgmirror = c.Int(),
                        sglmatress = c.Int(),
                        dblmatress = c.Int(),
                        kingqeen = c.Int(),
                        wardrobes = c.Int(),
                        totalpackestimate = c.Int(),
                        shipper = c.String(),
                        mover = c.String(),
                        moverrep = c.String(),
                        esttotal = c.Double(),
                        taxrate = c.Double(),
                        total = c.Double(),
                    })
                .PrimaryKey(t => t.workorderid)
                .ForeignKey("dbo.customers", t => t.custid)
                .Index(t => t.custid);
            
            DropTable("dbo.Cals");
        }
        
        public override void Down()
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
            
            DropForeignKey("dbo.workorders", "custid", "dbo.customers");
            DropIndex("dbo.workorders", new[] { "custid" });
            DropTable("dbo.workorders");
            DropTable("dbo.customers");
        }
    }
}
