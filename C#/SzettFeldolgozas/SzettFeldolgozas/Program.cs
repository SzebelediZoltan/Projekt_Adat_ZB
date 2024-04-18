using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SzettFeldolgozas
{
    internal class Program
    {
        static Random r = new Random();
        static List<Szett> szettek = new List<Szett>();
        static List<string> gyarNevek = new List<string>();
        static List<GyartasiSor> sorok = new List<GyartasiSor>();
        static void Main(string[] args)
        {
            Beolvasas();
            GyartasiSorGeneralas();

            Kiiratas();
        }

        static void GyartasiSorGeneralas()
        {
            for (int i = 0; i < szettek.Count; i++)
            {
                List<int> voltak = new List<int>();

                while (!(voltak.Count == 3))
                {
                    int szam = r.Next(0, 10);
                    if (!voltak.Contains(Convert.ToInt32(szettek[szam].szeriaszam))) 
                    {
                        voltak.Add(Convert.ToInt32(szettek[szam].szeriaszam));
                        GyartasiSor gy = new GyartasiSor(gyarNevek[i], r.Next(100, 2501), Convert.ToInt32(szettek[szam].szeriaszam), r.Next(2000, 100001));
                        sorok.Add(gy);
                    }
                }
            }
        }

        static void Kiiratas()
        {
            StreamWriter fw = new StreamWriter("SQL_Szett.sql");
            fw.Write(ImportSzoveg(Szett.SQL_Nev, szettek));
            fw.Write(ImportSzoveg(GyartasiSor.SQL_Nev, sorok));
            fw.Close();
        }

        static string ImportSzoveg<T>(string nev, List<T> lista)
        {
            string szoveg = $"INSERT INTO {nev}\nVALUES\n";
            for (int i = 0; i < lista.Count - 1; i++)
            {
                szoveg += $"({lista[i].ToString()}),\n";
            }
            szoveg += $"({lista[lista.Count - 1].ToString()});\n\n";
            return szoveg;
        }

        static void Beolvasas()
        {
            StreamReader fr = new StreamReader("szettek.txt");
            while (!fr.EndOfStream)
            {
                string sorr = fr.ReadLine();
                string[] sor = sorr.Split(';');
                Szett v = new Szett(sor[1], sor[3], sor[5], sor[7], sor[0], sor[2], sor[4], sor[6]);
                szettek.Add(v);
            }
            fr.Close();

            StreamReader fr2 = new StreamReader("gyarak.txt");
            while (!fr2.EndOfStream)
            {
                string sorr = fr2.ReadLine();
                string[] sor = sorr.Split(';');
                gyarNevek.Add(sor[1]);
            }
        }
    }

    class GyartasiSor
    {
        static public string SQL_Nev = "Gyártási_Sor";
        public string gyarNev;
        public int AHM, szeriaszam, gyartasiAr;

        public GyartasiSor (string gyarNev, int AHM, int szeriaszam, int gyartasiAr)
        {
            this.gyarNev = gyarNev;
            this.AHM = AHM;
            this.szeriaszam = szeriaszam;
            this.gyartasiAr = gyartasiAr;
        }

        public override string ToString()
        {
            return $"\"{gyarNev}\", {szeriaszam}, {gyartasiAr}, {AHM}";
        }
    }

    class Szett
    {
        static public string SQL_Nev = "Szett";
        public string nev, forgalomban, tema, szeriaszam, kiadasiev, ar, db, kor;

        public Szett(string nev, string forgalomban, string tema, string szeriaszam, string kiadasiev, string ar, string db, string kor)
        {
            this.nev = nev;
            this.forgalomban = forgalomban;
            this.tema = tema;
            this.ar = ar;
            this.db = db;
            this.kor = kor;
            this.szeriaszam = szeriaszam;
            this.kiadasiev = kiadasiev;
        }

        public override string ToString()
        {
            return $"{kiadasiev}, \"{nev}\", {ar}, {forgalomban}, {db}, \"{tema}\", {kor}, {szeriaszam}";
        }
    }
}
