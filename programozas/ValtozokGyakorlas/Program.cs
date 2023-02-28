using System;
using System.Collections.Generic;
using System.Linq;

namespace ValtozokGyakorlas
{
    class Program
    {
        static void Main(string[] args)
        {
            Valtozok();
            Naptar();
            Filmcimek();
        }

        static void Valtozok()
        {
            // Változó deklarálása és értékadás külön sorban:
            string maiNap;
            maiNap = "hétfő";
            maiNap = "kedd";
            maiNap = "szerda";
            Console.WriteLine("Mai nap: " + maiNap);

            // Változók deklarálása és értékadás:
            string vezeteknev = "Próba";
            string keresztnev = "Elemér";
            string teljesNev = vezeteknev + " " + keresztnev;
            int iranyitoszam = 8900;
            string[] tantarnyak = { "matematika", "irodalom", "programozás" };
            bool tanulo = true;

            Console.Write(teljesNev);
            Console.WriteLine(" (irányítószám: " + iranyitoszam + ", tanulo: " + tanulo + ")");

            // If-Else elágazás:
            if (iranyitoszam == 8900)
            {
                Console.WriteLine("Zalaegerszegi");
            }
            else if (iranyitoszam == 8800)
            {
                Console.WriteLine("Nagykanizsai");
            }
            else
            {
                Console.WriteLine("Egyéb városból");
            }

            // Foreach ciklus:
            Console.Write("Tantárgyak: ");
            foreach (string tantargy in tantarnyak)
            {
                Console.Write(tantargy + ", ");
            }
            Console.WriteLine("\n");

            // For ciklus:
            for (int tantargySzama = 0; tantargySzama < tantarnyak.Length; tantargySzama++)
            {
                Console.WriteLine(tantargySzama + ": " + tantarnyak[tantargySzama]);
            }

            Console.WriteLine("\n-------------------------------\n");
        }

        static void Naptar()
        {
            string[] hetNapjai = { "hetfo", "kedd", "szerda", "csutortok", "pentek" };
            Console.WriteLine("A hét első napja: " + hetNapjai[0]);
            Console.WriteLine();

            foreach (string nap in hetNapjai)
            {
                bool hetfoVan = (nap == "hetfo");
                bool nincsHetfo = (nap != "hetfo");

                Console.Write(nap);
                Console.Write(" (hétfő van: " + hetfoVan + ")");
                Console.WriteLine(" (nincs hétfő: " + nincsHetfo + ")");

                if (nap == "hetfo")
                {
                    Console.WriteLine("- Meh hétfő!");
                }
                else if (nap == "pentek")
                {
                    Console.WriteLine("- Hurrá péntek van!");
                }
                else
                {
                    Console.WriteLine("- Nincs hétfő!");
                }

                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------\n");
        }

        static void Filmcimek()
        {
            List<string> filmCimek = new List<string>() { "Alien", "Alien2", "Alien3" };
            filmCimek.Add("Prometheus");

            Console.WriteLine("Utolsó film:" + filmCimek.Last() + "\n");

            foreach (string film in filmCimek)
            {
                bool regi = (film == "Alien" || film == "Alien2" || film == "Alien3");
                bool uj = film == "Prometheus";

                Console.Write(film);
                Console.Write(" (régi: " + regi + ")");
                Console.WriteLine(" (új: " + uj + ")");
            }

            Console.WriteLine("\n-------------------------------\n");
        }
    }
}
