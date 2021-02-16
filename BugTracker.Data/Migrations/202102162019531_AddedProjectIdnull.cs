namespace BugTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectIdnull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuildError", "ProjectId", "dbo.Project");
            DropIndex("dbo.BuildError", new[] { "ProjectId" });
            AlterColumn("dbo.BuildError", "ProjectId", c => c.Int());
            CreateIndex("dbo.BuildError", "ProjectId");
            AddForeignKey("dbo.BuildError", "ProjectId", "dbo.Project", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildError", "ProjectId", "dbo.Project");
            DropIndex("dbo.BuildError", new[] { "ProjectId" });
            AlterColumn("dbo.BuildError", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.BuildError", "ProjectId");
            AddForeignKey("dbo.BuildError", "ProjectId", "dbo.Project", "ProjectId", cascadeDelete: true);
        }
    }
}
