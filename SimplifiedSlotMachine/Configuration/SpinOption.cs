namespace SimplifiedSlotMachine.Configuration
{
    public class SpinOption
    {
        public double Coefficient { get; set; }

        public int PercentageChanceToAppear { get; set; }

        public SpinSymbol SpinSymbol { get; set; } = new();
    }
}