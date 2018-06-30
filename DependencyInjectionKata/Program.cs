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
                kernel.Get<IApp>().Run(args);
            }
        }
    }
}
