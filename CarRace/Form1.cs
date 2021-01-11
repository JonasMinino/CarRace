using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(2);
        }

        public void moveLine(int speed)
        {
            if (pictureBox1.Top >= 400) pictureBox1.Top = 0;
            else pictureBox1.Top += speed;
            if (pictureBox2.Top >= 400) pictureBox2.Top = 0;
            else pictureBox2.Top += speed;
            if (pictureBox3.Top >= 400) pictureBox3.Top = 0;
            else pictureBox3.Top += speed;
            if (pictureBox4.Top >= 400) pictureBox4.Top = 0;
            else pictureBox4.Top += speed;
            if (pictureBox5.Top >= 400) pictureBox5.Top = 0;
            else pictureBox5.Top += speed;            
        }
    }
}
