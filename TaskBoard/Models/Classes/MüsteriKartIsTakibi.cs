using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskBoard.Models.Classes
{
    public class MüsteriKartIsTakibi
    {
        [Key]
        public int ID { get; set; }
        public string Tarih { get; set; }
        public string Durum { get; set; }
        public string YapılacakIs { get; set; }
        public string Aciklama { get; set; }

        public int MüsteriKartId { get; set; }

        public virtual MüsteriKart MüsteriKart { get; set; }
    }
}