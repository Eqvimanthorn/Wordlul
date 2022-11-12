using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private int _guessCount;

        public GetHiddenWordViewModel()
        {
            HideWord();
            GameStatsViewModel = new GameStatsViewModel();
            //hiddenWordLabel.Content = _hiddenWord;
            GuessCount = _selectedWord.Length;
            //guessCountLabel.Content = $"Guesses remaining: {_guessCount}";
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

        public void GameLogic(char selectedLetter)
        {
            for (int i = 0; i < SelectedWord.Length; i++)
            {
                if (selectedLetter == SelectedWord[i])
                {
                    HiddenWord = HiddenWord.Remove(i, 1);
                    HiddenWord = HiddenWord.Insert(i, selectedLetter.ToString());
                    //hiddenWordLabel.Content = _hiddenWord;
                    //_saveButton.Background = new LinearGradientBrush(Colors.Green, Colors.Green, 90);
                    GameStatsViewModel.GoodGuesses++;
                    //adviceLabel.Content = $"{selectedLetter} is in the word!";
                    //if (_hiddenWord.Contains('*') == false)
                    //{
                    //    adviceLabel.Content = $"The hidden word was {_selectedWord}!  Click restart to play again!";
                    //}
                }
                //else if (_selectedWord.Contains(selectedLetter) == false)
                //{
                //    _saveButton.Background = new LinearGradientBrush(Colors.DarkGray, Colors.DarkGray, 90);
                GameStatsViewModel.WrongGuesses++;
                //    adviceLabel.Content = $"{selectedLetter} is NOT in the word!";
                //}
            }
            if (_selectedWord.Contains(selectedLetter) == false)
            {
                GuessCount--;
            }
            //guessCountLabel.Content = $"Guesses remaining: {_guessCount}";
            //if (_guessCount == 0)
            //{
            //    hiddenWordLabel.Content = _selectedWord;
            //    adviceLabel.Content = $"You ran out of guesses... the word was {_selectedWord}!";
            //}
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
    }
}
