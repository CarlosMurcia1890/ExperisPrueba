namespace ExperisPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Obligatorios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entrevistas", "FechaEntrevista", c => c.String(nullable: false));
            AlterColumn("dbo.Entrevistas", "Horaentrevista", c => c.String(nullable: false));
            AlterColumn("dbo.Entrevistas", "TipoEntrevista", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entrevistas", "TipoEntrevista", c => c.String());
            AlterColumn("dbo.Entrevistas", "Horaentrevista", c => c.String());
            AlterColumn("dbo.Entrevistas", "FechaEntrevista", c => c.String());
        }
    }
}
