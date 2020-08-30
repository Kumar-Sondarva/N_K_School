namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Dob = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Gender = c.Int(nullable: false),
                        DateOfJoining = c.String(),
                        Qualification = c.String(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
