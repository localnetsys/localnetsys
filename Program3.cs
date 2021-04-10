using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;


namespace Batcreator2

{
    class Program
    {
        struct Blokkok
        {
            public string blok1;
            public string blok2;
            public string blok3;
            // public string blok4;
            // public string blok5;
        }

        static void Main(string[] args)
        {
            string nevekG1;
            string nevekG2;
            int kiszam = 1024;
            List<Blokkok> LISTA_blokk = new List<Blokkok>();
            int szamlalo = 0;
            string[] txt = File.ReadAllLines("USER.txt", Encoding.UTF8);//utf8 nembiztos h kell txt nél
            string[] kimenet1 = new string[kiszam];
            string commment;
            string com = ("Felhasználó");
            string newkod;
            string Kszam = ("12345");
            string kitxt2;
            string kitxtalap = ("USER.bat");
            string b1;
            string b2;

            Console.Write("\nAutomata beolvasás <ENTER> / Érték megadásos <E> billenytyűt ,Nyomja meg!):"); string üzem = Console.ReadLine();
            if (üzem != ("e")) ;
            else
            {
                string[] kimenet2 = new string[kiszam];
                int szamszor;
                string kiiras;
                Console.Write("\nMegjegyzés:"); commment = Console.ReadLine(); com = commment;

                Console.Write("\nALAP szám jelszóhoz:"); newkod = Console.ReadLine();
                if (newkod.Length < 5) newkod = ("12345");
                Kszam = newkod;
                Console.Write("\nKimeneti File neve:"); kitxt2 = Console.ReadLine(); kitxtalap = kitxt2;
                Console.Write("\nGeneralt 1neve:"); nevekG1 = Console.ReadLine();
                Console.Write("\nGeneralt 2neve:"); nevekG2 = Console.ReadLine();
                //Console.Write("\nSzamozas:"); szamszor = Convert.ToInt32(Console.ReadLine());

                b1 = nevekG1.Substring(0, 1).ToUpper();
                b2 = nevekG2.Substring(0, 1);

                for (int sz = 0; sz < 40;)
                {


                    sz = szamszor;
                    kiiras = ("NET USER " + nevekG1 + nevekG2 + " " + b1 + b2 + Kszam + " /ADD /FULLNAME:" + "\"" + nevekG1 + " " + nevekG2 + "\"" + " /comment:" + "\"" + com + "\"" + " /DOMAIN");
                    kimenet2[szamszor] = "NET USER " + nevekG1 + nevekG2 + " " + b1 + b2 + Kszam + " /ADD /FULLNAME:" + "\"" + nevekG1 + " " + nevekG2 + "\"" + " /comment:" + "\"" + com + "\"" + " /DOMAIN";
                    Console.WriteLine(kiiras);
                    File.WriteAllLines(nevekG1 + kitxtalap + ".txt", kimenet2);
                }
               
            }
            Console.WriteLine("listaíras");
            Console.ReadKey();

            foreach (string s in txt)

            {
                if (s.Length > 0)
                {
                    string[] adatok = s.Split('.');
                    szamlalo++;
                    Random r = new Random();
                    int vszamlao = r.Next();

                    {

                        string Betu1;
                        string Betu2;
                        string Nev1;
                        string Nev2;

                        List<string> vezeteknev = new List<string>(); // Create new list of strings
                        vezeteknev.Add(adatok[0]);
                        StringBuilder veznevBULD = new StringBuilder();
                        foreach (string user in vezeteknev) // Loop through all strings

                        { veznevBULD.Append(user).Append(""); }

                        string nev1 = veznevBULD.ToString(); // Get string from StringBuilder
                        Betu1 = nev1.Substring(0, 1).ToUpper();
                        Nev1 = (nev1.Substring(0, 1).ToUpper() + nev1.Substring(1, nev1.Length - 1));

                        List<string> keresztnev = new List<string>(); // Create new list of strings
                        keresztnev.Add(adatok[1]);
                        StringBuilder kernevBULD = new StringBuilder();
                        foreach (string user2 in keresztnev) // Loop through all strings

                        { kernevBULD.Append(user2).Append(""); }

                        string nev2 = kernevBULD.ToString(); // 
                        Betu2 = nev2.Substring(0, 1); //keresztnév első betuje 
                        Nev2 = (nev2.Substring(0, 1).ToUpper() + nev2.Substring(1, nev2.Length - 1));


                        if (szamlalo > 0) { kiszam = szamlalo; }
                        else { }

                        string kimenos = ("NET USER " + nev1 + nev2 + " " + Betu1 + Betu2 + Kszam + " /ADD /FULLNAME:" + "\"" + Nev1 + " " + Nev2 + "\"" + " /comment:" + "\"" + com + "\"" + " /DOMAIN");
                        kimenet1[szamlalo] = "NET USER " + nev1 + nev2 + " " + Betu1 + Betu2 + Kszam + " /ADD /FULLNAME:" + "\"" + Nev1 + " " + Nev2 + "\"" + " /comment:" + "\"" + com + "\"" + " /DOMAIN";

                        Console.WriteLine(kimenos);
                        File.WriteAllLines(kitxtalap + ".txt", kimenet1);
                    }


                }

            }

            Console.ReadKey();

        }

    }

}


















