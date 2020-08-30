namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacherSubject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        TeacherID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherID, t.SubjectID })
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.SubjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSubjects", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSubjects", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.TeacherSubjects", new[] { "SubjectID" });
            DropIndex("dbo.TeacherSubjects", new[] { "TeacherID" });
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.Subjects");
        }
    }
}
