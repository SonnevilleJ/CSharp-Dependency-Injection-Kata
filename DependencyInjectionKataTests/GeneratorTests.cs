using DependencyInjectionKata;
using NUnit.Framework;

namespace DependencyInjectionKataTests
{
    [TestFixture]
    public class GeneratorTests
    {
        private Generator _generator;

        [SetUp]
        public void Setup()
        {
            _generator = new Generator(new RandomWrapper());
        }

        [Test]
        public void ShouldReturnNonEmptyString()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_generator.GenerateKey()));
        }

        [Test]
        public void ShouldReturn25CharacterString()
        {
            Assert.AreEqual(25, _generator.GenerateKey().Length);
        }

        [Test]
        public void ShouldReturnUniqueResult()
        {
            Assert.AreNotEqual(_generator.GenerateKey(), _generator.GenerateKey());
        }
    }
}
