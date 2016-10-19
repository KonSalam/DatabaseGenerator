using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class PrzelotZałoga
    {
        public int FK_Przelot { get; set; } // Numer Lotu
        public int FK_Zaloga { get; set; } // Pesel

        public PrzelotZałoga(int FK_Przelot, int FK_Zaloga)
        {
            this.FK_Przelot = FK_Przelot;
            this.FK_Zaloga = FK_Zaloga;
        }
    }
}
