using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseGenerator
{
    public class Zdarzenia
    {
        [XmlElement("NazwaWezlaWXml")]
        public DateTime DataZdarzenia { get; set; }

        [XmlAttribute("NrLotu")]
        public int FK_Przelot { get; set; } // Numer Lotu 

        [XmlElement("Typ")]
        public string Typ { get; set; }

        [XmlElement("Opis")]
        public string Opis { get; set; }


        public Zdarzenia (DateTime DataZdarzenia, int FK_Przelot, string Typ,string Opis)
        {
            this.DataZdarzenia = DataZdarzenia;
            this.FK_Przelot = FK_Przelot;
            this.Typ = Typ;
            this.Opis = Opis;
        }
    }
}
