using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webSiteInicial.Models
{
    public class ArteEvento
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public bool isArtePrincipal { get; set; }

        public bool Ativa { get; set; }

        public DateTime? DataExpira { get; set; }
        
        [Display(Name = "Arquivo")]        
        public string CaminhoArquivo { get; set; }

        [Required]
        [Display(Name = "Evento")]
        public int EventoID { get; set; }
        
        [ForeignKey("EventoID")]
        public virtual Evento Evento { get; set; }

        //[NotMapped]
        //[Display(Name = "File")]
        //public HttpPostedFileBase File { get; set; }
    }
}