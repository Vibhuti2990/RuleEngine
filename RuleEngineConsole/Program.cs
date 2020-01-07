using RuleEngineConsole.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace RuleEngineConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UTIL.CheckRules();
            Console.ReadKey();
        }
    }
}
