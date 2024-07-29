namespace SimplifiedSlotMachine.SpinObjects
{
    public class SpinResult
    {
        private readonly SpinResultRow[] _spinResultRows;

        public SpinResultRow[] ResultRows { get { return _spinResultRows; } }

        public SpinResult(int rows, int columns)
        {
            _spinResultRows = new SpinResultRow[rows];

            for (int i = 0; i < rows; i++)
            {
                _spinResultRows[i] = new SpinResultRow(columns);
            }
        }
    }
}