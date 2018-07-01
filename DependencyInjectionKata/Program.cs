using DependencyInjectionKata.Ninject;
using Ninject;

namespace DependencyInjectionKata
{
    public class Program
    {
        public static readonly StandardKernel Kernel = new StandardKernel(new KataModule());

        public static void Main(string[] args)
        {
            using (Kernel)
            {
                Kernel.Get<IApp>().Run(args);
            }
        }
    }
}
