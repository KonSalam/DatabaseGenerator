using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class FileWriter
    {
        public static StreamWriter file { get; set; }
   
        public static void WriteZalogaToFile (List<Załoga> List)
        {
            using (file = new System.IO.StreamWriter(@"C:\Users\Konrad\Documents\DatabaseFiles\WriteLines2.txt"))
            {
                foreach (Załoga Obj in List)
                {
                    file.WriteLine(String.Format("{0}|{1}|{2}|{3}", Obj.PESEL, Obj.Imie, Obj.Nazwisko, Obj.Stanowisko));
                }

                file.Close();
                Console.WriteLine("Zapisywanie Zalogi SUCCES");
            }
        }
    }
}