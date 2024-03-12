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
        static void Main(string[] args)
        {
            //MAIN
            Fajlbeolvasas();

            //END
            Console.ReadKey();
        }
        //METÓDUSOK
        static void Fajlbeolvasas()
        {
            string[] adatok = File.ReadAllLines(".txt");
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] st = adatok[i].Split(' ');
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

    struct Beosztas
    {
        public int taj;
        public string gyarnev;

        public Beosztas(int ujtaj, string ujgyarnev)
        {
            taj = ujtaj;
            gyarnev = ujgyarnev;
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
    }
}
