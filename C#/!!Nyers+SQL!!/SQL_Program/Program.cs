using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.InteropServices;

namespace SQL_Program
{
    internal class Program
    {
        static List<Alkalmazott> Alkalmazottak = new List<Alkalmazott>();
        static List<Gyar> Gyarak = new List<Gyar>();
        static List<Beosztas> Beosztasok = new List<Beosztas>();
        static void Main(string[] args)
        {
            Beolvasas();
            Redundancia();
            Kiiratas();
        }

        static void Kiiratas()
        {
            StreamWriter fw = new StreamWriter("tablakGeneralt.sql");
            fw.Write(ImportSzoveg(Alkalmazott.SQL_Nev,Alkalmazottak));
            fw.Write(ImportSzoveg(Gyar.SQL_Nev, Gyarak));
            fw.Write(ImportSzoveg(Beosztas.SQL_Nev, Beosztasok));
            fw.Close();
        }

        static string ImportSzoveg<T>(string nev, List<T> lista)
        {
            string szoveg = $"INSERT INTO {nev}\nVALUES\n";
            for (int i = 0; i < lista.Count-1; i++)
            {
                szoveg += $"({lista[i].ToString()}),\n";
            }
            szoveg += $"({lista[lista.Count-1].ToString()});\n\n";
            return szoveg;
        }

        static void Redundancia()
        {
            Egyediek(ref Gyarak);
        }

        static void Egyediek<T>(ref List<T> lista)
        {
            List<T> slista = new List<T>();
            for (int i = 0; i < lista.Count; i++)
            {
                 if(!vanBenne(slista, lista[i]))
                {
                    slista.Add(lista[i]);
                }
            }

            lista = slista;
        }

        static bool vanBenne<T>(List<T> lista, T item)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].ToString() == item.ToString())
                {
                    return true;
                }
            }

            return false;
        }

        static void Beolvasas()
        {
            StreamReader fr = new StreamReader("nyersAdatok.txt");
            while(!fr.EndOfStream)
            {
                string[] sor = fr.ReadLine().Split(';');
                Alkalmazott sa = new Alkalmazott(sor[0], sor[1], Convert.ToInt32(sor[3]), Convert.ToInt32(sor[2]), sor[4], sor[5]);
                Gyar gya = new Gyar(sor[7], sor[9], Convert.ToInt32(sor[6]), Convert.ToInt32(sor[8]), Convert.ToInt32(sor[10]));
                Beosztas ba = new Beosztas(sor[7], Convert.ToInt32(sor[3]));

                Alkalmazottak.Add(sa);
                Gyarak.Add(gya);
                Beosztasok.Add(ba);
            }
        }

    }

    class Beosztas
    {
        static public string SQL_Nev = "Beosztás";
        public string gyarnev;
        public int taj;

        public Beosztas(string gyarnev, int taj)
        {
            this.gyarnev = gyarnev;
            this.taj = taj;
        }

        public override string ToString()
        {
            return $"{taj}, \"{gyarnev}\"";
        }
    }

    class Gyar
    {
        static public string SQL_Nev = "Gyár";
        public string nev, telepules;
        public int ahm, epitesiev, bevetel;

        public Gyar(string nev, string telepules, int ahm, int epitesiev, int bevetel)
        {
            this.nev = nev;
            this.telepules = telepules;
            this.ahm = ahm;
            this.epitesiev = epitesiev;
            this.bevetel = bevetel;
        }

        public override string ToString()
        {
            return $"\"{nev}\", {ahm}, {epitesiev}, \"{telepules}\", {bevetel}";
        }
    }

    class Alkalmazott
    {
        static public string SQL_Nev = "Alkalmazott";
        public string nev, email, szuletesidatum, telefonszam;
        public int taj, fizetes;

        public Alkalmazott(string nev, string email, int taj, int fizetes, string szuletesidatum, string telefonszam)
        {
            this.nev = nev;
            this.email = email;
            this.taj = taj;
            this.fizetes = fizetes;
            this.szuletesidatum = szuletesidatum;
            this.telefonszam = telefonszam;
        }

        public override string ToString()
        {
            return $"{taj}, \"{nev}\", \"{email}\", {fizetes}, \"{szuletesidatum}\", \"{telefonszam}\"";
        }
    }
}
