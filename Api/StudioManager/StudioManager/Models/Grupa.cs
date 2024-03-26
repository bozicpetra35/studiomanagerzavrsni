using System.ComponentModel.DataAnnotations.Schema;

namespace StudioManager.Models
{
    public class Grupa:Entitet
    {

        public string? Termin { get; set; }

        [ForeignKey("planiprogram")]
        public Planiprogram PlaniProgram { get; set; }

        public DateTime DatumPocetka { get; set; }

        public int MaksimalanBrojVjezbaca { get; set; }

        public List<Vjezbac>? Vjezbaci { get; set; }
    }
}
