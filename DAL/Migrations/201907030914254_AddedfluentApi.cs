namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedfluentApi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskCategory", "CategoryName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Task", "TaskDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Task", "UserStory", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.TaskCategory", "CategoryName", unique: true);
            CreateIndex("dbo.User", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.TaskCategory", new[] { "CategoryName" });
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Task", "UserStory", c => c.String(nullable: false));
            AlterColumn("dbo.Task", "TaskDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TaskCategory", "CategoryName", c => c.String(nullable: false));
        }
    }
}
