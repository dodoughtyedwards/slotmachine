namespace SimplifiedSlotMachine.Configuration
{
    public class SlotsConfiguration
    {
        public int Rows { get; set; }

        public int Columns { get; set; }

        public List<SpinOption> SpinOptions { get; set; } = [];
    }
}
