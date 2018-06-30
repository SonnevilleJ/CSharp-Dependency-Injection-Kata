using System;
using DependencyInjectionKata.Ninject;
using Ninject;

namespace DependencyInjectionKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var kernel = new StandardKernel(new KataModule()))
            {
                var generator = kernel.Get<Generator>();

                if (args.Length == 1 && args[0] == "generate")
                {
                    Console.WriteLine($"The new key is {generator.GenerateKey()}");
                }
                else
                {
                    Console.WriteLine("OK, I won't generate a key");
                }
            }
        }
    }
}
