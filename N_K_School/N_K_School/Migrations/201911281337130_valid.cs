namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "MiddleName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Dob", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Phone_Home", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "DateOfAdmission", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfAdmission", c => c.String());
            AlterColumn("dbo.Students", "Phone_Home", c => c.String());
            AlterColumn("dbo.Students", "Address", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Dob", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "MiddleName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
        }
    }
}
