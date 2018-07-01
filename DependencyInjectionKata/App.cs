using System.IO;

namespace DependencyInjectionKata
{
    public interface IApp
    {
        void Run(string[] args);
    }

    public class App : IApp
    {
        private readonly IGenerator _generator;
        private readonly TextWriter _outputWriter;

        public App(IGenerator generator, TextWriter outputWriter)
        {
            _generator = generator;
            _outputWriter = outputWriter;
        }

        public void Run(string[] args)
        {
            if (args.Length == 1 && args[0] == "generate")
            {
                _outputWriter.WriteLine($"The new key is {_generator.GenerateKey()}");
            }
            else
            {
                _outputWriter.WriteLine("OK, I won't generate a key");
            }
        }
    }
}
