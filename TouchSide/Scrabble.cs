using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchSide
{
    public class Scrabble : IScrabble
    {
        private  readonly Dictionary<char, int> LetterScores = new Dictionary<char, int>
        {
            { 'A', 1 }, { 'E', 1 }, { 'I', 1 }, { 'O', 1 }, { 'U', 1 }, { 'L', 1 }, { 'N', 1 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
            { 'D', 2 }, { 'G', 2 },
            { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
            { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
            { 'K', 5 },
            { 'J', 8 }, { 'X', 8 },
            { 'Q', 10 }, { 'Z', 10 },
        };

        public string word { get; set; }
        public Scrabble() { }

        public Scrabble(string word)
        {
            this.word = word;
        }

        public int Score()
        {
            return Score(word);
        }

        private  int LetterScore(char c)
        {

            return LetterScores.ContainsKey(c) ? LetterScores[c] : 0;
        }

        public  int Score(string word)
        {
            return word == null ? 0 : word.ToUpperInvariant().Sum(c => LetterScore(c));
        }
    }
}
