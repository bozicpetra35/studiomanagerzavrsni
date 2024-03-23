using Microsoft.EntityFrameworkCore;
using StudioManager.Models;

namespace StudioManager.Data
{

/// <summary>
/// ovdje navodim datasetove i nacine spajanja u bazi
/// </summary>

    public class StudioManagerContext:DbContext
    {
/// <summary>
        /// konstruktor
        /// prosljedili smo mu opcije definirane u programu
        /// </summary>
        /// 

        public StudioManagerContext(DbContextOptions<StudioManagerContext> options)
            :base(options)
        { 
        
        }

/// <summary>
/// programi u bazi
/// preimenovala sam program u planiprogram jer se poistovjecivalo s program.scom
/// </summary>

        public DbSet<Planiprogram> Planiprogrami { get; set; }

        public DbSet<Trener> Treneri { get; set; }

    }
}
