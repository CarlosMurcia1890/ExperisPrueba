namespace ExperisPrueba.Datos
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ExperisPrueba.Models;

    public class AccesoDatos : DbContext
    {        
        public AccesoDatos()
            : base("name=DbDatos")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Entrevista> Entrevistas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbContext>(null);
            base.OnModelCreating(modelBuilder);
        }



    }

   
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}