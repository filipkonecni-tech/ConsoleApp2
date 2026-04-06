using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Poligon
    {
        public int br_temena;
        public Tacka[] teme;
        public Poligon()
        {
        }
        public Poligon(int n)
        {
            br_temena = n;
            teme = new Tacka[n];
        }
        public static double Povrsina(Poligon p)
        {
            double povrsina = 0;
            for(int i = 0; i < p.teme.Length; i++)
            {
                if(i != p.teme.Length - 1) {
                     povrsina = povrsina + (p.teme[i].x * p.teme[i+1].y -p.teme[i+1].x * p.teme[i].y);
                }
                else
                {
                    povrsina = povrsina + (p.teme[i].x * p.teme[0].y -p.teme[0].x * p.teme[i].y);
                }
            }
            return (Math.Abs(povrsina) / 2);
        }
        public bool prost()
        {
            for (int i = 0; i < br_temena-1; i++)
            {
                for (int j = i+1; j < br_temena; j++)
                {
                    if (Tacka.jednake(teme[i], teme[j]))
                    {
                        return false;
                    }
                }
            }
            Vektor[] stranica = new Vektor[br_temena];
            for (int i = 0; i < br_temena-1; i++)
            {
                stranica[i] = new Vektor(teme[i], teme[i + 1]);
            }
            stranica[br_temena - 1] = new Vektor(teme[br_temena - 1], teme[0]);
            for (int i = 0; i < br_temena; i++)
            {
                int kraj;
                if (i == 0) kraj = br_temena - 1;
                else kraj = br_temena;
                for (int j = i + 2; j < kraj; j++)
                {
                    if (Vektor.seku_se(stranica[i], stranica[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static Poligon unos()
        {
            Console.WriteLine("Koliko temena?");
            int n = Convert.ToInt32(Console.ReadLine());
            Poligon novi = new Poligon(n);
            for(int i = 0; i < n; i++)
            {
                novi.teme[i] = new Tacka();
                Console.WriteLine("x koordinate tacke {0}=", i + 1);
                novi.teme[i].x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("y koordinate tacke {0}=", i + 1);
                novi.teme[i].y = Convert.ToDouble(Console.ReadLine());

            }
            return novi;
        }
        public void stampa()
        {
            Console.WriteLine("Poligon ima {0} temena", br_temena);
            for (int i = 0; i < br_temena; i++)
            {
                Console.WriteLine("Koordinate {0}. tacke su x={1} i y={2}", i + 1, teme[i].x, teme[i].x);
            }
        }
        public void snimi()
        {
            StreamWriter izlaz = new StreamWriter("text.txt");
            izlaz.WriteLine(br_temena);
            for (int i = 0; i < br_temena; i++)
            {
                izlaz.WriteLine(teme[i].x);
                izlaz.WriteLine(teme[i].y);
            }
            izlaz.Close();
        }
        public static Poligon ucitaj()
        {
            using (StreamReader sr = new StreamReader("../../text.txt"))
            {
                int lineCount = File.ReadAllLines("../../text.txt").Length;
                Poligon p = new Poligon(lineCount / 2);
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    p.teme[i] = new Tacka();
                    p.teme[i].x = Convert.ToDouble(line);
                    line=sr.ReadLine();
                    p.teme[i].y = Convert.ToDouble(line);
                    i++;
                }
                return p;
            }
        }
        public double obim()
        {
            Vektor a;
            double obim = 0;
            for (int i = 0; i < br_temena-1; i++)
            {
                a = new Vektor(teme[i], teme[i + 1]);
                obim += a.duzina();
            }
            a = new Vektor(teme[br_temena-1], teme[0]);
            obim += a.duzina();
            return obim;
        }
    }
}