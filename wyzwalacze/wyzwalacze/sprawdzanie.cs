using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wyzwalacze
{
    public class sprawdzanie : INotifyPropertyChanged
    {
        private string word1 = "";
        private string word2 = "";
        private string result = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Word1
        {
            get { return word1; }
            set
            {
                if (word1 != value)
                {
                    word1 = value;
                    OnPropertyChanged(nameof(Word1));
                }
            }
        }

        public string Word2
        {
            get { return word2; }
            set
            {
                if (word2 != value)
                {
                    word2 = value;
                    OnPropertyChanged(nameof(Word2));
                }
            }
        }

        public string Result
        {
            get { return result; }
            private set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public void CheckAnagram()
        {
            if (AreAnagrams(Word1, Word2))
            {
                Result = "Słowa są anagramami!";
            }
            else
            {
                Result = "Słowa nie są anagramami.";
            }
        }

        private bool AreAnagrams(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            char[] sortedWord1 = word1.ToCharArray();
            char[] sortedWord2 = word2.ToCharArray();
            Array.Sort(sortedWord1);
            Array.Sort(sortedWord2);

            for (int i = 0; i < sortedWord1.Length; i++)
            {
                if (sortedWord1[i] != sortedWord2[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
