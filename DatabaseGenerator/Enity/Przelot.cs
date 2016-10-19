using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class Przelot
    {
        public int NumerLotu { get; set; }
        public DateTime PlanowanaDataRozpoczecia { get; set; }
        public DateTime PlanowanaDataZakonczenia { get; set; }
        public DateTime FaktycznaDataRozpoczecia { get; set; }
        public DateTime FaktycznaDataZakonczenia { get; set; }
        public int PlanowanaLiczbaMiejscZajetych { get; set; }
        public int FaktycznaLiczbaMiejscZajetych { get; set; }
        public string  StatusLotu { get; set; }
        public int FK_LotniskoPoczatkowe { get; set; } // ID Lotniska
        public int FK_PlanowaneLotniskoKoncowe { get; set; } // ID Lotniska
        public int FK_FaktyczneLotniskoKoncowe { get; set; } // ID Lotniska
        public int FK_PlanowanySamolot { get; set; }
        public int FK_FaktycznySamolot { get; set; }

        public Przelot(int NumerLotu, DateTime PlanowanaDataRozpoczecia, DateTime PlanowanaDataZakonczenia, DateTime FaktycznaDataRozpoczecia,
            DateTime FaktycznaDataZakonczenia, int PlanowanaLiczbaMiejscZajetych, int FaktycznaLiczbaMiejscZajetych, string StatusLotu, 
            int FK_LotniskoPoczatkowe, int FK_PlanowaneLotniskoKoncowe, int FK_FaktyczneLotniskoKoncowe, int FK_PlanowanySamolot, int FK_FaktycznySamolot)
        {
            this.NumerLotu = NumerLotu;
            this.PlanowanaDataRozpoczecia = PlanowanaDataRozpoczecia;
            this.PlanowanaDataZakonczenia = PlanowanaDataZakonczenia;
            this.FaktycznaDataRozpoczecia = FaktycznaDataRozpoczecia;
            this.FaktycznaDataZakonczenia = FaktycznaDataZakonczenia;
            this.PlanowanaLiczbaMiejscZajetych = PlanowanaLiczbaMiejscZajetych;
            this.FaktycznaLiczbaMiejscZajetych = FaktycznaLiczbaMiejscZajetych;
            this.StatusLotu = StatusLotu;
            this.FK_LotniskoPoczatkowe = FK_LotniskoPoczatkowe;
            this.FK_PlanowaneLotniskoKoncowe = FK_PlanowaneLotniskoKoncowe;
            this.FK_FaktyczneLotniskoKoncowe = FK_FaktyczneLotniskoKoncowe;
            this.FK_PlanowanySamolot = FK_PlanowanySamolot;
            this.FK_FaktycznySamolot = FK_FaktycznySamolot;
        }
    }
}