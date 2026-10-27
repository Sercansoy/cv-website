namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAboutDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "PhoneNumber", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Abouts", "Details", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "Details", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Abouts", "PhoneNumber", c => c.String(maxLength: 11, unicode: false));
        }
    }
}
