namespace Capstone_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                        AcceptsTextNotifications = c.Boolean(nullable: false),
                        AcceptsEmailNotifications = c.Boolean(nullable: false),
                        PersonalUser_Id = c.Int(),
                        PersonalUser_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalUsers", t => t.PersonalUser_Id)
                .ForeignKey("dbo.PersonalUsers", t => t.PersonalUser_Id1)
                .Index(t => t.PersonalUser_Id)
                .Index(t => t.PersonalUser_Id1);
            
            CreateTable(
                "dbo.PersonalUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        AcceptsTextNotifications = c.Boolean(nullable: false),
                        AcceptsEmailNotifications = c.Boolean(nullable: false),
                        Company_Id = c.Int(),
                        Company_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id1)
                .Index(t => t.Company_Id)
                .Index(t => t.Company_Id1);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CompanyCompanies",
                c => new
                    {
                        Company_Id = c.Int(nullable: false),
                        Company_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Company_Id, t.Company_Id1 })
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id1)
                .Index(t => t.Company_Id)
                .Index(t => t.Company_Id1);
            
            CreateTable(
                "dbo.PersonalUserPersonalUsers",
                c => new
                    {
                        PersonalUser_Id = c.Int(nullable: false),
                        PersonalUser_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonalUser_Id, t.PersonalUser_Id1 })
                .ForeignKey("dbo.PersonalUsers", t => t.PersonalUser_Id)
                .ForeignKey("dbo.PersonalUsers", t => t.PersonalUser_Id1)
                .Index(t => t.PersonalUser_Id)
                .Index(t => t.PersonalUser_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PersonalUsers", "Company_Id1", "dbo.Companies");
            DropForeignKey("dbo.PersonalUsers", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.PersonalUserPersonalUsers", "PersonalUser_Id1", "dbo.PersonalUsers");
            DropForeignKey("dbo.PersonalUserPersonalUsers", "PersonalUser_Id", "dbo.PersonalUsers");
            DropForeignKey("dbo.Companies", "PersonalUser_Id1", "dbo.PersonalUsers");
            DropForeignKey("dbo.Companies", "PersonalUser_Id", "dbo.PersonalUsers");
            DropForeignKey("dbo.CompanyCompanies", "Company_Id1", "dbo.Companies");
            DropForeignKey("dbo.CompanyCompanies", "Company_Id", "dbo.Companies");
            DropIndex("dbo.PersonalUserPersonalUsers", new[] { "PersonalUser_Id1" });
            DropIndex("dbo.PersonalUserPersonalUsers", new[] { "PersonalUser_Id" });
            DropIndex("dbo.CompanyCompanies", new[] { "Company_Id1" });
            DropIndex("dbo.CompanyCompanies", new[] { "Company_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PersonalUsers", new[] { "Company_Id1" });
            DropIndex("dbo.PersonalUsers", new[] { "Company_Id" });
            DropIndex("dbo.Companies", new[] { "PersonalUser_Id1" });
            DropIndex("dbo.Companies", new[] { "PersonalUser_Id" });
            DropTable("dbo.PersonalUserPersonalUsers");
            DropTable("dbo.CompanyCompanies");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Events");
            DropTable("dbo.PersonalUsers");
            DropTable("dbo.Companies");
            DropTable("dbo.Admins");
        }
    }
}
