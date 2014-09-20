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
    public abstract class Circle
    {
        public Vector2 position;
        public int radius;
        private List<Vector2> vertices;
        private Texture2D blank;
        public int thickness = 3;
        public Color color;

        public Circle(Vector2 Position, int Radius, Color Color)
        {
            position = Position;
            radius = Radius;

            color = Color;

            blank = new Texture2D(ViewPortHelper.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { color });
        }

        public virtual void Update()
        {
            vertices = new List<Vector2> { };


            for (int x = -radius; x < radius; x++)
            {
                for (int y = -radius; y < radius; y++)
                {
                    if (Math.Pow(x, 2) + Math.Pow(y,2) < Math.Pow(radius,2))
                    {
                        vertices.Add(position + new Vector2((float)x, (float)y));
                    }
                }
            }
        }

        public virtual void Draw(SpriteBatch sbatch)
        {

            for (int x = 0; x < (vertices.Count()); x++)
            {
                sbatch.Draw(blank, vertices[x], null, color, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            }
        }

    }
}