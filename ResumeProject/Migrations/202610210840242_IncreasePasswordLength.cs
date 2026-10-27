namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreasePasswordLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
