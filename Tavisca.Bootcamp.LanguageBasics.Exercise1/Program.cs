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
            // Add your code here.
            int l = equation.Length;
            int m = l+1;
            int x = 0;
            char[] ch = equation.ToCharArray();
            
             for(int i = 0 ; i < l ; i++){
                if(ch[i] == '?' && i >= (l/2 + 1)){
                    string[] str = equation.Split("=");
                    string s = str[1];
                    string str1 = str[0];
                    string[] str2 = str1.Split("*");
                    string str3 = str2[0];
                    string str4 = str2[1];
                    int num1 = Int32.Parse(str3);
                    int num2 = Int32.Parse(str4);
                    int result = num1 * num2;
                    string result1 = result.ToString();
                    char[] ch1 = s.ToCharArray();
                    char[] ch2 = result1.ToCharArray();
                    char res = ' ';
                    for(int j = 0 ; j < s.Length ; j++){
                        if(ch1[j] == '?'){
                            res = ch2[j];
                        }
                    }
                    x = res - '0';
                    return x;
                }else if(ch[i] == '?' && i < (l/2 + 1)){
                    string[] str = equation.Split("=");
                    string s = str[1];
                    string str1 = str[0];
                    string[] str2 = str1.Split("*");
                    string str3 = str2[0];
                    string str4 = str2[1];
                    int num1 = 0;
                    int num2 = 0;
                    int num3 = Int32.Parse(s);
                    int result = 0;
                    if(str3.Contains('?')){
                        num2 = Int32.Parse(str4);
                        result = num3 / num2;
                    }else{
                        if(str4.Contains('?') && str4.Length == 3){
                            x = -1;
                            break;
                        }
                        num1 = Int32.Parse(str3);
                        result = num3 / num1;
                    }
                    string result1 = result.ToString();
                    char[] ch1 = new char[]{}; 
                    if(str3.Contains('?')){
                        ch1 = str3.ToCharArray();
                    }else{
                        ch1 = str4.ToCharArray();
                    }
                    char[] ch2 = result1.ToCharArray();
                    char res = ' ';
                    for(int j = 0 ; j < ch1.Length ; j++){
                        if(ch1[j] == '?'){
                            res = ch2[j];
                        }
                    }
                    x = res - '0';
                    return x;
                }
            }
            return x;
            throw new NotImplementedException();
        }
    }
}
