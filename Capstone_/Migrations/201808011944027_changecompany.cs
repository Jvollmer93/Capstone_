namespace Capstone_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.CompanyCompanies", "Company_Id1", "dbo.Companies");
            DropIndex("dbo.CompanyCompanies", new[] { "Company_Id" });
            DropIndex("dbo.CompanyCompanies", new[] { "Company_Id1" });
            AddColumn("dbo.Companies", "Company_Id", c => c.Int());
            CreateIndex("dbo.Companies", "Company_Id");
            AddForeignKey("dbo.Companies", "Company_Id", "dbo.Companies", "Id");
            DropTable("dbo.CompanyCompanies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CompanyCompanies",
                c => new
                    {
                        Company_Id = c.Int(nullable: false),
                        Company_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Company_Id, t.Company_Id1 });
            
            DropForeignKey("dbo.Companies", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Companies", new[] { "Company_Id" });
            DropColumn("dbo.Companies", "Company_Id");
            CreateIndex("dbo.CompanyCompanies", "Company_Id1");
            CreateIndex("dbo.CompanyCompanies", "Company_Id");
            AddForeignKey("dbo.CompanyCompanies", "Company_Id1", "dbo.Companies", "Id");
            AddForeignKey("dbo.CompanyCompanies", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
