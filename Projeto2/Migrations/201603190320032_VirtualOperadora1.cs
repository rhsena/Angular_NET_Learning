namespace Projeto2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualOperadora1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contato", "OperadoraID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contato", "OperadoraID");
        }
    }
}
