namespace SimplifiedSlotMachine.Input
{
    /// <summary>
    /// InputReader was added so that the SlotRunner could run independently of the inputs being gathered.
    /// This was added to allow for mocking inputs made to the SlotRunner
    /// </summary>
    public class InputReader : IInputReader
    {
        public double ReadDoubleValue()
        {
            bool validInput = double.TryParse(Console.ReadLine(), out double inputValue) && inputValue > 0;

            while (!validInput && inputValue <= 0)
            {
                Console.WriteLine("Value must be an double greater than 0.");
                validInput = double.TryParse(Console.ReadLine(), out inputValue) && inputValue > 0;
            }

            return inputValue;
        }
    }
}
