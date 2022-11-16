using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenWordGame
{
    public class GameStatsModel 
    {
        private readonly GameStatsViewModel _gameStats;

        public GameStatsViewModel GameStats
        {
            get { return _gameStats; }
        }
    }
}
