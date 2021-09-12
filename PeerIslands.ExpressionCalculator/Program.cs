using PeerIslands.ExpressionCalculator.Tools;
using System;

namespace PeerIslands.ExpressionCalculator
{
    class Program
    {
        static void Main()
        {
            Run();
        }

        static void Run()
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
                            StringExpressionVerifier.VerifyExpression(stringExpression);

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