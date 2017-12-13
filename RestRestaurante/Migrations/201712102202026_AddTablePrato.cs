namespace RestRestaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePrato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pratoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nmPrato = c.String(),
                        restaurante_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Restaurantes", t => t.restaurante_id)
                .Index(t => t.restaurante_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pratoes", "restaurante_id", "dbo.Restaurantes");
            DropIndex("dbo.Pratoes", new[] { "restaurante_id" });
            DropTable("dbo.Pratoes");
        }
    }
}
