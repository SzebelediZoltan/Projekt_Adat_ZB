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

        static Random r = new Random();
        static void Main(string[] args)
        {
            //MAIN
            Fajlbeolvasas();
            Redundancia1();
            Redundancia2();
            InsertFunction();

            //END
            Console.ReadKey();
        }
        //METÓDUSOK

        static void InsertFunction()
        {
            StreamWriter f = new StreamWriter("Insert.sql");
            f.WriteLine("INSERT INTO Alkalmazott \n VALUES");
            for (int i = 0; i < alkalmazottak.Count; i++)
            {
                Alkalmazott a = alkalmazottak[i];
                f.WriteLine($"({a.taj}, \"{a.nev}\", \"{a.email}\", {a.fizetes}, \"{a.datum}\", {a.telefonszam}),");
            }
            f.WriteLine(";\n");
            f.WriteLine("INSERT INTO Gyar \n VALUES");
            for (int i = 0; i < gyarak.Count; i++)
            {
                Gyar a = gyarak[i];
                f.WriteLine($"(\"{a.nev}\", {a.ahm}, {a.epitesiev}, \"{a.telepules}\", {a.bevetel}),");
            }
            Console.WriteLine(";");
            f.Close();
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
        

        //FájlBeolvasás
        static void Fajlbeolvasas()
        {
            string[] adatok = File.ReadAllLines(".txt");
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] st = adatok[i].Split(';');
                Alkalmazott sv = new Alkalmazott(st[0], st[1], st[2], st[3], Convert.ToInt32(st[4]), Convert.ToInt32(st[5]));
                alkalmazottak.Add(sv);
                Gyar sv2 = new Gyar(st[6], st[7], Convert.ToInt32(st[8]), Convert.ToInt32(st[9]), Convert.ToInt32(st[10]));
                gyarak.Add(sv2);
            }
            // insert into .... (...),
            //(...)
            //(...)
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

    }
