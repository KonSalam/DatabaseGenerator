using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class Controler
    {
        public List<Przelot> ListOfPrzelot { get; set; }
        public List<PrzelotZałoga> ListOfPrzelotZaloga { get; set; }
        public List<Załoga> ListOfZaloga { get; set; }
        public List<Samolot> ListOfSamolot { get; set; }
        public List<Zdarzenia> ListOfZdarzenia { get; set; }
        public List<Lotnisko> ListOfLotnisko { get; set; }
        public int IleLotow { get; set; }
        private DefaultGenerator Generator { get; set; }
        private PeselGenerator PeselGenerator { get; set; }
        private ZdarzeniaGenerator ZdarzeniaGenerator { get; set; }
        private DateTimeGenerator DataTimeGeneratror { get; set; }
        private FileWriter FileWriter { get; set; }
        private Data Data { get; }

        public Controler(int IleLotow)
        {
            this.IleLotow = IleLotow;
            ListOfPrzelot = new List<Przelot>();
            ListOfPrzelotZaloga = new List<PrzelotZałoga>();
            ListOfZaloga = new List<Załoga>();
            ListOfSamolot = new List<Samolot>();
            ListOfZdarzenia = new List<Zdarzenia>();
            ListOfLotnisko = new List<Lotnisko>();

            Generator = new DefaultGenerator();
            PeselGenerator = new PeselGenerator();
            ZdarzeniaGenerator = new ZdarzeniaGenerator();
            DataTimeGeneratror = new DateTimeGenerator("2016-10-01 12:00");
        }

        public void Generate()
        {
            int index = 0;
            GenerateZaloga(IleLotow);
            GenerateSamolot(IleLotow);
            FillLotniska(Data.LotnistkoKrajMiasto, false, ref index);
            FillLotniska(Data.LotniskoKrajMiastoUE, true, ref index);
            GeneratePrzelot(IleLotow);
            GenerateZdarzenia();
        }

        private void GeneratePrzelot(int IleLotow)
        {
            DateTime DateTimePlanedStart;
            DateTime DateTimePlanedEnd;
            DateTime DateTimeRealStart;
            DateTime DateTimeRealEnd;
            string status;

            DataTimeGeneratror.GeneratePlanedDateTimeEnd();
            for (int i = 0; i < IleLotow; i++)
            {
                //Start DateTime Generator
                DateTimePlanedStart = DataTimeGeneratror.DateTimePlanedStart;
                DataTimeGeneratror.GenerateRealDateTimeStart();
                DateTimeRealStart = DataTimeGeneratror.DateTimeRealStart;
                DataTimeGeneratror.GeneratePlanedDateTimeEnd();

                //End DateTime Generator
                DateTimePlanedEnd = DataTimeGeneratror.DateTimePlanedEnd;
                DataTimeGeneratror.GenerateRealDateTimeEnd();
                DateTimeRealEnd = DataTimeGeneratror.DateTimeRealEnd;

                if ((DateTimePlanedStart == DateTimeRealStart) && (DateTimePlanedEnd == DateTimeRealEnd))
                {
                    status = Data.Status[0];
                }
                else
                {
                    status = Data.Status[1];
                }

                ListOfPrzelot.Add(new Przelot(i, DateTimePlanedStart, DateTimePlanedEnd, DateTimeRealStart, DateTimeRealEnd, 0, 0, status, 0, 0, 0, 0, 0));
            }
            FileWriter.WritePrzelotToFile(ListOfPrzelot, "PrzelotT1.bulk");
        }

        private void GenerateZdarzenia()
        {
            foreach (Przelot przelot in ListOfPrzelot)
            {
                int numberOfZdarzenia = DefaultGenerator.Random.Next(1, 4);
                ZdarzeniaGenerator.DateTimeStart = przelot.FaktycznaDataRozpoczecia;

                for (int j = 0; j < numberOfZdarzenia; j++)
                {
                    int typNumber = ZdarzeniaGenerator.GenerateTyp(Data.ZdarzeniaTypOpis);
                    var typZdarzeniaList = Data.ZdarzeniaTypOpis.Keys.ToList();
                    DateTime tmpDateTime = ZdarzeniaGenerator.GenerateDateTimeZdarzenia(przelot.FaktycznaDataZakonczenia, numberOfZdarzenia);

                    ListOfZdarzenia.Add(new Zdarzenia(tmpDateTime, przelot.NumerLotu, typZdarzeniaList[typNumber], ZdarzeniaGenerator.GenerateOpis(Data.ZdarzeniaTypOpis, typZdarzeniaList[typNumber])));
                }
            }
            FileWriter.WriteZdarzeniaToFile(ListOfZdarzenia, "ZdarzeniaT1.bulk");
            FileWriter.WriteZdarzeniaToXML(ListOfZdarzenia, "XmlZdarzeniaT1.xml");
        }

        private void GenerateZaloga(int IleLotow)
        {
            for (int i = 0; i < IleLotow; i++)
            {
                ListOfZaloga.Add(new Załoga(PeselGenerator.GeneratePeselNumbers(), Generator.GenerateString(Data.Imie), Generator.GenerateString(Data.Nazwisko), Generator.GenerateString(Data.Stanowisko)));
            }

            FileWriter.WriteZalogaToFile(ListOfZaloga, "ZalogaT1.bulk");
        }

        private void GenerateSamolot(int ileLotow)
        {
            for (int i = 0; i < IleLotow; i++)
            {
                int tmpRandomNumber = Generator.GenerateNumber(Data.LiczbaMiejsc);
                ListOfSamolot.Add(new Samolot(i, Data.Model[tmpRandomNumber], Data.LiczbaMiejsc[tmpRandomNumber], Data.Paliwo[tmpRandomNumber]));
            }

            FileWriter.WriteSamolotToFile(ListOfSamolot, "SamolotyT1.bulk");
        }

        private void FillLotniska(Dictionary<string, string[]> LotnistkoKrajMiasto, bool flaga, ref int index)
        {
            var KrajList = LotnistkoKrajMiasto.Keys.ToList();

            foreach (string Kraj in KrajList)
            {
                string[] tmpMiastoArray;
                LotnistkoKrajMiasto.TryGetValue(Kraj, out tmpMiastoArray);

                foreach (string Miasto in tmpMiastoArray)
                {
                    ListOfLotnisko.Add(new Lotnisko(index, Kraj, Miasto, flaga));
                    index++;
                }
            }

            FileWriter.WriteLotniskoToFile(ListOfLotnisko, "LotniskaT1.bulk");
        }
    }
}