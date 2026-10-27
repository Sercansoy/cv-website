namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredEducation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "FirstName", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Abouts", "LastName", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Abouts", "Address", c => c.String(nullable: false, maxLength: 70, unicode: false));
            AlterColumn("dbo.Abouts", "PhoneNumber", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Abouts", "EMail", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Educations", "Title", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Educations", "SubTitle", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Educations", "Date", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Messages", "Name", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Messages", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Messages", "Subject", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Messages", "Messages", c => c.String(nullable: false, maxLength: 1000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Messages", c => c.String(maxLength: 1000, unicode: false));
            AlterColumn("dbo.Messages", "Subject", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Messages", "Email", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Messages", "Name", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Educations", "Date", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Educations", "SubTitle", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Educations", "Title", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Abouts", "EMail", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Abouts", "PhoneNumber", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Abouts", "Address", c => c.String(maxLength: 70, unicode: false));
            AlterColumn("dbo.Abouts", "LastName", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Abouts", "FirstName", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
