using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SQLProgram
{
    class Program
    {
        //VÁLTOZÓK
        static List<Alkalmazott> alkalmazottak = new List<Alkalmazott>();
        static List<Alkalmazott> ujalkalmazottak = new List<Alkalmazott>();
        
        static List<Gyar> gyarak = new List<Gyar>();
        static List<Gyar> ujgyarak = new List<Gyar>();

        static List<Beosztas> beosztasok  = new List<Beosztas>();
        static List<Beosztas> ujbeosztasok  = new List<Beosztas>();

        static List<GyartasiSor> gyarsorok = new List<GyartasiSor>();
        static List<GyartasiSor> ujgyarsorok = new List<GyartasiSor>();


        static void Main(string[] args)
        {
            //MAIN
            Fajlbeolvasas1();
            Fajlbeolvasas2();
            Fajlbeolvasas3();
            Fajlbeolvasas4();
            Redundancia1();
            Redundancia2();
            Redundancia3();
            Redundancia4();
            InsertFunction1();
            InsertFunction2();
            InsertFunction3();
            InsertFunction4();

            //END
            Console.ReadKey();
        }
        //METÓDUSOK
        static void InsertFunction1()
        {
            Console.WriteLine("INSERT INTO Alkalmazott (");
            for (int i = 0; i < alkalmazottak.Count; i++)
            {
                Alkalmazott a = alkalmazottak[i];
                Console.WriteLine($" {a.taj}, {a.nev}, {a.email}, {a.fizetes}, {a.datum}, {a.telefonszam}");
            }
            Console.WriteLine(");");
        }

        static void InsertFunction2()
        {
            Console.WriteLine("INSERT INTO  (");
            for (int i = 0; i < .Count; i++)
            {
                 a = [i];
                Console.WriteLine($" {a.}, {}");
            }
            Console.WriteLine(");");
        }

        static void InsertFunction3()
        {
            Console.WriteLine("INSERT INTO  (");
            for (int i = 0; i < .Count; i++)
            {
                a = [i];
                Console.WriteLine($" {a.}, {}");
            }
            Console.WriteLine(");");
        }

        static void InsertFunction4()
        {
            Console.WriteLine("INSERT INTO  (");
            for (int i = 0; i < .Count; i++)
            {
                a = [i];
                Console.WriteLine($" {a.}, {}");
            }
            Console.WriteLine(");");
        }


        static void Redundancia1()
        {
            for (int i = 0; i < alkalmazottak.Count; i++)
            {
                if (!BenneVanE1(alkalmazottak[i]))
                {
                    ujalkalmazottak.Add(alkalmazottak[i]);
                }
            }
        }

        static bool BenneVanE1(Alkalmazott a)
        {
            int j = 0;
            while(j < ujalkalmazottak.Count && !a.Equals(ujalkalmazottak[j]))
            {
                j++;
            }
            return j < ujalkalmazottak.Count;
        }

        //2
        static void Redundancia2()
        {
            for (int i = 0; i < gyarak.Count; i++)
            {
                if (!BenneVanE2(gyarak[i]))
                {
                    ujgyarak.Add(gyarak[i]);
                }
            }
        }

        static bool BenneVanE2(Gyar a)
        {
            int j = 0;
            while (j < ujgyarak.Count && !a.Equals(ujgyarak[j]))
            {
                j++;
            }
            return j < ujgyarak.Count;
        }
        
        //3
        static void Redundancia3()
        {
            for (int i = 0; i < beosztasok.Count; i++)
            {
                if (!BenneVanE3(beosztasok[i]))
                {
                    ujbeosztasok.Add(beosztasok[i]);
                }
            }
        }

        static bool BenneVanE3(Beosztas a)
        {
            int j = 0;
            while (j < ujbeosztasok.Count && !a.Equals(ujbeosztasok[j]))
            {
                j++;
            }
            return j < ujbeosztasok.Count;
        }

        //4
        static void Redundancia4()
        {
            for (int i = 0; i < gyarsorok.Count; i++)
            {
                if (!BenneVanE4(gyarsorok[i]))
                {
                    ujgyarsorok.Add(gyarsorok[i]);
                }
            }
        }

        static bool BenneVanE4(GyartasiSor a)
        {
            int j = 0;
            while (j < ujgyarsorok.Count && !a.Equals(ujgyarsorok[j]))
            {
                j++;
            }
            return j < ujgyarsorok.Count;
        }

        //FájlBeolvasás
        static void Fajlbeolvasas1()
        {
            string[] adatok = File.ReadAllLines(".txt");
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] st = adatok[i].Split(' ');
                Alkalmazott sv = new Alkalmazott(st[0], st[1], st[2], st[3], Convert.ToInt32(st[4]), Convert.ToInt32(st[5]));
                alkalmazottak.Add(sv);
            }
            // insert into .... (...),
            //(...)
            //(...)
        }

        static void Fajlbeolvasas2()
        {
            string[] adatok = File.ReadAllLines(".txt");
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] st = adatok[i].Split(' ');
                Gyar sv = new Gyar(st[0], st[1], Convert.ToInt32(st[2]), Convert.ToInt32(st[3]), Convert.ToInt32(st[4]));
                gyarak.Add(sv);
            }
            
        }

        static void Fajlbeolvasas3()
        {
            string[] adatok = File.ReadAllLines(".txt");
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] st = adatok[i].Split(' ');
                Beosztas sv = new Beosztas(Convert.ToInt32(st[0]), st[1]);
                beosztasok.Add(sv);
            }

        }

        static void Fajlbeolvasas4()
        {
            string[] adatok = File.ReadAllLines(".txt");
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] st = adatok[i].Split(' ');
                GyartasiSor sv = new GyartasiSor(st[0], Convert.ToInt32(st[1]), Convert.ToInt32(st[1]), Convert.ToInt32(st[2]));
                gyarsorok.Add(sv);
            }

        }

    }
    //STRUCT
    struct Alkalmazott
    {
        public string nev, email, telefonszam, datum;
        public int taj, fizetes;

        //KONSTRUKTOR
        public Alkalmazott(string ujnev, string ujemail, string ujtelefonszam, string ujdatum, int ujtaj, int ujfizetes)
        {
            nev = ujnev;
            email = ujemail;
            telefonszam = ujtelefonszam;
            datum = ujdatum;
            taj = ujtaj;
            fizetes = ujfizetes;
        }

        public string nevkiir()
        {
            return "Alkalmazott";
        }
    }

    struct Gyar
    {
        public string nev, telepules;
        public int ahm, epitesiev, bevetel;

        public Gyar(string ujnev, string ujtelepules, int ujahm, int ujepitesiev, int ujbevetel)
        {
            nev = ujnev;
            telepules = ujtelepules;
            ahm = ujahm;
            epitesiev = ujepitesiev;
            bevetel = ujbevetel;
        }

        public string nevkiir()
        {
            return "Gyar";
        }
    }

    /*
    struct Szett
    {
        public string nev, tema;
        public int szeriaszam, kiadasiev, ar, db, kor;
        public bool forgalomban;

        public Szett(string ujnev, string ujtema, int ujszeriaszam, int ujkiadasiev, int ujar, int ujdb, int ujkor, bool ujforgalomban)
        {
            nev = ujnev;
            tema = ujtema;
            szeriaszam = ujszeriaszam;
            kiadasiev = ujkiadasiev;
            ar = ujar;
            db = ujdb;
            kor = ujkor;
            forgalomban = ujforgalomban;
        }
    }
    */

    struct Beosztas
    {
        public int taj;
        public string gyarnev;

        public Beosztas(int ujtaj, string ujgyarnev)
        {
            taj = ujtaj;
            gyarnev = ujgyarnev;
        }

        public string nevkiir()
        {
            return "Beosztas";
        }
    }

    struct GyartasiSor
    {
        public string gyarnev;
        public int szeriaszam, gyartasiar, ahe;

        public GyartasiSor(string ujgyarnev, int ujszeriaszam, int ujgyartasiar, int ujahe)
        {
            gyarnev = ujgyarnev;
            szeriaszam = ujszeriaszam;
            gyartasiar = ujgyartasiar;
            ahe = ujahe;
        }

        public string nevkiir()
        {
            return "GyartasiSor";
        }

        public override string ToString()
        {
            return $"{gyarnev}, {szeriaszam}, {gyartasiar}, {ahe}";
        }
    }
}
