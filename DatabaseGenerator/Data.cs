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
        public static string[] Imie = {"Konrad", "Adam", "Maciej", "Adrian", "Daniel", "Mikołaj", "Marcin", "Kuba" , "Daria", "Julia", "Malgorzata", "Pawel",
        "Paulina", "Marta", "Darek", "Aleksandra", "Anna", "Andrzej", "Piotr", "Krzysztof", "Maria", "Krystyna", "Barbara", "Teresa", "Elzbieta", "Zofia", "Irena",
        "Ewa", "Urszula", "Wanda", "Alicja", "Dorota", "Edyta", "Agnieszka", "Jan", "Tadeusz", "Jerzy", "Ryszard", "Henryk", "Edward", "Grzegorz", "Roman", "Beata",
        "Katarzyna", "Joanna", "Renata", "Lucja", "Bożena", "Grażyna", "Marzena", "Mariola", "Emilia", "Izabela", "Agata", "Aneta", "Sylwia", "Zuzanna", "Natalia",
        "Justyna", "Ilona", "Karolina", "Aldona", "Tomasz", "Wojciech", "Stefan", "Zygmunt", "Jacek", "Dariusz", "Karol", "Franciszek", "Robert", "Mariusz", "Witold",
        "Aleksander", "Ireneusz", "Artur", "Leon", "Rafał", "Ludwik", "Sylwester", "Wiktor", "Ignacy" };

        public static string[] Nazwisko = { "Nowak", "Salamon", "Grzyb", "Dab", "Dudek", "Mazur", "Wojcik", "Kaczmarek", "Krawczyk", "Adamczyk", "Zajac", "Krol",
        "Wrobel", "Pawlak", "Walczak", "Stepien", "Sikora", "Baran", "Duda", "Szewczyk", "Pietrzak", "Bak", "Kubiak", "Wilk", "Lis", "Los", "Kuna", "Jenot", "Rys",
        "Zubr", "Bazant", "Łyska", "Bekas", "Cietrzew", "Mazurek", "Sobczak", "Kazimierczak", "Cieślak", "Kołodziej", "Szymczak", "Szulc", "MrOz", "Mrozkowiak",
        "Krupa", "Kozak", "Kania", "Mucha", "Tomczak", "Kozioł", "Kowalik", "Janik", "Musiał", "Tomczyk", "Jarosz", "Kurek", "Kopeć", "Zak", "luczak", "Dziedzic",
        "Kot", "Stasiak", "Piatek", "Polak", "Kruk", "Jozwiak", "Urban", "Pawlik", "DomagaLa", "ZiEba", "Janicki", "Maj", "Sowa", "Gajda", "Klimek", "Ratajczak",
        "Madej", "Kasprzak", "Grzelak", "Marek", "Kowal", "Bednarczyk", "Skiba", "Wrona", "Owczarek", "Matusiak", "Olejnik", "Pająk", "Czech", "Lukasik", "Lesniak"};

        public static string[] Stanowisko = { "Kapitan", "Drugi Pilot", "Nawigator", "Technik", "Starszy Steward" ,"Steward" };

        // Samolot
        public static string[] Model = { "Airbus A330-300", "Boeing B747-200" ,"Boeing B747-400","ATR72-500"}; // dodac z 12 

        public static int[] LiczbaMiejsc = { 900, 853, 800, 776, 700, 680, 640, 624, 550, 525, 440, 372, 350, 295 };

        public static int[] Paliwo = { 310000, 300000, 290000,  }; // uzupelnic ze skalowaniem malejącym względem ilosci miejsc ( tyle samo rekordow co miejsc)

        // Zdarzenia
        public static Dictionary<string, string[]> ZdarzeniaTypOpis = new Dictionary<string, string[]>()
        {
            {"Kolizja", new string[] {"Wina Pilota","Turbulencja" } },
            {"CHUJ",  new string[] {"DUPA","CYCKI" } }

         // dodaj tak zeby bylo fajnie 
        };

        // Lotniska
        public static Dictionary<string, string[]> LotniskoKarjMiastoUE = new Dictionary<string, string[]>()
        {
            {"Polska", new string[] {"Gdansk","Warszawa","Krakow","Poznan" } },
            {"Rosja",  new string[] {"Moskwa","Kalingrad","Petersburg","Kazan" } }

            //dodac z 10 krajow po 4 miasta 
        };

        public static Dictionary<string, string[]> LotniskoKarjMiasto = new Dictionary<string, string[]>()
        {
            {"USA", new string[] {"Nowy Jork","Waszyngton","Chicago","Los Angeles" } },
            {"Brazylia",  new string[] {"Rio de Janeiro","Salvador","Brasilia","Sao Paulo" } }

            //dodac z 10 krajow po 4 miasta 
        };

    }
}