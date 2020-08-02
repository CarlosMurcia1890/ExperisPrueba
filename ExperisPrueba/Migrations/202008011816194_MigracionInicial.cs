namespace ExperisPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        IdCandidato = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Suite = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.IdCandidato);
            
            CreateTable(
                "dbo.Candidatos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Correo = c.String(),
                        Telefono = c.String(),
                        WebSite = c.String(),
                        Address_IdCandidato = c.Int(),
                        Company_IdCandidato = c.Int(),
                        Entrevista_IdCandidato = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Addresses", t => t.Address_IdCandidato)
                .ForeignKey("dbo.Companies", t => t.Company_IdCandidato)
                .ForeignKey("dbo.Entrevistas", t => t.Entrevista_IdCandidato)
                .Index(t => t.Address_IdCandidato)
                .Index(t => t.Company_IdCandidato)
                .Index(t => t.Entrevista_IdCandidato);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        IdCandidato = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CatchPhrase = c.String(),
                        Bs = c.String(),
                    })
                .PrimaryKey(t => t.IdCandidato);
            
            CreateTable(
                "dbo.Entrevistas",
                c => new
                    {
                        IdCandidato = c.Int(nullable: false, identity: true),
                        FechaEntrevista = c.String(),
                        Horaentrevista = c.String(),
                    })
                .PrimaryKey(t => t.IdCandidato);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatos", "Entrevista_IdCandidato", "dbo.Entrevistas");
            DropForeignKey("dbo.Candidatos", "Company_IdCandidato", "dbo.Companies");
            DropForeignKey("dbo.Candidatos", "Address_IdCandidato", "dbo.Addresses");
            DropIndex("dbo.Candidatos", new[] { "Entrevista_IdCandidato" });
            DropIndex("dbo.Candidatos", new[] { "Company_IdCandidato" });
            DropIndex("dbo.Candidatos", new[] { "Address_IdCandidato" });
            DropTable("dbo.Entrevistas");
            DropTable("dbo.Companies");
            DropTable("dbo.Candidatos");
            DropTable("dbo.Addresses");
        }
    }
}
