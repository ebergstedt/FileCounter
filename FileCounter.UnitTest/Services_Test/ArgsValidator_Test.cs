using FileCounter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCounter.Test.Services_Test
{
    public class ArgsValidator_Test
    {
        [Fact]
        public void Validate_NullArguments_ReturnsFailedResult()
        {
            // Arrange
            var validator = new ArgsValidator();

            // Act
            var result = validator.Validate(null);

            // Assert
            Assert.False(result.Success);
            Assert.NotNull(result.Reason);
        }

        [Fact]
        public void Validate_MultipleArguments_ReturnsFailedResult()
        {
            // Arrange
            var validator = new ArgsValidator();
            var args = new string[] { "file1.txt", "file2.txt" };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.False(result.Success);
            Assert.NotNull(result.Reason);
        }

        [Fact]
        public void Validate_NonExistingFilePath_ReturnsFailedResult()
        {
            // Arrange
            var validator = new ArgsValidator();
            var args = new string[] { "./non-existing-file.txt" };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.False(result.Success);
            Assert.NotNull(result.Reason);
        }

        [Fact]
        public void Validate_ValidFilePath_ReturnsSuccessfulResult()
        {
            // Arrange
            var filename = Path.GetTempFileName();
            try
            {
                var validator = new ArgsValidator();
                var args = new string[] { filename };

                // Act
                var result = validator.Validate(args);

                // Assert
                Assert.True(result.Success);
                Assert.True(string.IsNullOrEmpty(result.Reason));
            }
            finally
            {
                File.Delete(filename);
            }
        }
    }
}
