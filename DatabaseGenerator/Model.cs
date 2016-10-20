﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class Model
    {
        public List<Przelot> ListOfPrzelot { get; set; }
        public List<PrzelotZałoga> ListOfPrzelotZaloga { get; set; }
        public List<Załoga> ListOfZaloga { get; set; }
        public List<Samolot> ListOfSamolot { get; set; }
        public List<Zdarzenia> ListOfZdarzenia { get; set; }
        public List<Lotnisko> ListOfLotnisko { get; set; }
        public int IleLotow { get; set; }
        private DefaultGenerator Generator { get; set; }
        private Data Data { get; }

        public Model(int IleLotow)
        {
            this.IleLotow = IleLotow;
            ListOfPrzelot = new List<Przelot>();
            ListOfPrzelotZaloga = new List<PrzelotZałoga>();
            ListOfZaloga = new List<Załoga>();
            ListOfSamolot = new List<Samolot>();
            ListOfZdarzenia = new List<Zdarzenia>();
            ListOfLotnisko = new List<Lotnisko>();
            Generator = new DefaultGenerator();
        }

        public void Generate()
        {
            for (int i = 0; i < IleLotow; i++)
            {
                ListOfZaloga.Add(new Załoga(0, Generator.Generate(Data.Imie), Generator.Generate(Data.Nazwisko), Generator.Generate(Data.Stanowisko)));
            }
            
        }

    }
}