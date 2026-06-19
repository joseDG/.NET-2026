using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdapterApp
{
    public class WordSet : IEnumerable<string>
    {
        private IImmutableSet<string> Content { get; }
        private IEnumerable<string> SkipWords { get; }

        public WordSet(IEnumerable<string> skipWords)
        {
            Content = ImmutableHashSet.Create<string>(StringComparer.OrdinalIgnoreCase);
            SkipWords = skipWords.ToList();
        }

        private WordSet(IEnumerable<string> skipWords, IImmutableSet<string> content)
        {
            SkipWords = skipWords;
            Content = content;
        }

        public WordSet AddText(string text) =>
            new WordSet(SkipWords,
                    Content.Union(BreakIntoWords(text).Where(ShouldRetain)));


        private bool ShouldRetain(string word) =>
            SkipWords.All(skip => !string.Equals(word, skip, StringComparison.OrdinalIgnoreCase));
        

        private IEnumerable<string> BreakIntoWords(string content) =>
            Regex.Matches(content, @"[\p{L}0-9]+")
            .Select(match => match.Value);

        public IEnumerator<string> GetEnumerator() => 
            Content.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
