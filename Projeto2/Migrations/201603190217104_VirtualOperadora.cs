namespace Projeto2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualOperadora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contato", "Operadora_OperadoraID", c => c.Int());
            CreateIndex("dbo.Contato", "Operadora_OperadoraID");
            AddForeignKey("dbo.Contato", "Operadora_OperadoraID", "dbo.Operadora", "OperadoraID");
            DropColumn("dbo.Contato", "OperadoraDoContato");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contato", "OperadoraDoContato", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contato", "Operadora_OperadoraID", "dbo.Operadora");
            DropIndex("dbo.Contato", new[] { "Operadora_OperadoraID" });
            DropColumn("dbo.Contato", "Operadora_OperadoraID");
        }
    }
}
