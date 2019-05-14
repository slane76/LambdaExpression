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
            Func<int, int> n2 = number => number + 1;
            Console.WriteLine(n2(10));

            //Powers
            double power = Math.Pow(12, 12);
            Console.WriteLine(power);

            //An expression which returns an integer, takes two integer 
            //parameters, and raises the second parameter to the power of the first.
            Func<int, int, int> n3 = (myPower, @base) => (int)Math.Pow(@base, myPower);
            Console.WriteLine(n3(12, 12));

            //An expression which returns an integer, takes two integer parameters and sums them.
            Func<int, int, int> n4 = (numberOne, numberTwo) => numberOne + numberTwo;
            Console.WriteLine(n4(10, 35));

            //An expression which returns a string, takes two strings, and appends the first to the second.
            Func<string, string, string> n5 = (stringOne, stringTwo) => stringOne + stringTwo;
            Console.WriteLine(n5("Hello" + " ", "Samuel"));

            IEnumerable<int> numberRange = Enumerable.Range(1, 10);

            foreach (int num in numberRange)
            {
                Console.WriteLine(num);
            }

            //Declare a list of sequential integers with a method from the Enumerable class
            var ints = Enumerable.Range(1, 10);

            //Declare a list of dummy string.
            var strings = new List<string>() { "cat", "dog", "cow", "pig" };

            //Use #2 to add one to a list of integers individually.
            ints.Select(n2);
            ints.Select(n2).ToList().ForEach(Console.WriteLine);

            //Other ways to do it
            ints.Select(x => n2(x));

            ints.Select(x => (x));

            ints.Select(x => n4(5, x));

            //Use #3 to raise a list of integers to the second power individually.
            Console.WriteLine();
            ints.Select(x => n3(2, x)).ToList().ForEach(Console.WriteLine);

            //Use #4 to sum a list of integers.
            ints.Aggregate((accum, number) => accum + number);
            //or
            ints.Aggregate((x, y) => n4(x, y));
            //or
            ints.Aggregate(n4);
            Console.WriteLine(ints.Aggregate(n4));

            //Use #5 to concatenate a list of strings, returning an empty string if given an empty list.
            Console.WriteLine(strings.Aggregate(n5)); //Doesn't handle empty string

            Console.WriteLine(strings.Aggregate("", n5, s => new string(s.Reverse().ToArray()))); //Reverses string

            Console.WriteLine(new List<string>().Aggregate("", n5));

            //Use #3 and a method from the Enumerable class in a new lambda expression which returns an integer,
            //takes two integer parameters (base and times), and which raises the base to its own value times -1 
            Func<int, int, int> tetration0 = (@base, times) => n3(@base, @base); 

            Func<int, int, int> tetration1 = (@base, times) => @base;

            Func<int, int, int> tetration2 = (@base, times) => (int)Math.Pow(@base, @base); //Special case: times == 2

            Func<int, int, int> tetration3 = (@base, times) => (int)Math.Pow(Math.Pow(@base, @base), @base);

            Func<int, int, int> tetration = (@base, times) => Enumerable.Repeat(@base, times).Aggregate(n3);
            Console.WriteLine(tetration(2, 4));

            //times. Evaluating your function with base of 2 and times of 4 should result in 65536. This is 
            //repeated exponentiation, also known as tetration, and is frequently expressed in Knuth's up-arrow notation
            // (Links to an external site.)
            // using double up-arrows.




        }
    }
}
