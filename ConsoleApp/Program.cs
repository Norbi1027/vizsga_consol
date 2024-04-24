using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Dolgozo> dolgozok;
        static void Main(string[] args)
        {
            dolgozok = db.getAllDolgozo();
            feladat01();
            feladat02();
            feladat03();
            feladat04();
            Console.WriteLine("Program vége!");
            Console.ReadLine();
        }

        private static void feladat04()
        {
            foreach (var item in dolgozok.FindAll(a => a.reszleg == "asztalosműhely"))
            {
                Console.WriteLine($"\t{item.nev}");
            }
        }

        private static void feladat03()
        {
            foreach (var item in dolgozok.GroupBy(a => a.reszleg).Select(b => new {reszleg=b.Key,letszam=b.Count() }).OrderBy(c => c.reszleg))
            {
                Console.WriteLine($"\t{item.reszleg}: {item.letszam} fő");
            }
        }

        private static void feladat02()
        {
            int maxBer = dolgozok.Max(a => a.ber);
            Dolgozo dolgozo=dolgozok.Find(a => a.ber == maxBer);
            Console.WriteLine($"\tA legmagasabb bérrel rendelkező ember: {dolgozo.nev} a bére:{maxBer}");
        }

        private static void feladat01()
        {
            Console.WriteLine("1. feladat:");
            Console.WriteLine($"\tA dolgozók száma: {dolgozok.Count} fő");
        }
    }
}
