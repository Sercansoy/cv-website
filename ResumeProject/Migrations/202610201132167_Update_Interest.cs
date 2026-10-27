namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Interest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Interests", "Title", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Interests", "Title", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
