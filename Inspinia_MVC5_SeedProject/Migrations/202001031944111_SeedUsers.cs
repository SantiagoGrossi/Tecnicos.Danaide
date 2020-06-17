namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2524aac1-4c25-4c87-9829-d6fa7ee9d5bc', NULL, 0, N'AMl9NQbj9tGJPTFxbxTAEi9ftP1mYR/tIdYf4gamdpoiU1P5k8235Lwfbz9EPC3gXg==', N'86ef922a-bf8f-43d7-9352-0522f06c366c', NULL, 0, 0, NULL, 0, 0, N'webapplayers')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4cb0d4c7-3bb4-43ee-92f4-32694111efb7', NULL, 0, N'ANWGI+uzFWiKqmTb8EkzEHpivifNoP8GpSjfVB4bSv7KeQJHdM0EN77hVGLVPBqvKQ==', N'b5415db6-d754-45bc-8ce7-f72f3a70f220', NULL, 0, 0, NULL, 0, 0, N'admin@danaide.com.ar')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'60e3cebb-32b2-4d1b-a65a-7c24a4ac26fc', NULL, 0, N'AM820M5Q5L6zna2L0KvkciJbCR32MMAL9iLQns5C3/A+Mk5cHMlJCg5s+b7awhDvWQ==', N'a7bb9d9f-b1d1-4c16-9452-aad0204eaea6', NULL, 0, 0, NULL, 0, 0, N'cetchechuri@danaide.com.ar')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'77c37ba3-0c6a-4419-adc1-e2773533bdfc', NULL, 0, N'AHsJoSJzpMdQLE1o0zRoLul1Fl/8hi09o0p2OaeNMFwnYweCYRucFti7YsSejNKOQg==', N'0f2fb379-1164-43b3-9ca6-0145ae293b34', NULL, 0, 0, NULL, 0, 0, N'dgiaquinta@danaide.com.ar')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2123fd27-9bf3-47f4-9a4e-02caeddb3aa3', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4cb0d4c7-3bb4-43ee-92f4-32694111efb7', N'2123fd27-9bf3-47f4-9a4e-02caeddb3aa3')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'60e3cebb-32b2-4d1b-a65a-7c24a4ac26fc', N'2123fd27-9bf3-47f4-9a4e-02caeddb3aa3')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'77c37ba3-0c6a-4419-adc1-e2773533bdfc', N'2123fd27-9bf3-47f4-9a4e-02caeddb3aa3')


");
        }
        
        public override void Down()
        {
        }
    }
}
