namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valid3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "MiddleName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Dob", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "DateOfJoining", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Qualification", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Qualification", c => c.String());
            AlterColumn("dbo.Teachers", "DateOfJoining", c => c.String());
            AlterColumn("dbo.Teachers", "Phone", c => c.String());
            AlterColumn("dbo.Teachers", "Address", c => c.String());
            AlterColumn("dbo.Teachers", "Email", c => c.String());
            AlterColumn("dbo.Teachers", "Dob", c => c.String());
            AlterColumn("dbo.Teachers", "LastName", c => c.String());
            AlterColumn("dbo.Teachers", "MiddleName", c => c.String());
            AlterColumn("dbo.Teachers", "FirstName", c => c.String());
        }
    }
}
