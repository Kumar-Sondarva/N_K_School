namespace N_K_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valid2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Phone_Office", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Phone_Office", c => c.String());
        }
    }
}
