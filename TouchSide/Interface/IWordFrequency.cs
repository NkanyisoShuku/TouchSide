using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchSide.Interface
{
    public interface IWordFrequency
    {
        IDictionary<string, int> FrequencyWordsCount(string path);
    }
}
