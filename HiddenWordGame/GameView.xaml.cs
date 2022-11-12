using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HiddenWordGame
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        private GetHiddenWordViewModel _hiddenWordGet = new GetHiddenWordViewModel();
        private string _selectedWord;
        private string _hiddenWord;
        private Button _saveButton;
        private GameStatsViewModel _gameStats;
        private int _guessCount;

        public GameView()
        {
            InitializeComponent();
            Loaded += GameView_Loaded;
            Unloaded += GameView_Unloaded;
        }

        private void GameView_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= GameView_Loaded;
            Unloaded -= GameView_Unloaded;
        }

        private void GameView_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new GetHiddenWordViewModel();
            _hiddenWordGet.HideWord();
            _hiddenWord = _hiddenWordGet.HiddenWord;
            hiddenWordLabel.Content = _hiddenWord;
            _selectedWord = _hiddenWordGet.SelectedWord;
            _guessCount = _selectedWord.Length;
            guessCountLabel.Content = $"Guesses remaining: {_guessCount}";
        }

        /*The meat of the game takes place here.  
         * when a letter is clicked, the code tries to match the given letter
         * to a char in the _selectedWord string.  
         * If the letter does match, it will remove the * from the hidden word
         * and insert the char.
         */
        private void LetterButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedLetterButton = (sender as Button).Content.ToString();
            char selectedLetter = Char.ToLower(selectedLetterButton[0]);
            _saveButton = (sender as Button);

            ((GetHiddenWordViewModel)DataContext).GameLogic(selectedLetter);

            //for (int i = 0; i < _selectedWord.Length; i++)
            //{
            //    if (selectedLetter == _selectedWord[i])
            //    {
            //        _hiddenWord = _hiddenWord.Remove(i, 1);
            //        _hiddenWord = _hiddenWord.Insert(i, selectedLetter.ToString());
            //        hiddenWordLabel.Content = _hiddenWord;
            //        _saveButton.Background = new LinearGradientBrush(Colors.Green, Colors.Green, 90);
            //        _gameStats.GoodGuesses++;
            //        adviceLabel.Content = $"{selectedLetter} is in the word!";
            //        if (_hiddenWord.Contains('*') == false)
            //        {
            //            adviceLabel.Content = $"The hidden word was {_selectedWord}!  Click restart to play again!";
            //        }
            //    }
            //    else if (_selectedWord.Contains(selectedLetter) == false)
            //    {
            //        _saveButton.Background = new LinearGradientBrush(Colors.DarkGray, Colors.DarkGray, 90);
            //        _gameStats.WrongGuesses++;
            //        adviceLabel.Content = $"{selectedLetter} is NOT in the word!";
            //    }
            //}
            //if (_selectedWord.Contains(selectedLetter) == false)
            //{
            //    _guessCount--;
            //}
            //guessCountLabel.Content = $"Guesses remaining: {_guessCount}";
            //if (_guessCount == 0)
            //{
            //    hiddenWordLabel.Content = _selectedWord;
            //    adviceLabel.Content = $"You ran out of guesses... the word was {_selectedWord}!";
            //}
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new GameView();

        }

    }
}

