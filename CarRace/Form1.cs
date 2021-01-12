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
         readonly Random r = new Random();
        int score = 0;
        Point startLocation = new Point(29, 275);
        public Form1()
        {
            InitializeComponent();
            pnlGameOver.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveLine(2);
            MoveEnemy(2);
            MoveCoin(2);
            CoinCollection();
            GameOver();
        }
        /// <summary>
        /// Adds movement to the center lanes to a specific speed. 
        /// </summary>
        /// <param name="speed"></param>
        public void MoveLine(int speed)
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
        public void MoveEnemy(int speed)
        {
            int x = r.Next(17, 246);
            if (enemy1.Top >= 400) enemy1.Location = new Point(x,0);
            else enemy1.Top += speed;
            if (enemy2.Top >= 400) enemy2.Location = new Point(x, 0);
            else enemy2.Top += speed;           
        }

        public void MoveCoin(int speed)
        {
            int x = r.Next(17, 246);
            if (coin1.Top >= 400) coin1.Location = new Point(x, 0);
            else coin1.Top += speed;
            if (coin2.Top >= 400) coin2.Location = new Point(x, 0);
            else coin2.Top += speed;
            if (coin3.Top >= 400) coin3.Location = new Point(x, 0);
            else coin3.Top += speed;
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
                pnlGameOver.Visible = true;
            }
        }
        /// <summary>
        /// Changes the score of the game when a coin is collected.
        /// Changes the position of the interesected coin. 
        /// </summary>
        private void CoinCollection()
        {
            if (mainCar.Bounds.IntersectsWith(coin1.Bounds))
            {
                score++;
                lblScore.Text = "Score = " + score;
                int x = r.Next(17, 246);
                coin1.Location = new Point(x, 0);
            }

            if (mainCar.Bounds.IntersectsWith(coin2.Bounds))
            {
                score++;
                lblScore.Text = "Score = " + score;
                int x = r.Next(17, 246);
                coin2.Location = new Point(x, 0);
            }

            if (mainCar.Bounds.IntersectsWith(coin3.Bounds))
            {
                score++;
                lblScore.Text = "Score = " + score;
                int x = r.Next(17, 246);
                coin3.Location = new Point(x, 0);
            }
        }
        /// <summary>
        ///Repositions the main car and colliting enemy car.
        /// Clears the score.
        /// Makes game over panel invisible.
        /// Restarts the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            int x = r.Next(17, 246);
            mainCar.Location = startLocation;
            if (mainCar.Bounds.IntersectsWith(enemy1.Bounds)) enemy1.Location = new Point(x, 0);
            if (mainCar.Bounds.IntersectsWith(enemy2.Bounds)) enemy2.Location = new Point(x, 0);
            pnlGameOver.Visible = false;
            lblScore.Text = "Score = 0";
            score = 0;
            timer1.Enabled = true;      
        }
    }
}
