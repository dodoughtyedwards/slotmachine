using SimplifiedSlotMachine.Configuration;
using SimplifiedSlotMachine.SpinObjects;

namespace SimplifiedSlotMachine.Services
{
    public class SpinService(List<SpinOption> spinOptions) : ISpinService
    {
        public SpinResult Spin(int rows, int columns)
        {
            var rnd = new Random();
            var spinResult = new SpinResult(rows, columns);

            foreach (var row in spinResult.ResultRows)
            {
                for (int i = 0; i < row.Result.Count(); i++)
                {
                    var cellResult = rnd.Next(1, 101);
                    var chanceTrack = 100;

                    foreach (var spinOption in spinOptions)
                    {
                        if (cellResult > chanceTrack - spinOption.PercentageChanceToAppear)
                        {
                            row.Result[i] = spinOption;
                            break;
                        }

                        chanceTrack -= spinOption.PercentageChanceToAppear;
                    }
                }
            }

            return spinResult;
        }

        public double CalculateWinningsCoefficient(SpinResult spinResult)
        { 
            return spinResult.ResultRows.Select(x => CalculateRowWinningsCoefficient(x)).Sum();
        }

        private static double CalculateRowWinningsCoefficient(SpinResultRow spinResult)
        {
            var distinctValues = spinResult.Result.Distinct();

            return distinctValues.Count() switch
            {
                1 => spinResult.Result.Select(x => x.Coefficient).Sum(),
                2 => distinctValues.Any(x => x.SpinSymbol.SymbolType.Equals(SymbolType.Wildcard)) ?
                        spinResult.Result.Select(x => x.Coefficient).Sum() :
                        0,
                _ => 0
            };
        }
    }
}