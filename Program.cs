using System;
using System.IO;
namespace ConsoleApplication1
{
  
    class Program
    {
       
        static void Main(string[] args)
        {
           
            try
            {
                Console.WriteLine("Enter a Number to convert to currency");
                string number = Console.ReadLine();
                number = Double.Parse(number).ToString();
                
                    Console.WriteLine("The number in currency format is \n" + NumberToCurrency(Double.Parse(number)));
                
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
          
        }
        public static string NumberToCurrency(double doubleNumber)
        {
            var beforeFloatingPoint = (int)Math.Floor(doubleNumber);
            var beforeFloatingPointWord = $"{NumberToCurrency(beforeFloatingPoint)} Dollars";
            var afterFloatingPointWord =
                $"{SmallNumberToCurrency((int)(((doubleNumber - beforeFloatingPoint) * 100) + .10), "")} Cents";
            return $"{beforeFloatingPointWord} and {afterFloatingPointWord}";
        }

        private static string NumberToCurrency(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToCurrency(Math.Abs(number));

            var words = "";

            if (number / 1000000000 > 0)
            {
                words += NumberToCurrency(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if (number / 1000000 > 0)
            {
                words += NumberToCurrency(number / 1000000) + " million ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += NumberToCurrency(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += NumberToCurrency(number / 100) + " hundred ";
                number %= 100;
            }

            words = SmallNumberToCurrency(number, words);

            return words;
        }

        private static string SmallNumberToCurrency(int number, string words)
        {
            if (number <= 0) return words;
            if (words != "")
                words += " ";

            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
               
            words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
            return words;
        }

       
    }
}
