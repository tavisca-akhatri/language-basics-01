using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
            
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            int index_star = equation.IndexOf("*");
            int index_equal = equation.IndexOf("=");
            String operand1 = equation.Substring(0, index_star);
            String operand2 = equation.Substring(index_star+1, index_equal-index_star-1);
            String operand3 = equation.Substring(index_equal+1);

            if(operand1.IndexOf("?") != -1 || operand2.IndexOf("?") != -1)
            {
                if(operand2.IndexOf("?") != -1)
                {
                    String temp = operand1;
                    operand1 = operand2;
                    operand2 = temp;
                }
                int val3 = int.Parse(operand3);
                int val2 = int.Parse(operand2);
                int val1 = val3 / val2;
                String operand1original = val1.ToString();
                if(operand1.Length != operand1original.Length)
                {
                    return -1;
                }
                int index = operand1.IndexOf("?");
                char result = operand1original[index];
                return result - '0' == 0 && index == 0 ? -1 : (result-'0');
            }
            else
            {
                int val1 = int.Parse(operand1);
                int val2 = int.Parse(operand2);
                int val3 = val1 * val2;
                String operand3original = val3.ToString();
                if(operand3.Length != operand3original.Length)
                {
                    return -1;
                } 
                int index = operand3.IndexOf("?");
                char result = operand3original[index];
                return result - '0' == 0 && index == 0 ? -1 : (result - '0');
            }
        }
    }
}
