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
            int length = equation.Length;
            int result = 0;
            char[] equationch = equation.ToCharArray();   //converting string to character array
            for(int i = 0 ; i < length ; i++){
                if(equationch[i] == '?' && i >= (length/2 + 1)){  //checking if ? is after = sign
                    string[] splitonequal = equation.Split("="); //split equation on equal sign to get 2 strings
                    string charsbeforeequal = splitonequal[0];  //contains characters which are before equal
                    string charsafterequal = splitonequal[1];   //contains characters after equal
                    string[] splitonmul = charsbeforeequal.Split("*"); //split on multiplication
                    string number1 = splitonmul[0];  // first number
                    string number2 = splitonmul[1];  // second number
                    int num1 = Int32.Parse(number1);
                    int num2 = Int32.Parse(number2);
                    int resultmul = num1 * num2;     //getting number   
                    string result1 = resultmul.ToString();
                    char[] chwithquestionmark = charsafterequal.ToCharArray();  //contain equal sign  
                    char[] chwithnumbers = result1.ToCharArray(); //contain result
                    char resultch = ' ';
                    for(int j = 0 ; j < charsafterequal.Length ; j++){//comparing both result and result with ? mark
                        if(chwithquestionmark[j] == '?'){
                            resultch = chwithnumbers[j];
                        }
                    }
                    result = resultch - '0';  //subtracting to get int
                    return result;
                }else if(equationch[i] == '?' && i < (length/2 + 1)){// ? on left side of equation
                    string[] splitonequal = equation.Split("="); //splitting on = to get 2 strings
                    string charsbeforeequal = splitonequal[0]; // string with = sign
                    string charsafterequal = splitonequal[1]; //string without original sign
                    string[] splitonmul = charsbeforeequal.Split("*"); //split on * to get the two numbers
                    string str3 = splitonmul[0]; // first number
                    string str4 = splitonmul[1]; // second number
                    int num1 = 0;
                    int num2 = 0;
                    int num3 = Int32.Parse(charsafterequal); //converting result to int
                    int resultdiv = 0;
                    if(str3.Contains('?')){
                        num2 = Int32.Parse(str4); //if first num has ? mark
                        resultdiv = num3 / num2; //divide result with 2nd number
                    }else{
                        if(str4.Contains('?') && str4.Length == 3){
                            result = -1; 
                            break;
                        }
                        num1 = Int32.Parse(str3); //if second number has ? mark
                        resultdiv = num3 / num1;  //divide result with 1st number
                    }
                    string result1 = resultdiv.ToString();  
                    char[] ch1 = new char[]{};  //searching for question mark in the number
                    if(str3.Contains('?')){
                        ch1 = str3.ToCharArray();
                    }else{
                        ch1 = str4.ToCharArray();
                    }
                    char[] ch2 = result1.ToCharArray(); //number found by dividing
                    char resultch = ' ';
                    for(int j = 0 ; j < ch1.Length ; j++){ //searching ? and getting appropriate number
                        if(ch1[j] == '?'){
                            resultch = ch2[j];
                        }
                    }
                    result = resultch - '0';
                    return result;
                }
            }
            return result;
        }
    }
}
