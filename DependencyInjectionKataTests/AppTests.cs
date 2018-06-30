using System;
using System.IO;
using DependencyInjectionKata;
using NUnit.Framework;

namespace DependencyInjectionKataTests
{
    [TestFixture]
    public class AppTests
    {
        private StreamReader _inputReader;
        private StreamWriter _inputWriter;
        private StreamReader _outputReader;
        private StreamWriter _outputWriter;
        private string[] _generateArgs;

        [SetUp]
        public void Setup()
        {
            _generateArgs = new[] {"generate"};

            var inputStream = new MemoryStream();
            _inputReader = new StreamReader(inputStream);
            _inputWriter = new StreamWriter(inputStream) {AutoFlush = true};
            Console.SetIn(_inputReader);

            var outputStream = new MemoryStream();
            _outputReader = new StreamReader(outputStream);
            _outputWriter = new StreamWriter(outputStream) {AutoFlush = true};
            Console.SetOut(_outputWriter);
        }

        [TearDown]
        public void Teardown()
        {
            _inputReader?.Dispose();
            _inputWriter?.Dispose();
            _outputReader?.Dispose();
            _outputWriter?.Dispose();
        }

        [Test]
        public void ShouldRunWithoutException()
        {
            new App(new Generator(new RandomWrapper())).Run(_generateArgs);
        }

        [Test]
        public void ShouldReturnNonEmptyString()
        {
            new App(new Generator(new RandomWrapper())).Run(_generateArgs);

            Assert.IsFalse(string.IsNullOrWhiteSpace(ReadAllOutput()));
        }

        [Test]
        public void ShouldReturn25CharacterString()
        {
            new App(new Generator(new RandomWrapper())).Run(_generateArgs);

            Assert.AreEqual(41, ReadAllOutput().Length);
        }

        [Test]
        public void ShouldReturnUniqueResult()
        {
            new App(new Generator(new RandomWrapper())).Run(_generateArgs);
            var result1 = ReadAllOutput();

            new App(new Generator(new RandomWrapper())).Run(_generateArgs);
            var result2 = ReadAllOutput();

            Assert.AreNotEqual(result1, result2);
        }

        [Test]
        public void ShouldReturnMessageWhenNotGenerating()
        {
            new App(new Generator(new RandomWrapper())).Run(new string[] { });
            
            Assert.AreEqual($"OK, I won\'t generate a key{Environment.NewLine}", ReadAllOutput());
        }

        private string ReadAllOutput()
        {
            _outputReader.BaseStream.Position = 0;
            return _outputReader.ReadToEnd();
        }
    }
}
