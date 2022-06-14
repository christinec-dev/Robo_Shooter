using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace RoboShooter
{
    //will spawn bullets on our screen
    class bullet
    {
        //public variables
        public string direction;
        public int bulletSpeed = 20; 
        public int bulletLeft; 
        public int bulletTop;
        PictureBox Bullet = new PictureBox();
        Timer bulletSpread = new Timer();

        public void spawnBullets(Form form)
        {
            //creates the bullets, which will be little cubes when space bar is pressed 
            Bullet.BackColor = Color.Gold; 
            Bullet.Size = new Size(5, 5); 
            Bullet.Tag = "bullet"; 
            Bullet.Left = bulletLeft;
            Bullet.Top = bulletTop; 
            Bullet.BringToFront(); 

            //adds bullet to screen at x speed when button is pressed
            form.Controls.Add(Bullet); 
            bulletSpread.Interval = bulletSpeed; 
            bulletSpread.Tick += new EventHandler(bulletSpreadTick);
            bulletSpread.Start(); 
        }

        //direction of the bullet
        public void bulletSpreadTick(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                Bullet.Left -= bulletSpeed; 
            }

            if (direction == "right")
            {
                Bullet.Left += bulletSpeed;
            }

            if (direction == "up")
            {
                Bullet.Top -= bulletSpeed;
            }

            if (direction == "down")
            {
                Bullet.Top += bulletSpeed;
            }

            //if the bullets have reached a certain point from the player, it dissapears
            if (Bullet.Left < 16 || Bullet.Left > 860 || Bullet.Top < 10 || Bullet.Top > 616)
            {
                bulletSpread.Stop();
                bulletSpread.Dispose(); 
                Bullet.Dispose(); 
                bulletSpread = null; 
                Bullet = null; 
            }
        }
    }
}
