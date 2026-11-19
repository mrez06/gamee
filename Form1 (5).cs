using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Top_up_Ball
{
    public partial class Form1 : Form
    {
        int xal = 0;
        int sur = 5; // topun sureti
        int sx = 5; //saga ya da sola getme sureti "internetden ilhamlanaraq"
        bool yuxari = false;

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // klavia tusu ile islesin deyedi bu hisse
            this.DoubleBuffered = true;
            this.KeyDown += Form1_KeyDown;

            timer1.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            // yuxari-asagi hereket
            if (yuxari)
                pictureBox1.Top -= sur;
            else
                pictureBox1.Top += sur;

            // sola-saga hereket (cep gedir)
            pictureBox1.Left += sx;

            // sol divara deyende, saga getsin
            if (pictureBox1.Left <= 0)
            {
                pictureBox1.Left = 0;
                sx = sur;
            }

            // sag divara deyende, sola getsin
            if (pictureBox1.Right >= ClientSize.Width)
            {
                pictureBox1.Left = ClientSize.Width - pictureBox1.Width;
                sx = -sur;
            }

            // yuxari divara deyende, asagi dussun
            if (pictureBox1.Top <= 0)
            {
                pictureBox1.Top = 0;
                yuxari = false;
            }

            
            if (!yuxari &&
                pictureBox1.Bottom >= panel2.Top &&
                pictureBox1.Bottom <= panel2.Bottom &&
                pictureBox1.Right > panel2.Left &&
                pictureBox1.Left < panel2.Right){   // qara xetde deyende: yuxari cixsin + xal 1 artsin
                
                yuxari = true;
                pictureBox1.Top = panel2.Top - pictureBox1.Height;
                xal++;
                

                // mentiqi internetden alinib 
                sx = rnd.Next(2) == 0 ? sur : -sur;    // yeni istiqamet: yuxari sola ya yuxari saga
            }

            
            if (pictureBox1.Bottom >= ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Oyun bitdi! Xaliniz: " + xal, "Game Over");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && panel2.Left > 0)
            {
                panel2.Left -= 20;
            }
            if (e.KeyCode == Keys.Right && panel2.Right < ClientSize.Width)
            {
                panel2.Left += 20;
            }
        }
    }
}
