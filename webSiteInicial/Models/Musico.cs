using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webSiteInicial.Models
{
    public class Musico
    {
        [Key]
        public int idMusico { get; set; }
        public string NomeMusico { get; set; }
        public Instrumento Toca  { get; set; }
        
        public int? BandaPrincipalID { get; set; }

        [Required]
        [ForeignKey("BandaPrincipalID")]
        public virtual Banda BandaPrincipal { get; set; }
    }

    public enum Instrumento
    {
        Guitarra,
        Baixo,
        Bateria
    }
}