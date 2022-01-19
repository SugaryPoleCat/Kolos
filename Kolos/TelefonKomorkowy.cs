using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos
{
    enum EnumOperator { tmobile, plusgsm, virgin, heyah }

    internal class TelefonKomorkowy: Telefon
    {
        EnumOperator dostawca;
        static decimal oplataDodatkowaZaMinute;

        static TelefonKomorkowy()
        {
            oplataDodatkowaZaMinute = 0.05m;
        }

        /// <summary>
        /// Konstrukcja nowego komorkowego
        /// </summary>
        /// <param name="_numer"></param>
        /// <param name="_wlasciciel"></param>
        /// <param name="_dostawca"></param>
        public TelefonKomorkowy(string _numer, Osoba _wlasciciel, EnumOperator _dostawca) : base(_numer, _wlasciciel)
        {
            dostawca = _dostawca;
        }

        public override string ToString()
        {
           string result = $"{base.ToString()}, {dostawca}";
            return result;
        }

    }
}
