using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchSide.Interface;

namespace TouchSide
{
    public class WordFrequencyCountOne : IWordFrequency
    {

        /// <summary>
        /// we need tests for this class ,I would have done it with time.
        /// I have introduce IWordFrequency interface to test performance in two ways.
        /// </summary>
        private readonly char[] separators = { ' ' };

        public IDictionary<string, int> FrequencyWordsCount(string filePath)
        {
            var wordCount = new Dictionary<string, int>();

            using (var fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var streamReader = new StreamReader(fileStream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (wordCount.ContainsKey(word))
                        {
                            wordCount[word] = wordCount[word] + 1;
                        }
                        else
                        {
                            wordCount.Add(word, 1);
                        }
                    }
                }
            }

            return wordCount;
        }
    }
}

