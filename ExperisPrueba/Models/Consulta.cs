using System.ComponentModel;

namespace ExperisPrueba.Models
{
    public class Consulta
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string WebSite { get; set; }
        public int IdCandidato { get; set; }
        [DisplayName("Fecha Entrevista")]
        public string FechaEntrevista { get; set; }
        [DisplayName("Hora Entrevista")]
        public string Horaentrevista { get; set; }
        [DisplayName("Tipo Entrevista")]
        public string TipoEntrevista { get; set; }
        [DisplayName("Nombre Contacto")]
        public string NombreContacto { get; set; }
        public int Edad { get; set; }
    }
}