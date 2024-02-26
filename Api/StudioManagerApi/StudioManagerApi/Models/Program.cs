using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudioManagerApi.Models
{

/// <summary>
/// Ovo je poco mapiran na bazu
/// </summary>

    public class Program:Entitet
    {

        [Required(ErrorMessage = "Naziv obavezno")]
        public string? Naziv { get; set; }



        //[Range(30, 500, ErrorMessage = "{0} mora biti između {1} i {2}")]
        //[Column("brojsati")]
        //public int? Tjednasatnica { get; set; }

        

        //[Range(0, 10000, ErrorMessage = "Vrijednost {0} mora biti između {1} i {2}")]
        //public decimal? Cijena { get; set; }

      
        //public decimal? Trener { get; set; }


    }
}
