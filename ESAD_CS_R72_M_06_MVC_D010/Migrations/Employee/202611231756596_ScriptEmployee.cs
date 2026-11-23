namespace ESAD_CS_R72_M_06_MVC_D010.Migrations.Employee
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeQualifications",
                c => new
                    {
                        EmployeeQualificationId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        QualificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeQualificationId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.QualificationId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.QualificationId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        JoinDate = c.DateTime(nullable: false, storeType: "date"),
                        Salary = c.Decimal(nullable: false, storeType: "money"),
                        Picture = c.String(),
                        IsActive = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        QualificationId = c.Int(nullable: false, identity: true),
                        QualificationName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.QualificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeQualifications", "QualificationId", "dbo.Qualifications");
            DropForeignKey("dbo.EmployeeQualifications", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeQualifications", new[] { "QualificationId" });
            DropIndex("dbo.EmployeeQualifications", new[] { "EmployeeId" });
            DropTable("dbo.Qualifications");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeQualifications");
        }
    }
}
