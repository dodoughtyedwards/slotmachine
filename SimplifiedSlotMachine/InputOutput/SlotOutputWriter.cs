using SimplifiedSlotMachine.SpinObjects;

namespace SimplifiedSlotMachine.InputOutput
{
    /// <summary>
    /// SlotOutputWriter was added so that the SlotRunner could run independently of the outputs being displayed.
    /// This was added to allow for mocking ouputs made from the SlotRunner
    /// </summary>
    public class SlotOutputWriter : ISlotOutputWriter
    {
        public void WriteSpinResult(SpinResult spinResult)
        {
            Console.WriteLine($"\n{string.Join("\n", spinResult.ResultRows.Select(x => GetSlotResultRowOutput(x)))}\n");
        }

        public void Writetring(string output)
        {
            Console.WriteLine(output);
        }

        public string GetSlotResultRowOutput(SpinResultRow spinResultRow)
        {
            return string.Join(" ", spinResultRow.Result.Select(x => x.SpinSymbol.Name));
        }
    }
}
