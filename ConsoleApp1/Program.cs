using ConsoleApp1.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sedolValidator = new SedolValidator();
            var a = sedolValidator.ValidateSedol("VA.CDE8");

            Console.WriteLine($"{a.InputString} | {a.IsValidSedol} | {a.IsUserDefined} | {a.ValidationDetails}");
        }
    }
}
