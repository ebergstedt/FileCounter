using FileCounter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCounter.Services
{
    public class ArgsValidator
    {
        public ArgsValidationResult Validate(string[] args)
        {
            if (args == null || args.Length != 1)            
                return new ArgsValidationResult(false, "Please provide a single file path argument.");            

            var filePath = args[0];

            if (!File.Exists(filePath))
                return new ArgsValidationResult(false, $"The provided file path does not exist: {filePath}");                            

            return new ArgsValidationResult(true);
        }
    }
}
