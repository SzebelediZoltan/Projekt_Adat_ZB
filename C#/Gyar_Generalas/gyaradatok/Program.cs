using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gyaradatok
{
    class Program
    {
        //VÁLTOZÓK
        static List<Gyarak> gyar = new List<Gyarak>();
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
            StreamWriter f = new StreamWriter("gyarak.txt");
            for (int i = 0; i < gyar.Count; i++)
            {
                f.WriteLine($"{gyar[i].ahm};{gyar[i].nev};{gyar[i].epites};{gyar[i].telepules};{gyar[i].bevetel}");
            }
            f.Close();
        }

        static void Adat()
        {
            for (int i = 0; i < 50; i++)
            {
                Gyarak sv = new Gyarak(Ahm(), EpitesiEv(), Bevetel(), Nev(Telepules(i)), Telepules(i));
                gyar.Add(sv);
            }
        }

        static int Ahm()
        {
            return r.Next(2500000, 4000001);
        }

        static int EpitesiEv()
        {
            return r.Next(1920, 2021);
        }

        static int Bevetel()
        {
            return r.Next(2000000000, 2147483647);
        }

        static string Nev(string varos)
        {
            return varos + "i Lego Gyár";
        }

        static string Telepules(int index)
        {
            string[] varosok = File.ReadAllLines("varosok.txt");
            return varosok[index];
        }

        //END
    }
    //STRUCT
    struct Gyarak
    {
        public int ahm, epites, bevetel;
        public string nev, telepules;

        public Gyarak(int ujahm, int ujepites, int ujbevetel, string ujnev, string ujtelepules)
        {
            ahm = ujahm;
            epites = ujepites;
            bevetel = ujbevetel;
            nev = ujnev;
            telepules = ujtelepules;
        }
    }

    //END
}
