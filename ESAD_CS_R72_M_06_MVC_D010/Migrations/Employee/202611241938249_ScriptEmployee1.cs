namespace ESAD_CS_R72_M_06_MVC_D010.Migrations.Employee
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptEmployee1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "IsActive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
