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
        private LotniskoGenerator LotniskoGenerator { get; set; }
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
            LotniskoGenerator = new LotniskoGenerator();
        }

        public void Generate()
        {
            int index = 0;
            GenerateZaloga(IleLotow);
            GenerateSamolot(IleLotow);
            FillLotniska(Data.LotniskoKarjMiasto, false, ref index);
            FillLotniska(Data.LotniskoKarjMiastoUE, true, ref index);
        }

        private void GeneratePrzelot(int IleLotow)
        {
            for (int i = 0; i < IleLotow; i++)
            {


            }
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
                ListOfSamolot.Add(new Samolot(i, Generator.GenerateString(Data.Model), Data.LiczbaMiejsc[tmpRandomNumber], Data.Paliwo[0]));
            }

            FileWriter.WriteSamolotToFile(ListOfSamolot, "SamolotyT1.bulk");
        }

        private void FillLotniska(Dictionary<string, string[]> LotniskoKarjMiasto, bool flaga, ref int index)
        {
            var KrajList = LotniskoKarjMiasto.Keys.ToList();

            foreach (string Kraj in KrajList)
            {
                string[] tmpMiastoArray;
                LotniskoKarjMiasto.TryGetValue(Kraj, out tmpMiastoArray);

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