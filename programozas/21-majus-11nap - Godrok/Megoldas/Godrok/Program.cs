using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Godrok
{
    internal class Program
    {
        static List<int> melysegAdatok = new List<int>();
        static int godrokSzama = 0;
        static int tavolsagErtek = 0;

        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
        }

        static void Feladat1()
        {
            Console.WriteLine("1. feladat");

            StreamReader olvaso = new StreamReader("melyseg.txt");

            string sor = olvaso.ReadLine();

            while (!string.IsNullOrEmpty(sor))
            {
                int.TryParse(sor, out int sorErteke);
                melysegAdatok.Add(sorErteke);
                sor = olvaso.ReadLine();
            }

            olvaso.Close();

            Console.WriteLine($"A fájl adatainak száma: {melysegAdatok.Count}");
            Console.WriteLine();
        }

        static void Feladat2()
        {
            Console.WriteLine("2. feladat");

            Console.Write("Adjon meg egy távolságértéket! ");
            string tavolsag = Console.ReadLine();

            int.TryParse(tavolsag, out tavolsagErtek);

            Console.WriteLine($"Ezen a helyen a felszín {melysegAdatok[tavolsagErtek - 1]} méter mélyen van.");
            Console.WriteLine();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat");

            double erintetlen = 0;

            foreach (int melysegAdat in melysegAdatok)
            {
                if (melysegAdat == 0)
                {
                    erintetlen += 1;
                }
            }

            double erintetlenTerulet = erintetlen / melysegAdatok.Count * 100;

            Console.WriteLine($"Az érintetlen terület aránya {erintetlenTerulet}%.");
            Console.WriteLine();
        }

        static void Feladat4()
        {
            StreamWriter fileIro = new StreamWriter("godrok.txt");

            string godorLeirasa = "";

            foreach (int melysegAdat in melysegAdatok)
            {
                if (melysegAdat != 0)
                {
                    godorLeirasa = godorLeirasa + melysegAdat + " ";
                }
                else
                {
                    fileIro.WriteLine(godorLeirasa);
                    godrokSzama += 1;
                    godorLeirasa = "";
                }
            }

            fileIro.Close();
        }

        static void Feladat5()
        {
            Console.WriteLine("5. feladat");

            Console.WriteLine($"A gödrök száma: {godrokSzama}");
            Console.WriteLine();
        }

        static void Feladat6()
        {
            Console.WriteLine("6. feladat");

            if (melysegAdatok[tavolsagErtek - 1] == 0)
            {
                Console.WriteLine("Az adott helyen nincs gödör.");
            }
            else
            {
                List<int> godorLeirasa = new List<int>();
                bool ezAzAGodorAmitKeresunk = false;
                int godorKezdete = 0;
                int godorVege = 0;
                int index = -1;

                foreach (int melysegAdat in melysegAdatok)
                {
                    index += 1;

                    if (tavolsagErtek == index)
                    {
                        ezAzAGodorAmitKeresunk = true;
                    }

                    if (melysegAdat == 0)
                    {
                        if (ezAzAGodorAmitKeresunk)
                        {
                            break;
                        }
                        else
                        {
                            godorKezdete = 0;
                            godorVege = 0;
                            godorLeirasa.Clear();
                        }
                    }
                    else
                    {
                        godorLeirasa.Add(melysegAdat);
                        if (godorKezdete == 0)
                        {
                            godorKezdete = index + 1;
                        }
                        godorVege = index + 1;
                    }
                }

                Console.WriteLine("a)");
                Console.WriteLine($"A gödör kezdete: {godorKezdete} méter, a gödör vége: {godorVege} méter.");

                Console.WriteLine("b)");
                bool melyulFolyamatosan = true;
                int elozoMelyseg = 0;
                foreach (int melyseg in godorLeirasa)
                {
                    if (melyseg < elozoMelyseg)
                    {
                        melyulFolyamatosan = false;
                    }
                    elozoMelyseg = melyseg;
                }

                if (melyulFolyamatosan)
                {
                    Console.WriteLine($"Mélyül folyamatosan.");
                }
                else
                {
                    Console.WriteLine($"Nem mélyül folyamatosan.");
                }

                Console.WriteLine("c)");
                Console.WriteLine($"A legnagyobb mélysége {godorLeirasa.Max()} méter.");

                Console.WriteLine("d)");
                int terfogata = 0;
                foreach (int melyseg in godorLeirasa)
                {
                    terfogata += melyseg * 10;
                }
                Console.WriteLine($"A térfogata {terfogata} m^3.");

                Console.WriteLine("e)");
                int vizmennyiseg = 0;
                foreach (int melyseg in godorLeirasa)
                {
                    vizmennyiseg += (melyseg - 1) * 10;
                }
                Console.WriteLine($"A vízmennyiség {vizmennyiseg} m^3.");
            }
        }
    }
}
