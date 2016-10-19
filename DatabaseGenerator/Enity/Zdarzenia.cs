using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class Zdarzenia
    {
        public DateTime DataZdarzenia { get; set; }
        public int FK_Przelot { get; set; } // Numer Lotu 

        public Zdarzenia (DateTime DataZdarzenia, int FK_Przelot)
        {
            this.DataZdarzenia = DataZdarzenia;
            this.FK_Przelot = FK_Przelot;
        }
    }
}
