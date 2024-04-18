using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace adatok
{
    class Program
    {
        //VÁLTOZÓK
        static List<Alkalmazott> adatok = new List<Alkalmazott>();
        static Random r = new Random();
        static void Main(string[] args)
        {
            //MAIN
            Adat();
            Kiiratas();

            //END
            Console.ReadKey();
        }
        //METÓDUSOK
        static void Kiiratas()
        {
            StreamWriter f = new StreamWriter("alkalmazottak.txt");
            for (int i = 0; i < adatok.Count; i++)
            {
                f.WriteLine($"{adatok[i].nev};{adatok[i].email};{adatok[i].fizetes};{adatok[i].taj};{adatok[i].szuletes};{adatok[i].telefonszam}");
            }
            f.Close();
        }

        static void Adat()
        {
            for (int i = 0; i < 100; i++)
            {
                Alkalmazott sv = new Alkalmazott(Tajszam(), Fizetes(), Nev(i), Email(Nev(i)), Szuletes(), Telefonszam());
                adatok.Add(sv);
            }
        }
        static int Tajszam()
        {
            return r.Next(146000000, 147000000);
        }

        static int Fizetes()
        {
            return r.Next(400000, 600001);
        }

        static string Nev(int index)
        {
            string[] nevek = File.ReadAllLines("nevek.txt");
            return nevek[index];
        }

        static string Email(string nev)
        {
            string[] neve = nev.Split(' ');
            string email = neve[0] + "." + neve[1] + "@gmail.com";
            return email;
        }

        static string Szuletes()
        {
            string szuletesnap = r.Next(1930, 2001) + "-" + r.Next(0, 13) + "-" + r.Next(1, 29);
            return szuletesnap;
        }

        static string Telefonszam()
        {
            List<string> elojelek = new List<string>();
            elojelek.Add("20");
            elojelek.Add("30");
            elojelek.Add("70");
            string telszam = "06" + elojelek[r.Next(0, 3)] + r.Next(1000000, 9999999);
            return telszam;
        }
    }
    //STRUKTÚRA
    struct Alkalmazott
    {
        public int taj, fizetes;
        public string nev, email, szuletes, telefonszam;

        public Alkalmazott(int ujtaj, int ujfizetes, string ujnev, string ujemail, string ujszuletes, string ujtelefonszam)
        {
            taj = ujtaj;
            fizetes = ujfizetes;
            nev = ujnev;
            email = ujemail;
            szuletes = ujszuletes;
            telefonszam = ujtelefonszam;
        }
    }
}
