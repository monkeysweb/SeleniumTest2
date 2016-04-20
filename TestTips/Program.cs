using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTips
{
    class Program
    {
        static void Main(string[] args)
        {
            string myCustomEmailAddress1 = TestDataHelper.GenerateEmailAddress();

            string myCustomEmailAddress2 = TestDataHelper.GenerateEmailAddress();

            string myCustomEmailAddress3 = TestDataHelper.GenerateEmailAddress();

            Console.WriteLine(myCustomEmailAddress1);

            Console.WriteLine(myCustomEmailAddress2);

            Console.WriteLine(myCustomEmailAddress3);

            Console.ReadKey();
        }
    }
}
