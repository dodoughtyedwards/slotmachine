using Moq;

using SimplifiedSlotMachine.Input;
using SimplifiedSlotMachine.InputOutput;
using SimplifiedSlotMachine.Runners;
using SimplifiedSlotMachine.Services;
using SimplifiedSlotMachine.SpinObjects;

namespace SimplifiedSlotMachine.Tests.Runners
{
    public class SlotRunnerTests
    {
        private SlotRunner _slotRunner;
        private Mock<ISpinService> _spinServiceMock = new (MockBehavior.Strict);
        private Mock<IMoneyService> _moneyServiceMock = new (MockBehavior.Strict);
        private Mock<IInputReader> _inputReaderMock = new (MockBehavior.Strict);
        private Mock<ISlotOutputWriter> _outputWriterMock = new(MockBehavior.Strict);

        [SetUp]
        public void SetUp()
        {
            _slotRunner = new SlotRunner(_spinServiceMock.Object, _moneyServiceMock.Object, _inputReaderMock.Object, _outputWriterMock.Object, 3, 3);
        }

        [TearDown]
        public void TearDown()
        {
            _spinServiceMock.Reset();
            _moneyServiceMock.Reset();
            _inputReaderMock.Reset();
        }


        [Test]
        public void Run_CallsExpectedMethods_ExpectedNumberOfTimes()
        {
            // Arrange
            // Mock services to return regardless of input
            _inputReaderMock.Setup(x => x.ReadDoubleValue()).Returns(200);
            _spinServiceMock.Setup(x => x.Spin(It.IsAny<int>(), It.IsAny<int>())).Returns(new SpinResult(3,3));
            _spinServiceMock.Setup(x => x.CalculateWinningsCoefficient(It.IsAny<SpinResult>())).Returns(0);
            _moneyServiceMock.Setup(x => x.ApplyWinnings(It.IsAny<double>())).Returns(0);
            _moneyServiceMock.Setup(x => x.SetBalance(It.IsAny<double>()));
            _moneyServiceMock.Setup(x => x.SetStake(It.IsAny<double>()));
            _outputWriterMock.Setup(x => x.Writetring(It.IsAny<string>()));
            _outputWriterMock.Setup(x => x.WriteSpinResult(It.IsAny<SpinResult>()));

            // Ensure a valid value is returned first time, then 0 the second to exit the loop
            _moneyServiceMock.SetupSequence(x => x.GetBalance()).Returns(200).Returns(0);
            // Act
            _slotRunner.Run();

            // Assert
            _inputReaderMock.Verify(x => x.ReadDoubleValue(), Times.Exactly(2));

            _spinServiceMock.Verify(x => x.Spin(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
            _spinServiceMock.Verify(x => x.CalculateWinningsCoefficient(It.IsAny<SpinResult>()), Times.Once());

            _moneyServiceMock.Verify(x => x.ApplyWinnings(It.IsAny<double>()), Times.Once());
            _moneyServiceMock.Verify(x => x.SetBalance(It.IsAny<double>()), Times.Once());
            _moneyServiceMock.Verify(x => x.SetStake(It.IsAny<double>()), Times.Once());

            _outputWriterMock.Verify(x => x.Writetring(It.IsAny<string>()), Times.Exactly(5));
            _outputWriterMock.Verify(x => x.WriteSpinResult(It.IsAny<SpinResult>()), Times.Once());
        }
    }
}
