namespace Capstone_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.PersonalUserCompanies", "PersonalUser_Id", "dbo.PersonalUsers");
            DropForeignKey("dbo.PersonalUserCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.PersonalUsers", "PersonalUser_Id", "dbo.PersonalUsers");
            DropIndex("dbo.Companies", new[] { "Company_Id" });
            DropIndex("dbo.PersonalUsers", new[] { "PersonalUser_Id" });
            DropIndex("dbo.PersonalUserCompanies", new[] { "PersonalUser_Id" });
            DropIndex("dbo.PersonalUserCompanies", new[] { "Company_Id" });
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
            DropColumn("dbo.Companies", "Company_Id");
            DropColumn("dbo.PersonalUsers", "PersonalUser_Id");
            DropTable("dbo.PersonalUserCompanies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonalUserCompanies",
                c => new
                    {
                        PersonalUser_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonalUser_Id, t.Company_Id });
            
            AddColumn("dbo.PersonalUsers", "PersonalUser_Id", c => c.Int());
            AddColumn("dbo.Companies", "Company_Id", c => c.Int());
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
            CreateIndex("dbo.PersonalUserCompanies", "Company_Id");
            CreateIndex("dbo.PersonalUserCompanies", "PersonalUser_Id");
            CreateIndex("dbo.PersonalUsers", "PersonalUser_Id");
            CreateIndex("dbo.Companies", "Company_Id");
            AddForeignKey("dbo.PersonalUsers", "PersonalUser_Id", "dbo.PersonalUsers", "Id");
            AddForeignKey("dbo.PersonalUserCompanies", "Company_Id", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonalUserCompanies", "PersonalUser_Id", "dbo.PersonalUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Companies", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
