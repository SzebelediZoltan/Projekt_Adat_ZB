using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nev_Gyaqr
{
    class Program
    {
        static List<Alkalmazott> alkalmazottak = new List<Alkalmazott>();
        static List<Gyar> gyarak = new List<Gyar>();
        static void Main(string[] args)
        {
            Fajlbeolvasas1();
            Fajlbeolvasas2();

            Kiiras();
        }

        static void Kiiras()
        {
            Random r = new Random();
            StreamWriter fw = new StreamWriter("nyersAdatok.txt");
            for (int i = 0; i < alkalmazottak.Count; i++)
            {
                int szam = r.Next(0, 101);
                fw.Write($"{alkalmazottak[i].nev};{alkalmazottak[i].email};{alkalmazottak[i].fizetes};{alkalmazottak[i].taj};{alkalmazottak[i].szuletes};{alkalmazottak[i].telefonszam};{gyarak[szam].ahm};{gyarak[szam].nev};{gyarak[szam].epitesiev};{gyarak[szam].telepules};{gyarak[szam].bevetel}\n");
            }
        }

        static void Fajlbeolvasas2()
        {
            StreamReader fr = new StreamReader("Gyarak.txt");

            while (!fr.EndOfStream)
            {
                string[] sor = fr.ReadLine().Split(';');
                Gyar v = new Gyar(Convert.ToInt32(sor[0]), sor[1], Convert.ToInt32(sor[2]), sor[3], Convert.ToInt32(sor[4]));
                gyarak.Add(v);
            }
        }

        static void Fajlbeolvasas1()
        {
            StreamReader fr = new StreamReader("Alkalmazottak.txt");

            while(!fr.EndOfStream)
            {
                string[] sor = fr.ReadLine().Split(';');
                Alkalmazott v = new Alkalmazott(sor[0], sor[1], Convert.ToInt32(sor[2]), Convert.ToInt32(sor[3]), sor[4], sor[5]);
                alkalmazottak.Add(v);
            }
        }
    }

    class Gyar
    {
        public string nev, telepules;
        public int ahm, epitesiev, bevetel;

        public Gyar(int ahm, string nev, int epitesiev, string telepules, int bevetel)
        {
            this.nev = nev;
            this.telepules = telepules;
            this.ahm = ahm;
            this.epitesiev = epitesiev;
            this.bevetel = bevetel;
        }
    }

    class Alkalmazott
    {
        public string nev, email, szuletes, telefonszam;
        public int taj, fizetes;

        public Alkalmazott(string nev, string email, int fizetes, int taj, string telefonszam, string szuletes)
        {
            this.nev = nev;
            this.email = email;
            this.szuletes = szuletes;
            this.telefonszam = telefonszam;
            this.taj = taj;
            this.fizetes = fizetes;
        }
    }
}
