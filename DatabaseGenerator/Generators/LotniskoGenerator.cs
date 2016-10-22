using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class LotniskoGenerator : BaseGenerator
    {
        private int Max { get; set; }
        private int Min { get; set; }
        public LotniskoGenerator() : base()
        {
            Min = 0;
        }

        public int GenerateKraj(Dictionary<string, string[]> LotniskoKarjMiasto)
        {
            Max = LotniskoKarjMiasto.Keys.Count;
            return Random.Next(Min, Max);
        }

        public string GenerateMiasto(Dictionary<string, string[]> LotniskoKarjMiasto, string  Kraj)
        {
            string[] tmpMiastoArray;
            LotniskoKarjMiasto.TryGetValue(Kraj, out tmpMiastoArray);
            return tmpMiastoArray[Random.Next(Min, tmpMiastoArray.Length)];
        }


    }
}
