using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    class Program
    {

        static void Main(string[] args)
        {
            //An expression which does not return a value,
            //takes no parameters, and evaluates to the string "Hello, World".
            Func<string> greet = () => "Hello, World!";
            Console.WriteLine(greet());

            //An expression which returns an integer, takes a 
            //single integer parameter, and adds the integer 1 to it.
            Func<int, int> addNumber = number => number + 1;
            Console.WriteLine(addNumber(10));

            //Powers
            double power = Math.Pow(12, 12);
            Console.WriteLine(power);

            //An expression which returns an integer, takes two integer 
            //parameters, and raises the second parameter to the power of the first.
            Func<int, int, double> powNumber = (x, y) => Math.Pow(y, x);
            Console.WriteLine(powNumber(12, 12));

            //An expression which returns an integer, takes two integer parameters and sums them.
            Func<int, int, int> sumNumber = (numberOne, numberTwo) => numberOne + numberTwo;
            Console.WriteLine(sumNumber(10, 35));

            //An expression which returns a string, takes two strings, and appends the first to the second.
            Func<string, string, string> completeString = (stringOne, stringTwo) => stringOne + stringTwo;
            Console.WriteLine(completeString("Hello" + " ", "Samuel"));


            IEnumerable<int> numberRange = Enumerable.Range(1, 10);

            foreach (int num in numberRange)
            {
                Console.WriteLine(num);
            }

            numberRange.Select((num, next) => num + 1);

            /*
            foreach (int num in numberRange)
            {
                Console.WriteLine(num + 1);
            }
            */
        }
    }
}
