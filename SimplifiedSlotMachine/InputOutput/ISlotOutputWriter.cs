using SimplifiedSlotMachine.SpinObjects;

namespace SimplifiedSlotMachine.InputOutput
{
    /// <summary>
    /// ISlotOutputWriter was added so that the SlotRunner could run independently of the outputs being displayed.
    /// This was added to allow for mocking ouputs made from the SlotRunner
    /// </summary>
    public interface ISlotOutputWriter
    {
        public void Writetring(string output);

        public void WriteSpinResult(SpinResult spinResult);
    }
}