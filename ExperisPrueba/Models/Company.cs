using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExperisPrueba.Models
{
    public class Company
    {
        [Key]
        [ForeignKey("Candidatos")]
        public int IdCandidato { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }

    }
}