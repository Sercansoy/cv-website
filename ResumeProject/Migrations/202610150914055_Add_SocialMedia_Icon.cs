namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SocialMedia_Icon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Social_media", "Icon", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Social_media", "Icon");
        }
    }
}
