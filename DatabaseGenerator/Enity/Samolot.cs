using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class Samolot
    {
        public int IDSamolotu { get; set; }
        public string Model { get; set; }
        public int LiczbaMiejsc { get; set; }
        public int Paliwo { get; set; }

        public Samolot (int IDSamolotu, string Model, int LiczbaMiejsce, int Paliwo)
        {
            this.IDSamolotu = IDSamolotu;
            this.Model = Model;
            this.LiczbaMiejsc = LiczbaMiejsce;
            this.Paliwo = Paliwo;
        }
    }
}