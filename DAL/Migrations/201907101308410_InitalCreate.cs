namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CategoryName, unique: true);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeSpent = c.Int(nullable: false),
                        TaskDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpectedTime = c.Int(nullable: false),
                        UserStory = c.String(nullable: false, maxLength: 200),
                        UserId = c.Int(nullable: false),
                        TaskCategoryId = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskCategory", t => t.TaskCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TaskCategoryId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "UserId", "dbo.User");
            DropForeignKey("dbo.Task", "TaskCategoryId", "dbo.TaskCategory");
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.Task", new[] { "TaskCategoryId" });
            DropIndex("dbo.Task", new[] { "UserId" });
            DropIndex("dbo.TaskCategory", new[] { "CategoryName" });
            DropTable("dbo.User");
            DropTable("dbo.Task");
            DropTable("dbo.TaskCategory");
        }
    }
}
