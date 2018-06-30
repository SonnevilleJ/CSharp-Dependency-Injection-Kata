using Ninject.Modules;

namespace DependencyInjectionKata.Ninject
{
    public class KataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRandom>().To<RandomWrapper>();
        }
    }
}
