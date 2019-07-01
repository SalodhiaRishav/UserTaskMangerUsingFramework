namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimeSpent = c.Int(nullable: false),
                        TaskDate = c.DateTime(nullable: false),
                        ExpectedTime = c.Int(nullable: false),
                        UserStory = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        TaskCategoryID = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TaskCategory", t => t.TaskCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.TaskCategoryID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "UserID", "dbo.User");
            DropForeignKey("dbo.Task", "TaskCategoryID", "dbo.TaskCategory");
            DropIndex("dbo.Task", new[] { "TaskCategoryID" });
            DropIndex("dbo.Task", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Task");
            DropTable("dbo.TaskCategory");
        }
    }
}
