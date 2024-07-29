namespace SimplifiedSlotMachine.Services
{
    /// <summary>
    /// IMoneyService is an interface designed to simulate an account/user service outside of the game that handles
    /// aspects of the player's winnings outside of the Slots game.
    /// It has been left intentionally shallow to avoid overcomplicating this assignment while still removing all
    /// responsibility for changes to money from the game itself
    /// </summary>
    public interface IMoneyService
    {
        public double ApplyWinnings(double winningCoefficient);
        public double GetBalance();
        public void SetBalance(double balance);
        public void SetStake(double stake);
    }
}