namespace Forma_Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteNumberInStockAndAvailableNumber : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FormaActivities", "NumberInStock");
            DropColumn("dbo.FormaActivities", "NumberAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormaActivities", "NumberAvailable", c => c.Byte(nullable: false));
            AddColumn("dbo.FormaActivities", "NumberInStock", c => c.Byte(nullable: false));
        }
    }
}
