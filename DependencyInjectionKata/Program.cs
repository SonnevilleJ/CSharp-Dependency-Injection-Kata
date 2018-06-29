using System;

namespace DependencyInjectionKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "generate")
            {
                Console.WriteLine($"The new key is {new Generator().GenerateKey()}");
            }
            else
            {
                Console.WriteLine("OK, I won't generate a key");
            }
        }
    }
}
