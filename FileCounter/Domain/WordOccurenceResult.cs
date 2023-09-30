using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCounter.Domain
{
    public class WordOccurenceResult
    {
        public string FilePath { get; }
        public string Word { get; }
        public int OccurenceCount { get; }

        public WordOccurenceResult(string filePath, string word, int occurenceCount)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (string.IsNullOrEmpty(word)) throw new ArgumentNullException(nameof(filePath));
            if (occurenceCount < 0) throw new ArgumentOutOfRangeException(nameof(occurenceCount));

            FilePath = filePath;
            Word = word;
            OccurenceCount = occurenceCount;
        }
    }
}
