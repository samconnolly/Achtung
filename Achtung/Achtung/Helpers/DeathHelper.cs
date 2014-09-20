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
    public static class DeathHelper
    {
        private static List<CirclePlayer> _deathList = new List<CirclePlayer> { };

        public static List<CirclePlayer> KillPlayer  
        {
            get { return _deathList; }
            set { _deathList = value; }
        }

    }
}