namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Dob", c => c.String());
            AlterColumn("dbo.Students", "Phone_Home", c => c.String());
            AlterColumn("dbo.Students", "Phone_Office", c => c.String());
            AlterColumn("dbo.Students", "DateOfAdmission", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfAdmission", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Phone_Office", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Phone_Home", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
