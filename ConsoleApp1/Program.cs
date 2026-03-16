using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Filip Konecni
            // Tacka prva = new Tacka();
            // Console.WriteLine(prva.d());
            Tacka A = new Tacka(1, 2);
            Tacka B = new Tacka(2, 3);
            Vektor AB = new Vektor(A, B);
            Tacka C = AB.Centriraj();
            Console.WriteLine(C.d());
        }
    }
}
