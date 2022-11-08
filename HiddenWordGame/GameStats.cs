using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenWordGame
{
    public class GameStats
    {
        private int _wrongGuesses;
        private int _goodGuesses;

        public int WrongGuesses
        {
            get { return _wrongGuesses; }
            set { value = _wrongGuesses; }
        }

        public int GoodGuesses
        {
            get { return _goodGuesses; }
            set { value = _goodGuesses; }
        }

    }
}
