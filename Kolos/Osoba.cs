﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos
{
    internal class Osoba
    {
        private string imie;
        private string nazwisko;
        private string pesel;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="_imie"></param>
        /// <param name="_nazwisko"></param>
        /// <param name="_pesel"></param>
        /// <exception cref="FormatException">To sie dzieje jak pesel jest pusty albo nie ma 11 znakow</exception>
        public Osoba(string _imie, string _nazwisko, string _pesel)
        {
            this.imie = _imie;
            this.nazwisko = _nazwisko;
            // jezeli nasz pesel jest pusty lub NULL, LUB nie ma 11 znakow
            if (string.IsNullOrEmpty(_pesel) || _pesel.Length != 11)
            {
                // mozna dopisac wiadomosc w ();
                throw new FormatException();
            }
        }

        /// <summary>
        /// Nadpisuje metode aby wypisywala info w dany sposob
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = $" {this.imie} {this.nazwisko} ({this.pesel})";
            return result;
        }
    }
}
