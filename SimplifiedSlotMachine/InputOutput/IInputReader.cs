namespace SimplifiedSlotMachine.Input
{
    /// <summary>
    /// IInputReader was added so that the SlotRunner could run independently of the inputs being gathered.
    /// This was added to allow for mocking inputs made to the SlotRunner
    /// </summary>
    public interface IInputReader
    {
        public double ReadDoubleValue();
    }
}