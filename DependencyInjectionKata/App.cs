using System;

namespace DependencyInjectionKata
{
    public interface IApp
    {
        void Run(string[] args);
    }

    public class App : IApp
    {
        private readonly Generator _generator;

        public App(Generator generator)
        {
            _generator = generator;
        }

        public void Run(string[] args)
        {
            if (args.Length == 1 && args[0] == "generate")
            {
                Console.WriteLine($"The new key is {_generator.GenerateKey()}");
            }
            else
            {
                Console.WriteLine("OK, I won't generate a key");
            }
        }
    }
}
