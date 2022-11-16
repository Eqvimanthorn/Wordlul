using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
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
        private readonly List<Button> _buttons = new List<Button>();

        public GameView()
        {
            InitializeComponent();
        }

        private void LetterButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedLetterButton = (sender as Button).Content.ToString();
            char selectedLetter = Char.ToLower(selectedLetterButton[0]);

            Button button = (sender as Button);
            if (((GetHiddenWordViewModel)DataContext).GameLogic(selectedLetter) == true)
            {
                button.Background = new LinearGradientBrush(Colors.Green, Colors.Green, 90);
            }
            else
            {
                button.Background = new LinearGradientBrush(Colors.DarkGray, Colors.DarkGray, 90);
            }
            _buttons.Add(button);
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new GetHiddenWordViewModel();
            foreach(var button in _buttons)
            {
                button.ClearValue(Button.BackgroundProperty);
            }
        }

    }
    public class GuessCountLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Guesses remaining: {value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

