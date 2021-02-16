using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskBoard.Models.Classes
{
    public class MüsteriKart
    {
        [Key]
        public int ID { get; set; }
        public string ReferansNo { get; set; }
        public string ProjeNo { get; set; }
        public string DolduranMusteri { get; set; }
        public string DolduranBimar { get; set; }
        public string Tarih { get; set; }
        public string KartNo { get; set; }
        public string EkDokuman { get; set; }
        public float TeknikST { get; set; }
        public string Risk { get; set; }
        public string IslemTipi { get; set; }
        public string Oncelik { get; set; }
        public string IsinAciklamasi { get; set; }
        public string Notlar { get; set; }
        public ICollection<TeknikKart> TeknikKarts { get; set; }
        public ICollection<MüsteriKartIsTakibi> MüsteriKartIsTakibis { get; set; }

    }

}