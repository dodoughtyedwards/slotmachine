using SimplifiedSlotMachine.SpinObjects;

namespace SimplifiedSlotMachine.Services
{
    public interface ISpinService
    {
        public SpinResult Spin(int rows, int columns);

        public double CalculateWinningsCoefficient(SpinResult spinResult);
    }
}
