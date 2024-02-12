using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Program
{
    internal class Program
    {

        // Itt tároljuk az adatokat! Így minden metódusban eléred.
        static List<Lego> legok = new List<Lego>();

        static void Main(string[] args)
        {
            Beolvasas();

            Console.ReadLine();
        }

        // Alap beolvasas konstruktor segítségével.
        static void Beolvasas()
        {
            StreamReader fr = new StreamReader("adatok.txt");

            while(!fr.EndOfStream)
            {
                string[] sorList = fr.ReadLine().Split(',');

                Lego l = new Lego(sorList);
                legok.Add(l);
            }
        }

        // Struktúra a lego szetteknek.
        struct Lego
        {
            public string nev, franchise, kor; // Változók a stringként tárolt adatoknak.
            public int szeriaSzam, kiadasEv, ar, forgalom, dbszam; // Változók az intként tárolt adatoknak.

            // Konstruktor!
            public Lego(string[] adatok)
            {
                nev = adatok[0];
                szeriaSzam = Convert.ToInt32(adatok[1]);
                franchise = adatok[2];
                kiadasEv = Convert.ToInt32(adatok[3]);
                ar = Convert.ToInt32(adatok[4]);
                kor = adatok[5];
                forgalom = Convert.ToInt32(adatok[6]);
                dbszam = Convert.ToInt32(adatok[7]);
            }
        }
    }
}
