using PeerIslands.ExpressionCalculator.Tools;
using System;

namespace PeerIslands.ExpressionCalculator
{
    public class Program
    {
        public static void Main()
        {
            Run();
        }

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Write an expression to calculate or type 'quit' to exit:");
                var calculator = new Calculator();
                var stringExpression = Console.ReadLine();

                switch (stringExpression)
                {
                    case "quit":
                        return;

                    default:
                        try
                        {
                            StringExpressionValidator.ValidateExpression(stringExpression);

                            var result = calculator.Calculate(stringExpression);
                            Console.WriteLine($"{stringExpression} = {result}");

                            continue;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                }
            }
        }
    }
}