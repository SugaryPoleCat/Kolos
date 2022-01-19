using System;
using System.Collections.Generic;
using System.Linq;

namespace Kolos
{
    abstract class Telefon : IWydarzenieCykliczne, IComparable<Telefon>
    {
        public string numer;
        Osoba wlasiciel;
        public List<decimal> rozmowy;
        static decimal oplataZaMinute;


        //konstruktor statyczny
        static Telefon()
        {
            oplataZaMinute = 0.1m;
        }


        /// <summary>
        /// Konstrutkor telefoni
        /// </summary>
        public Telefon(string _numer, Osoba _wlasciciel)
        {
            try
            {
                if (string.IsNullOrEmpty(_numer) || _numer.Length != 9)
                {
                    // mozna dopisac wiadomosc w ();
                    throw new FormatException();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            this.numer = _numer;
            this.wlasiciel = _wlasciciel;
            //pusta lista
            rozmowy = new List<decimal>();
        }


        // Oblicz oplaty
        virtual public decimal Oplata(float minuty)
        {
            //trzeba convert bo rozne formaty
            decimal result = Convert.ToDecimal(minuty) * oplataZaMinute;

            return result;
        }


        // Metoda co dodaje (metody zawsze cos zwracaja albo void)
        public void Rozmowa(float minuty)
        {
            // dodaj do listy rozmow, oplate, uzwyajac obliczenia z metody Oplata
            rozmowy.Add(Oplata(minuty));
        }


        // implementacja metody z interfejsu w klasie
        public void Przypomnienie(DateTime data, string komunikat)
        {
            if (komunikat == null)
            {
                throw new Exception("KOmunikat nie moze byc pusty deklu");
            }
            if (data.DayOfWeek == DateTime.Now.DayOfWeek)
            {
                Console.WriteLine($"{data} {komunikat}");
            }
        }

        // porownaj this do _telefon
        public decimal CompareTo(Telefon telefonDoPorownania)
        {
            // stary kods
            /**
            decimal result = 0;
            // To jest dzialanie dla THIS, czyli dla klasy
            decimal suma = 0;
            //przez wszystkie rozmowy z array rozmowy
            for (int i = 0; i < this.rozmowy.Count; i++)
            {
                // dodaj oplate kazdej rozmowy do sumy
                suma += this.rozmowy[i];
            }

            decimal sumaDoPorownania = 0;
            for (int i = 0; i < _telefon.rozmowy.Count; i++)
            {
                sumaDoPorownania += _telefon.rozmowy[i];
            }


            if (suma != sumaDoPorownania)
            {
                result = suma.CompareTo(sumaDoPorownania);
            }
            else
            {
                result = sumaDoPorownania.CompareTo(suma);
            }
            return result;
            */

            // nowy kod
            if (telefonDoPorownania == null)
            {
                return 1m;
            }
            if (telefonDoPorownania != null)
            {
                decimal naszaSuma = sumaRozmow(this.rozmowy);
                decimal ichSuma = sumaRozmow(telefonDoPorownania.rozmowy);

                return naszaSuma.CompareTo(ichSuma);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private decimal sumaRozmow(List<decimal> rozmowa)
        {
            decimal suma = 0m;
            for (int i = 0; i < rozmowa.Count; i++)
            {
                suma += rozmowa[i];
            }
            return suma;
        }

        /// <summary>
        /// Dupa
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            decimal sum = 0;
            for(int i = 0; i < this.rozmowy.Count; i++)
            {
                sum += this.rozmowy[i];
            }
            string result = $"{wlasiciel.ToString()}, tel.:{this.numer} ({sum.ToString("C")})";
            return result;
        }

        int IComparable<Telefon>.CompareTo(Telefon other)
        {
            throw new NotImplementedException();
        }
    }
}
