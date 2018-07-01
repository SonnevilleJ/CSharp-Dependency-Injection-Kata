using DependencyInjectionKata;
using Moq;
using Ninject;
using NUnit.Framework;

namespace DependencyInjectionKataTests
{
    [TestFixture]
    public class BindingsTests
    {
        [Test]
        public void ShouldPassArgsToAppAndDisposeKernel()
        {
            var mockApp = new Mock<IApp>();
            Program.Kernel.Rebind<IApp>().ToConstant(mockApp.Object);

            var args = new []{"one", "two", "three"};
            Program.Main(args);

            mockApp.Verify(app => app.Run(args));
            Assert.IsTrue(Program.Kernel.IsDisposed);
        }

        [Test]
        public void ShouldBindApp()
        {
            var app = Program.Kernel.Get<IApp>();

            Assert.IsNotNull(app);
        }
    }
}
