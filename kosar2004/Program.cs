using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
    class Program
    {
        static List<Meccs> meccsek = new List<Meccs>();
        static Dictionary<string, int> stadionok = new Dictionary<string, int>();

        static void MasodikFeladat()
        {
            StreamReader file = new StreamReader("eredmenyek.csv");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                string[] adat = file.ReadLine().Split(';');
                meccsek.Add(new Meccs(adat[0],adat[1],int.Parse(adat[2]),int.Parse(adat[3]),adat[4],adat[5]));
            }
            file.Close();
        }

        static void HarmadikFeladat()
        {
            int hazaidb = 0;
            int idegendb = 0;
            for (int i = 0; i < meccsek.Count; i++)
            {
                if (meccsek[i].Hazai == "Real Madrid")
                {
                    hazaidb++;
                }
                if (meccsek[i].Idegen == "Real Madrid")
                {
                    idegendb++;
                }
            }
            Console.WriteLine("3. feladat: Real Madrid: Hazai: {0}, Idegen: {1}",hazaidb,idegendb);

            //var hazai = from m in meccsek where m.Hazai == "Real Madrid" select new { Hazai = m.Hazai };
            //int hazaiDB = hazai.ToList().Count;

            //var idegen = from m in meccsek where m.Idegen == "Real Madrid" select new { Idegen = m.Idegen };
            //int IdegenDb = idegen.ToList().Count;

            //Console.WriteLine($"3. feladat: Real Madrid: Hazai: {hazaiDB}, Idegen: {IdegenDb}");
        }

        static void NegyedikFeladat()
        {
            int dontetlen = 0;
            foreach (var m in meccsek)
            {
                if (m.HPont == m.IPont)
                {
                    dontetlen++;
                }
            }

            Console.Write("4. feladat: Volt döntetlen? ");
            if (dontetlen>=1)
            {
                Console.Write("van");
            }
            else
            {
                Console.Write("nem");
            }
        }
        
        static void OtodikFeladat()
        {
            Console.WriteLine();
            var csapat = from m in meccsek where m.Hazai.Contains("Barcelona") select m.Hazai;
            string Barca = csapat.First();
            Console.WriteLine("5. feladat: A barcelonai csapat neve: {0}",Barca);
        }

        static void HatodikFeladat()
        {
            Console.WriteLine("6. feladat:");
            foreach (var m in meccsek)
            {
                if (m.Ido == "2004-11-21")
                {
                    Console.WriteLine($"\t{m.Hazai} - {m.Idegen} ({m.HPont}:{m.IPont})");
                }
            }
        }

        static void HetedikFeladat()
        {
            Console.WriteLine("7. feladat: ");
            foreach (var m in meccsek)
            {
                if (!stadionok.ContainsKey(m.Hely))
                {
                    stadionok.Add(m.Hely, 0);
                }
            }

            foreach (var m in meccsek)
            {
                stadionok[m.Hely]++;
            }

            foreach (var s in stadionok)
            {
                if (s.Value>20)
                {
                    Console.WriteLine($"\t{s.Key}: {s.Value}");
                }           
            }
        }

        static void NyolcadikFeladat()
        {
            StreamWriter file = new StreamWriter("meccsek.txt");
            foreach (var m in meccsek)
            {
                file.WriteLine(m.Atalakit());
            }
            file.Close();
        }


        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            HetedikFeladat();
            NyolcadikFeladat();

            Console.ReadKey();
        }
    }
}
