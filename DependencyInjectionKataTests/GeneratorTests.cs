using System.Threading;
using DependencyInjectionKata;
using Moq;
using NUnit.Framework;

namespace DependencyInjectionKataTests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void ShouldReturnBasedOnRandomInput()
        {
            // this test injects a mock IRandom to verify the behavior of the Generator class
            
            var i = 0;
            var mockRandom = new Mock<IRandom>();
            mockRandom.Setup(random => random.Next(62))
                .Returns(() => Interlocked.Increment(ref i));

            var key = new Generator(mockRandom.Object).GenerateKey();

            Assert.AreEqual("BCDEFGHIJKLMNOPQRSTUVWXYZ", key);
        }

        [Test]
        public void ShouldReturnUniqueResult()
        {
            // this test injects a RandomWrapper, just like production
            
            var generator = new Generator(new RandomWrapper());

            Assert.AreNotEqual(generator.GenerateKey(), generator.GenerateKey());
        }
    }
}
