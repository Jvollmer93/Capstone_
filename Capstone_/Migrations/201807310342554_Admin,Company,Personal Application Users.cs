namespace Capstone_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminCompanyPersonalApplicationUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Companies", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.PersonalUsers", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Admins", "ApplicationUserID");
            CreateIndex("dbo.Companies", "ApplicationUserID");
            CreateIndex("dbo.PersonalUsers", "ApplicationUserID");
            AddForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Companies", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PersonalUsers", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalUsers", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.PersonalUsers", new[] { "ApplicationUserID" });
            DropIndex("dbo.Companies", new[] { "ApplicationUserID" });
            DropIndex("dbo.Admins", new[] { "ApplicationUserID" });
            DropColumn("dbo.PersonalUsers", "ApplicationUserID");
            DropColumn("dbo.Companies", "ApplicationUserID");
            DropColumn("dbo.Admins", "ApplicationUserID");
        }
    }
}
