namespace FileCounter.IntegrationTest
{
    public class Program_Test
    {
        [Fact]
        public void Main_ValidArgs_WritesExpectedOutput()
        {
            // Arrange
            var text = "Hello world! Say hello to the world!";
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, text);

            var expectedOutput = $"The word '{Path.GetFileNameWithoutExtension(tempFile)}' was found 0 times in file {tempFile}.{Environment.NewLine}";
            var writer = new StringWriter();
            Console.SetOut(writer);

            var args = new string[] { tempFile };

            // Act
            Program.Main(args);

            // Assert
            Assert.Equal(expectedOutput, writer.ToString());

            // Cleanup
            File.Delete(tempFile);
        }
    }
}