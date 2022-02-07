using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Implementations.Tests
{
    [TestClass()]
    public class SedolValidatorTests
    {
        SedolValidator sedolValidator;
        Dictionary<int, string> errors;

        [TestInitialize]
        public void TestInitialize()
        {
            sedolValidator = new SedolValidator();
            
            errors = new();
            errors.Add(0, default);
            errors.Add(1, "Checksum digit does not agree with the rest of the input");
            errors.Add(2, "Input string was not 7-characters long");
            errors.Add(3, "SEDOL contains invalid characters");
        }

        [TestMethod()]
        [DataRow("NULL")]
        [DataRow("")]
        [DataRow("12")]
        [DataRow("123456789")]
        public void Null_EmptyStringOrStringOtherThan7CharactersLong(string inputString)
        {
            var result = sedolValidator.ValidateSedol(inputString);

            Assert.AreEqual(result.InputString, inputString);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.ValidationDetails, errors.GetValueOrDefault(2));
        }

        [TestMethod()]
        [DataRow("1234567")]
        public void InvalidChecksumNonUserDefinedSEDOL(string inputString)
        {
            var result = sedolValidator.ValidateSedol(inputString);

            Assert.AreEqual(result.InputString, inputString);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.ValidationDetails, errors.GetValueOrDefault(1));
        } 
        
        [TestMethod()]
        [DataRow("0709954")]
        [DataRow("B0YBKJ7")]
        public void ValidNonUserDefinedSEDOL(string inputString)
        {
            var result = sedolValidator.ValidateSedol(inputString);

            Assert.AreEqual(result.InputString, inputString);
            Assert.AreEqual(result.IsValidSedol, true);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.ValidationDetails, errors.GetValueOrDefault(0));
        }
        
        [TestMethod()]
        [DataRow("9123451")]
        [DataRow("9ABCDE8")]
        public void InvalidChecksumUserDefinedSEDOL(string inputString)
        {
            var result = sedolValidator.ValidateSedol(inputString);

            Assert.AreEqual(result.InputString, inputString);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.IsUserDefined, true);
            Assert.AreEqual(result.ValidationDetails, errors.GetValueOrDefault(1));
        }

        [TestMethod()]
        [DataRow("9123_51")]
        [DataRow("VA.CDE8")]
        public void InvaidCharactersFound(string inputString)
        {
            var result = sedolValidator.ValidateSedol(inputString);

            Assert.AreEqual(result.InputString, inputString);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.ValidationDetails, errors.GetValueOrDefault(3));
        }

        [TestMethod()]
        [DataRow("9123458")]
        [DataRow("9ABCDE1")]
        public void ValidUserDefinedSEDOL(string inputString)
        {
            var result = sedolValidator.ValidateSedol(inputString);

            Assert.AreEqual(result.InputString, inputString);
            Assert.AreEqual(result.IsValidSedol, true);
            Assert.AreEqual(result.IsUserDefined, true);
            Assert.AreEqual(result.ValidationDetails, errors.GetValueOrDefault(0));
        }
    }
}