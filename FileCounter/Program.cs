using FileCounter.Domain;
using FileCounter.Services;

namespace FileCounter
{
    public class Program
    {
        static WordCounter wordCounter = new WordCounter();

        public static void Main(string[] args)
        {
            var validator = new ArgsValidator();
            ArgsValidationResult validationResult = validator.Validate(args);

            if (!validationResult.Success)
            {
                Console.WriteLine(validationResult.Reason);
                return;
            }

            string filePath = args[0];
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            WordOccurenceResult wordResult = wordCounter.CountWordInFile(fileName, filePath);
            Console.WriteLine($"The word '{wordResult.Word}' was found {wordResult.OccurenceCount} times in file {wordResult.FilePath}.");
        }
    }
}