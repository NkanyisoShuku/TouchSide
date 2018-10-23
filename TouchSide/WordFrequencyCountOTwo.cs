using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchSide.Interface;

namespace TouchSide
{
    /// <summary>
    /// we need tests for this class ,I would have done it with time.
    /// I have introduce IWordFrequency interface to test performance in two ways.
    /// </summary>
    public class WordFrequencyCountOTwo : IWordFrequency
    {
        private readonly char[] separators = { ' ' };

        public IDictionary<string, int> FrequencyWordsCount(string filePath)
        {
            var wordCounts =
                File.ReadLines(filePath)
                .SelectMany(l => l.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                .GroupBy(word => word.ToLower())
                .Select(n => new { Word = n.Key, Count = n.Count() })
                .ToDictionary(n => n.Word, n => n.Count);       
            return wordCounts;
        }
    }

}


