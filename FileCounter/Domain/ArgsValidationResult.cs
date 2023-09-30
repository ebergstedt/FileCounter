using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCounter.Domain
{
    public class ArgsValidationResult
    {
        public bool Success { get; }
        public string Reason { get; }

        public ArgsValidationResult(bool success, string reason = "")
        {
            Success = success;
            Reason = reason;
        }
    }
}
