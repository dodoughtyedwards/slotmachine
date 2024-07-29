using SimplifiedSlotMachine.Input;
using SimplifiedSlotMachine.InputOutput;
using SimplifiedSlotMachine.Services;

namespace SimplifiedSlotMachine.Runners
{
    public class SlotRunner(ISpinService spinService, IMoneyService moneyService, IInputReader inputReader, ISlotOutputWriter outputWriter, int rows, int columns) : ISlotRunner
    {
        public void Run()
        { 
            outputWriter.Writetring("Enter an amount of money to play with:");
            moneyService.SetBalance(inputReader.ReadDoubleValue());

            while (moneyService.GetBalance() > 0)
            {
                outputWriter.Writetring("Enter stake amount:");
                moneyService.SetStake(inputReader.ReadDoubleValue());

                // Get spin result
                var spinResult = spinService.Spin(rows, columns);

                // Display result
                outputWriter.WriteSpinResult(spinResult);

                // Calculate winnings
                var winningCoefficient = spinService.CalculateWinningsCoefficient(spinResult);
                var stakeReturn = moneyService.ApplyWinnings(winningCoefficient);

                // Display changes to winnings
                outputWriter.Writetring($"You have won: {Math.Round(stakeReturn, 2)}");
                outputWriter.Writetring($"Current balance is: {moneyService.GetBalance()}\n");
            }

            outputWriter.Writetring("GAME OVER...");
        }
    }
}
