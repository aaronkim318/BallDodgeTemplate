using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BallDodgeTemplate
{

    internal class BallMaker
    {
        //colour, rectangle

        public int size = 10;
        public int xSpeed, ySpeed;
        public int x, y;


        public BallMaker(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;


        }
        public void Move(Size ss)
        {
            x += xSpeed;
            y += ySpeed;
            //check if the ball has reached the right or left edge
            if (x > ss.Width - size || x < 0)
            {
                xSpeed *= -1; ;
            }
            //check if the ball reach the top of bottom edge
            if (y > ss.Height - size || y < 0)
            {
                ySpeed *= -1; ;
            }
        }
    }
}
