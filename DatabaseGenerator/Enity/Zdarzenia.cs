using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseGenerator
{
    [XmlType("zdarzenie")]
    public class Zdarzenia
    {
        [XmlAttribute("data")]
        public DateTime DataZdarzenia { get; set; }

        [XmlElement("numerLotu")]
        public int FK_Przelot { get; set; } // Numer Lotu 

        [XmlElement("typ")]
        public string Typ { get; set; }

        [XmlElement("opis")]
        public string Opis { get; set; }

        public Zdarzenia() { }

        public Zdarzenia (DateTime DataZdarzenia, int FK_Przelot, string Typ,string Opis)
        {
            this.DataZdarzenia = DataZdarzenia;
            this.FK_Przelot = FK_Przelot;
            this.Typ = Typ;
            this.Opis = Opis;
        }
    }
}
