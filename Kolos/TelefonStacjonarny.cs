using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos
{
    internal class TelefonStacjonarny: Telefon
    {
        bool autosekretarka;

        public TelefonStacjonarny(string _numer, Osoba _wlasciciel, bool _autosekretarka) : base(_numer, _wlasciciel)
        {
            autosekretarka = _autosekretarka;
        }

        public override string ToString()
        {
            // base bierze metode z funkcji ktora inheretujemy.
           string result = $"{base.ToString()}";
            //jezeli autosekretraka egzystuje
            if (autosekretarka)
            {
                result += $", [auto+]";
            }
            return result;
        }




    }
}
