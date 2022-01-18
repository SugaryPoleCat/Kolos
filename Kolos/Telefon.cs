using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos
{
    abstract class Telefon
    {
        string numer;
        Osoba wlasiciel;
        List<decimal> rozmowy;
        static decimal oplataZaMinute;

        //konstruktor statyczny
        static Telefon()
        {
            oplataZaMinute = 0.1m;
        }

        public Telefon(string _numer, Osoba _wlasciciel, List<decimal> _rozmowy)

    }
}
