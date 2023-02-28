using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KarácsonyiCLI
{
    class Program
    {
        class NapiMunka
        {
            public static int KeszultDb { get; private set; }
            public int Nap { get; private set; }
            public int HarangKesz { get; private set; }
            public int HarangEladott { get; private set; }
            public int AngyalkaKesz { get; private set; }
            public int AngyalkaEladott { get; private set; }
            public int FenyofaKesz { get; private set; }
            public int FenyofaEladott { get; private set; }

            public NapiMunka(string sor)
            {
                string[] s = sor.Split(';');
                Nap = Convert.ToInt32(s[0]);
                HarangKesz = Convert.ToInt32(s[1]);
                HarangEladott = Convert.ToInt32(s[2]);
                AngyalkaKesz = Convert.ToInt32(s[3]);
                AngyalkaEladott = Convert.ToInt32(s[4]);
                FenyofaKesz = Convert.ToInt32(s[5]);
                FenyofaEladott = Convert.ToInt32(s[6]);

                NapiMunka.KeszultDb += HarangKesz + AngyalkaKesz + FenyofaKesz;
            }

            public int NapiBevetel()
            {
                return -(HarangEladott * 1000 + AngyalkaEladott * 1350 + FenyofaEladott * 1500);
            }
        }

        static List<NapiMunka> tarolo = new List<NapiMunka>();

        static void beolvas()
        {
            StreamReader olvas = new StreamReader("diszek.txt");
            string sor;
            NapiMunka egynap;

            while (!olvas.EndOfStream)
            {
                sor = olvas.ReadLine();
                egynap = new NapiMunka(sor);
                tarolo.Add(egynap);
            }
            olvas.Close();
            olvas.Dispose();
            egynap = null;
        }

        static void fel4()
        {
            int osszeg = 0;
                foreach(NapiMunka item in tarolo)
            {
                osszeg += item.AngyalkaKesz + item.FenyofaKesz + item.HarangKesz;
            }
            Console.WriteLine("4. Feladat: Összesen {0} darab készült.", NapiMunka.KeszultDb);   
        }

        static void fel5()
        {
            int osszeg = 0;
            foreach (NapiMunka item in tarolo)
            {
                osszeg += item.AngyalkaKesz + item.FenyofaKesz + item.HarangKesz;
                if(osszeg==0)
                {
                    Console.WriteLine("5. Feladat: Volt olyan nap, amikor egyetlen disz sem készült.\n");
                    break;
                }
            }
        }

        static void fel6()
        {
            Console.WriteLine("6.Feladat");
            int nap = 0;
            do
            {
                Console.Write("Adja meg a keresett napot [1...40]:");
                nap = Convert.ToInt32(Console.ReadLine());
            } while (nap < 1 || nap > 40);

            int angyal = 0;
            int fenyo = 0;
            int harang = 0;
            foreach(NapiMunka item in tarolo)
            {
                angyal += item.AngyalkaKesz + item.AngyalkaEladott;
                fenyo += item.FenyofaKesz + item.FenyofaEladott;
                harang += item.HarangKesz + item.HarangEladott;

                if (item.Nap >= nap)
                    break;
            }
            Console.WriteLine("\tA(z) {0}. nap végén {1} harang, {2} angyalka és {3} fenyőfa maradt készleten.\n", nap, harang, fenyo, angyal);
        }
        static void Main(string[] args)
        {
            beolvas();
            fel4();
            fel5();
            fel6();

            Console.ReadKey();
        }
    }
}
