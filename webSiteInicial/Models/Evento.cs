using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webSiteInicial.Models
{
    public class Evento
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Data { get; set; }
        public string DobroDe { get; set; }
        
        public int? BandaAberturaID { get; set; }
        [ForeignKey("BandaAberturaID")]
        public virtual Banda BandaAbertura { get; set; }

        public int? BandaPrincipalID { get; set; }
        [Required]
        [ForeignKey("BandaPrincipalID")]
        public virtual Banda BandaPrincipal { get; set; }

        public DiaDaSemana Dia { get; set; }
        public string  LinkFacebook { get; set; }
        public Ambiente Ambiente { get; set; }
    }
    public enum Ambiente
    {
        Pub,
        Club,
        PubClub
    }
    public enum DiaDaSemana
    {
        Quarta,
        Quinta,
        Sexta,
        Sábado,
        Domingo,
        Segunda,
        Terça
    }
}