namespace Forma_Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rental : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NewRentals", newName: "Rentals");
            AddColumn("dbo.FormaActivities", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.FormaActivities", "NumberAvailable", c => c.Byte(nullable: false));
			Sql("UPDATE FormaActivities SET NumberAvailable = NumberInStock");
		}
        
        public override void Down()
        {
            DropColumn("dbo.FormaActivities", "NumberAvailable");
            DropColumn("dbo.FormaActivities", "NumberInStock");
            RenameTable(name: "dbo.Rentals", newName: "NewRentals");
        }
    }
}
