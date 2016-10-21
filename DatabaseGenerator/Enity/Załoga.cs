using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class Załoga
    {
        public string PESEL { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }

        public Załoga(string PESEL, string Imie, string Nazwisko, string Stanowisko)
        {
            this.PESEL = PESEL;
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.Stanowisko = Stanowisko;
        }
    }
}
