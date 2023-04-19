using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Feladat1();
            //Feladat2();
            //Feladat3();
            //Feladat4();
            //Feladat5();
            //Feladat6();
            //Feladat7();
            //Feladat8();
            //FelhasznalokKiiras();
            //Feladat11();
            //Feladat12();
            Feladat13();

            Console.ReadKey();
        }

        //static void Feladat1() {
        //    string networkAddress = "192.168.1.0";
        //    Console.WriteLine("Hálózati cím: " + networkAddress);

        //    string netMask = "255.255.255.0";
        //    Console.WriteLine("Alhálózati maszk: " + netMask);

        //    List<string> ipAddresses = new List<string>() { "192.168.1.2", "192.168.1.87", "192.168.1.172" };
        //    //Console.WriteLine("IP cím: " + ipAddresses[0]);
        //    //Console.WriteLine("IP cím: " + ipAddresses[1]);
        //    //Console.WriteLine("IP cím: " + ipAddresses[2]);

        //    foreach (string address in ipAddresses) 
        //    {
        //        Console.WriteLine(address);
        //    }

        //    int numberOfAddresses = ipAddresses.Count;
        //    Console.WriteLine("Konfigurált IP címek száma: " + numberOfAddresses);
        //}

        static void Feladat1()
        {
            string networkAddress = "192.168.1.0";
            Console.WriteLine("Hálózati cím: " + networkAddress);

            string netMask = "255.255.255.0";
            Console.WriteLine("Alhálózati maszk: " + netMask);

            List<string> ipAddresses = new List<string>() { "192.168.1.2", "192.168.1.87", "192.168.1.172" };
            int numberOfAddresses = 0;

            foreach (string address in ipAddresses)
            {
                numberOfAddresses = numberOfAddresses + 1;
                Console.WriteLine(address);
            }

            Console.WriteLine("Konfigurált IP címek száma: " + numberOfAddresses);
        }

        static void Feladat2()
        {
            string[] varosok = { "Győr", "Zalaegerszeg", "Budapest", "Debrecen" };

            //int kulonbseg;
            //kulonbseg = 2;
            //int osszeg = 0;
            //osszeg = 8;
            //kulonbseg = osszeg;
            //int novekmeny = 2;
            //osszeg = novekmeny;
            //osszeg = novekmeny + kulonbseg;

            int osszeg = 0;
            int novekmeny = 2;

            foreach (string varos in varosok)
            {
                osszeg = osszeg + novekmeny;
                Console.WriteLine(varos);
            }
        }
        static void Feladat3()
        {
            int[] szamok = { 1, 2, 3, 4 };
            int osszeg = 0;

            foreach (int szam in szamok)
            {
                osszeg = osszeg + szam;
            }
            Console.WriteLine("Szamok osszege: {0}", osszeg);

            foreach (int szam in szamok)
            {
                Console.WriteLine(szam);
            }
        }

        static void Feladat4()
        {
            int szul = 1989;
            int aktualisEv = 2023;
            string szulhely = "Zalaegerszeg";
            int kor = aktualisEv - szul;
            Console.WriteLine("Születési év: {0}, Kora: {1}", szul, kor);
        }
        static void Feladat5()
        {
            int[] szulevek = { 2004, 2005, 2006 };
            int aktualisev = 2023;
            foreach (int szulev in szulevek)
            {
                int kor = aktualisev - szulev;
                Console.WriteLine("Születési év: {0}, Kora: {1}", szulev, kor);
            }
        }
        static void Feladat6()
        {
            string rendszam = "TMP123";
            int gyartasiev = 2002;
            string alvazszam = "abcdef";

            int[] szulevek = { 1999, 1976, 1968, 1953 };
            string[] szulhelyek = { "Zalaegerszeg", "Bak", "Pécs", "Kispáli" };
            int index = 0;
            foreach (string szulhely in szulhelyek)
            {
                int szulev = szulevek[index];
                Console.WriteLine("Szulhely: {0}, index: {1}, szuletes ev: {2}", szulhely, index, szulev);
                index = index + 1;
            }
        }

        // Futó programok: cmd.exe, chrome.exe, vscode.exe, 
        static void Feladat7()
        {
            string rendszam = "ABC123";
            int gyartasiev = 1998;

            List<string> programok = new List<string> { "cmd.exe", "chrome.exe", "vscode.exe" };
            Console.Write("Futó programok: ");
            /*Console.Write(programok[0] + ", ");
            Console.Write(programok[1] + ", " );
            Console.Write(programok[2]);*/
            int szamlalo = 0;
            foreach (string program in programok)
            {
                Console.Write(programok[szamlalo]);
                if (szamlalo < programok.Count - 1)
                {
                    Console.Write(", ");
                }
                szamlalo = szamlalo + 1;
            }
        }

        static void Feladat8()
        {
            string[] szukhelyek = { "a", "b", "c", "d" };
            int[] szulevek = { 2001, 2002, 2003, 2004 };
            string[] szulnemek = { "f", "f", "l", "f" };
            int szamlalo = 0;

            foreach (string szulhely in szukhelyek)
            {
                int szulev = szulevek[szamlalo];
                string szulneme = szulnemek[szamlalo];
                Console.WriteLine("Szuletési helye: {0}, Szuletési év: {1}, Szuletési neme: {2}", szulhely, szulev, szulneme);
                szamlalo = szamlalo + 1;
            }

            /*
             * Ami a program futása közben történik:
            string[] szukhelyek = { "a", "b", "c", "d" };
            int[] szulevek = { 2001, 2002, 2003, 2004 };
            int szamlalo = 0;

            string szulhely = szukhelyek[0];        // "a"
            int szulev = szulevek[szamlalo];        // 2001
            string szulneme = szulnemek[szamlalo];  // "f"
            Console.WriteLine("Szuletési helye: {0}, Szuletési év: {1}", szulhely, szulev);
            szamlalo = szamlalo + 1;                // 1

            string szulhely = szukhelyek[1];        // "b"
            int szulev = szulevek[szamlalo];        // 2002
            string szulneme = szulnemek[szamlalo];  // "f"
            Console.WriteLine("Szuletési helye: {0}, Szuletési év: {1}", szulhely, szulev);
            szamlalo = szamlalo + 1;                // 2

            string szulhely = szukhelyek[2];        // "c"
            int szulev = szulevek[szamlalo];        // 2003
            string szulneme = szulnemek[szamlalo];  // "l"
            Console.WriteLine("Szuletési helye: {0}, Szuletési év: {1}", szulhely, szulev);
            szamlalo = szamlalo + 1;                // 3

            string szulhely = szukhelyek[3];        // "d"
            int szulev = szulevek[szamlalo];        // 2004
            string szulneme = szulnemek[szamlalo];  // "f"
            Console.WriteLine("Szuletési helye: {0}, Szuletési év: {1}", szulhely, szulev);
            szamlalo = szamlalo + 1;                // 4
            */
        }
        static void FelhasznalokKiiras()
        {
            string[] felhasznalok = { "user1", "user2", "user3", "user4" };
            bool[] isadmins = { true, true, false, true };
            string[] emailcimek = { "a@", "b@", "c@", "d@" };
            Console.WriteLine(isadmins[2]);

            Kiiras(felhasznalok);

            //int szam = 0;
            //foreach (string felhasznalo in felhasznalok) {
            //    Kiiras(szam);
            //    Console.WriteLine("felhasználo: {0}, sorszam: {1}, admin: {2}, email: {3}", felhasznalo, szam, isadmins[szam], emailcimek[szam]);
            //    szam = szam + 1;
            //}
        }

        static void Kiiras(string[] felhasznalok)
        {
            foreach (string felhasznalo in felhasznalok)
            {

                Console.WriteLine("felhasználo: {0}", felhasznalo);
            }
        }

        //static void Feladat10() {
        //    Felfasznalo user = new Felfasznalo();
        //    user.Nev = "user1";
        //    user.Email = "a@";
        //    user.IsAdmin = false;
        //    Console.WriteLine(user.Nev);

        //    Felfasznalo user2 = new Felfasznalo() {
        //        Nev = "user2",
        //        Email = "b@",
        //        IsAdmin = true,
        //    };
        //    Console.WriteLine(user2.Nev);
        //}
        static void Feladat11()
        {
            negyzetreemeles(5);
            negyzetreemeles(7);
            negyzetreemeles(9);

            //int szam1 = 5;
            //int szam2 = 4;
            //int vegosszeg = szam1 + szam2;
            //Console.WriteLine(vegosszeg);

            //Szorzas(5, 6);
        }

        static void Osszeadas(int szam1, int szam2)
        {
            int vegosszeg = szam1 + szam2;
            Console.WriteLine(vegosszeg);
        }
        static void Szorzas(int szam1, int szam2)
        {
            int osszeg = szam1 * szam2;
            Console.WriteLine(osszeg);
        }
        static void negyzetreemeles(int szam1)
        {
            int szamnegyzete = szam1 * szam1;
            Console.WriteLine(szamnegyzete);
        }
        static void Feladat12()
        {
            string keresztnev = "Ádám";
            string vezeteknev = "Takács";
            string elvalasztojel = "-";
            //Console.WriteLine("Teljes név: {0} {1}", vezeteknev, keresztnev);
            teljesnevkiiras(keresztnev, vezeteknev, elvalasztojel);
            teljesnevkiiras(keresztnev, vezeteknev, "*");
            teljesnevkiiras(keresztnev, vezeteknev, " ");
            teljesnevkiiras("Géza", vezeteknev, elvalasztojel);
            kivonas(10, 6);
            kivonas(21, 7);
            kivonas(2, 1100000);
            kivonas(111, 111);


        }
        static void teljesnevkiiras(string keresztnev, string vezeteknev, string elvalasztojel)
        {
            Console.WriteLine("Teljes név: {0}{2}{1}", vezeteknev, keresztnev, elvalasztojel);
        }
        static void kivonas(int szam1, int szam2)
        {
            if (szam1 > szam2)
            {
                int eredmeny = szam1 - szam2;
                Console.WriteLine("{1} - {2} = {0}", eredmeny, szam1, szam2);
            }
            else if (szam1 == szam2)
            {
                int eredmeny = szam1 - szam2;
                Console.WriteLine("{1} - {2} = {0}", eredmeny, szam1, szam2);
            }
            else
            {
                int eredmeny = szam2 - szam1;
                Console.WriteLine("{2} - {1} = {0}", eredmeny, szam1, szam2);
            }

        }
        static void Feladat13()
        {
            //int eredmeny = osszeadas2(19, 56);
            //Console.WriteLine(eredmeny);
            //eredmeny = osszeadas2(55, 78);
            //Console.WriteLine("{0}", eredmeny);
            //eredmeny = szorzas2(34, 11);
            //Console.WriteLine(eredmeny);
            //eredmeny = kulonbseg(11, 3);
            //Console.WriteLine(eredmeny);
            //eredmeny = kulonbseg(3, 11);
            //Console.WriteLine(eredmeny);

            int eredmeny1 = kulonbseg(11, 3);
            int eredmeny2 = kulonbseg(3, 11);
            if(eredmeny1 == eredmeny2)
            {
                Console.WriteLine("Minden rendben.");
            }
            else
            {
                Console.WriteLine("Rendszer hiba!");
            }
        }
        static int osszeadas2(int szam1, int szam2)
        {
            return szam1 + szam2;
        }
        static int szorzas2(int szam1, int szam2)
        {
            return szam1 * szam2;
        }
        static int kulonbseg(int szam1, int szam2)
        {
            if (szam1 > szam2)
            {
                return szam1 - szam2;
            }
            else
            {
                return szam2 - szam1;
            }
            
        }
    }
}

//class Felfasznalo {
//    public string Nev { get; set; }
//    public string Email { get; set; }
//    public bool IsAdmin { get; set; }
//}
