namespace HRWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.DepartmetnEmployees",
                c => new
                    {
                        DepartmentEmployeeId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        IsPrimaryDepartment = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentEmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        IsLeaveApprover = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateIndex("dbo.Departments", "CompanyId");
            AddForeignKey("dbo.Departments", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmetnEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DepartmetnEmployees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "CompanyId", "dbo.Companies");
            DropIndex("dbo.DepartmetnEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.DepartmetnEmployees", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "CompanyId" });
            DropTable("dbo.Employees");
            DropTable("dbo.DepartmetnEmployees");
            DropTable("dbo.Companies");
        }
    }
}
