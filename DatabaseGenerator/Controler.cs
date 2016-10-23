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
            FillLotniska(Data.LotnistkoKrajMiasto, 0, ref index);
            FillLotniska(Data.LotniskoKrajMiastoUE, 1, ref index);
            GeneratePrzelot(IleLotow);
            GeneratePrzelotSamolot();
            GeneratePrzelotLotnisko();
            GenerateZdarzenia();
            FileWriter.WritePrzelotToFile(ListOfPrzelot, "PrzelotT1.bulk");
            GeneratePrzelotZaloga();
        }

        public void GenerateT2(int IleLotow)
        {
            ChangeZaloga();
            AddSamolotAndZaloga(IleLotow);

            Console.WriteLine("T2 GENERUJE !!");
            FileWriter.WriteSamolotToFile(ListOfSamolot, "SamolotyT2.bulk");
            FileWriter.WriteZalogaToFile(ListOfZaloga, "ZalogaT2.bulk");
            FileWriter.WriteLotniskoToFile(ListOfLotnisko, "LotniskaT2.bulk");
            FileWriter.WriteZdarzeniaToFile(ListOfZdarzenia, "ZdarzeniaT2.bulk");
            FileWriter.WriteZdarzeniaToXML(ListOfZdarzenia, "XmlZdarzeniaT2.xml");
            FileWriter.WritePrzelotToFile(ListOfPrzelot, "PrzelotT2.bulk");
            FileWriter.WritePrzelotZalogaToFile(ListOfPrzelotZaloga, "PrzelotZalogaT2.bulk");
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

                ListOfPrzelot.Add(new Przelot(i, DateTimePlanedStart, DateTimePlanedEnd, DateTimeRealStart, DateTimeRealEnd, status));
            }

        }

        private void GeneratePrzelotSamolot()
        {
            foreach (Przelot przelot in ListOfPrzelot)
            {
                przelot.FK_PlanowanySamolot = DefaultGenerator.Random.Next(0, ListOfSamolot.Count);
                if (DefaultGenerator.Random.Next(0, 4) != 3)
                {
                    przelot.FK_FaktycznySamolot = przelot.FK_PlanowanySamolot;
                }
                else
                {
                    przelot.FK_FaktycznySamolot = DefaultGenerator.Random.Next(0, ListOfSamolot.Count);
                }
                przelot.PlanowanaLiczbaMiejscZajetych = ListOfSamolot[przelot.FK_FaktycznySamolot].LiczbaMiejsc - DefaultGenerator.Random.Next(0, 6);
                przelot.FaktycznaLiczbaMiejscZajetych = przelot.PlanowanaLiczbaMiejscZajetych - DefaultGenerator.Random.Next(0, 5);
            }
        }

        private void GeneratePrzelotLotnisko()
        {
            foreach (Przelot przelot in ListOfPrzelot)
            {
                while (true)
                {
                    przelot.FK_LotniskoPoczatkowe = DefaultGenerator.Random.Next(0, ListOfLotnisko.Count);
                    przelot.FK_PlanowaneLotniskoKoncowe = DefaultGenerator.Random.Next(0, ListOfLotnisko.Count);
                    if (przelot.FK_LotniskoPoczatkowe != przelot.FK_PlanowaneLotniskoKoncowe) break;
                }

                if (DefaultGenerator.Random.Next(0, 8) != 7)
                {
                    przelot.FK_FaktyczneLotniskoKoncowe = przelot.FK_PlanowaneLotniskoKoncowe;
                }
                else
                {
                    while (true)
                    {
                        przelot.FK_FaktyczneLotniskoKoncowe = DefaultGenerator.Random.Next(0, ListOfLotnisko.Count);
                        if (przelot.FK_LotniskoPoczatkowe != przelot.FK_FaktyczneLotniskoKoncowe) break;
                    }
                }
            }
        }

        private void GeneratePrzelotZaloga()
        {
            for (int i = 0; i < ListOfPrzelot.Count; i++)
            {
                for (int j = i * 6; j < i * 6 + 6; j++)
                {
                    ListOfPrzelotZaloga.Add(new PrzelotZałoga(ListOfPrzelot[i].NumerLotu, ListOfZaloga[j].PESEL));
                }
            }

            FileWriter.WritePrzelotZalogaToFile(ListOfPrzelotZaloga, "PrzelotZalogaT1.bulk");
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
            string pesel;
            for (int i = 0; i < IleLotow; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    while (true)
                    {
                        pesel = PeselGenerator.GeneratePeselNumbers();

                        if (isAddedPeselNumber(pesel) == false)
                        {
                            break;
                        }
                    }

                    ListOfZaloga.Add(new Załoga(pesel, Generator.GenerateString(Data.Imie), Generator.GenerateString(Data.Nazwisko), Data.Stanowisko[j]));
                }
            }

            FileWriter.WriteZalogaToFile(ListOfZaloga, "ZalogaT1.bulk");
        }

        private void ChangeZaloga()
        {
            foreach (Załoga person in ListOfZaloga)
            {
                if (person.Stanowisko.Equals("Steward"))
                {
                    if (DefaultGenerator.Random.Next(0, 2) == 1)
                    {
                        person.Stanowisko = "Starszy Steward";
                    }
                }

                if (person.Stanowisko.Equals("Drugi Pilot"))
                {
                    if (DefaultGenerator.Random.Next(0, 2) == 1)
                    {
                        person.Stanowisko = "Kapitan";
                    }
                }
            }
        }

        private void AddSamolotAndZaloga(int ile)
        {
            string pesel;
            int SamolotListSize = ListOfSamolot.Count;
            int ZalogaListSize = ListOfZaloga.Count;

            for (int i = SamolotListSize; i < SamolotListSize + ile; i++)
            {
                int tmpRandomNumber = Generator.GenerateNumber(Data.LiczbaMiejsc);
                ListOfSamolot.Add(new Samolot(i, Data.Model[tmpRandomNumber], Data.LiczbaMiejsc[tmpRandomNumber], Data.Paliwo[tmpRandomNumber]));
            }

            for (int i = ZalogaListSize; i < ZalogaListSize + ile; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    while (true)
                    {
                        pesel = PeselGenerator.GeneratePeselNumbers();

                        if (isAddedPeselNumber(pesel) == false)
                        {
                            break;
                        }
                    }
                    ListOfZaloga.Add(new Załoga(pesel, Generator.GenerateString(Data.Imie), Generator.GenerateString(Data.Nazwisko), Data.Stanowisko[j]));
                }

            }
        }

        private bool isAddedPeselNumber(string Pesel)
        {
            foreach (Załoga person in ListOfZaloga)
            {
                if (person.PESEL.Equals(Pesel))
                {
                    return true;
                }
            }
            return false;
        }

        private void GenerateSamolot(int ileLotow)
        {
            for (int i = 0; i < IleLotow + 5; i++)
            {
                int tmpRandomNumber = Generator.GenerateNumber(Data.LiczbaMiejsc);
                ListOfSamolot.Add(new Samolot(i, Data.Model[tmpRandomNumber], Data.LiczbaMiejsc[tmpRandomNumber], Data.Paliwo[tmpRandomNumber]));
            }

            FileWriter.WriteSamolotToFile(ListOfSamolot, "SamolotyT1.bulk");
        }

        private void FillLotniska(Dictionary<string, string[]> LotnistkoKrajMiasto, int flaga, ref int index)
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