namespace StudioManager.Models
{

    namespace EdunovaAPP.Models
    {
        public record PlaniprogramDTORead(int sifra, string naziv, int tjednasatnica,
            decimal cijena, int trener);


        public record PlaniprogramDTOInsertUpdate(string naziv, int tjednasatnica,
           decimal cijena, Trener trener);

    }



}
