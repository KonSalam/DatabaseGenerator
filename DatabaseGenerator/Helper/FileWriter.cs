using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public static void WritePrzelotToFile(List<Przelot> List, string FileName)
        {
            Path = String.Format(@"C:\Users\Konrad\Documents\DatabaseFiles\{0}", FileName);

            using (file = new StreamWriter(Path))
            {
                foreach (Przelot Obj in List)
                {
                    file.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}", Obj.NumerLotu, Obj.PlanowanaDataRozpoczecia, Obj.PlanowanaDataZakonczenia, Obj.FaktycznaDataRozpoczecia, Obj.FaktycznaDataZakonczenia));
                }

                file.Close();
                Console.WriteLine("Saving Przeloty Data Files = Succes");
            }
        }

        public static void WriteZdarzeniaToFile(List<Zdarzenia> List, string FileName)
        {
            Path = String.Format(@"C:\Users\Konrad\Documents\DatabaseFiles\{0}", FileName);

            using (file = new StreamWriter(Path))
            {
                foreach (Zdarzenia Obj in List)
                {
                    file.WriteLine(String.Format("{0}|{1}|{2}|{3}", Obj.DataZdarzenia, Obj.FK_Przelot, Obj.Typ, Obj.Opis));
                }

                file.Close();
                Console.WriteLine("Saving Zdarzenia Data Files = Succes");
            }
        }

        public static void WriteZdarzeniaToXML(List<Zdarzenia> List, string FileName)
        {
            Path = String.Format(@"C:\Users\Konrad\Documents\DatabaseFiles\{0}", FileName);
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName= "zdarzenia";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Zdarzenia>), oRootAttr);

            using (TextWriter file = new StreamWriter(Path))
            {
                oSerializer.Serialize(file, List);
                file.Close();
                Console.WriteLine("Saving Zdarzenia XML Data Files = Succes");
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