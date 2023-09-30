using FileCounter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCounter.Test.Services_Test
{
    public class WordCounterTest
    {
        [Fact]
        public void CountWordInFile_NullWord_ThrowsException()
        {
            // Arrange
            var wordCounter = new WordCounter();
            var filePath = Path.GetTempFileName();

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => wordCounter.CountWordInFile(null, filePath));
        }

        [Fact]
        public void CountWordInFile_FileDoesNotExist_ThrowsException()
        {
            // Arrange
            var wordCounter = new WordCounter();

            // Act + Assert
            Assert.Throws<FileNotFoundException>(() => wordCounter.CountWordInFile("Test", "./non-existing-file.txt"));
        }

        [Fact]
        public void CountWordInFile_ValidFileAndWord_ReturnsOccurenceResult()
        {
            var text = "Hello world! Say hello to the world!";
            var tempFile = Path.GetTempFileName();

            File.WriteAllText(tempFile, text);

            // Arrange
            var wordCounter = new WordCounter();

            // Act
            var result = wordCounter.CountWordInFile("hello", tempFile, true);

            // Assert
            Assert.Equal(2, result.OccurenceCount);
            Assert.Equal("hello", result.Word);
            Assert.Equal(tempFile, result.FilePath);

            // Cleanup
            File.Delete(tempFile);
        }

        [Fact]
        public void CountWordInFile_ValidFileAndWordCaseSensitive_ReturnsOccurenceResult()
        {
            var text = "Hello world! Say hello to the world!";
            var tempFile = Path.GetTempFileName();

            File.WriteAllText(tempFile, text);

            // Arrange
            var wordCounter = new WordCounter();

            // Act
            var result = wordCounter.CountWordInFile("hello", tempFile, false);

            // Assert
            Assert.Equal(1, result.OccurenceCount);
            Assert.Equal("hello", result.Word);
            Assert.Equal(tempFile, result.FilePath);

            // Cleanup
            File.Delete(tempFile);
        }
    }
}
