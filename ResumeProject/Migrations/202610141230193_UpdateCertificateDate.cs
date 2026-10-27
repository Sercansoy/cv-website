namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCertificateDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Certificates", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Certificates", "Date", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
