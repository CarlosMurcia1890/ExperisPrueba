﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperisPrueba.Models
{
    public class Address
    {
        [Key]
        [ForeignKey("Candidatos")]
        public int IdCandidato { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}