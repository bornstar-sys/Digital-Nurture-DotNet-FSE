using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            _mockMailSender = new Mock<IMailSender>();

            // Accept ANY two strings, always return true
            _mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue()
        {
            bool result = _customerComm.SendMailToCustomer();
            Assert.That(result, Is.EqualTo(true));
        }
    }
}