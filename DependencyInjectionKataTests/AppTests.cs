using System;
using System.IO;
using DependencyInjectionKata;
using Moq;
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
        private Mock<IGenerator> _mockGenerator;
        private string _newKey;
        private App _app;

        [SetUp]
        public void Setup()
        {
            var inputStream = new MemoryStream();
            _inputReader = new StreamReader(inputStream);
            _inputWriter = new StreamWriter(inputStream) {AutoFlush = true};
            Console.SetIn(_inputReader);

            var outputStream = new MemoryStream();
            _outputReader = new StreamReader(outputStream);
            _outputWriter = new StreamWriter(outputStream) {AutoFlush = true};
            Console.SetOut(_outputWriter);

            _newKey = "new key";

            _mockGenerator = new Mock<IGenerator>();
            _mockGenerator.Setup(generator => generator.GenerateKey())
                .Returns(_newKey);

            _app = new App(_mockGenerator.Object, _outputWriter);
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
        public void ShouldWriteNewKeyToConsole()
        {
            _app.Run(new[] {"generate"});

            Assert.AreEqual($"The new key is {_newKey}{Environment.NewLine}", ReadAllOutput());
        }

        [Test]
        public void ShouldNotGenerateKey()
        {
            _app.Run(new string[] { });

            Assert.AreEqual($"OK, I won't generate a key{Environment.NewLine}", ReadAllOutput());
        }

        [Test]
        [TestCase("")]
        [TestCase("hello")]
        [TestCase("generate new key")]
        public void ShouldIgnoreOtherInput(string input)
        {
            _app.Run(input.Split(" "));

            Assert.AreEqual($"OK, I won't generate a key{Environment.NewLine}", ReadAllOutput());
        }

        private string ReadAllOutput()
        {
            _outputReader.BaseStream.Position = 0;
            return _outputReader.ReadToEnd();
        }
    }
}
