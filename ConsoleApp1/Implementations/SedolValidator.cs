using ConsoleApp1.Extensions;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Implementations
{
    public class SedolValidator : ISedolValidator
    {
        #region Global Variables

        const string SEDOLCHECKSUM = "131739";
        readonly Dictionary<int, string> errors;

        #endregion
        
        #region Constructor

        public SedolValidator()
        {
            errors = new();
            errors.Add(0, default);
            errors.Add(1, "Checksum digit does not agree with the rest of the input");
            errors.Add(2, "Input string was not 7-characters long");
            errors.Add(3, "SEDOL contains invalid characters");
        }

        #endregion

        #region ValidateSedol

        public ISedolValidationResult ValidateSedol(string input)
        {
            var mesg = Validate(input);

            if (mesg == default)
            {
                int[] sedolVal_outarry = input.ToIntArray();

                int checkSum = CalculateCheckSum(sedolVal_outarry);

                var isValid = IsValid(sedolVal_outarry.Last(), CheckDigit(checkSum));

                return new SedolValidationResult(input, isValid, IsUserDefined(sedolVal_outarry.First()), ValidationDetails(isValid));
            }

            return new SedolValidationResult(input, false, false, mesg);
        }

        #endregion

        #region Helper Methods

        private int CalculateCheckSum(int[] sedolVal_outarry)
        {
            var outarry = SEDOLCHECKSUM.ToIntArray();
            var stack = new Stack<int>();

            for (int i = 0; i < outarry.Length; i++)
                stack.Push(sedolVal_outarry[i] * outarry[i]);

            return stack.Sum();
        }

        private static bool IsUserDefined(int digit)
        {
            return digit == 9;
        }

        private static int CheckDigit(int sum)
        {
            return (10 - (sum % 10)) % 10;
        }

        private static bool IsValid(int SEDOLNO, int checkDigit)
        {
            return SEDOLNO == checkDigit;
        }

        private string ValidationDetails(bool isValid)
        {
            return errors.GetValueOrDefault(isValid ? 0 : 1);
        }

        private string Validate(string input)
        {
            var specialChar = new char[] { '_', '.' };
            int errorDigit = 0;

            if (input.Length != 7) errorDigit = 2;
            else if (input.IndexOfAny(specialChar) > 0) errorDigit = 3;

            return errors.GetValueOrDefault(errorDigit);
        }

        #endregion
    }
}
