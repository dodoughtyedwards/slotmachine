using SimplifiedSlotMachine.Configuration;

namespace SimplifiedSlotMachine.SpinObjects
{
    public class SpinResultRow
    {
        private readonly SpinOption[] _result;

        public SpinOption[] Result { get { return _result; } }

        public SpinResultRow(int columns)
        {
            _result = new SpinOption[columns];
        }
    }
}