using SimplifiedSlotMachine.Configuration;
using SimplifiedSlotMachine.Services;

namespace SimplifiedSlotMachine.Tests.Services
{
    public class SpinServiceTests
    {
        private List<SpinOption> _spinOptions;
        private SpinService _spinService;

        [OneTimeSetUp]
        public void Setup()
        {
            _spinOptions =
            [
                new() {
                    SpinSymbol = new()
                    {
                       Name = "A",
                       SymbolType = SymbolType.Apple,
                    },
                    PercentageChanceToAppear = 45,
                    Coefficient = 0.4
                },
                new() {
                    SpinSymbol = new()
                    {
                        Name = "B",
                        SymbolType = SymbolType.Banana
                    },
                    PercentageChanceToAppear = 35,
                    Coefficient = 0.6
                },
                new() {
                    SpinSymbol = new()
                    {
                        Name = "P",
                        SymbolType = SymbolType.Pineapple,
                    },
                    PercentageChanceToAppear = 15,
                    Coefficient = 0.8
                },
                new() {
                    SpinSymbol = new()
                    {
                        Name = "*",
                        SymbolType = SymbolType.Wildcard,
                    },
                    PercentageChanceToAppear = 5,
                    Coefficient = 0.0
                }
            ];
            _spinService = new SpinService(_spinOptions);
        }

        [Test]
        public void Spin_ReturnsProvidedNumberOfRowsAndColumns([Values(1, 2, 3)] int rows, [Values(1, 2, 3)]int columns)
        {
            // Act
            var result = _spinService.Spin(rows, columns);

            // Assert
            Assert.That(result.ResultRows.Count(), Is.EqualTo(rows));
            Assert.That(result.ResultRows.All(x => x.Result.Count() == columns), Is.True);
        }
    }
}