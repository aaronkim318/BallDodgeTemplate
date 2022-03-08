using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    public partial class GameScreen : UserControl
    {
        List<BallMaker> dodgeBalls = new List<BallMaker>();
        BallMaker chaseBall;
        Player hero;
        Size screenSize;

        Random randgen = new Random();

        public bool rightDown = false;
        public bool leftDown = false;
        public bool upArrowDown = false;
        public bool downArrowDown = false;

        public static int gsWidth = 600;
        public static int gsHeight = 600;

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }


        public void InitializeGame()
        {

            screenSize = new Size(this.Width, this.Height);

            int x = randgen.Next(40, gsWidth - 40);
            int y = randgen.Next(40, gsHeight - 40);

            chaseBall = new BallMaker(x, y, 8, 8);

            for (int i = 0; i < 2; i++)
            {
                x = randgen.Next(40, gsWidth - 40);
                y = randgen.Next(40, gsHeight - 40);

                BallMaker b = new BallMaker(x, y, 8, 8);
                dodgeBalls.Add(b);
            }
            x = randgen.Next(40, gsWidth - 40);
            y = randgen.Next(40, gsHeight - 40);

            hero = new Player(x, y);
        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            chaseBall.Move(screenSize);
            
            if (leftDown == true)
            {
                hero.PMove("left", screenSize);
            }
            else if (rightDown == true)
            {
                hero.PMove("right", screenSize);
            }

            if (upArrowDown == true)
            {
                hero.PMove("up", screenSize);
            }
            else if (downArrowDown == true)
            {
                hero.PMove("down", screenSize);
            }

            foreach (BallMaker b in dodgeBalls)
            {
                b.Move(screenSize);
            }

            foreach(BallMaker c in dodgeBalls)
            {
                if (hero.Collision(c))
                {
                    //if they have collided do something here
                   
                }

            }

            Rectangle chaseRec = new Rectangle(chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);
            Rectangle heroRec = new Rectangle(hero.x, hero.y, hero.width, hero.height);

            if (heroRec.IntersectsWith(chaseRec))
            {
                chaseBall.ySpeed *= -1;
            }

            Refresh();

        }


        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Green, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);
            e.Graphics.FillRectangle(Brushes.Blue, hero.x, hero.y, hero.width, hero.height);
            foreach (BallMaker b in dodgeBalls)
            {
                e.Graphics.FillEllipse(Brushes.Red, b.x, b.y, b.size, b.size);

            }
        }
    }
}
