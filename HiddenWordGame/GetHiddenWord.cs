using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace HiddenWordGame
{
    public class GetHiddenWord
    {
        private string[] words = { "wizard", "crystal", "demon", "river", "forest", "stream", "magician", "knight", "exclamation", "fever", "christmas", "fettered", "viking", "cipher", "defeated", 
            "scream", "troll", "void", "sharp", "string" };

        private string selectedWord;
        private string hiddenWord;

        public string RetrieveWord()
            => hiddenWord;

        public string GuessWork()
            => selectedWord;

        public void HideWord()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, words.Length);

            string selectedWord = words[randomIndex];

            this.selectedWord = selectedWord;

            string hiddenWord = "";

            for (int i = 0; i < selectedWord.Length; i++)
            {
                hiddenWord += "*";
            }
            this.hiddenWord = hiddenWord;
        }
            
    }
}
