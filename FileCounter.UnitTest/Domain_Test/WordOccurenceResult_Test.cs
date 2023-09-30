using FileCounter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCounter.Test.Domain_Test
{
    public class WordOccurenceResult_Test
    {
        [Fact]
        public void Constructor_SetProperties_Successfully()
        {
            // Arrange
            string filePath = "test.txt";
            string word = "example";
            int occurenceCount = 5;

            // Act
            var wordOccurenceResult = new WordOccurenceResult(filePath, word, occurenceCount);

            // Assert
            Assert.Equal(filePath, wordOccurenceResult.FilePath);
            Assert.Equal(word, wordOccurenceResult.Word);
            Assert.Equal(occurenceCount, wordOccurenceResult.OccurenceCount);
        }
    }
}
