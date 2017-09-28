namespace CustomerJQX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ab : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Customers", newSchema: "jqx");
            MoveTable(name: "dbo.Orders", newSchema: "jqx");
            MoveTable(name: "dbo.Products", newSchema: "jqx");
            MoveTable(name: "dbo.OrderCourseNew", newSchema: "jqx");
            DropColumn("jqx.Customers", "PhoneNo");
            DropColumn("jqx.Customers", "District");
        }
        
        public override void Down()
        {
            AddColumn("jqx.Customers", "District", c => c.String(maxLength: 40));
            AddColumn("jqx.Customers", "PhoneNo", c => c.String(maxLength: 20));
            MoveTable(name: "jqx.OrderCourseNew", newSchema: "dbo");
            MoveTable(name: "jqx.Products", newSchema: "dbo");
            MoveTable(name: "jqx.Orders", newSchema: "dbo");
            MoveTable(name: "jqx.Customers", newSchema: "dbo");
        }
    }
}
