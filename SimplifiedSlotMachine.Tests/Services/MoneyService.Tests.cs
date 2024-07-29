using SimplifiedSlotMachine.Services;

namespace SimplifiedSlotMachine.Tests.Services
{
    public class MoneyServiceTests
    {
        private MoneyService _moneyService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _moneyService = new MoneyService();
        }

        [Test]
        public void ApplyWinnings_AddsCorrectWinnings([Values(1, 1.2, 0)] double coefficient)
        {
            // Arrange
            var startingBalance = 100;
            _moneyService.SetBalance(startingBalance);
            var stake = 10;
            _moneyService.SetStake(stake);

            // Act
            var result = _moneyService.ApplyWinnings(coefficient);

            // Assert
            Assert.That(result, Is.EqualTo(coefficient * stake));
            Assert.That(_moneyService.GetBalance(), Is.EqualTo(startingBalance + result - stake));
        }
    }
}
