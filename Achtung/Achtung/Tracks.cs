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
    public class Tracks
    {
        
    //private static int x = ViewPortHelper.WindowedWidth;
    //private static int y = ViewPortHelper.WindowedHeight;
        public int[,] trails = new int[1080, 720];
        public Texture2D blank;
        public List<Color> colors = new List<Color> { Color.Green, Color.Red, Color.Blue, Color.Yellow, Color.White, Color.White, Color.White, Color.White };
        private List<Tuple<Vector2,int>> addList = new List<Tuple<Vector2,int>> { };
        
        public Tracks(Color Color)
        {

            blank = new Texture2D(ViewPortHelper.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });

            ObjectHelper.Get_Tracks = this;
        }

        public void Add(Vector2 here, int player)
        {
            addList.Add(new Tuple<Vector2,int>(here,player+1));
        }

        public bool Check(Vector2 here)
        {
            if ((int)here.X < 0 | (int)here.X >= ViewPortHelper.WindowedWidth
                    | (int)here.Y < 0 | (int)here.Y >= ViewPortHelper.WindowedHeight)
            {
                return true;
            }
            else if (trails[(int)here.X, (int)here.Y] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update()
        {
            foreach (Tuple<Vector2,int> points in addList)
            {
                Vector2 here = points.Item1;
                int colour = points.Item2;

                trails[(int)here.X, (int)here.Y] = colour;

                if ((int)here.X < ViewPortHelper.WindowedWidth - 1) { trails[(int)here.X + 1, (int)here.Y] = colour; }

                if ((int)here.X > 1) { trails[(int)here.X - 1, (int)here.Y] = colour; }

                if ((int)here.Y < ViewPortHelper.WindowedHeight - 1) { trails[(int)here.X, (int)here.Y + 1] = colour; }

                if ((int)here.Y > 0) { trails[(int)here.X, (int)here.Y - 1] = colour; }

                if ((int)here.X < ViewPortHelper.WindowedWidth - 1 && here.Y < ViewPortHelper.WindowedHeight - 1) { trails[(int)here.X + 1, (int)here.Y + 1] = colour; }

                if ((int)here.X < ViewPortHelper.WindowedWidth - 1 && here.Y > 1) { trails[(int)here.X + 1, (int)here.Y - 1] = colour; }

                if ((int)here.X > 1 && here.Y < ViewPortHelper.WindowedHeight - 1) { trails[(int)here.X - 1, (int)here.Y + 1] = colour; }

                if ((int)here.X > 1 && here.Y > 1) { trails[(int)here.X - 1, (int)here.Y - 1] = colour; }
            }
        }

        public void Draw(SpriteBatch sbatch)
        {
            for (int x = 0; x < (trails.GetLength(0)); x++)
            {
                for (int y = 0; y < (trails.GetLength(1)); y++)
                {   
                    if (trails[x, y] > 0)
                    {
                        int c = trails[x, y];
                        sbatch.Draw(blank, new Vector2(x,y), null, colors[trails[x, y]-1], 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    }
                }
            }

        }
    }
}
