namespace Capstone_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companypersonaluser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.CompanyCompanies", "Company_Id1", "dbo.Companies");
            DropForeignKey("dbo.Companies", "PersonalUser_Id", "dbo.PersonalUsers");
            DropForeignKey("dbo.Companies", "PersonalUser_Id1", "dbo.PersonalUsers");
            DropForeignKey("dbo.PersonalUserPersonalUsers", "PersonalUser_Id", "dbo.PersonalUsers");
            DropForeignKey("dbo.PersonalUserPersonalUsers", "PersonalUser_Id1", "dbo.PersonalUsers");
            DropForeignKey("dbo.PersonalUsers", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.PersonalUsers", "Company_Id1", "dbo.Companies");
            DropIndex("dbo.Companies", new[] { "PersonalUser_Id" });
            DropIndex("dbo.Companies", new[] { "PersonalUser_Id1" });
            DropIndex("dbo.PersonalUsers", new[] { "Company_Id" });
            DropIndex("dbo.PersonalUsers", new[] { "Company_Id1" });
            DropIndex("dbo.CompanyCompanies", new[] { "Company_Id" });
            DropIndex("dbo.CompanyCompanies", new[] { "Company_Id1" });
            DropIndex("dbo.PersonalUserPersonalUsers", new[] { "PersonalUser_Id" });
            DropIndex("dbo.PersonalUserPersonalUsers", new[] { "PersonalUser_Id1" });
            CreateTable(
                "dbo.PersonalUserCompanies",
                c => new
                    {
                        PersonalUser_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonalUser_Id, t.Company_Id })
                .ForeignKey("dbo.PersonalUsers", t => t.PersonalUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.PersonalUser_Id)
                .Index(t => t.Company_Id);
            
            AddColumn("dbo.Companies", "Company_Id", c => c.Int());
            AddColumn("dbo.PersonalUsers", "PersonalUser_Id", c => c.Int());
            CreateIndex("dbo.Companies", "Company_Id");
            CreateIndex("dbo.PersonalUsers", "PersonalUser_Id");
            AddForeignKey("dbo.Companies", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.PersonalUsers", "PersonalUser_Id", "dbo.PersonalUsers", "Id");
            DropColumn("dbo.Companies", "PersonalUser_Id");
            DropColumn("dbo.Companies", "PersonalUser_Id1");
            DropColumn("dbo.PersonalUsers", "Company_Id");
            DropColumn("dbo.PersonalUsers", "Company_Id1");
            DropTable("dbo.CompanyCompanies");
            DropTable("dbo.PersonalUserPersonalUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonalUserPersonalUsers",
                c => new
                    {
                        PersonalUser_Id = c.Int(nullable: false),
                        PersonalUser_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonalUser_Id, t.PersonalUser_Id1 });
            
            CreateTable(
                "dbo.CompanyCompanies",
                c => new
                    {
                        Company_Id = c.Int(nullable: false),
                        Company_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Company_Id, t.Company_Id1 });
            
            AddColumn("dbo.PersonalUsers", "Company_Id1", c => c.Int());
            AddColumn("dbo.PersonalUsers", "Company_Id", c => c.Int());
            AddColumn("dbo.Companies", "PersonalUser_Id1", c => c.Int());
            AddColumn("dbo.Companies", "PersonalUser_Id", c => c.Int());
            DropForeignKey("dbo.PersonalUsers", "PersonalUser_Id", "dbo.PersonalUsers");
            DropForeignKey("dbo.PersonalUserCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.PersonalUserCompanies", "PersonalUser_Id", "dbo.PersonalUsers");
            DropForeignKey("dbo.Companies", "Company_Id", "dbo.Companies");
            DropIndex("dbo.PersonalUserCompanies", new[] { "Company_Id" });
            DropIndex("dbo.PersonalUserCompanies", new[] { "PersonalUser_Id" });
            DropIndex("dbo.PersonalUsers", new[] { "PersonalUser_Id" });
            DropIndex("dbo.Companies", new[] { "Company_Id" });
            DropColumn("dbo.PersonalUsers", "PersonalUser_Id");
            DropColumn("dbo.Companies", "Company_Id");
            DropTable("dbo.PersonalUserCompanies");
            CreateIndex("dbo.PersonalUserPersonalUsers", "PersonalUser_Id1");
            CreateIndex("dbo.PersonalUserPersonalUsers", "PersonalUser_Id");
            CreateIndex("dbo.CompanyCompanies", "Company_Id1");
            CreateIndex("dbo.CompanyCompanies", "Company_Id");
            CreateIndex("dbo.PersonalUsers", "Company_Id1");
            CreateIndex("dbo.PersonalUsers", "Company_Id");
            CreateIndex("dbo.Companies", "PersonalUser_Id1");
            CreateIndex("dbo.Companies", "PersonalUser_Id");
            AddForeignKey("dbo.PersonalUsers", "Company_Id1", "dbo.Companies", "Id");
            AddForeignKey("dbo.PersonalUsers", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.PersonalUserPersonalUsers", "PersonalUser_Id1", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.PersonalUserPersonalUsers", "PersonalUser_Id", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.Companies", "PersonalUser_Id1", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.Companies", "PersonalUser_Id", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.CompanyCompanies", "Company_Id1", "dbo.Companies", "Id");
            AddForeignKey("dbo.CompanyCompanies", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
