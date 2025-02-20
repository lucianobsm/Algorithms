using Algorithms.Chapter_3.Models;

namespace Algorithms.Chapter_3
{
    public class Recursion
    {

        public static void FindKeyWithoutRecursion(Box box)
        {
            var stack = new Stack<Box>([box]);

            while (stack.Count > 0)
            {
                var caixa = stack.Pop();

                if (caixa.Boxes?.Count > 0)
                {
                    foreach (var innerBox in caixa.Boxes)
                    {
                        stack.Push(innerBox);
                    }
                }
                else if (caixa.HasKey)
                {
                    Console.WriteLine("I found the key");
                    break;
                }
            }
        }

        public static void FindKeyWithRecursion(Box currentBox)
        {
            foreach (var item in currentBox.Boxes)
            {
                if (item.Boxes?.Count > 0)
                {
                    FindKeyWithRecursion(item);
                }
                else if (item.HasKey)
                {
                    Console.WriteLine("I found the key");
                    return;
                }
            }
        }

        public static void ExampleRecursionRegress(int n)
        {
            if (n == 0)
            {
                return;
            }
            else
            {
                Console.Write($"{n}{(n > 1 ? "..": "")}");
                ExampleRecursionRegress(n - 1);
            }
        }
    }
}
