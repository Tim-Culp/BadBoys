namespace BadBoys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeededTableData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Case",
                c => new
                    {
                        CaseKeyId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        DateOfIncident = c.DateTime(nullable: false),
                        BadgeId = c.Int(nullable: false),
                        SuspectId = c.Int(nullable: false),
                        CrimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CaseKeyId)
                .ForeignKey("dbo.Crime", t => t.CrimeId, cascadeDelete: true)
                .ForeignKey("dbo.Officer", t => t.BadgeId, cascadeDelete: true)
                .ForeignKey("dbo.Suspect", t => t.SuspectId, cascadeDelete: true)
                .Index(t => t.BadgeId)
                .Index(t => t.SuspectId)
                .Index(t => t.CrimeId);
            
            CreateTable(
                "dbo.Crime",
                c => new
                    {
                        CrimeId = c.Int(nullable: false, identity: true),
                        CrimeType = c.Int(nullable: false),
                        CrimeDescription = c.String(nullable: false),
                        Penalty = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CrimeId);
            
            CreateTable(
                "dbo.Officer",
                c => new
                    {
                        BadgeId = c.Int(nullable: false, identity: true),
                        OfficerId = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        RankOfOfficer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BadgeId);
            
            CreateTable(
                "dbo.Suspect",
                c => new
                    {
                        SuspectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Height = c.String(nullable: false),
                        Weight = c.Int(nullable: false),
                        PriorConviction = c.Boolean(nullable: false),
                        DateBooked = c.DateTime(),
                    })
                .PrimaryKey(t => t.SuspectId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Case", "SuspectId", "dbo.Suspect");
            DropForeignKey("dbo.Case", "BadgeId", "dbo.Officer");
            DropForeignKey("dbo.Case", "CrimeId", "dbo.Crime");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Case", new[] { "CrimeId" });
            DropIndex("dbo.Case", new[] { "SuspectId" });
            DropIndex("dbo.Case", new[] { "BadgeId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Suspect");
            DropTable("dbo.Officer");
            DropTable("dbo.Crime");
            DropTable("dbo.Case");
        }
    }
}
