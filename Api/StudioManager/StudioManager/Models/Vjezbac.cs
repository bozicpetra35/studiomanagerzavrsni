namespace StudioManager.Models
{
    public class Vjezbac : Osoba
    {

        public int? BrojUpisnogLista { get; set; }

        public ICollection<Grupa>? Grupe { get; } = new List<Grupa>();

        //ICollection je sučelje kojeg lista implementira
        //sa strane vjezbaca, ne zanima nas u kojoj su grupi
        //sa strane grupe, zanima nas koji vjezbaci joj pripadaju
        //nema set jer ne necemo moci preko polaznika upravljat grupom
        //ali ima get jer cemo moci dohvatiti i vidjeti u kojoj je grupi

        //new list grupa označava da moze postojati prazna grupa
        //u trenutku kad ju odlucimo otvoriti, a nismo selektirali vjezbace
        //kaze: bolje imat pa makar praznu

        //stavili smo prvoj listu na drugu i drugoj listu na prvu
        //moze se dogodit da dobimo stack overflow exeption
        //nastavljas u contaxtu
    }
}
