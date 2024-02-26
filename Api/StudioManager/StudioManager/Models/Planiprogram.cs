using System.ComponentModel.DataAnnotations;

namespace StudioManager.Models
{
    public class Planiprogram
    {
        [Required(ErrorMessage = "Naziv obavezno")]
        public string? Naziv { get; set; }
    }
}
