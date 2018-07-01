using System.Linq;

namespace DependencyInjectionKata
{
    public interface IGenerator
    {
        string GenerateKey();
    }

    public class Generator : IGenerator
    {
        private readonly IRandom _random;

        public Generator(IRandom random)
        {
            _random = random;
        }

        public string GenerateKey()
        {
            const int count = 25;
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(
                Enumerable.Range(0, count)
                    .Select(i => validChars[_random.Next(validChars.Length)])
                    .ToArray()
            );
        }
    }
}