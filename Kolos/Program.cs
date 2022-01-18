using System;

namespace Kolos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Osoba osoba = new Osoba("jan", "kowalski", "12345678912");
            Console.WriteLine(osoba.ToString());
            //osoba2.ToString();

            // ZACZYAN MY ZADANIE 3 CZA zrobic

            // errror dzilaa
            //Osoba osoba2 = new Osoba("chuj", "kurwa", "786");
            //Console.WriteLine(osoba2.ToString());

            Console.ReadKey();
        }
    }
}
