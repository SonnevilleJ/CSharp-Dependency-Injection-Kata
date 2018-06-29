using System;
using System.Linq;

namespace DependencyInjectionKata
{
    public class Generator
    {
        public string GenerateKey()
        {
            var random = new Random();
            const int count = 25;
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(
                Enumerable.Range(0, count)
                    .Select(i => validChars[random.Next(validChars.Length)])
                    .ToArray()
            );
        }
    }
}