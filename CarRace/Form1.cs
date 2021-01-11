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
            LblGameOver.Visible = false;
                    }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(2);
            moveEnemy(2);
            GameOver();
        }
        /// <summary>
        /// Adds movement to the center lanes to a specific speed. 
        /// </summary>
        /// <param name="speed"></param>
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
        /// <summary>
        /// Adds movement to the enemy objects.
        /// </summary>
        /// <param name="speed"></param>
        public void moveEnemy(int speed)
        {
            Random r = new Random();
            int x = r.Next(17, 246);
            if (enemy1.Top >= 400) enemy1.Location = new Point(x,0);
            else enemy1.Top += speed;
            if (enemy2.Top >= 400) enemy2.Location = new Point(x, 0);
            else enemy2.Top += speed;           
        }
        /// <summary>
        /// Adds movement to the main car object at a specific speed;
        /// Limits the movement to the playing area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 3;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if(mainCar.Right<pictureBox7.Left) mainCar.Left+=speed;
                    break;
                case Keys.Left:
                    if (mainCar.Left>pictureBox6.Right) mainCar.Left-=speed;
                    break;
                case Keys.Up:
                    if (mainCar.Top > 0) mainCar.Top-=speed;
                    break;
                case Keys.Down:
                    if (mainCar.Bottom < 357) mainCar.Top+=speed;
                    break;
            }
        }
        /// <summary>
        /// Game stops when there's a collision. 
        /// </summary>
        private void GameOver()
        {
            if(mainCar.Bounds.IntersectsWith(enemy1.Bounds) ||
                mainCar.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                LblGameOver.Visible = true;
            }
        }
    }
}
