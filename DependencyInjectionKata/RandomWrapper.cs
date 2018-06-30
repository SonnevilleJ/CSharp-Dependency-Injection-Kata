using System;

namespace DependencyInjectionKata
{
    public class RandomWrapper : IRandom
    {
        public int Next(int maxValue)
        {
            return new Random().Next(maxValue);
        }
    }
}