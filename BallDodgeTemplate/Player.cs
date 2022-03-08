using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BallDodgeTemplate
{
    internal class Player
    {
        public int speed = 8;
        public int x, y;
        public int height = 10;
        public int width = 30;

        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public void PMove(string direction, Size ss)
        {
            if (direction == "left")
            {
                x -= speed;

                if (x < 0)
                {
                    x = 0;
                }
            }
            else if (direction == "right")
            {
                x += speed;

                if (x > ss.Width - width)
                {
                    x = ss.Width - width;
                }

            }

            if (direction == "up")
            {
                y -= speed;

                if (y < 0)
                {
                    y = 0;
                }
            }
            else if (direction == "down")
            {
                y += speed;

                if (y > ss.Height - height)
                {
                    y = ss.Height - height;
                }
            }


        }
        public bool Collision(BallMaker b)
        {
            Rectangle ball = new Rectangle(b.x, b.y, b.size, b.size);
            Rectangle player = new Rectangle(x, y, width, height);

            return player.IntersectsWith(ball);
        }
    }

}
