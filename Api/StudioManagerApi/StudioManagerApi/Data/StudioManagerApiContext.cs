using Microsoft.EntityFrameworkCore;

namespace StudioManagerApi.Data
{

/// <summary>
/// ovdje navodim datasetove i nacine spajanja na bazu
/// </summary>

    public class StudioManagerApiContext:DbContext
    {

/// <summary>
/// konstruktor
/// </summary>
/// <param name="options"></param>

        public StudioManagerApiContext(DbContextOptions<StudioManagerApiContext> options)
            :base(options)
        { 
        
        }

/// <summary>
/// ovo su programi u bazi
/// </summary>

        public DbSet<Program> Programi { get; set; }

    }
}

