namespace ExperisPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoEntrevista : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entrevistas", "TipoEntrevista", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entrevistas", "TipoEntrevista");
        }
    }
}
