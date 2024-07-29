namespace SimplifiedSlotMachine.Services
{
    /// <summary>
    /// MoneyService is a class designed to simulate an account/user service outside of the game that handles
    /// aspects of the player's winnings outside of the Slots game.
    /// It has been left intentionally shallow to avoid overcomplicating this assignment while still removing all
    /// responsibility for changes to money from the game itself
    /// </summary>
    public class MoneyService() : IMoneyService
    {
        private double _balance;

        private double _stake;

        public double GetBalance()
        {
            return _balance;
        }

        public void SetBalance(double balance)
        {
            _balance = balance;
        }

        public void SetStake(double stake)
        {
            _stake = stake;
        }

        public double ApplyWinnings(double winningCoefficient)
        {
            var stakeReturn = _stake * winningCoefficient;
            _balance += stakeReturn - _stake;

            return stakeReturn;
        }
    }
}
