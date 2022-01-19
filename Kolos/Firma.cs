using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kolos
{
    [Serializable]
    internal class Firma
    {
        string nazwa;
        List<Telefon> zarejestrowaneTelefony;

        public Firma(string _nazwa)
        {
            this.zarejestrowaneTelefony = new List<Telefon>();
            this.nazwa = _nazwa;
        }

        public void DodajTelefon(Telefon _telefon)
        {
            this.zarejestrowaneTelefony.Add(_telefon);
        }

        public decimal SumaOplat()
        {
            decimal suma = 0;
            // najpierw loopuje rpzez zarejestrowane telefony do tej firmy
            for(int i = 0; i < zarejestrowaneTelefony.Count; i++)
            {
                // a potem loopuje przez wszystkie rozmowy jakie posiada ten telefon.
                for(int j = 0; j < zarejestrowaneTelefony[i].rozmowy.Count; j++)
                {
                    suma += zarejestrowaneTelefony[i].rozmowy[j];
                }
            }
            return suma;
        }
        public Telefon UsunTelefon(string numer)
        {
            Telefon telefon = zarejestrowaneTelefony.Find(tel => tel.numer == numer);
            zarejestrowaneTelefony.Remove(telefon);
            return telefon;
        }

        public void Sortuj()
        {
            // sortuj liste zarejestrowanychTelefonow wedlug oplat.
            // Czyli napewno trzeba bedzie sumowac wszystkie oplaty, telefon po teleofnu.
            for(int i = 0; i < zarejestrowaneTelefony.Count; i++)
            {
                //Telefon telefon = zarejestrowaneTelefony.Find(tel => tel.);
                Console.WriteLine($"to jest kurwa glupie * {i}");
            }
        }

        public override string ToString()
        {
            string result = $"{nazwa}";
            zarejestrowaneTelefony.ForEach(tel => {
                result += $"\n{tel.ToString()}";
            });
            return result;
        }

        public void ZapiszXml(string nazwa)
        {
            try
            {
                StreamWriter sw = new StreamWriter(nazwa);
                XmlSerializer xs = new XmlSerializer(typeof(Firma));
                xs.Serialize(sw, this);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void OdczytajXml(string nazwa)
        {
            try
            {
                StreamReader sr = new StreamReader(nazwa);
                XmlSerializer xs = new XmlSerializer(typeof(Firma));
                Firma f = (Firma)xs.Deserialize(sr);
                sr.Close();
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
