using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExperisPrueba.Models
{
    public class Entrevista
    {
        [Key]
        [ForeignKey("Candidatos")]
        public int IdCandidato { get; set; }
        [Required(ErrorMessage = "Debe ingresar una fecha valida")]
        [DataType(DataType.Date)]
        [DisplayName("Fecha Entrevista")]
        public string FechaEntrevista { get; set; }
        [Required(ErrorMessage = "Debe Ingresar una hora valida")]
        [DataType(DataType.Time)]
        [DisplayName("Hora Entrevista")]
        public string Horaentrevista { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un tipo de entrevista")]
        [DisplayName("Tipo Entrevista")]
        public string TipoEntrevista { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; } 
    }
}