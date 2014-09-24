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
    public class CirclePlayer:Circle
    {
        public Vector2 velocity;
        Random random;
        float speed = 2.0f;
        public float rotSpeed = 0.1f;
        public bool dead = false;
        public int player;

        public CirclePlayer(Vector2 Position, int Radius, Color Color, int nplayer)
            : base(Position, Radius, Color)
        {
            random = new Random(nplayer);
            velocity = Vector2.One*speed;
            double angle = random.NextDouble() * Math.PI * 2;
            velocity = RotateVector(velocity, angle);
            player = nplayer;

        }

        public Vector2 RotateVector(Vector2 vector, double theta)
        {
            Vector2 rot = new Vector2((float)(vector.X * Math.Cos(theta) - vector.Y * Math.Sin(theta)), (float)(vector.X * Math.Sin(theta) + vector.Y * Math.Cos(theta)));


            return rot;   
        }

        public void Die()
        {
            dead = true;
            DeathHelper.KillPlayer.Add(this);
        }

        public override void Update()
        {
            if (InputHelper.IsPadThumbstickLeft(player) == true | 
                    (player == 0 && InputHelper.IsButtonDown(Keys.Left)) |
                        (player == 1 && InputHelper.IsButtonDown(Keys.A)) |
                            (player == 2 && InputHelper.IsButtonDown(Keys.F)) |
                                (player == 3 && InputHelper.IsButtonDown(Keys.J)))
            {
                velocity = RotateVector(velocity, -rotSpeed);
            }
            else if (InputHelper.IsPadThumbstickRight(player) == true |
                    (player == 0 && InputHelper.IsButtonDown(Keys.Right)) |
                        (player == 1 && InputHelper.IsButtonDown(Keys.S)) |
                            (player == 2 && InputHelper.IsButtonDown(Keys.G)) |
                                (player == 3 && InputHelper.IsButtonDown(Keys.K)))
            {
                velocity = RotateVector(velocity, rotSpeed);
            }
            
            position += velocity;// *gameTime.ElapsedGameTime.Milliseconds / 1000.0f;


            if (position.X >= 0 && position.X < ViewPortHelper.WindowedWidth
                    && position.Y >= 36 && position.Y < ViewPortHelper.WindowedHeight)
            {

                ObjectHelper.Get_Tracks.Add(position, player);

                if (ObjectHelper.Get_Tracks.Check(position) == true)
                {
                    Die();
                }
            }
            else
            {
                Die();
            }

            base.Update();
        }

        public override void Draw(SpriteBatch sbatch)
        {
            base.Draw(sbatch);
        }
    }
}
