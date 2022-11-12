using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SQLite;


namespace HiddenWordGame
{
    public class GameStatsViewModel : ViewModelBase
    {
        
        private int _wrongGuesses;
        private int _goodGuesses;

        public int WrongGuesses
        {
            get { return _wrongGuesses; }
            set { value = _wrongGuesses; RaisePropertyChanged(); }
        }

        public int GoodGuesses
        {
            get { return _goodGuesses; }
            set { value = _goodGuesses; RaisePropertyChanged(); }
        }

    }
}
