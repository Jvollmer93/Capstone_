namespace Capstone_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.AspNetUsers", "Company_Id1", "dbo.Companies");
            DropForeignKey("dbo.Companies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PersonalUser_Id", "dbo.PersonalUsers");
            DropForeignKey("dbo.AspNetUsers", "PersonalUser_Id1", "dbo.PersonalUsers");
            DropForeignKey("dbo.PersonalUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalUsers", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Company_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonalUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonalUser_Id1" });
            DropIndex("dbo.Companies", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Companies", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.PersonalUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PersonalUsers", new[] { "ApplicationUser_Id1" });
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
            
            AddColumn("dbo.Companies", "PersonalUser_Id", c => c.Int());
            AddColumn("dbo.Companies", "PersonalUser_Id1", c => c.Int());
            AddColumn("dbo.PersonalUsers", "Company_Id", c => c.Int());
            AddColumn("dbo.PersonalUsers", "Company_Id1", c => c.Int());
            CreateIndex("dbo.Companies", "PersonalUser_Id");
            CreateIndex("dbo.Companies", "PersonalUser_Id1");
            CreateIndex("dbo.PersonalUsers", "Company_Id");
            CreateIndex("dbo.PersonalUsers", "Company_Id1");
            AddForeignKey("dbo.Companies", "PersonalUser_Id", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.Companies", "PersonalUser_Id1", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.PersonalUsers", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.PersonalUsers", "Company_Id1", "dbo.Companies", "Id");
            DropColumn("dbo.AspNetUsers", "Company_Id");
            DropColumn("dbo.AspNetUsers", "Company_Id1");
            DropColumn("dbo.AspNetUsers", "PersonalUser_Id");
            DropColumn("dbo.AspNetUsers", "PersonalUser_Id1");
            DropColumn("dbo.Companies", "ApplicationUser_Id");
            DropColumn("dbo.Companies", "ApplicationUser_Id1");
            DropColumn("dbo.PersonalUsers", "ApplicationUser_Id");
            DropColumn("dbo.PersonalUsers", "ApplicationUser_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalUsers", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.PersonalUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Companies", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.Companies", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "PersonalUser_Id1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "PersonalUser_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Company_Id1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Company_Id", c => c.Int());
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
            DropIndex("dbo.PersonalUsers", new[] { "Company_Id1" });
            DropIndex("dbo.PersonalUsers", new[] { "Company_Id" });
            DropIndex("dbo.Companies", new[] { "PersonalUser_Id1" });
            DropIndex("dbo.Companies", new[] { "PersonalUser_Id" });
            DropColumn("dbo.PersonalUsers", "Company_Id1");
            DropColumn("dbo.PersonalUsers", "Company_Id");
            DropColumn("dbo.Companies", "PersonalUser_Id1");
            DropColumn("dbo.Companies", "PersonalUser_Id");
            DropTable("dbo.PersonalUserPersonalUsers");
            DropTable("dbo.CompanyCompanies");
            CreateIndex("dbo.PersonalUsers", "ApplicationUser_Id1");
            CreateIndex("dbo.PersonalUsers", "ApplicationUser_Id");
            CreateIndex("dbo.Companies", "ApplicationUser_Id1");
            CreateIndex("dbo.Companies", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "PersonalUser_Id1");
            CreateIndex("dbo.AspNetUsers", "PersonalUser_Id");
            CreateIndex("dbo.AspNetUsers", "Company_Id1");
            CreateIndex("dbo.AspNetUsers", "Company_Id");
            AddForeignKey("dbo.PersonalUsers", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PersonalUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "PersonalUser_Id1", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "PersonalUser_Id", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.Companies", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Companies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Company_Id1", "dbo.Companies", "Id");
            AddForeignKey("dbo.AspNetUsers", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
