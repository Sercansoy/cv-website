namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateCertificate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certificates", "Date", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Certificates", "Date");
        }
    }
}
