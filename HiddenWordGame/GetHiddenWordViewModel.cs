using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HiddenWordGame
{
    public class GetHiddenWordViewModel : ViewModelBase
    {
        private string[] words = { "wizard", "crystal", "demon", "river", "forest", "stream", "magician", "knight", "exclamation", "fever", "christmas", "fettered", "viking", "cipher", "defeated", 
            "scream", "troll", "void", "sharp", "string" };

        private GameStatsViewModel _gameStatsViewModel;
        private string _selectedWord;
        private string _hiddenWord;
        private string _advice;
        private int _guessCount;

        public GetHiddenWordViewModel()
        {
            HideWord();
            GameStatsViewModel = new GameStatsViewModel();
            GuessCount = _selectedWord.Length;
        }

        public string HiddenWord 
        { 
            get 
            { 
                return _hiddenWord;
            }

            set
            {
                _hiddenWord = value;
                RaisePropertyChanged();
            }            
        }

        public string SelectedWord
        {
            get
            {
                return _selectedWord;
            }
            set
            {
                _selectedWord = value;
                RaisePropertyChanged();
            }
        }

        public GameStatsViewModel GameStatsViewModel
        {
            get
            {
                return _gameStatsViewModel;
            }
            set
            {
                _gameStatsViewModel = value;
                RaisePropertyChanged();
            }
        }

        public int GuessCount
        {
            get
            {
                return _guessCount;
            }

            set
            {
                _guessCount = value;
                RaisePropertyChanged();
            }
        }

        public string Advice
        {
            get
            {
                return _advice;
            }
            set
            {
                _advice = value;
                RaisePropertyChanged();
            }
        }

        public bool GameLogic(char selectedLetter)
        {
            for (int i = 0; i < SelectedWord.Length; i++)
            {
                if (selectedLetter == SelectedWord[i])
                {
                    HiddenWord = HiddenWord.Remove(i, 1);
                    HiddenWord = HiddenWord.Insert(i, selectedLetter.ToString());
                    GameStatsViewModel.GoodGuesses++;
                }
                else if (_selectedWord.Contains(selectedLetter) == false)
                {
                    GameStatsViewModel.WrongGuesses++;
                }
            }
            if (SelectedWord.Contains(selectedLetter))
            {
                Advice = $"{selectedLetter} is in the word!";
                if (HiddenWord == SelectedWord)
                {
                    Advice = $"{SelectedWord} was the hidden word!";
                }
                return true;
            }
            else
            {
                Advice = $"{selectedLetter} is NOT in the word!";
                GuessCount--;
                if (GuessCount == 0)
                {
                    HiddenWord = SelectedWord;
                    Advice = $"You ran out of guesses... the hidden word was {SelectedWord}!";
                }
                return false;
            }
        }

        public void HideWord()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, words.Length);

            SelectedWord = words[randomIndex];

            string hiddenWord = "";

            for (int i = 0; i < SelectedWord.Length; i++)
            {
                hiddenWord += "*";
            }
            HiddenWord = hiddenWord;
        }

       public GetHiddenWordViewModel ResetModel()
        {
            return new GetHiddenWordViewModel();
        }
    }
    //public class GetHiddenWordScreenViewModel
    //{
    //    private GetHiddenWordViewModel _getHiddenWordViewModel;

    //    public GetHiddenWordViewModel CurrentGetHiddenWord { get; set; }
    //}
}
