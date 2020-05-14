using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WordSolver
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private Words words;

        public MainPage()
        {
            InitializeComponent();
            words = new Words();
        }

        /// <summary>
        /// Callback function the main button and entry textbox.
        /// </summary>
        /// <param name="sender">The button or entry element.</param>
        /// <param name="e">The event that triggered the call.</param>
        void Button_Clicked(object sender, System.EventArgs e)
        {
            if (EntryBox.Text == null)
            {
                StatusMessage.Text = "Happy Mother's Day! I love you Mom!";
                return;
            }

            String letters = EntryBox.Text.Trim();
            if (letters.Length < 3)
            {
                StatusMessage.Text = "Too few letters";
                Clear();
            }
            else if (letters.Length > 30)
            {
                StatusMessage.Text = "Too many letters";
                Clear();
            }
            else
            {
                StatusMessage.Text = "";
                Solve(letters);
            }
        }

        /// <summary>
        /// Find and display all the matches.
        /// </summary>
        /// <param name="letters">The letters to match.</param>
        void Solve(string letters)
        {
            FoundWordList.Text = "";

            WordMap wordMap = new WordMap(letters);
            foreach (string word in words.getWordList())
            {
                if (wordMap.isMatch(word))
                {
                    FoundWordList.Text += word + "\n";
                }
            }
        }

        /// <summary>
        /// Clears the word display.
        /// </summary>
        void Clear()
        {
            FoundWordList.Text = "";
        }
    }
}
