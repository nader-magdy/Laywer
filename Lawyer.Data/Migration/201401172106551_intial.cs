namespace Lawyer.Data.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Court",
                c => new
                    {
                        CourtId = c.String(nullable: false, maxLength: 128),
                        CourtName = c.String(),
                        Address = c.String(),
                        LastModified = c.DateTime(),
                        Created = c.DateTime(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CourtId);
            
            CreateTable(
                "dbo.Lawyer",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        Username = c.String(maxLength: 128),
                        Password = c.String(maxLength: 128),
                        LastModified = c.DateTime(),
                        Created = c.DateTime(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Case",
                c => new
                    {
                        CaseId = c.String(nullable: false, maxLength: 128),
                        CaseNumber = c.String(nullable: false, maxLength: 64),
                        CircleId = c.String(maxLength: 128),
                        LastModified = c.DateTime(),
                        Created = c.DateTime(),
                        Lawyer_UserId = c.String(maxLength: 128),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CaseId)
                .ForeignKey("dbo.Circle", t => t.CircleId)
                .ForeignKey("dbo.Lawyer", t => t.Lawyer_UserId)
                .Index(t => t.CircleId)
                .Index(t => t.Lawyer_UserId);
            
            CreateTable(
                "dbo.Circle",
                c => new
                    {
                        CircleId = c.String(nullable: false, maxLength: 128),
                        LastModified = c.DateTime(),
                        Created = c.DateTime(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CircleId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionId = c.String(nullable: false, maxLength: 128),
                        LastModified = c.DateTime(),
                        Created = c.DateTime(),
                        Case_CaseId = c.String(maxLength: 128),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Case", t => t.Case_CaseId)
                .Index(t => t.Case_CaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Case", "Lawyer_UserId", "dbo.Lawyer");
            DropForeignKey("dbo.Session", "Case_CaseId", "dbo.Case");
            DropForeignKey("dbo.Case", "CircleId", "dbo.Circle");
            DropIndex("dbo.Case", new[] { "Lawyer_UserId" });
            DropIndex("dbo.Session", new[] { "Case_CaseId" });
            DropIndex("dbo.Case", new[] { "CircleId" });
            DropTable("dbo.Session");
            DropTable("dbo.Circle");
            DropTable("dbo.Case");
            DropTable("dbo.Lawyer");
            DropTable("dbo.Court");
        }
    }
}
