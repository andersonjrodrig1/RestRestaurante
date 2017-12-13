namespace RestRestaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty_vrPreco_TablePrato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pratoes", "vrPreco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pratoes", "vrPreco");
        }
    }
}
