using System;

namespace Calculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //string expr = "4 - 2 + 2 + 20";
            //string expr = "2 * 2 - 2 / 2 + 10";
            string expr = "1 + 2 * ( 3 - 4 ) + 6 / 7";
            
            Calculator calculator = new Calculator(expr);

            Console.WriteLine(expr + " = " + calculator.PlusMinus());
            Console.WriteLine("Check = " + (1 + 2 * (3 - 4) + 6 / 7.0));
        }
    }
}