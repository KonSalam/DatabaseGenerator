using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class ZdarzeniaGenerator : BaseGenerator
    {
        public static DateTime DateTimeStart { get; set; }
        private int Min { get; set; }
        private int Max { get; set; }

        public ZdarzeniaGenerator() : base()
        {
            Min = 0;
        }

        public DateTime GenerateDateTimeZdarzenia(DateTime DateEnd, int IloscZdarzen)
        {
            int hours = Math.Abs((DateEnd.Hour - DateTimeStart.Hour) * 60);
            int minutes = Math.Abs(DateEnd.Minute - DateTimeStart.Minute);
            int dependecy = ((hours + minutes) / IloscZdarzen);

            if (dependecy < 1) dependecy = 2;
            DateTimeStart = DateTimeStart.AddMinutes(Random.Next(1, dependecy));
            return DateTimeStart;
        }

        public int GenerateTyp(Dictionary<string, string[]> Zdarzenia)
        {
            Max = Zdarzenia.Keys.Count;
            return Random.Next(Min, Max);
        }

        public string GenerateOpis(Dictionary<string, string[]> Zdarzenia, string Kraj)
        {
            string[] tmpOpisArray;
            Zdarzenia.TryGetValue(Kraj, out tmpOpisArray);
            return tmpOpisArray[Random.Next(Min, tmpOpisArray.Length)];
        }
    }
}