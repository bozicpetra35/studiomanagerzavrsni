namespace StudioManager.Models
{
        public record PlaniprogramDTORead(int sifra, string naziv, int tjednasatnica,
            decimal cijena, int trener);


        public record PlaniprogramDTOInsertUpdate(string naziv, int tjednasatnica,
           decimal cijena, int trener);


        //------------------------

        public record VjezbacDTORead(int sifra, string ime, string prezime, string telefon,
           int brojupisnoglista);


        public record VjezbacDTOInsertUpdate(string ime, string prezime, string telefon,
           int brojupisnoglista);


        //------------------------

        public record TrenerDTORead(int sifra, string ime, string prezime, string telefon,
           string iban, string oib);


        public record TrenerDTOInsertUpdate(string ime, string prezime, string telefon,
           string iban, string oib);

        //------------------------

        public record GrupaDTORead(int sifra, string termin, int planiprogram, 
            DateTime datumpocetka, int maksimalanbrojvjezbaca, int brojvjezbaca);

        public record GrupaDTOInsetUpdate(string termin, int planiprogram,
       DateTime datumpocetka, int maksimalanbrojvjezbaca, int brojvjezbaca);


}

