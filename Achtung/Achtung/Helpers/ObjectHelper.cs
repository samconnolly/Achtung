using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Achtung
{
    public static class ObjectHelper
    {
        private static Tracks _tracks;
        //private static CirclePlayer _player;
         
        public static Tracks Get_Tracks
        {
            get { return _tracks;}
            set { _tracks = value; }
        }

        //public static CirclePlayer Player
        //{
        //    get { return _player; }
        //    set { _player = value; }
        //}
    }
}
