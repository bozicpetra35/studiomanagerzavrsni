using System.ComponentModel.DataAnnotations;

namespace StudioManager.Models
{

/// <summary>
/// vršna nad klasa zaosnovne atribute
/// </summary>

    public abstract class Entitet
    {

/// <summary>
/// Key oznacava primarni ključ u bazi koji generira vrijednost (1,1)
/// </summary>

        [Key]
        public int Sifra { get; set; }

    }
}
