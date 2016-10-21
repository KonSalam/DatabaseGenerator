using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class PeselGenerator : BaseGenerator, NumbersGenerator
    {
        public int FirstNumbers { get; set; }
        public int SecondNumbers { get; set; }
        public int ThirdNumbers { get; set; }
        public int FourthNumbers { get; set; }
        public int FivethNumbers { get; set; }
        public int EndNumber { get; set; }
        public PeselGenerator() : base() { }

        public string GeneratePeselNumbers()
        {
            FirstNumbers = Random.Next(29, 96);
            SecondNumbers = Random.Next(0, 12);
            ThirdNumbers = Random.Next(0, 30);
            FourthNumbers = Random.Next(0, 99);
            FivethNumbers = Random.Next(0, 99);
            EndNumber = Random.Next(0, 9);

            #region
            string TmpSecondNumbers;
            string TmpThirdNumbers;
            string TmpFourthNumber;
            string TmpFiveNumbers;

            if (SecondNumbers < 10)
            {
                TmpSecondNumbers = String.Format("0{0}", SecondNumbers);
            }
            else
            {
                TmpSecondNumbers = String.Format("{0}", SecondNumbers);
            }

            if (ThirdNumbers < 10)
            {
                TmpThirdNumbers = String.Format("0{0}", ThirdNumbers);
            }
            else
            {
                TmpThirdNumbers = String.Format("{0}", ThirdNumbers);
            }

            if (FourthNumbers < 10)
            {
                TmpFourthNumber = String.Format("0{0}", FourthNumbers);
            }
            else
            {
                TmpFourthNumber = String.Format("{0}", FourthNumbers);
            }

            if (FivethNumbers < 10)
            {
                TmpFiveNumbers = String.Format("0{0}", FivethNumbers);
            }
            else
            {
                TmpFiveNumbers = String.Format("{0}", FivethNumbers);
            }
            #endregion

            return String.Format("{0}{1}{2}{3}{4}{5}", FirstNumbers, TmpSecondNumbers, TmpThirdNumbers, TmpFourthNumber, TmpFiveNumbers, EndNumber);
        }
    }
}
