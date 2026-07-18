using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using MagicFilesLib;

namespace MagicFilesLib.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        private Mock<IDirectoryExplorer> _mockExplorer;

        [OneTimeSetUp]
        public void Init()
        {
            _mockExplorer = new Mock<IDirectoryExplorer>();

            _mockExplorer
                .Setup(m => m.GetFiles(It.IsAny<string>()))
                .Returns(new List<string> { _file1, _file2 });
        }

        [TestCase]
        public void GetFiles_WhenCalled_ReturnsExpectedFileList()
        {
            ICollection<string> result = _mockExplorer.Object.GetFiles("C:\\SomeFakePath");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result, Does.Contain(_file1));
        }
    }
}