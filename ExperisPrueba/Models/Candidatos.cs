using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExperisPrueba.Models
{
    public class Candidatos
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Nombre Candidato")]
        public string Nombre { get; set; }
        [DisplayName("Apellido Candidato")]
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string WebSite { get; set; }
    }

}