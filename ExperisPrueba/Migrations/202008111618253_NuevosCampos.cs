namespace ExperisPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevosCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatos", "NombreContacto", c => c.String(nullable: false));
            AddColumn("dbo.Candidatos", "Edad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatos", "Edad");
            DropColumn("dbo.Candidatos", "NombreContacto");
        }
    }
}
