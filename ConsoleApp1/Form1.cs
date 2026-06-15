using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poligon392026B
{
    public partial class Form1 : Form
    {
        Tacka[] temena;
        int br_temena;
        Poligon radni;
        bool fleg_Crtaj;

        public Form1()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            temena = new Tacka[20];
            br_temena = 0;
            fleg_Crtaj = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            Tacka nova = new Tacka(x, y);
            temena[br_temena] = nova;
            listBox1.Items.Add(x.ToString()+" "+y.ToString());
            br_temena++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radni = new Poligon(br_temena, temena);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radni.snimi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (radni.konveksan()) label3.Text = "Konveksan";
                else label3.Text = "Nije Konveksan";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radni.prost()) label3.Text = "Prost";
            else label3.Text = "Nije prost";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fleg_Crtaj = true;
            panel1.Invalidate();
            panel1.Refresh();
        }

        void Crtaj(Graphics dr, Tacka t)
        {
                int panelHeight = panel1.ClientSize.Height;
                int panelWidth = panel1.ClientSize.Width;
                // x - osa
                int pocetak = panelWidth / 10;
                int kraj = panelWidth - pocetak;
                int visina = panelHeight - panelHeight / 10;

                Pen linija = new Pen(Color.Black, 2);
                dr.DrawLine(linija, pocetak, visina, kraj, visina);

                int x = panelWidth / 2 + (int)t.x * 20; // Shift x to center
                int y = panelHeight / 2 - (int)t.y * 30; // Invert y and shift to center

                using (var cetka = new SolidBrush(Color.Red))
                {
                    dr.FillEllipse(cetka, x, y, 8, 8);
                }
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (fleg_Crtaj)
            {
                for (int i = 0; i < br_temena; i++)
                {
                    Tacka t = temena[i];
                    Crtaj(e.Graphics, t);
                }
            }
        }
    }
}
