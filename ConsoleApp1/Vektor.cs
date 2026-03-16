using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poligon_3_9
{
    internal class Vektor
    {
        Tacka pocetak, kraj;
        public Vektor(Tacka A, Tacka B)
        {
            pocetak = A;
            kraj = B;
        }
        public Tacka Centriraj()
        {
            Tacka Nova = new Tacka(kraj.x - pocetak.x, kraj.y - pocetak.y);
            return Nova;
        }
    }
}