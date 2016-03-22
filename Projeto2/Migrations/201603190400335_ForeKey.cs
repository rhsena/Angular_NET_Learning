namespace Projeto2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contato", "Operadora_OperadoraID", "dbo.Operadora");
            DropIndex("dbo.Contato", new[] { "Operadora_OperadoraID" });
            RenameColumn(table: "dbo.Contato", name: "Operadora_OperadoraID", newName: "OperadoraIDContato");
            AlterColumn("dbo.Contato", "OperadoraIDContato", c => c.Int(nullable: false));
            CreateIndex("dbo.Contato", "OperadoraIDContato");
            AddForeignKey("dbo.Contato", "OperadoraIDContato", "dbo.Operadora", "OperadoraID", cascadeDelete: true);
            DropColumn("dbo.Contato", "OperadoraID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contato", "OperadoraID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Contato", "OperadoraIDContato", "dbo.Operadora");
            DropIndex("dbo.Contato", new[] { "OperadoraIDContato" });
            AlterColumn("dbo.Contato", "OperadoraIDContato", c => c.Int());
            RenameColumn(table: "dbo.Contato", name: "OperadoraIDContato", newName: "Operadora_OperadoraID");
            CreateIndex("dbo.Contato", "Operadora_OperadoraID");
            AddForeignKey("dbo.Contato", "Operadora_OperadoraID", "dbo.Operadora", "OperadoraID");
        }
    }
}
