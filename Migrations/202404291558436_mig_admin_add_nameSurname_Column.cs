namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_add_nameSurname_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "NameSurname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "NameSurname");
        }
    }
}
