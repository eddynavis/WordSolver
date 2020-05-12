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

        void Button_Clicked(object sender, System.EventArgs e)
        {
            if (EntryBox.Text == null)
            {
                StatusMessage.Text = "Happy Mother's Day! I love you Mom!";
                return;
            }

            String letters = EntryBox.Text;
            if (letters.Length < 3)
            {
                StatusMessage.Text = "Too few letters";
                Clear();
            }
            else if (letters.Length > 8)
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

        void Solve(string letters)
        {
            FoundWordList.Text = "";

            Combinations combinations = new Combinations(letters);
            foreach (string word in combinations.getWordCombinations())
            {
                if (words.contains(word))
                {
                    FoundWordList.Text += word + "\n";
                }
            }
        }

        void Clear()
        {
            FoundWordList.Text = "";
        }
    }
}
