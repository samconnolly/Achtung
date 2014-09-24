using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Achtung
{
    class AICirclePlayer:CirclePlayer
    {
        private Vector2 checkStep;
        private bool turn = false;
        private int turnDir = 1;
        private int turnSum = 0;
        private Random random;

        public AICirclePlayer(Vector2 Position, int Radius, Color Colour, int player)
            : base(Position, Radius, Colour, player)
        {
            random = new Random(player);
        }

        public override void Update()
        {
            checkStep = base.velocity;
            checkStep.Normalize();

            turn = false;
            
            for (int i = 3; i < 50; i++)
            {
                Vector2 check = base.position + checkStep * i;

                if (check.X < 0)
                {
                    if (base.velocity.Y >= 0)
                    {
                        turn = true;
                        turnDir = -1;
                    }
                    else
                    {
                        turn = true;
                        turnDir = 1;
                    }
                }
                else if (check.X >= ViewPortHelper.WindowedWidth)
                {
                    if (base.velocity.Y >= 0)
                    {
                        turn = true;
                        turnDir = 1;
                    }
                    else
                    {
                        turn = true;
                        turnDir = -1;
                    }
                }
                else if (check.Y < 36)
                {
                    if (base.velocity.X >= 0)
                    {
                        turn = true;
                        turnDir = 1;
                    }
                    else
                    {
                        turn = true;
                        turnDir = -1;
                    }
                }  
                else if (check.Y >= ViewPortHelper.WindowedHeight)
                {
                    if (base.velocity.X >= 0)
                    {
                        turn = true;
                        turnDir = -1;
                    }
                    else
                    {
                        turn = true;
                        turnDir = 1;
                    }
                } 
                else if (ObjectHelper.Get_Tracks.Check(check) == true)
                {
                    turn = true;

                    int left = 0;
                    int right = 0;

                    Vector2 leftCheck;
                    Vector2 rightCheck;

                    for (int j = 3; j < 50; j++)
                    {
                        leftCheck = base.RotateVector(base.position + checkStep * i, 0.1);
                        rightCheck = base.RotateVector(base.position + checkStep * i, -0.1);

                        if (ObjectHelper.Get_Tracks.Check(leftCheck)) { left += 1 + (int)((50 - i) * 0.01f); }
                        if (ObjectHelper.Get_Tracks.Check(rightCheck)) { right += 1 + (int)((50 - i) * 0.01f); }
                    }

                    if (left > right)
                    {
                        turnDir = 1;
                    }
                    else
                    {
                        turnDir = -1;
                    }
                }
            }

            if (turn == false)
            {
                if (random.NextDouble() < 0.7f) //0.7f
                {
                    turn = true;

                    if (turnSum > 1000)
                    {
                        turnDir = -1;
                    }
                    else if (turnSum < -1000)
                    {
                        turnDir = 1;
                    }
                }
            }


            if (turn == false)
            {
                turnDir = 0;
            }

            if (turn == true)
            {
                if (turnDir == 0)
                {
                    if (random.Next(2) == 0)
                    {
                        turnDir = -1;
                    }
                    else
                    {
                        turnDir = 1;
                    }
                }

                turnSum += turnDir;
                
                base.velocity = base.RotateVector(velocity, base.rotSpeed*turnDir);
            }

            base.Update();
        }
    }
}
