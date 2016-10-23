using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    public class Data
    {
        //Przeloty
        public static string[] Status = { "Normalny", "Opozniony" };

        // Zaloga
        public static string[] Imie = {"Konrad", "Adam", "Maciej", "Adrian", "Daniel", "Mikolaj", "Marcin", "Kuba" , "Daria", "Julia", "Malgorzata", "Pawel",
        "Paulina", "Marta", "Darek", "Aleksandra", "Anna", "Andrzej", "Piotr", "Krzysztof", "Maria", "Krystyna", "Barbara", "Teresa", "Elzbieta", "Zofia", "Irena",
        "Ewa", "Urszula", "Wanda", "Alicja", "Dorota", "Edyta", "Agnieszka", "Jan", "Tadeusz", "Jerzy", "Ryszard", "Henryk", "Edward", "Grzegorz", "Roman", "Beata",
        "Katarzyna", "Joanna", "Renata", "Lucja", "Bozena", "Grazyna", "Marzena", "Mariola", "Emilia", "Izabela", "Agata", "Aneta", "Sylwia", "Zuzanna", "Natalia",
        "Justyna", "Ilona", "Karolina", "Aldona", "Tomasz", "Wojciech", "Stefan", "Zygmunt", "Jacek", "Dariusz", "Karol", "Franciszek", "Robert", "Mariusz", "Witold",
        "Aleksander", "Ireneusz", "Artur", "Leon", "Rafal", "Ludwik", "Sylwester", "Wiktor", "Ignacy" };

        public static string[] Nazwisko = { "Nowak", "Salamon", "Grzyb", "Dab", "Dudek", "Mazur", "Wojcik", "Kaczmarek", "Krawczyk", "Adamczyk", "Zajac", "Krol",
        "Wrobel", "Pawlak", "Walczak", "Stepien", "Sikora", "Baran", "Duda", "Szewczyk", "Pietrzak", "Bak", "Kubiak", "Wilk", "Lis", "Los", "Kuna", "Jenot", "Rys",
        "Zubr", "Bazant", "Lyska", "Bekas", "Cietrzew", "Mazurek", "Sobczak", "Kazimierczak", "Cieslak", "Kolodziej", "Szymczak", "Szulc", "Mroz", "Mrozkowiak",
        "Krupa", "Kozak", "Kania", "Mucha", "Tomczak", "Koziol", "Kowalik", "Janik", "Musial", "Tomczyk", "Jarosz", "Kurek", "Kopec", "Zak", "Luczak", "Dziedzic",
        "Kot", "Stasiak", "Piatek", "Polak", "Kruk", "Jozwiak", "Urban", "Pawlik", "Domagala", "Zieba", "Janicki", "Maj", "Sowa", "Gajda", "Klimek", "Ratajczak",
        "Madej", "Kasprzak", "Grzelak", "Marek", "Kowal", "Bednarczyk", "Skiba", "Wrona", "Owczarek", "Matusiak", "Olejnik", "Pajak", "Czech", "Lukasik", "Lesniak"};

        public static string[] Stanowisko = { "Kapitan", "Drugi Pilot", "Nawigator", "Technik", "Starszy Steward", "Steward" };

        // Samolot
        public static string[] Model = { "Airbus A330-300", "Boeing B747-200" ,"Boeing B747-400","ATR72-500", "Antonov AN-24B", "Boeing 737-400", "Bombardier Dash Q400",
                                        "Embarer 170", "Tupolew TU-154", "Sukhoi 100w", "Fokker 100", "Concorde 110A", "Ilyushi IL-86", "Airbus E330", "Antonov AN-11C", "ATR35-270", "Boeing El1"};

        // public static int[] LiczbaMiejsc = { 900, 853, 800, 776, 700, 680, 640, 624, 550, 525, 440, 372, 350, 295 }; 
        public static int[] LiczbaMiejsc = { 56, 54, 52, 50, 48, 46, 44, 42, 40, 38, 36, 34, 32, 30, 28, 26, 24 };

        public static int[] Paliwo = { 310000, 300000, 290000, 280000, 270000, 260000, 250000, 240000, 230000, 220000, 210000, 200000, 190000, 180000, 170000, 160000, 150000 };

        // Zdarzenia
        public static Dictionary<string, string[]> ZdarzeniaTypOpis = new Dictionary<string, string[]>()
        {
            {"Kolizja", new string[] {"wina pilota","turbulencja", "zderzenie z ptakiem", "wtargniecie na pas startowy", "blad stacji kontroli lotow"} },
            {"Pogoda",  new string[] {"mgla", "burza", "silny wiatr", "huragan"} },
            {"Uszkodzenie samolotu",  new string[] {"uszkodzenie silnika","uszkodzenie podwozia", "uszkodzenie nadwozia", "uszkodzenie skrzydla"} },
            {"Wypadek na pokladzie",  new string[] {"pozar", "sabotaz", "atak pasazera" } },
            {"Awaria",  new string[] {"nieszczelnosc", "wyciek paliwa", "brak ciagu", "brak lacznosci", "awaria czujnikow", "awaria elektroniki" } }
        };

        // Lotniska
        public static Dictionary<string, string[]> LotniskoKrajMiastoUE = new Dictionary<string, string[]>()
        {
            {"Polska", new string[] {"Gdansk","Warszawa","Krakow","Poznan" } },
            {"Rosja",  new string[] {"Moskwa","Kalingrad","Petersburg","Kazan" } },
            {"Austria",  new string[] {"Wieden","Salzburg","Linz","Innsbruck" } },
            {"Belgia",  new string[] {"Antwerpia","Bruksela","Genk","Hasselt" } },
            {"Holandia",  new string[] {"Amsterdam","Eindhoven","Groningen","Rotterdam" } },
            {"Niemcy",  new string[] {"Berlin","Monachium","Hanower","Brema" } },
            {"Dania",  new string[] {"Kopenhaga","Karup","Esbjerg","Aalborg" } },
            {"Chorwacja",  new string[] {"Zagrzeb","Zadar","Osijek","Rijeka" } },
            {"Grecja",  new string[] {"Ateny","Rodos","Paros","Ikaria" } },
            {"Estonia",  new string[] {"Tallin","Tartu","Kardla","Kuressaare" } },
            {"Hiszpania",  new string[] {"Madryt","Girona","Malaga","Burgos" } },
            {"Czechy",  new string[] {"Praga","Ostrawa","Brno","Pardubice" } }

        };

        public static Dictionary<string, string[]> LotnistkoKrajMiasto = new Dictionary<string, string[]>()
        {
            {"USA", new string[] {"Nowy Jork","Waszyngton","Chicago","Los Angeles" } },
            {"Brazylia",  new string[] {"Rio de Janeiro","Salvador","Brasilia","Sao Paulo" } },
            {"Chiny",  new string[] {"Szanghaj","Pekin","Guangzhou","Xiamen" } },
            {"Egipt",  new string[] {"Kair","Aleksandria","Luksor","Asjut" } },
            {"Tajlandia",  new string[] {"Bangkok","Ranong","Loei","Krabi" } },
            {"Filipiny",  new string[] {"Davao","Dipolog","Laoag","Bacolod" } },
            {"Indie",  new string[] {"Mumbej","Maduraj","Bhuj","Gaya" } },
            {"Korea Poludniowa",  new string[] {"Seul","Ulsan","Osan","Yeosu" } },
            {"Japonia",  new string[] {"Tokio","Osaka","Sapporo","Misawa" } },
            {"Argentyna",  new string[] {"Buenos Aires","Rio Grande","Cordoba","Formoza" } },
            {"Peru",  new string[] {"Lima","Cuzco","Talara","Piura" } },
            {"Kanada",  new string[] {"Toronto","Hamilton","Vancouver","Montreal" } }
        };

    }
}