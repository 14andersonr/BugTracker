namespace BugTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorsandProjects : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BuildError", newName: "Error");
            AddColumn("dbo.Error", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Error", "LineNumber", c => c.Int());
            AlterColumn("dbo.Error", "BuildErrorMessage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Error", "BuildErrorMessage", c => c.String(nullable: false));
            AlterColumn("dbo.Error", "LineNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Error", "Discriminator");
            RenameTable(name: "dbo.Error", newName: "BuildError");
        }
    }
}
