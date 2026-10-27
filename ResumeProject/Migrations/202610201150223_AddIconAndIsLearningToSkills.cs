namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIconAndIsLearningToSkills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Icon", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Skills", "IsLearning", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "IsLearning");
            DropColumn("dbo.Skills", "Icon");
        }
    }
}
