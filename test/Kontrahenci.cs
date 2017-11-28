using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Kontrahenci
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int telefon { get; set; }
        public string miejscowosc { get; set; }
        public string data { get; set; }
        public string opis { get; set; }
        public int ocena { get; set; }

        public Kontrahenci()
        {

        }

        public Kontrahenci(string imie1, string nazwisko1, int telefon1, string miejscowosc1, string data1, string opis1, int ocena1)
        {
            imie = imie1;
            nazwisko = nazwisko1;
            telefon = telefon1;
            miejscowosc = miejscowosc1;
            data = data1;
            opis = opis1;
            ocena = ocena1;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6}", imie, nazwisko, telefon, miejscowosc, data, opis, ocena);
        }
    }
}
