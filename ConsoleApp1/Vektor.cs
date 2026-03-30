using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vektor
    {
        public Tacka pocetak, kraj;
        public double k, c;
        public Vektor(Tacka A, Tacka B)
        {
            pocetak = A;
            kraj = B;
        }
        public void Vrednosti()
        {
            if(kraj.x - pocetak.x != 0) {
            this.k = (kraj.y - pocetak.y) / (kraj.x - pocetak.x);
            this.c = kraj.y - (kraj.x * k);
            }
            else
            {
                k = 0;
                c = 0;
            }
        }
        public Tacka Centriraj()
        {
            Tacka Nova = new Tacka(kraj.x - pocetak.x, kraj.y - pocetak.y);
            return Nova;
        }
        public static double SP(Vektor a, Vektor b)
        {
            Tacka aC = a.Centriraj();
            Tacka bC = b.Centriraj();
            return aC.x * bC.x + aC.y * bC.y;
        }
        public static double VP(Vektor a, Vektor b)
        {
            Tacka aC = a.Centriraj();
            Tacka bC = b.Centriraj();
            return aC.x * bC.y - bC.x * aC.y;
        }

    }
}
