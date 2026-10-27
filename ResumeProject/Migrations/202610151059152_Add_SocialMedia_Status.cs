namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SocialMedia_Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Social_media", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Social_media", "Status");
        }
    }
}
