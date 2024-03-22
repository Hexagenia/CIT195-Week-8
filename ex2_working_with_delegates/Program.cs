using System;
namespace ex2_working_with_delegates
{

    public delegate double ComparisonDelegate(double a, double b);

    public class MathSolutions
    {
        public double GetSum(double x, double y)
        {
            return x + y;
        }

        public double GetProduct(double a, double b)
        {
            return a * b;
        }

        public void GetSmaller(double a, double b)
        {
            if (a < b)
                Console.WriteLine($" {a} is smaller than {b}");
            else if (b < a)
                Console.WriteLine($" {b} is smaller than {a}");
            else
                Console.WriteLine($" {b} is equal to {a}");
        }

        static void Main(string[] args)
        {

            MathSolutions answer = new MathSolutions();
            Random r = new Random();
            double firstNumber = Math.Round(r.NextDouble() * 100);
            double secondNumber = Math.Round(r.NextDouble() * 100);

            Action<double, double> actionDelegate = answer.GetSmaller;
            actionDelegate(firstNumber, secondNumber);


            Func<double, double, double> funcDelegate = answer.GetProduct;
            double product = funcDelegate(firstNumber, secondNumber);
            Console.WriteLine($" {firstNumber} * {secondNumber} = {product}");


            ComparisonDelegate customDelegate = answer.GetSum;
            double sum = customDelegate(firstNumber, secondNumber);
            Console.WriteLine($" {firstNumber} + {secondNumber} = {sum}");
        }
    }
}