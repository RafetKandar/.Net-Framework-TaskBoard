using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskBoard.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<TeknikKart> teknikKarts { get; set; }
        public DbSet<MüsteriKart> müsteriKarts { get; set; }
        public DbSet<MüsteriKartIsTakibi> müsteriKartIsTakibis { get; set; }
        public DbSet<TeknikKartIsTakibi> teknikKartIsTakibis { get; set; }

    }
}