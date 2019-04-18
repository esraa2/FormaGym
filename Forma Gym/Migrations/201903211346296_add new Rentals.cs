namespace Forma_Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Activity_Id = c.Int(nullable: false),
                        Subscriber_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormaActivities", t => t.Activity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subscribers", t => t.Subscriber_Id, cascadeDelete: true)
                .Index(t => t.Activity_Id)
                .Index(t => t.Subscriber_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewRentals", "Subscriber_Id", "dbo.Subscribers");
            DropForeignKey("dbo.NewRentals", "Activity_Id", "dbo.FormaActivities");
            DropIndex("dbo.NewRentals", new[] { "Subscriber_Id" });
            DropIndex("dbo.NewRentals", new[] { "Activity_Id" });
            DropTable("dbo.NewRentals");
        }
    }
}
