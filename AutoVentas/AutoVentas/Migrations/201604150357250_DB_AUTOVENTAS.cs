namespace AutoVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AUTOVENTAS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Automovils", "idUsuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Automovils", "idUsuario");
        }
    }
}
