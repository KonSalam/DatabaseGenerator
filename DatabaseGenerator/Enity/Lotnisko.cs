using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class Lotnisko
    {
        public int ID_Lotniska { get; set; }
        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public int CzyStrefaUE { get; set; }

        public Lotnisko(int ID_Lotniska, string Kraj, string Miasto, int CzyStrefaUE)
        {
            this.ID_Lotniska = ID_Lotniska;
            this.Kraj = Kraj;
            this.Miasto = Miasto;
            this.CzyStrefaUE = CzyStrefaUE;
        }
    }
}
