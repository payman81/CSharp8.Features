using System;
using NUnit.Framework;

namespace CSharp8.Features
{
    public class IndicesAndRanges
    {
        readonly string[] _words = new string[]
        {
            // index from start    index from end
            "The",      // 0                   ^9
            "quick",    // 1                   ^8
            "brown",    // 2                   ^7
            "fox",      // 3                   ^6
            "jumped",   // 4                   ^5
            "over",     // 5                   ^4
            "the",      // 6                   ^3
            "lazy",     // 7                   ^2
            "dog"       // 8                   ^1
        };

        [Test]
        public void AccessElementsByIndicesAndRages()
        {
            Assert.AreEqual("quickbrownfox", string.Join(string.Empty, _words[1..4]));
            Assert.AreEqual("foxjumpedoverthelazydog", string.Join(string.Empty, _words[3..^0]));
        }

        [Test]
        public void OtherUsages()
        {
            Range phrase = 1..4;
            Assert.AreEqual("quickbrownfox", string.Join(string.Empty, _words[1..4]));
            
            var allWords = _words[..]; // contains "The" through "dog".
            var firstPhrase = _words[..4]; // contains "The" through "fox"
            var lastPhrase = _words[6..]; // contains "the", "lazy" and "dog"
        }
    }
}