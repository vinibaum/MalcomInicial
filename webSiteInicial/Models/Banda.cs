using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webSiteInicial.Models
{
    public class Banda
    {
        [Key]
        public int idBanda { get; set; }
        public string NomeBanda { get; set; }
        public virtual IList<Musico> Integrantes { get; set; }
    }
}