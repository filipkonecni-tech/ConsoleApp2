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
            using (StreamWriter st = new StreamWriter("../../text.txt"))
            {
                for (int i = 0; i < teme.Length; i++)
                {
                    string sentence = "Koordinate tacke " + (i + 1) + " su " + teme[i].x + " i " + teme[i].y;
                    st.WriteLine(sentence);
                }
            }
        }
        public void snimi()
        {
            StreamWriter izlaz = new StreamWriter("text.txt");
        }
        public static Poligon ucitaj()
        {
            using (StreamReader sr = new StreamReader("../../text.txt"))
            {
                int lineCount = File.ReadAllLines("../../text.txt").Length;
                Poligon p = new Poligon(lineCount);
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    p.teme[i] = new Tacka();
                    p.teme[i].x = (double)line[22];
                    p.teme[i].y = (double)line[26];
                    i++;
                }
                return p;
            }
        }
    }
}