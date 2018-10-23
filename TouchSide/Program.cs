using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using TouchSide.Interface;

namespace TouchSide
{
    class Program
    {

        private static IScrabble _scrabble;
        private static IWordFrequency _word;
        private static int maxValue, most7CharWord;
        private static string keyOfMaxValue, key7OfMaxValue;
        private static string filePath = ConfigurationManager.AppSettings["FilePath"];

        static void Main(string[] args)
        {
            _scrabble = new Scrabble();
            _word = new WordFrequencyCountOne();

            IDictionary<string, int> words = _word.FrequencyWordsCount(filePath);
            IDictionary<string, int> dicScore = new Dictionary<string, int>();

            WordProcessor(words, out maxValue, out keyOfMaxValue, out most7CharWord, out key7OfMaxValue);
            IOrderedEnumerable<KeyValuePair<string, int>> sorteddicScore = SortedDict(words, dicScore);

            int highestScore = sorteddicScore.FirstOrDefault().Value;
            var highestdicScore = sorteddicScore.Where(c => c.Value == highestScore).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Most frequent word: { keyOfMaxValue} occurred { maxValue } times");
            Console.WriteLine($"Most frequent 7 - character word: { key7OfMaxValue} occurred { most7CharWord} times");
            Console.WriteLine($"Highest scoring word(s) (according to Scrabble):");
            foreach (var item in highestdicScore)
            {
                Console.WriteLine($"{item.Key} with a score of {item.Value}");
            }
            Console.ReadKey();
        }

        private static IOrderedEnumerable<KeyValuePair<string, int>> SortedDict(IDictionary<string, int> words, IDictionary<string, int> dicScore)
        {
            foreach (var item in words)
            {
                _scrabble.word = item.Key;
                dicScore.Add(item.Key, _scrabble.Score());
            }
            var sorteddicScore = from pair in dicScore
                                 orderby pair.Value
                                 descending
                                 select pair;
            return sorteddicScore;
        }
        private static void WordProcessor(IDictionary<string, int> words, out int maxValue, out string keyOfMaxValue, out int most7CharWord, out string key7OfMaxValue)
        {
            maxValue = words.Values.Max();
            keyOfMaxValue = words.Keys.Aggregate((x, y) => words[x] > words[y] ? x : y);
            IDictionary<string, int> wordsseven = words.Where(m => m.Key.ToString().Length == 7).ToDictionary(x => x.Key, x => x.Value);
            most7CharWord = wordsseven.Values.Max();
            key7OfMaxValue = wordsseven.Keys.Aggregate((x, y) => wordsseven[x] > wordsseven[y] ? x : y);
        }

    }
}







