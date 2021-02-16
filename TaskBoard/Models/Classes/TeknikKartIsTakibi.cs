using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskBoard.Models.Classes
{
    public class TeknikKartIsTakibi
    {
        [Key]
        public int ID { get; set; }
        public string Tarih { get; set; }
        public string Durum { get; set; }
        public string YapılacakIs { get; set; }
        public string Aciklama { get; set; }

        public int TeknikKartId { get; set; }

        public virtual TeknikKart TeknikKart { get; set; }
    }
}