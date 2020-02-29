namespace HRWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maintablemakeing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveSetings",
                c => new
                    {
                        LeaveSetingId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ApproverId = c.Int(nullable: false),
                        Leavel = c.String(),
                    })
                .PrimaryKey(t => t.LeaveSetingId)
                .ForeignKey("dbo.Employees", t => t.ApproverId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.EmployeeId)
                .Index(t => t.ApproverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveSetings", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.LeaveSetings", "ApproverId", "dbo.Employees");
            DropIndex("dbo.LeaveSetings", new[] { "ApproverId" });
            DropIndex("dbo.LeaveSetings", new[] { "EmployeeId" });
            DropTable("dbo.LeaveSetings");
        }
    }
}
