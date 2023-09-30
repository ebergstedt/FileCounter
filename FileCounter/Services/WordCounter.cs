using FileCounter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileCounter.Services
{
    public class WordCounter
    {
        public WordOccurenceResult CountWordInFile(
            string word, 
            string filePath, 
            bool ignoreCase = true)
        {
            if(string.IsNullOrEmpty(word)) throw new ArgumentNullException(nameof(word));
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File not found: {filePath}");

            string text = File.ReadAllText(filePath);

            RegexOptions options = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            Regex regex = new Regex($@"\b{Regex.Escape(word)}\b", options);
            MatchCollection matches = regex.Matches(text);

            int count = matches.Count;

            return new WordOccurenceResult(filePath, word, count);
        }
    }
}
