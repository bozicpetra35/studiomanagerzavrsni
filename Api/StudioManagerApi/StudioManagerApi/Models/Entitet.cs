using System.ComponentModel.DataAnnotations;

namespace StudioManagerApi.Models
{

/// <summary>
        /// Ovo je vršna nad klasa koja služi za osnovne atribute
        /// tipa sifra, operater, datum unosa, promjene, itd.
        /// </summary>

/// <summary>
            /// Ovo svojstvo mi služi kao primarni ključ u bazi s generiranjem vrijednosti identity(1,1)
            /// </summary>
                       
     public abstract class Entitet
     {    
            [Key]
            public int Sifra { get; set; }
     

     }
}
