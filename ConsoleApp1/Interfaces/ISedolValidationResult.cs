using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface ISedolValidationResult
    {
        string InputString { get; }
        bool IsValidSedol { get; }
        bool IsUserDefined { get; }
        string ValidationDetails { get; }
    }
}
