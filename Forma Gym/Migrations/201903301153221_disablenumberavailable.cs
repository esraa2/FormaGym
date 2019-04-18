namespace Forma_Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disablenumberavailable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FormaActivities", "NumberAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormaActivities", "NumberAvailable", c => c.Byte(nullable: false));
        }
    }
}
