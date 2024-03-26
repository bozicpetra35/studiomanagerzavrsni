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

        public DbSet<Vjezbac> Vjezbaci { get; set; }

        public DbSet<Grupa> Grupe { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapiranje veze 1:n

            modelBuilder.Entity<Planiprogram>().HasOne(p => p.Trener);
            modelBuilder.Entity<Grupa>().HasOne(g => g.PlaniProgram);

            //mapiranje veze n:n
            //u vjezbacima je prethodna biljeska
            //usingEntity je ovdje jer u bazi imamo posebnu tablicu koju ovdje nismo predstavili pa moramo ovako

            modelBuilder.Entity<Grupa>()
              .HasMany(g => g.Vjezbaci)
              .WithMany(v => v.Grupe)
              .UsingEntity<Dictionary<string, object>>("vjezbacixgrupe",
              vxg => vxg.HasOne<Vjezbac>().WithMany().HasForeignKey("vjezbac"),
              vxg => vxg.HasOne<Grupa>().WithMany().HasForeignKey("grupa"),
              vxg => vxg.ToTable("vjezbacixgrupe")
              );


        }

    }
}
