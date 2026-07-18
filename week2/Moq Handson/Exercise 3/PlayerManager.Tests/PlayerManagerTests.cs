using System;
using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayersManagerLib.Tests
{
    [TestFixture]
    public class PlayerManagerTests
    {
        private Mock<IPlayerMapper> _mockMapper;

        [OneTimeSetUp]
        public void Init()
        {
            _mockMapper = new Mock<IPlayerMapper>();

            // Ensure the "name already exists" check always returns false,
            // so RegisterNewPlayer proceeds instead of throwing.
            _mockMapper
                .Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(false);
        }

        [TestCase("Virat")]
        public void RegisterNewPlayer_ValidName_ReturnsPlayerWithExpectedAttributes(string name)
        {
            Player player = Player.RegisterNewPlayer(name, _mockMapper.Object);

            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo(name));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }

        [TestCase("")]
        public void RegisterNewPlayer_EmptyName_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() =>
                Player.RegisterNewPlayer(name, _mockMapper.Object));
        }

        [Test]
        public void RegisterNewPlayer_NameAlreadyExists_ThrowsArgumentException()
        {
            var mapperWithExistingName = new Mock<IPlayerMapper>();
            mapperWithExistingName
                .Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(true);

            Assert.Throws<ArgumentException>(() =>
                Player.RegisterNewPlayer("Rohit", mapperWithExistingName.Object));
        }
    }
}