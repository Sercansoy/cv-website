namespace ResumeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20, unicode: false),
                        LastName = c.String(maxLength: 20, unicode: false),
                        Address = c.String(maxLength: 70, unicode: false),
                        PhoneNumber = c.String(maxLength: 11, unicode: false),
                        EMail = c.String(maxLength: 30, unicode: false),
                        Details = c.String(maxLength: 500, unicode: false),
                        ImageUrl = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        User = c.String(maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.CertificateID);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100, unicode: false),
                        SubTitle = c.String(maxLength: 100, unicode: false),
                        Date = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.EducationID);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100, unicode: false),
                        Company = c.String(maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                        Date = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ExperienceID);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.InterestID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Subject = c.String(maxLength: 100, unicode: false),
                        Messages = c.String(maxLength: 1000, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.MessageID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Skill = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
            DropTable("dbo.Messages");
            DropTable("dbo.Interests");
            DropTable("dbo.Experiences");
            DropTable("dbo.Educations");
            DropTable("dbo.Certificates");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
