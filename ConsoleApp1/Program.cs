using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tacka
    {
        public double x;
        public double y;
        public Tacka()
        {
            x = 0;
            y = 0;
        }
        public Tacka(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        double d()
        {
            return Math.Sqrt(x*x + y*y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Filip Konecni

        }
    }
}
