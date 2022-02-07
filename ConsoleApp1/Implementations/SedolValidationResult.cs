using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Implementations
{
    public class SedolValidationResult : ISedolValidationResult
    {
        #region Private Properties

        private readonly string _inputStrings;
        private readonly bool _isValidSedol;
        private readonly bool _isUserDefined;
        private readonly string _validationDetails; 
        
        #endregion

        #region Constructor

        public SedolValidationResult(string inputStrings, bool isValidSedol, bool isUserDefined, string validationDetails)
        {
            _inputStrings = inputStrings;
            _isValidSedol = isValidSedol;
            _isUserDefined = isUserDefined;
            _validationDetails = validationDetails;
        }

        #endregion

        #region Properties

        public string InputString
        {
            get { return _inputStrings; }
        }

        public bool IsValidSedol
        {
            get { return _isValidSedol; }
        }

        public bool IsUserDefined
        {
            get { return _isUserDefined; }
        }

        public string ValidationDetails
        {
            get { return _validationDetails; }
        } 

        #endregion
    }
}
