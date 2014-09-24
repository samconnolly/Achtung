using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Achtung
{
    public static class ScoreHelper
    {
        private static int _nplayers = 1;
        private static int _nAIplayers = 1;
        private static List<CirclePlayer> _players;
        private static List<int> _scores = new List<int>{0,0,0,0};

        public static int NPlayers
        {
            get { return _nplayers; }
            set { _nplayers = value; }
        }

        public static int NAIPlayers
        {
            get { return _nAIplayers; }
            set { _nAIplayers = value; }
        }

        public static List<CirclePlayer> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        public static List<int> Scores
        {
            get { return _scores; }
            set { _scores = value; }
        }


    }
}

