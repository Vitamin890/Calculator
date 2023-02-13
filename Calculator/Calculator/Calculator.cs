using System;

/* E -> T+E | T-E | T
 * T -> F*T | F\T | F
 * F -> -M  | M
 * M -> (E) | func(E) | N
 * 
 */
namespace Calculator
{
    public class Calculator
    {
        private string[] token;
        private int pos;
        public Calculator(string expr) {
            token = expr.Split(' ');
            pos = 0;
        }
        public double  PlusMinus()
        {
            double first = Multiply();
            while (pos < token.Length)
            {
                string operators = token[pos];
                if (operators != "+" && operators != "-") {
                    break;
                }
                else {
                    pos++;
                }
                double second = Multiply();
                if (operators == "+") {
                    first += second;
                }
                else {
                    first -= second;
                }
            }
            return first;
            //return Math.Round(first, 3);
        }
        
        public double  Multiply() {
            double first = Bracket();

            while (pos < token.Length)
            {
                string operators = token[pos];
                if (operators != "*" && operators != "/") {
                    break;
                }
                else {
                    pos++;
                }
                double second = Bracket();
                if (operators == "*") {
                    first *= second;
                }
                else {
                    first /= second;
                }
            }
            return first;
        }
        public double Bracket()
        {
            string next = token[pos];
            double result;
            if (next == "(") {
                pos++;
                result = PlusMinus();
                string closingBracket;
                if (pos < token.Length) {
                    closingBracket = token[pos];
                }
                else {
                    throw new Exception("UNEXPECTED END OF EXPRESSION");
                }

                if (closingBracket == ")") {
                    pos++;
                    return result;
                }
                throw new Exception("')' EXPECTED BUT " + closingBracket + " FOUND");
            }
            pos++;
            return Double.Parse(next);
        }
    }
}