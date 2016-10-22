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
        private static string Path { get; set; }

        public static void WriteZalogaToFile(List<Załoga> List, string FileName)
        {
            Path = String.Format(@"C:\Users\Konrad\Documents\DatabaseFiles\{0}", FileName);
            RemoveFile(Path);

            using (file = new StreamWriter(Path))
            {
                foreach (Załoga Obj in List)
                {
                    file.WriteLine(String.Format("{0}|{1}|{2}|{3}", Obj.PESEL, Obj.Imie, Obj.Nazwisko, Obj.Stanowisko));
                }

                file.Close();
                Console.WriteLine("Saving Zaloga Data Files = Succes");
            }
        }

        public static void WriteSamolotToFile(List<Samolot> List, string FileName)
        {
            Path = String.Format(@"C:\Users\Konrad\Documents\DatabaseFiles\{0}", FileName);
            RemoveFile(Path);

            using (file = new StreamWriter(Path))
            {
                foreach (Samolot Obj in List)
                {
                    file.WriteLine(String.Format("{0}|{1}|{2}|{3}", Obj.IDSamolotu, Obj.Model, Obj.LiczbaMiejsc, Obj.Paliwo));
                }

                file.Close();
                Console.WriteLine("Saving Samoloty Data Files = Succes");
            }
        }

        public static void WriteLotniskoToFile(List<Lotnisko> List, string FileName)
        {
            Path = String.Format(@"C:\Users\Konrad\Documents\DatabaseFiles\{0}", FileName);

            using (file = new StreamWriter(Path))
            {
                foreach (Lotnisko Obj in List)
                {
                    file.WriteLine(String.Format("{0}|{1}|{2}|{3}", Obj.ID_Lotniska, Obj.Kraj, Obj.Miasto, Obj.CzyStrefaUE));
                }

                file.Close();
                Console.WriteLine("Saving Lotniska Data Files = Succes");
            }
        }

        private static void RemoveFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}