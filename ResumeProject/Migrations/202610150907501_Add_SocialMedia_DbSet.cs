namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SocialMedia_DbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Social_media",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30, unicode: false),
                        Link = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Social_media");
        }
    }
}
