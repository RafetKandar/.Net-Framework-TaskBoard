using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskBoard.Models.Classes
{
    public class TeknikKart
    {
        [Key]
        public int ID { get; set; }
        public string ProjeNo { get; set; }
        public string TeknikUzman { get; set; }
        public float TahminSüresi { get; set; }
        public float GerçekleşenSüre { get; set; }
        public string IsinAciklamasi { get; set; }
        public string Notlar { get; set; }
        public string Tarih { get; set; }
        public string KartNo { get; set; }

        public int MüsteriKartId { get; set; }

        public virtual MüsteriKart MüsteriKart  { get; set; }

        public ICollection<TeknikKartIsTakibi> TeknikKartIsTakibis { get; set; }

    }
}