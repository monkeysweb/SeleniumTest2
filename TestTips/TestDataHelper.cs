using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTips
{
    public class TestDataHelper
    {
        private static Random _random = new Random();

        public static string GenerateEmailAddress()
        {
            return "vitalina.boiko" + _random.Next(10000, 99999) + "@gmail.com";
        }
    }
}
