namespace Forma_Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class solvedeleteditems : DbMigration
    {
        public override void Up()
        {
			Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'040c7598-1a4a-4744-9f51-2e59980d8c96', N'Esraa_ali.94@gmail.com', 0, N'AHcvdecT/yzCVxrL0sNMv7OVUamUtq4fIuKvBu2PyLpMA47NGPjfWpcm3MAH3vYFIA==', N'6a189572-b147-40ef-9f73-3eab8e31fc61', NULL, 0, 0, NULL, 1, 0, N'Esraa_ali.94@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3ba8afa2-4309-4c33-b661-ec5ded49f740', N'Admin@FormaGym.com', 0, N'AHwyL7TkANhQ1UE3bJEzKwy2a+2MoKyBNfYwYCRLCvBLdZhyWSsDr8s4lp2H/izDKg==', N'99e57e63-bede-493b-91d4-415390ee162b', NULL, 0, 0, NULL, 1, 0, N'Admin@FormaGym.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd77daebd-004a-4803-934e-d0882a061f47', N'ManageActivities')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3ba8afa2-4309-4c33-b661-ec5ded49f740', N'd77daebd-004a-4803-934e-d0882a061f47')

");
		}
        
        public override void Down()
        {
        }
    }
}
