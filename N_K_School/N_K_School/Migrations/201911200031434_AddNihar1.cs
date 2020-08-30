namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNihar1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Std10_Marks", new[] { "StudentId" });
            DropIndex("dbo.Std8_Marks", new[] { "StudentId" });
            DropIndex("dbo.Std9_Marks", new[] { "StudentId" });
            CreateIndex("dbo.Std10_Marks", "StudentID");
            CreateIndex("dbo.Std8_Marks", "StudentID");
            CreateIndex("dbo.Std9_Marks", "StudentID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Std9_Marks", new[] { "StudentID" });
            DropIndex("dbo.Std8_Marks", new[] { "StudentID" });
            DropIndex("dbo.Std10_Marks", new[] { "StudentID" });
            CreateIndex("dbo.Std9_Marks", "StudentId");
            CreateIndex("dbo.Std8_Marks", "StudentId");
            CreateIndex("dbo.Std10_Marks", "StudentId");
        }
    }
}
