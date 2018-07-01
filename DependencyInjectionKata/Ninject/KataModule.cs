using System;
using System.IO;
using Ninject.Modules;

namespace DependencyInjectionKata.Ninject
{
    public class KataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRandom>().To<RandomWrapper>();
            Bind<IGenerator>().To<Generator>();
            Bind<IApp>().To<App>();
            Bind<TextWriter>().ToConstant(Console.Out).WhenInjectedExactlyInto<App>();
        }
    }
}
