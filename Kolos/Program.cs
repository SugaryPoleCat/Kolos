using System;

namespace Kolos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Skurwielex SP ZOO";

            // stworzenie jakis skurwysynow
            Osoba sebo = new Osoba("Sebastien", "Skurwiel", "98765432123");
            Osoba dupcys = new Osoba("Dupcys", "Chuj", "12345678987");

            // Tworzenie dupnej firmy
            Firma Skurwielex = new Firma("Skurwielex");

            // utworz 2 telefony komorkowe i stacjonarne
            TelefonKomorkowy telKom1 = new TelefonKomorkowy("987654321", sebo, EnumOperator.tmobile);
            TelefonKomorkowy telKom2 = new TelefonKomorkowy("123456789", dupcys, EnumOperator.virgin);
            TelefonStacjonarny telSta1 = new TelefonStacjonarny("654987321", sebo, true);
            TelefonStacjonarny telSta2 = new TelefonStacjonarny("789456132", dupcys, false);

            // dodaj rozmowy do telefonow
            telKom1.Rozmowa(988);
            telKom2.Rozmowa(1);
            telSta1.Rozmowa(2);
            telSta2.Rozmowa(937);

            // dodaj telefony do firmy
            Skurwielex.DodajTelefon(telKom1);
            Skurwielex.DodajTelefon(telKom2);
            Skurwielex.DodajTelefon(telSta1);
            Skurwielex.DodajTelefon(telSta2);

            // wuypisz do kurwa w pizdu ja pierdole
            Console.WriteLine(Skurwielex.ToString());

            Skurwielex.ZapiszXml("chuje");
            // usun telefon
            Console.WriteLine(Skurwielex.UsunTelefon("987654321"));

            Skurwielex.OdczytajXml("chuje");

            

            Console.ReadKey();
        }
    }
}
