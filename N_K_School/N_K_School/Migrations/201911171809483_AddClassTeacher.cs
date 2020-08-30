namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassTeacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassTeachers",
                c => new
                    {
                        Standards = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Standards)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassTeachers", "TeacherID", "dbo.Teachers");
            DropIndex("dbo.ClassTeachers", new[] { "TeacherID" });
            DropTable("dbo.ClassTeachers");
        }
    }
}
