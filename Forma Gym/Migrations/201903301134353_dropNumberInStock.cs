namespace Forma_Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropNumberInStock : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
			DropColumn("dbo.FormaActivities", "NumberAvailable");
		}
    }
}
