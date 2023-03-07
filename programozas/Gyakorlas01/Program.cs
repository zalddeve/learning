using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas01 {
    class Program {
        static void Main(string[] args) {
            //Feladat1();
            //Feladat2();
            //Feladat3();
            //Feladat4();
            //Feladat5();
            //Feladat6();
            //Feladat7();
            Feladat8();
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

        static void Feladat1() {
            string networkAddress = "192.168.1.0";
            Console.WriteLine("Hálózati cím: " + networkAddress);

            string netMask = "255.255.255.0";
            Console.WriteLine("Alhálózati maszk: " + netMask);

            List<string> ipAddresses = new List<string>() { "192.168.1.2", "192.168.1.87", "192.168.1.172" };
            int numberOfAddresses = 0;

            foreach (string address in ipAddresses) {
                numberOfAddresses = numberOfAddresses + 1;
                Console.WriteLine(address);
            }

            Console.WriteLine("Konfigurált IP címek száma: " + numberOfAddresses);
        }

        static void Feladat2() {
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

            foreach (string varos in varosok) {
                osszeg = osszeg + novekmeny;
                Console.WriteLine(varos);
            }
        }
        static void Feladat3() {
            int[] szamok = { 1, 2, 3, 4 };
            int osszeg = 0;

            foreach (int szam in szamok) {
                osszeg = osszeg + szam;
            }
            Console.WriteLine("Szamok osszege: {0}", osszeg);

            foreach (int szam in szamok) {
                Console.WriteLine(szam);
            }
        }

        static void Feladat4() {
            int szul = 1989;
            int aktualisEv = 2023;
            string szulhely = "Zalaegerszeg";
            int kor = aktualisEv - szul;
            Console.WriteLine("Születési év: {0}, Kora: {1}", szul, kor);
        }
        static void Feladat5() {
            int[] szulevek = { 2004, 2005, 2006 };
            int aktualisev = 2023;
            foreach (int szulev in szulevek) {
                int kor = aktualisev - szulev;
                Console.WriteLine("Születési év: {0}, Kora: {1}", szulev, kor);
            }
        }
        static void Feladat6() {
            string rendszam = "TMP123";
            int gyartasiev = 2002;
            string alvazszam = "abcdef";

            int[] szulevek = { 1999, 1976, 1968, 1953 };
            string[] szulhelyek = { "Zalaegerszeg", "Bak", "Pécs", "Kispáli" };
            int index = 0;
            foreach (string szulhely in szulhelyek) {
                int szulev = szulevek[index];
                Console.WriteLine("Szulhely: {0}, index: {1}, szuletes ev: {2}", szulhely, index, szulev);
                index = index + 1;
            }
        }

        // Futó programok: cmd.exe, chrome.exe, vscode.exe, 
        static void Feladat7() {
            string rendszam = "ABC123";
            int gyartasiev = 1998;

            List<string> programok = new List<string> { "cmd.exe", "chrome.exe", "vscode.exe" };
            Console.Write("Futó programok: ");
            /*Console.Write(programok[0] + ", ");
            Console.Write(programok[1] + ", " );
            Console.Write(programok[2]);*/
            int szamlalo = 0;
            foreach (string program in programok) {
                Console.Write(programok[szamlalo]);
                if (szamlalo < programok.Count - 1) {
                    Console.Write(", ");
                }
                szamlalo = szamlalo + 1;
            }
        }

        static void Feladat8() {
            string[] szukhelyek = { "a", "b", "c", "d" };
            int[] szulevek = { 2001, 2002, 2003, 2004 };
            string[] szulnemek = { "f", "f", "l", "f" };
            int szamlalo = 0;

            foreach (string szulhely in szukhelyek) {
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
    }
}
