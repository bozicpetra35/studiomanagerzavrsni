using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudioManager.Models
{
    public class Planiprogram:Entitet
    {
        [Required(ErrorMessage = "Naziv obavezan")]
        public string? Naziv { get; set; }

/// <summary>
        /// Planirani broj tjednih termina
        /// </summary>
   
        [Range(1,4,ErrorMessage ="{0} mora biti izmedu {1} i {2}")]

//čitaj to kao: vrijednost mora biti između ponuđenih vrijednosti

        public int TjednaSatnica { get; set; }

/// <summary>
        /// Cijena programa u eurima u ovisnosti o tjednoj satnici
        /// </summary>

        [Range(5, 37, ErrorMessage = "{0} mora biti izmedu {1} i {2}")]

        public decimal? Cijena { get; set; }

        /// <summary>
        /// Voditelj programa
        /// Program kreiran od strane jednog trenera provodi se u jednoj ili više grupa, a može ga koristiti jedan ili više trenera
        /// </summary>

        [ForeignKey("trener")]
        //trener pod navodnicima označava da je on kolona u tablici plan i program
        
        public Trener Trener { get; set; }




    }
}
