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
            string[] kimenet3 = new string[kiszam];
            string commment;
            string com = ("Felhasználó");
            string newkod;
            string Kszam = ("12345");
            string kitxt2;
            string kitxtalap = ("USER.bat");
            string b1;
            string b2;

            Console.Write("\nTXT file beolvasás <T> / Érték megadás <Enter> billenytyűt ,Nyomja meg!):"); string üzem = Console.ReadLine();
            if (üzem != ("t"))

            {

                int sz, szu;
                int szamlal;
                string kiiras;

                Console.Write("\nGeneralt 1neve:\n(Ha itt nem ad éréket akkor MAPPA generálás fog történni):\a"); nevekG1 = Console.ReadLine();
                if (nevekG1.Length == 0) { Console.Write("\nGeneralt MAPPA neve:"); nevekG2 = Console.ReadLine(); }
                else { Console.Write("\nGeneralt 2neve:"); nevekG2 = Console.ReadLine(); }
               
                Console.Write("\nALAP jelszó:"); newkod = Console.ReadLine();
                if (newkod.Length < 5) newkod = ("12345");
                Kszam = newkod;
                Console.Write("\nMegjegyzés:"); commment = Console.ReadLine(); com = commment;
                Console.Write("\nKimeneti File neve:"); kitxt2 = Console.ReadLine(); kitxtalap = kitxt2;

                Console.Write("\nszamozás: kezdő szám:"); sz = Convert.ToInt32(Console.ReadLine());
                if (sz < 0) sz = 0;

                Console.Write("\nszamozás: utolsó szám:"); szu = Convert.ToInt32(Console.ReadLine());
                if (szu < 0) szu = sz + 1;

                string[] kimenet2 = new string[szu];
                if (nevekG1.Length == 0) nevekG1 = "MD "; Console.Write("\nKönyvtár elérési út:"); string k = Console.ReadLine();
                b1 = nevekG1.Substring(0, 1).ToUpper(); b2 = nevekG2.Substring(0, 1).ToLower();

                // kiiras = ("NET USER " + nevekG1 + nevekG2 + " " + b1 + b2 + Kszam + " /ADD /FULLNAME:" + "\"" + nevekG1 + " " + nevekG2 + "\"" + " /comment:" + "\"" + com + "\"" + " /DOMAIN");
                for (int kezd = 0; kezd < szu; kezd++)

                {
                    szamlal = kezd;// Console.WriteLine(kiiras);
                    if (nevekG1 == "MD ")
                    { kimenet2[szamlal] = k + nevekG1 + nevekG2 + kezd; }
                    else

                    { kimenet2[szamlal] = "NET USER " + nevekG1 + nevekG2 + kezd + " " + newkod + kezd + " /ADD /FULLNAME:" + "\"" + nevekG1 + kezd + " " + nevekG2 + kezd + "\"" + " /comment:" + "\"" + com + "\"" + " /DOMAIN"; }

                    File.WriteAllLines(kitxt2 + "Ubat.txt", kimenet2);

                }
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (string kiszoveg in kimenet2) Console.WriteLine(kiszoveg);
                Console.ReadKey();
            }

            else


            {
                Console.WriteLine("\nUSER.txt file beolvasva ! . . . ");
                Console.Write("\nKönyvtár elérési út:(A generált Mappa file-hoz):"); string k = Console.ReadLine();
                if (k.Length == 0) k = "C:\\";
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
                            string mappa = (k + "MD " + Nev1 + Nev2);
                            kimenet1[szamlalo] = "NET USER " + nev1 + nev2 + " " + Betu1 + Betu2 + Kszam + " /ADD /FULLNAME:" + "\"" + Nev1 + " " + Nev2 + "\"" + " /comment:" + "\"" + com + "\"" + " /DOMAIN";
                            //string mappa = Nev1 + Nev2;
                            kimenet3[szamlalo] = k + "MD " + Nev1 + Nev2;
                          
                            File.WriteAllLines(kitxtalap + ".txt", kimenet1);
                            File.WriteAllLines("mappa" + ".txt",kimenet3);

                        }
                    }

                }
                Console.ForegroundColor = ConsoleColor.Green;
                string[] txtreaduser = File.ReadAllLines("USER.bat.txt");//, Encoding.UTF8);
                foreach (string bat in txtreaduser)
                { if (bat.Length > 0) Console.WriteLine(bat); }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nUSER Létrehozó file Kiirva . . . OK !\n"); Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.Yellow;
                string[] txtread = File.ReadAllLines("mappa.txt");// Encoding.UTF8);
                foreach (string mappa in txtread)
                { if (mappa.Length > 0) Console.WriteLine(mappa);}
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nKönyvtár Író file Létrehozva . . . OK !\n");
                Console.ReadKey();

            }
        }
    } 
}

   



















