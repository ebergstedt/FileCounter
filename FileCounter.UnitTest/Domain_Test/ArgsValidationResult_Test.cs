using FileCounter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCounter.Test.Domain_Test
{
    using Xunit;

    public class ArgsValidationResult_Test
    {
        [Fact]
        public void Constructor_SetProperties_Successfully()
        {
            // Arrange
            bool isSuccess1 = false;
            bool isSuccess2 = true;
            bool isSuccess3 = false;
            bool isSuccess4 = true;
            string errorMessage3 = "test";
            string errorMessage4 = "test";

            // Act
            var result1 = new ArgsValidationResult(isSuccess1);
            var result2 = new ArgsValidationResult(isSuccess2);
            var result3 = new ArgsValidationResult(isSuccess3, errorMessage3);
            var result4 = new ArgsValidationResult(isSuccess4, errorMessage4);

            // Assert
            Assert.Equal(isSuccess1, result1.Success);
            Assert.Equal(isSuccess2, result2.Success);
            Assert.Equal(isSuccess3, result3.Success);
            Assert.Equal(isSuccess4, result4.Success);

            Assert.True(string.IsNullOrEmpty(result1.Reason));
            Assert.True(string.IsNullOrEmpty(result2.Reason));
            Assert.Equal(errorMessage3, result3.Reason);
            Assert.Equal(errorMessage4, result4.Reason);
        }
    }
}
