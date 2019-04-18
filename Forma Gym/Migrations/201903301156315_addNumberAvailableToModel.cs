namespace Forma_Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberAvailableToModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormaActivities", "NumberAvailable", c => c.Byte(nullable: false));
			Sql("UPDATE FormaActivities SET NumberAvailable = NumberInStock");
		}
        
        public override void Down()
        {
            DropColumn("dbo.FormaActivities", "NumberAvailable");
        }
    }
}
