namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNihar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Std10_Marks",
                c => new
                    {
                        Std10Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        English = c.Int(nullable: false),
                        Maths = c.Int(nullable: false),
                        Science = c.Int(nullable: false),
                        SocialScience = c.Int(nullable: false),
                        ExamNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Std10Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Std8_Marks",
                c => new
                    {
                        Std8Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        English = c.Int(nullable: false),
                        Maths = c.Int(nullable: false),
                        Science = c.Int(nullable: false),
                        SocialScience = c.Int(nullable: false),
                        ExamNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Std8Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Std9_Marks",
                c => new
                    {
                        Std9Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        English = c.Int(nullable: false),
                        Maths = c.Int(nullable: false),
                        Science = c.Int(nullable: false),
                        SocialScience = c.Int(nullable: false),
                        ExamNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Std9Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Std9_Marks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Std8_Marks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Std10_Marks", "StudentId", "dbo.Students");
            DropIndex("dbo.Std9_Marks", new[] { "StudentId" });
            DropIndex("dbo.Std8_Marks", new[] { "StudentId" });
            DropIndex("dbo.Std10_Marks", new[] { "StudentId" });
            DropTable("dbo.Std9_Marks");
            DropTable("dbo.Std8_Marks");
            DropTable("dbo.Std10_Marks");
        }
    }
}
