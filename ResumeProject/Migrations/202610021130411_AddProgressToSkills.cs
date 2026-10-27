namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgressToSkills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Progress", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "Progress");
        }
    }
}
